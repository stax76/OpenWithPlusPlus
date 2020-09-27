
#include "stdafx.h"
#include "Main.h"


Item::~Item()
{
	if (Icon)
	{
		DeleteObject(Icon);
		Icon = NULL;
	}
}


BOOL FileExists(std::wstring file)
{
	if (file.length() == 0)
		return false;

	DWORD dwAttrib = GetFileAttributes(file.c_str());
	return dwAttrib != INVALID_FILE_ATTRIBUTES && !(dwAttrib & FILE_ATTRIBUTE_DIRECTORY);
}


HBITMAP Create32BitHBITMAP(UINT cx, UINT cy, PBYTE* ppbBits)
{
	BITMAPINFO bmi;
	ZeroMemory(&bmi, sizeof(bmi));
	bmi.bmiHeader.biSize = sizeof(bmi.bmiHeader);
	bmi.bmiHeader.biWidth = cx;
	bmi.bmiHeader.biHeight = -(LONG)cy;
	bmi.bmiHeader.biPlanes = 1;
	bmi.bmiHeader.biBitCount = 32;
	bmi.bmiHeader.biCompression = BI_RGB;
	HDC hDC = GetDC(NULL);
	HBITMAP hbmp = CreateDIBSection(hDC, &bmi, DIB_RGB_COLORS, (void**)ppbBits, NULL, 0);
	ReleaseDC(NULL, hDC);
	return(hbmp);
}


HBITMAP ConvertIconToBitmap(HICON hicon)
{
    IWICImagingFactory* pFactory;
    IWICBitmap* pBitmap;
    IWICFormatConverter* pConverter;
    HBITMAP ret = NULL;

    if (SUCCEEDED(CoCreateInstance(CLSID_WICImagingFactory, NULL,
        CLSCTX_INPROC_SERVER, IID_IWICImagingFactory, (void**)&pFactory)))
    {
        if (SUCCEEDED(pFactory->CreateBitmapFromHICON(hicon, &pBitmap)))
        {
            if (SUCCEEDED(pFactory->CreateFormatConverter(&pConverter)))
            {
                UINT cx, cy;
                PBYTE pbBits;
                HBITMAP hbmp;

                if (SUCCEEDED(pConverter->Initialize(pBitmap, GUID_WICPixelFormat32bppPBGRA,
                    WICBitmapDitherTypeNone, NULL, 0.0f, WICBitmapPaletteTypeCustom)) && SUCCEEDED(
                        pConverter->GetSize(&cx, &cy)) && NULL != (hbmp = Create32BitHBITMAP(cx, cy, &pbBits)))
                {
                    UINT cbStride = cx * sizeof(UINT32);
                    UINT cbBitmap = cy * cbStride;

                    if (SUCCEEDED(pConverter->CopyPixels(NULL, cbStride, cbBitmap, pbBits)))
                        ret = hbmp;
                    else
                        DeleteObject(hbmp);
                }

                pConverter->Release();
            }

            pBitmap->Release();
        }

        pFactory->Release();
    }

    return ret;
}


HRESULT SetIcon(HMENU menu, UINT position, UINT flags, Item* item)
{
	std::wstring path(item->IconFile);

	if (path.find(L"%") != std::string::npos)
	{
		WCHAR szPath[500];
		DWORD result = ExpandEnvironmentStrings(path.c_str(), szPath, std::size(szPath));

		if (result)
			path = szPath;
	}

	if (!FileExists(path))
		return S_OK;

	if (!item->Icon)
	{
		HICON iconSmall;
		int res = ExtractIconEx(path.c_str(), item->IconIndex, NULL, &iconSmall, 1);

		if (!res)
			return E_FAIL;

		HBITMAP bmp = ConvertIconToBitmap(iconSmall);
		
		if (iconSmall)
			DestroyIcon(iconSmall);

		if (!bmp)
			return E_FAIL;

		item->Icon = bmp;
	}

	int res = SetMenuItemBitmaps(menu, position, flags, item->Icon, item->Icon);

	if (!res)
		return E_FAIL;

	return S_OK;
}


std::wstring JoinList(std::list<std::wstring>* list, const std::wstring& sep)
{
	std::wstring ret;

	if ((*list).size() > 0)
		ret = *(*list).begin();

	if ((*list).size() > 1)
	{
		std::list<std::wstring>::iterator it = (*list).begin();
		it++;

		for (it; it != (*list).end(); it++)
			ret += sep + (*it);
	}

	return ret;
}


std::wstring ToLower(std::wstring val)
{
	std::transform(val.begin(), val.end(), val.begin(), tolower);
	return val;
}


std::wstring GetExtNoDot(std::wstring pathName)
{
	size_t period = pathName.find_last_of(L".");
	return ToLower(pathName.substr(period + 1));
}


BOOL DirectoryExist(std::wstring path)
{
	DWORD dwAttrib = GetFileAttributes(path.c_str());
	return (dwAttrib != INVALID_FILE_ATTRIBUTES && (dwAttrib & FILE_ATTRIBUTE_DIRECTORY));
}


HRESULT CMain::LoadXML()
{
	for (Item* item : g_Items)
		delete item;

	g_Items.clear();

	WCHAR path[500];
	SHRegGetPath(HKEY_CURRENT_USER, L"Software\\" PRODUCT_NAME, L"SettingsLocation", path, NULL);

	if (!FileExists(path))
		return E_FAIL;

	ATL::CComPtr<IXMLDOMDocument> doc;
	HRESULT hr = doc.CoCreateInstance(__uuidof(DOMDocument));

	if (FAILED(hr))
		return hr;

	VARIANT_BOOL success;
	hr = doc->load(ATL::CComVariant(path), &success);

	if (FAILED(hr))
		return hr;
	
	ATL::CComPtr<IXMLDOMNodeList> items;
	hr = doc->selectNodes(ATL::CComBSTR(L"AppSettings/Items/Item"), &items);

	if (FAILED(hr))
		return hr;

	IXMLDOMNode* itemNode;

	while (S_OK == items->nextNode(&itemNode))
	{
		Item* item = new Item();
		
		ATL::CComPtr<IXMLDOMNodeList> itemFields;
		hr = itemNode->get_childNodes(&itemFields);

		if FAILED(hr)
			hr;

		IXMLDOMNode* itemField;

		while (S_OK == itemFields->nextNode(&itemField))
		{
			BSTR nodeName;
			hr = itemField->get_nodeName(&nodeName);

			if FAILED(hr)
				return hr;

			ATL::CComBSTR cNodeName(nodeName);
			
			BSTR nodeText;
			hr = itemField->get_text(&nodeText);

			if FAILED(hr)
				return hr;

			ATL::CComBSTR cNodeText(nodeText);

			if (cNodeName == L"Name")
				item->Name = cNodeText;
			else if (cNodeName == L"Path")
				item->Path = cNodeText;
			else if (cNodeName == L"Arguments")
				item->Arguments = cNodeText;
			else if (cNodeName == L"WorkingDirectory")
				item->WorkingDirectory = cNodeText;
			else if (cNodeName == L"IconFile")
				item->IconFile = cNodeText;
			else if (cNodeName == L"IconIndex")
				item->IconIndex = std::stoi(std::wstring(cNodeText));
			else if (cNodeName == L"FileTypes")
				item->FileTypes = cNodeText;
			else if (cNodeName == L"SubMenu")
				item->SubMenu = (cNodeText == L"true") ? true : false;
			else if (cNodeName == L"Directories")
				item->Directories = (cNodeText == L"true") ? true : false;
			else if (cNodeName == L"RunAsAdmin")
				item->RunAsAdmin = (cNodeText == L"true") ? true : false;
			else if (cNodeName == L"HideWindow")
				item->HideWindow = (cNodeText == L"true") ? true : false;
			else if (cNodeName == L"Hidden")
				item->Hidden = (cNodeText == L"true") ? true : false;
			else if (cNodeName == L"Sort")
				item->Sort = (cNodeText == L"true") ? true : false;
		}

		g_Items.push_back(item);
	}

	return S_OK;
}


STDMETHODIMP CMain::Initialize(
	LPCITEMIDLIST pidlFolder,
	LPDATAOBJECT pDataObj,
	HKEY hProgID)
{
	FORMATETC fmt = { CF_HDROP, NULL, DVASPECT_CONTENT, -1, TYMED_HGLOBAL };
	STGMEDIUM stg;
	g_ShellItems.clear();

	if (pDataObj)
	{
		if (FAILED(pDataObj->GetData(&fmt, &stg)))
			return E_INVALIDARG;

		int uNumFiles = DragQueryFile((HDROP)stg.hGlobal, 0xFFFFFFFF, NULL, 0);

		if (!uNumFiles)
		{
			ReleaseStgMedium(&stg);
			return E_INVALIDARG;
		}

		for (int i = 0; i < uNumFiles; i++)
		{
			WCHAR buffer[500];
			DragQueryFile((HDROP)stg.hGlobal, i, buffer, std::size(buffer));
			g_ShellItems.push_back(buffer);
		}

		ReleaseStgMedium(&stg);
	}
	else if (pidlFolder)
	{
		WCHAR buffer[500];

		if (!SHGetPathFromIDList(pidlFolder, buffer))
			return E_FAIL;

		g_ShellItems.push_back(buffer);
	}
	else
		return E_FAIL;

	return S_OK;
}


STDMETHODIMP CMain::QueryContextMenu(
	HMENU hmenu, UINT uMenuIndex, UINT uidFirstCmd, UINT uidLastCmd, UINT uFlags)
{
	if (!g_Items.size() || SHRegGetBoolUSValue(
		L"Software\\" PRODUCT_NAME, L"Reload", FALSE, TRUE))
	{
		REGISTRY_ENTRY re = GetRegEntry(HKEY_CURRENT_USER,
			L"Software\\" PRODUCT_NAME, L"Reload", NULL, REG_DWORD, 0);

		if (FAILED(CreateRegKeyAndSetValue(&re)))
			return E_FAIL;

		HRESULT hr = LoadXML();

		if (FAILED(hr))
			return hr;

		WCHAR szExeDir[500];
		SHRegGetPath(HKEY_CURRENT_USER, L"Software\\" PRODUCT_NAME, L"ExeDir", szExeDir, NULL);
		std::wstring exeDir(szExeDir);
		std::wstring iconPath = exeDir + L"Icons\\Main.ico";

		if (FileExists(iconPath))
			IconItem.IconFile = iconPath;
	}

	UINT command = uidFirstCmd;
	HMENU subMenu = CreatePopupMenu();

	bool addSubSep = false;
	bool isCtrlPressed = GetKeyState(VK_CONTROL) < 0;
	bool isFile = FileExists(*g_ShellItems.begin());
	bool isDirectory = !isFile && DirectoryExist(*g_ShellItems.begin());

	g_EditCommandIndex = -1;

	int res = InsertMenu(hmenu, uMenuIndex, MF_BYPOSITION | MF_POPUP, (UINT_PTR)subMenu, L"Open with++");
	int subMenuIndex = uMenuIndex;

	if (!res)
		return E_FAIL;

	if (FileExists(IconItem.IconFile))
		SetIcon(hmenu, uMenuIndex, MF_BYPOSITION, &IconItem);

	uMenuIndex += 1;

	for (UINT i = 0; i < g_Items.size(); i++)
	{
		g_Items[i]->CommandIndex = -1;
		std::wstring ext = GetExtNoDot(*g_ShellItems.begin());

		if (isFile && g_Items[i]->FileTypes != L"" && ext != L""
			&& (L" " + g_Items[i]->FileTypes + L" ").find(L" " + ext + L" ") != std::wstring::npos
			&& (!g_Items[i]->Hidden || (g_Items[i]->Hidden && isCtrlPressed)))
		{
			g_Items[i]->CommandIndex = command - uidFirstCmd;

			if (g_Items[i]->SubMenu)
			{
				res = InsertMenu(subMenu, -1, MF_BYPOSITION, command, g_Items[i]->Name.c_str());

				if (!res)
					return E_FAIL;

				SetIcon(hmenu, command, MF_BYCOMMAND, g_Items[i]);
				addSubSep = true;
			}
			else
			{
				res = InsertMenu(hmenu, uMenuIndex, MF_BYPOSITION, command, g_Items[i]->Name.c_str());

				if (!res)
					return E_FAIL;

				SetIcon(hmenu, uMenuIndex, MF_BYPOSITION, g_Items[i]);
				uMenuIndex += 1;
			}

			command += 1;
		}           
	}

	if (addSubSep)
	{
		res = InsertMenu(subMenu, -1, MF_BYPOSITION | MF_SEPARATOR, command, NULL);

		if (!res)
			return E_FAIL;

		command += 1;
	}

	bool addSubSep2 = false;

	for (UINT i = 0; i < g_Items.size(); i++)
	{
		if ((g_Items[i]->FileTypes == L"*.*" && isFile) || (g_Items[i]->Directories && isDirectory)
			&& (!g_Items[i]->Hidden || (g_Items[i]->Hidden && isCtrlPressed)))
		{
			g_Items[i]->CommandIndex = command - uidFirstCmd;

			if (g_Items[i]->SubMenu)
			{
				res = InsertMenu(subMenu, -1, MF_BYPOSITION, command, g_Items[i]->Name.c_str());

				if (!res)
					return E_FAIL;

				SetIcon(hmenu, command, MF_BYCOMMAND, g_Items[i]);
				addSubSep2 = true;
			}
			else
			{
				res = InsertMenu(hmenu, uMenuIndex, MF_BYPOSITION, command, g_Items[i]->Name.c_str());

				if (!res)
					return E_FAIL;

				SetIcon(hmenu, uMenuIndex, MF_BYPOSITION, g_Items[i]);
				uMenuIndex += 1;
			}

			command += 1;
		}
	}

	if (addSubSep2)
	{
		res = InsertMenu(subMenu, -1, MF_BYPOSITION | MF_SEPARATOR, command, NULL);

		if (!res)
			return E_FAIL;

		command += 1;
	}

	if (addSubSep || addSubSep2)
	{
		res = InsertMenu(subMenu, -1, MF_BYPOSITION, command, L"Customize Open with++");

		if (!res)
			return E_FAIL;

		if (FileExists(IconItem.IconFile))
			SetIcon(subMenu, command, MF_BYCOMMAND, &IconItem);

		g_EditCommandIndex = command - uidFirstCmd;
	}
	else
		DeleteMenu(hmenu, subMenuIndex, MF_BYPOSITION);

	return MAKE_HRESULT(SEVERITY_SUCCESS, 0, command - uidFirstCmd + 1);
}


STDMETHODIMP CMain::InvokeCommand(LPCMINVOKECOMMANDINFO pCmdInfo)
{
	if (HIWORD(pCmdInfo->lpVerb) != 0)
		return E_FAIL;

	HWND hwnd = GetActiveWindow();
	WORD id = LOWORD(pCmdInfo->lpVerb);

	for (UINT i = 0; i < g_Items.size(); i++)
	{
		if (id == g_Items[i]->CommandIndex)
		{
			PROCESS_INFORMATION pi = {0};
			STARTUPINFO si = {sizeof(si)};

			std::wstring args = g_Items[i]->Arguments;

			if (args.find(L"%items%") != std::wstring::npos)
			{
				std::wstring joined = L"\"" + JoinList(&g_ShellItems, L"\" \"") + L"\"";
				ATL::CString value = args.c_str();
				value.Replace(L"%items%", joined.c_str());
				args = value.GetBuffer();
			}

			if (args.find(L"%paths%") != std::wstring::npos)
			{
				std::wstring joined = L"\"" + JoinList(&g_ShellItems, L"\" \"") + L"\"";
				ATL::CString value = args.c_str();
				value.Replace(L"%paths%", joined.c_str());
				args = value.GetBuffer();
			}

			std::wstring verb;

			if (g_Items[i]->RunAsAdmin || GetKeyState(VK_SHIFT) < 0)
				verb = L"runas";

			std::wstring path = g_Items[i]->Path;
			std::wstring var(L"%");

			if (path.find(var) != std::string::npos)
			{
				WCHAR szPath[500];
				DWORD result = ExpandEnvironmentStrings(path.c_str(), szPath, std::size(szPath));

				if (result)
					path = szPath;
			}

			if (args.find(var) != std::string::npos)
			{
				WCHAR szArgs[900];
				DWORD result = ExpandEnvironmentStrings(args.c_str(), szArgs, std::size(szArgs));

				if (result)
					args = szArgs;
			}

			std::wstring guiExe(L"OpenWithPPGUI.exe");

			if (guiExe == path)
			{
				WCHAR szExeDir[500];
				SHRegGetPath(HKEY_CURRENT_USER, L"Software\\" PRODUCT_NAME, L"ExeDir", szExeDir, NULL);
				std::wstring exeDir(szExeDir);
				path = exeDir + guiExe;
			}

			SHELLEXECUTEINFO info;

			info.cbSize = sizeof(SHELLEXECUTEINFO);
			info.fMask = NULL;
			info.hwnd = hwnd;
			info.lpVerb = verb.c_str();
			info.lpFile = path.c_str();
			info.lpParameters = args.c_str();

			if (g_Items[i]->WorkingDirectory.length() == 0)
			{
				WCHAR szDir[500];

				if (g_ShellItems.size() > 0)
				{
					std::wstring firstItem = *g_ShellItems.begin();

					if (FileExists(firstItem))
					{
						wcscpy_s(szDir, firstItem.c_str());
						PathRemoveFileSpec(szDir);
					}
					else if (DirectoryExist(firstItem))
					{
						wcscpy_s(szDir, firstItem.c_str());
					}
				}

				info.lpDirectory = DirectoryExist(szDir) ? szDir : NULL;
			}
			else
			{
				if (g_Items[i]->WorkingDirectory.find(var) != std::string::npos)
				{
					WCHAR szWorkingDirectory[500];
					DWORD result = ExpandEnvironmentStrings(
						g_Items[i]->WorkingDirectory.c_str(), szWorkingDirectory, std::size(szWorkingDirectory));

					if (result)
						g_Items[i]->WorkingDirectory = szWorkingDirectory;
				}

				info.lpDirectory = g_Items[i]->WorkingDirectory.c_str();
			}

			info.nShow = g_Items[i]->HideWindow ? SW_HIDE : SW_NORMAL;
			info.hInstApp = NULL;

			ShellExecuteEx(&info);
			return S_OK;
		}
	}

	if (id == g_EditCommandIndex)
	{
		WCHAR path[500];
		SHRegGetPath(HKEY_CURRENT_USER, L"Software\\" PRODUCT_NAME, L"ExeLocation", path, NULL);

		SHELLEXECUTEINFO info;

		info.cbSize = sizeof(SHELLEXECUTEINFO);
		info.fMask = NULL;
		info.hwnd = hwnd;
		info.lpVerb = NULL;
		info.lpFile = path;
		info.lpParameters = NULL;
		info.lpDirectory = NULL;
		info.nShow = SW_NORMAL;
		info.hInstApp = NULL;

		ShellExecuteEx(&info);
		return S_OK;
	}

	return E_FAIL;
}


STDMETHODIMP CMain::GetCommandString(UINT_PTR idCmd, UINT uFlags, UINT* pwReserved, LPSTR pszName, UINT cchMax)
{
	return S_OK;
}
