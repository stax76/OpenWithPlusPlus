
#include "stdafx.h"
#include "Main.h"
#include "Util.h"
#include "atlstr.h"
#include "wincodec.h"


Item::~Item()
{
	if (Icon)
	{
		DeleteObject(Icon);
		Icon = NULL;
	}
}


BOOL FileExist(std::wstring file)
{
	if (file.length() == 0)
		return false;

	DWORD dwAttrib = GetFileAttributes(file.c_str());
	return (dwAttrib != INVALID_FILE_ATTRIBUTES && !(dwAttrib & FILE_ATTRIBUTE_DIRECTORY));
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


HRESULT SetIcon(HMENU menu, UINT command, Item* item)
{
	if (!FileExist(item->IconFile))
		return S_OK;

	if (!item->Icon)
	{
		HICON iconSmall;
		HICON iconLarge = NULL;
		int res = ExtractIconEx(item->IconFile.c_str(), item->IconIndex, &iconLarge, &iconSmall, 1);

		if (!res)
			return E_FAIL;

		HBITMAP bmp = ConvertIconToBitmap(iconSmall);
		
		if (iconSmall)
			DestroyIcon(iconSmall);

		if (iconLarge)
			DestroyIcon(iconLarge);

		if (!bmp)
			return E_FAIL;

		item->Icon = bmp;
	}

	int res = SetMenuItemBitmaps(menu, command, MF_BYCOMMAND, item->Icon, item->Icon);

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
	for (Item* item : Items)
		delete item;

	Items.clear();

	TCHAR path[MAX_PATH];
	SHRegGetPath(HKEY_CURRENT_USER, L"Software\\" PRODUCT_NAME,
		L"SettingsLocation", path, NULL);

	if (!FileExist(path))
		return E_FAIL;

	CComPtr<IXMLDOMDocument> doc;
	HRESULT hr = doc.CoCreateInstance(__uuidof(DOMDocument));

	if (FAILED(hr))
		return hr;

	VARIANT_BOOL success;
	hr = doc->load(CComVariant(path), &success);

	if (FAILED(hr))
		return hr;
	
	CComPtr<IXMLDOMNodeList> items;
	hr = doc->selectNodes(CComBSTR(L"AppSettings/Items/Item"), &items);

	if (FAILED(hr))
		return hr;

	IXMLDOMNode *itemNode;

	while (!items->nextNode(&itemNode))
	{
		Item* item = new Item();
		
		CComPtr<IXMLDOMNodeList> itemFields;
		hr = itemNode->get_childNodes(&itemFields);

		if FAILED(hr)
			hr;

		IXMLDOMNode *itemField;

		while (!itemFields->nextNode(&itemField))
		{
			BSTR nodeName;
			hr = itemField->get_nodeName(&nodeName);

			if FAILED(hr)
				return hr;

			CComBSTR cNodeName(nodeName);
			
			BSTR nodeText;
			hr = itemField->get_text(&nodeText);

			if FAILED(hr)
				return hr;

			CComBSTR cNodeText(nodeText);

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
			else if (cNodeName == L"Sort")
				item->Sort = (cNodeText == L"true") ? true : false;
		}

		Items.push_back(item);
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
	ShellItems.clear();

	if (pDataObj)
	{
		if (FAILED(pDataObj->GetData(&fmt, &stg)))
			return E_INVALIDARG;

		int uNumFiles = DragQueryFile((HDROP)stg.hGlobal, 0xFFFFFFFF, NULL, 0);

		if (0 == uNumFiles)
		{
			ReleaseStgMedium(&stg);
			return E_INVALIDARG;
		}

		for (int i = 0; i < uNumFiles; i++)
		{
			TCHAR buf[MAX_PATH];
			DragQueryFile((HDROP)stg.hGlobal, i, buf, MAX_PATH);
			ShellItems.push_back(buf);
		}

		ReleaseStgMedium(&stg);
	}
	else if (pidlFolder)
	{
		TCHAR buf[MAX_PATH];

		if (!SHGetPathFromIDList(pidlFolder, buf))
			return E_FAIL;

		ShellItems.push_back(buf);
	}
	else
		return E_FAIL;

	return S_OK;
}


STDMETHODIMP CMain::QueryContextMenu(
	HMENU hmenu, UINT uMenuIndex, UINT uidFirstCmd, UINT uidLastCmd, UINT uFlags)
{
	if (Items.size() == 0 || SHRegGetBoolUSValue(
		L"Software\\" PRODUCT_NAME, L"Reload", FALSE, TRUE))
	{
		REGISTRY_ENTRY re = GetRegEntry(HKEY_CURRENT_USER,
			L"Software\\" PRODUCT_NAME, L"Reload",
			NULL, REG_DWORD, 0);

		if (FAILED(CreateRegKeyAndSetValue(&re)))
			return E_FAIL;

		HRESULT hr = LoadXML();

		if (FAILED(hr))
			return hr;
	}

	UINT command = uidFirstCmd;
	HMENU popMenu = CreatePopupMenu();
	bool addSubSep = false;

	BOOL isFile = FileExist(*ShellItems.begin());
	BOOL isDirectory = !isFile && DirectoryExist(*ShellItems.begin());

	int res = InsertMenu(hmenu, uMenuIndex, MF_BYPOSITION | MF_POPUP, (UINT_PTR)popMenu, L"Open with++");

	if (!res)
		return E_FAIL;

	uMenuIndex += 1;

	for (UINT i = 0; i < Items.size(); i++)
	{
		Items[i]->CommandIndex = -1;
		std::wstring ext = GetExtNoDot(*ShellItems.begin());

		if (isFile && Items[i]->FileTypes != L"" && ext != L"" &&
			(L" " + Items[i]->FileTypes + L" ").find(L" " + ext + L" ") != std::wstring::npos)
		{
			Items[i]->CommandIndex = command - uidFirstCmd;

			if (Items[i]->SubMenu)
			{
				res = InsertMenu(popMenu, -1, MF_BYPOSITION, command, Items[i]->Name.c_str());

				if (!res)
					return E_FAIL;

				SetIcon(hmenu, command, Items[i]);
				addSubSep = true;
			}
			else
			{
				res = InsertMenu(hmenu, uMenuIndex, MF_BYPOSITION, command, Items[i]->Name.c_str());

				if (!res)
					return E_FAIL;

				SetIcon(hmenu, command, Items[i]);
				uMenuIndex += 1;
			}

			command += 1;
		}           
	}

	if (addSubSep)
	{
		addSubSep = false;
		res = InsertMenu(popMenu, -1, MF_BYPOSITION | MF_SEPARATOR, command, L"");

		if (!res)
			return E_FAIL;
	}

	for (UINT i = 0; i < Items.size(); i++)
	{
		if ((Items[i]->FileTypes == L"*.*" && isFile) || (Items[i]->Directories && isDirectory))
		{
			Items[i]->CommandIndex = command - uidFirstCmd;

			if (Items[i]->SubMenu)
			{
				res = InsertMenu(popMenu, -1, MF_BYPOSITION, command, Items[i]->Name.c_str());

				if (!res)
					return E_FAIL;

				SetIcon(hmenu, command, Items[i]);
				addSubSep = true;
			}
			else
			{
				res = InsertMenu(hmenu, uMenuIndex, MF_BYPOSITION, command, Items[i]->Name.c_str());

				if (!res)
					return E_FAIL;

				SetIcon(hmenu, command, Items[i]);
				uMenuIndex += 1;
			}

			command += 1;
		}
	}

	if (addSubSep)
	{
		addSubSep = false;
		res = InsertMenu(popMenu, -1, MF_BYPOSITION | MF_SEPARATOR, command, L"");

		if (!res)
			return E_FAIL;
	}

	res = InsertMenu(popMenu, -1, MF_BYPOSITION, command, L"Customize Open with++");

	if (!res)
		return E_FAIL;

	EditIndex = command - uidFirstCmd;
	return MAKE_HRESULT(SEVERITY_SUCCESS, 0, command - uidFirstCmd + 1);
}


STDMETHODIMP CMain::InvokeCommand(LPCMINVOKECOMMANDINFO pCmdInfo)
{
	if (HIWORD(pCmdInfo->lpVerb) != 0)
		return E_FAIL;

	HWND hwnd = GetActiveWindow();
	WORD id = LOWORD(pCmdInfo->lpVerb);

	for (UINT i = 0; i < Items.size(); i++)
	{
		if (id == Items[i]->CommandIndex)
		{
			PROCESS_INFORMATION pi = {0};
			STARTUPINFO si = {sizeof(si)};

			std::wstring args = Items[i]->Arguments;

			if (args.find(L"%items%") != std::wstring::npos)
			{
				std::wstring joined = L"\"" + JoinList(&ShellItems, L"\" \"") + L"\"";
				CString argh = args.c_str();
				argh.Replace(L"%items%", joined.c_str());
				args = argh.GetBuffer();
			}

			if (args.find(L"%paths%") != std::wstring::npos)
			{
				std::wstring joined = L"\"" + JoinList(&ShellItems, L"\" \"") + L"\"";
				CString argh = args.c_str();
				argh.Replace(L"%paths%", joined.c_str());
				args = argh.GetBuffer();
			}

			WCHAR szDir[MAX_PATH];

			if (ShellItems.size() > 0)
			{
				std::wstring firstItem = *ShellItems.begin();

				if (FileExist(firstItem))
				{
					wcscpy_s(szDir, firstItem.c_str());
					PathRemoveFileSpec(szDir);
				}
				else if (DirectoryExist(firstItem))
				{
					wcscpy_s(szDir, firstItem.c_str());
				}
			}

			std::wstring verb;

			if (Items[i]->RunAsAdmin ||
				(GetKeyState(VK_CONTROL) < 0 || GetKeyState(VK_SHIFT) < 0))
			{	
				verb = L"runas";
			}

			std::wstring path = Items[i]->Path;
			std::wstring var(L"%");

			if (path.find(var) != std::string::npos)
			{
				TCHAR szEnvPath[MAX_PATH];
				DWORD result = ExpandEnvironmentStrings(path.c_str(), szEnvPath, MAX_PATH);

				if (result)
				{
					std::wstring newPath(szEnvPath);
					path = newPath;
				}
			}

			if (args.find(var) != std::string::npos)
			{
				TCHAR szEnvArgs[MAX_PATH];
				DWORD result = ExpandEnvironmentStrings(args.c_str(), szEnvArgs, MAX_PATH);

				if (result)
				{
					std::wstring newArgs(szEnvArgs);
					args = newArgs;
				}
			}

			std::wstring guiExe(L"OpenWithPPGUI.exe");

			if (guiExe == path)
			{
				TCHAR exeDir[MAX_PATH];
				SHRegGetPath(HKEY_CURRENT_USER, L"Software\\" PRODUCT_NAME,
					L"ExeDir", exeDir, NULL);

				std::wstring exeDirString(exeDir);
				path = exeDirString + guiExe;
			}

			SHELLEXECUTEINFO shExecInfo;

			shExecInfo.cbSize = sizeof(SHELLEXECUTEINFO);
			shExecInfo.fMask = NULL;
			shExecInfo.hwnd = hwnd;
			shExecInfo.lpVerb = verb.c_str();
			shExecInfo.lpFile = path.c_str();
			shExecInfo.lpParameters = args.c_str();

			if (Items[i]->WorkingDirectory.length() == 0)
				shExecInfo.lpDirectory = DirectoryExist(szDir) ? szDir : NULL;
			else
				shExecInfo.lpDirectory = Items[i]->WorkingDirectory.c_str();

			shExecInfo.nShow = Items[i]->HideWindow ? SW_HIDE : SW_NORMAL;
			shExecInfo.hInstApp = NULL;

			ShellExecuteEx(&shExecInfo);
			return S_OK;
		}
	}

	if (id == EditIndex)
	{
		TCHAR path[MAX_PATH];
		SHRegGetPath(HKEY_CURRENT_USER, L"Software\\" PRODUCT_NAME,
			L"ExeLocation", path, NULL);

		SHELLEXECUTEINFO shExecInfo;

		shExecInfo.cbSize = sizeof(SHELLEXECUTEINFO);

		shExecInfo.fMask = NULL;
		shExecInfo.hwnd = hwnd;
		shExecInfo.lpVerb = NULL;
		shExecInfo.lpFile = path;
		shExecInfo.lpParameters = NULL;
		shExecInfo.lpDirectory = NULL;
		shExecInfo.nShow = SW_NORMAL;
		shExecInfo.hInstApp = NULL;

		ShellExecuteEx(&shExecInfo);
		return S_OK;
	}

	return E_FAIL;
}


STDMETHODIMP CMain::GetCommandString(UINT_PTR idCmd, UINT uFlags, UINT* pwReserved, LPSTR pszName, UINT cchMax)
{
	return S_OK;
}
