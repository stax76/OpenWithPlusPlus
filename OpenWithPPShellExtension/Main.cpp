#include "stdafx.h"
#include "Main.h"
#include "Util.h"
#include "atlstr.h"

STDMETHODIMP CMain::Initialize (
	LPCITEMIDLIST pidlFolder, LPDATAOBJECT pDataObj, HKEY hProgID)
{
	FORMATETC fmt = {CF_HDROP, NULL, DVASPECT_CONTENT, -1, TYMED_HGLOBAL};
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

std::wstring ToLower(std::wstring val)
{
	std::transform(val.begin(), val.end(), val.begin(), tolower);
	return val;
}

std::wstring GetExtNoDot(std::wstring pathName)
{
	auto period = pathName.find_last_of(L".");
	return ToLower(pathName.substr(period + 1));
}

BOOL FileExist(std::wstring path)
{
	DWORD dwAttrib = GetFileAttributes(path.c_str());
	return (dwAttrib != INVALID_FILE_ATTRIBUTES && !(dwAttrib & FILE_ATTRIBUTE_DIRECTORY));
}

BOOL DirectoryExist(std::wstring path)
{
	DWORD dwAttrib = GetFileAttributes(path.c_str());

	return (dwAttrib != INVALID_FILE_ATTRIBUTES && (dwAttrib & FILE_ATTRIBUTE_DIRECTORY));
}

HRESULT CMain::LoadXML()
{
	Items.clear();

	TCHAR path[MAX_PATH];
	SHRegGetPath(HKEY_CURRENT_USER, L"Software\\" PRODUCT_NAME,
		L"SettingsLocation", path, NULL);
	if (!FileExist(path)) return E_FAIL;

	CComPtr<IXMLDOMDocument> doc;
	HRESULT hr = doc.CoCreateInstance(__uuidof(DOMDocument));
	if (FAILED(hr)) return hr;

	VARIANT_BOOL success;
	hr = doc->load(CComVariant(path), &success);
	if (FAILED(hr)) return hr;
	
	CComPtr<IXMLDOMNodeList> items;
	hr = doc->selectNodes(CComBSTR(L"AppSettings/Items/Item"), &items);
	if (FAILED(hr)) return hr;

	IXMLDOMNode *itemNode;

	while (S_OK == items->nextNode(&itemNode))
	{
		Item* item = new Item();
		
		CComPtr<IXMLDOMNodeList> itemFields;
		hr = itemNode->get_childNodes(&itemFields);
		if FAILED(hr) hr;

		IXMLDOMNode *itemField;

		while (S_OK == itemFields->nextNode(&itemField))
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

STDMETHODIMP CMain::QueryContextMenu(
	HMENU hmenu, UINT uMenuIndex, UINT uidFirstCmd,
	UINT uidLastCmd, UINT uFlags )
{
	if (Items.size() == 0 || SHRegGetBoolUSValue(
		L"Software\\" PRODUCT_NAME, L"Reload", FALSE, TRUE))
	{
		REGISTRY_ENTRY re = GetRegEntry(
			HKEY_CURRENT_USER,
			L"Software\\" PRODUCT_NAME,
			L"Reload",
			NULL,
			REG_DWORD,
			0);

		if (FAILED(CreateRegKeyAndSetValue(&re)))
			return E_FAIL;

		HRESULT hr = LoadXML();
		if (FAILED(hr)) return hr;
	}

	UINT commandIndex = uidFirstCmd;
	HMENU popMenu = CreatePopupMenu();
	bool addSubSep = false;

	BOOL isFile = FileExist(*ShellItems.begin());
	BOOL isDirectory = ! isFile && DirectoryExist(*ShellItems.begin());

	InsertMenu(hmenu, uMenuIndex, MF_BYPOSITION | MF_POPUP, (UINT_PTR)popMenu, L"Open with++");

	uMenuIndex += 1;

	for (UINT i = 0; i < Items.size(); i++)
	{
		Items[i]->CommandIndex = -1;
		std::wstring ext = GetExtNoDot(*ShellItems.begin());

		if (isFile && Items[i]->FileTypes != L"" && ext != L"" &&
			(L" " + Items[i]->FileTypes + L" ").find(L" " + ext + L" ") != std::wstring::npos)
		{
			Items[i]->CommandIndex = commandIndex - uidFirstCmd;

			if (Items[i]->SubMenu)
			{
				InsertMenu(popMenu, -1, MF_BYPOSITION, commandIndex, Items[i]->Name.c_str());
				addSubSep = true;
			}
			else
			{
				InsertMenu(hmenu, uMenuIndex, MF_BYPOSITION, commandIndex, Items[i]->Name.c_str());
				uMenuIndex += 1;
			}

			commandIndex += 1;
		}           
	}

	if (addSubSep)
	{
		addSubSep = false;
		InsertMenu(popMenu, -1, MF_BYPOSITION | MF_SEPARATOR, commandIndex, L"");
	}

	for (UINT i = 0; i < Items.size(); i++)
	{
		if ((Items[i]->FileTypes == L"*.*" && isFile) || (Items[i]->Directories && isDirectory))
		{
			Items[i]->CommandIndex = commandIndex - uidFirstCmd;

			if (Items[i]->SubMenu)
			{
				InsertMenu(popMenu, -1, MF_BYPOSITION, commandIndex, Items[i]->Name.c_str());
				addSubSep = true;
			}
			else
			{
				InsertMenu(hmenu, uMenuIndex, MF_BYPOSITION, commandIndex, Items[i]->Name.c_str());
				uMenuIndex += 1;
			}

			commandIndex += 1;
		}
	}

	if (addSubSep)
	{
		addSubSep = false;
		InsertMenu(popMenu, -1, MF_BYPOSITION | MF_SEPARATOR, commandIndex, L"");
	}

	InsertMenu(popMenu, -1, MF_BYPOSITION, commandIndex, L"Customize Open with++");
	EditIndex = commandIndex - uidFirstCmd;

	return MAKE_HRESULT(SEVERITY_SUCCESS, 0, commandIndex - uidFirstCmd + 1);
}

std::wstring JoinList(std::list<std::wstring>* l, const std::wstring &sep)
{
	std::wstring r;

	if ((*l).size() > 0)
		r = *(*l).begin();

	if ((*l).size() > 1)
	{
		std::list<std::wstring>::iterator it = (*l).begin();
		it++;

		for (it; it != (*l).end(); it++)
		{
			r += sep + (*it);
		}
	}

	return r;
}

STDMETHODIMP CMain::InvokeCommand(LPCMINVOKECOMMANDINFO pCmdInfo)
{
	if (HIWORD(pCmdInfo->lpVerb) != 0)
		return S_OK;

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
				std::wstring s = *ShellItems.begin();

				if (FileExist(s))
				{
					wcscpy_s(szDir, s.c_str());
					PathRemoveFileSpec(szDir);
				}
				else if (DirectoryExist(s))
				{
					wcscpy_s(szDir, s.c_str());
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
			shExecInfo.lpDirectory = DirectoryExist(szDir) ? szDir : NULL;
			shExecInfo.nShow = Items[i]->HideWindow ? SW_HIDE : SW_NORMAL;
			shExecInfo.hInstApp = NULL;

			ShellExecuteEx(&shExecInfo);
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
	}

	return S_OK;
}

STDMETHODIMP CMain::GetCommandString(UINT_PTR idCmd, UINT uFlags, UINT* pwReserved, LPSTR pszName, UINT cchMax)
{
	return S_OK;
}