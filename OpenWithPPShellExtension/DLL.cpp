
#include "stdafx.h"
#include "Common.h"
#include "Util.h"


HMODULE g_hmodThis;


class COpenWithPPShellExtensionModule : public ATL::CAtlDllModuleT< COpenWithPPShellExtensionModule >
{
public :
};


COpenWithPPShellExtensionModule _AtlModule;


extern "C" BOOL WINAPI DllMain(HINSTANCE hInstance, DWORD dwReason, LPVOID lpReserved)
{
	g_hmodThis = (HMODULE)hInstance;
	return _AtlModule.DllMain(dwReason, lpReserved); 
}

__control_entrypoint(DllExport)
STDAPI DllCanUnloadNow(void)
{
    return _AtlModule.DllCanUnloadNow();
}

_Check_return_
STDAPI DllGetClassObject(_In_ REFCLSID rclsid, _In_ REFIID riid, _Outptr_ LPVOID FAR* ppv)
{
    return _AtlModule.DllGetClassObject(rclsid, riid, ppv);
}

__control_entrypoint(DllExport)
STDAPI DllRegisterServer(void)
{
	WCHAR szModuleName[MAX_PATH];

    if (!GetModuleFileNameW(g_hmodThis, szModuleName, ARRAYSIZE(szModuleName)))
        return HRESULT_FROM_WIN32(GetLastError());

	REGISTRY_ENTRY regEntries[] = {
		GetRegEntry(
			HKEY_LOCAL_MACHINE,
			L"Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved",
			L"{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}",
			PRODUCT_NAME),
	
		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"CLSID\\{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}",
			NULL,
			PRODUCT_NAME),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"CLSID\\{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}\\InprocServer32",
			NULL,
			szModuleName),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"CLSID\\{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}\\InprocServer32",
			L"ThreadingModel",
			L"Apartment"),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"*\\shellex\\ContextMenuHandlers\\" PRODUCT_NAME,
			NULL,
			L"{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}"),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"Directory\\shellex\\ContextMenuHandlers\\" PRODUCT_NAME,
			NULL,
			L"{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}"),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"Folder\\shellex\\ContextMenuHandlers\\" PRODUCT_NAME,
			NULL,
			L"{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}"),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"Directory\\Background\\shellex\\ContextMenuHandlers\\" PRODUCT_NAME,
			NULL,
			L"{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}")
	};

    for (int i = 0; i < ARRAYSIZE(regEntries); i++)
    {
        HRESULT hr = CreateRegKeyAndSetValue(&regEntries[i]);
		if (FAILED(hr)) return hr;
    }

	return _AtlModule.DllRegisterServer(FALSE);
}

__control_entrypoint(DllExport)
STDAPI DllUnregisterServer(void)
{
		REGISTRY_ENTRY re[] = {

		GetRegEntry(
			HKEY_LOCAL_MACHINE,
			L"Software\\Microsoft\\Windows\\CurrentVersion\\Shell Extensions\\Approved",
			L"{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}",
			NULL),
	
		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"CLSID\\{E7B8ACF5-FC18-4f0d-BC50-D0184481A5DC}",
			NULL,
			NULL),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"*\\shellex\\ContextMenuHandlers\\" PRODUCT_NAME,
			NULL,
			NULL),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"Directory\\shellex\\ContextMenuHandlers\\" PRODUCT_NAME,
			NULL,
			NULL),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"Directory\\Background\\shellex\\ContextMenuHandlers\\" PRODUCT_NAME,
			NULL,
			NULL),

		GetRegEntry(
			HKEY_CLASSES_ROOT,
			L"Folder\\shellex\\ContextMenuHandlers\\" PRODUCT_NAME,
			NULL,
			NULL)
	};

    for (int i = 0; i < ARRAYSIZE(re); i++)
    {
        HRESULT hr = DeleteRegKeyOrValue(&re[i]);
		if (FAILED(hr)) return hr;
    }

	return _AtlModule.DllUnregisterServer(FALSE);
}