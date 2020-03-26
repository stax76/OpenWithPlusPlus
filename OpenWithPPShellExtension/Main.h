
#pragma once

#include <initguid.h>

#include <list>
#include <vector>
#include <algorithm>
#include <string>

EXTERN_C const CLSID CLSID_Main;

// {E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}
DEFINE_GUID(CLSID_Main, 0xe7b8acf5, 0xfc18, 0x4f0d, 0xbc, 0x50, 0xd0, 0x18, 0x44, 0x81, 0xa5, 0xdc);

class Item
{
public:
	HBITMAP Icon = NULL;

	std::wstring Name;
	std::wstring Path;
	std::wstring Arguments;
	std::wstring WorkingDirectory;
	std::wstring IconFile;
	std::wstring FileTypes;

	bool SubMenu;
	bool Directories;
	bool RunAsAdmin;
	bool HideWindow;
	bool Hidden;
	bool Sort;

	int CommandIndex;
	int IconIndex;

	~Item();
};

std::list<std::wstring> g_ShellItems;
std::vector<Item*> g_Items;
int g_EditCommandIndex;

// CMain

class ATL_NO_VTABLE CMain :
	public CComObjectRootEx<CComSingleThreadModel>,
	public CComCoClass<CMain, &CLSID_Main>,
	public IShellExtInit,
	public IContextMenu
{

private:

	HRESULT LoadXML();

public:

	CMain()
	{
	}

    DECLARE_NO_REGISTRY();
	DECLARE_NOT_AGGREGATABLE(CMain);

	BEGIN_COM_MAP(CMain)
		COM_INTERFACE_ENTRY(IShellExtInit)
		COM_INTERFACE_ENTRY(IContextMenu)
	END_COM_MAP()

	// IShellExtInit
    STDMETHODIMP Initialize(LPCITEMIDLIST, LPDATAOBJECT, HKEY);

    // IContextMenu
    STDMETHODIMP GetCommandString(UINT_PTR, UINT, UINT*, LPSTR, UINT);
    STDMETHODIMP InvokeCommand(LPCMINVOKECOMMANDINFO);
    STDMETHODIMP QueryContextMenu(HMENU, UINT, UINT, UINT, UINT);

	DECLARE_PROTECT_FINAL_CONSTRUCT()

	HRESULT FinalConstruct()
	{
		return S_OK;
	}

	void FinalRelease()
	{
	}
};

OBJECT_ENTRY_AUTO(CLSID_Main, CMain)
