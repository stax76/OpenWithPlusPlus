
#include "StdAfx.h"
#include "Util.h"


REGISTRY_ENTRY GetRegEntry(
	HKEY    hkeyRoot,
	LPCWSTR pszKeyName,
	LPCWSTR pszValueName,
	LPCWSTR pszData,
	DWORD   dwType,
	DWORD   dwData)
{
	REGISTRY_ENTRY r = {
		hkeyRoot,
		pszKeyName,
		pszValueName,
		dwType,
		pszData,
		dwData};

	return r;
}


HRESULT CreateRegKeyAndSetValue(REGISTRY_ENTRY *pRegistryEntry)
{
	HRESULT hr = E_FAIL;

	if (pRegistryEntry != NULL)
	{
		HKEY hKey;
		LSTATUS ls = RegCreateKeyExW(pRegistryEntry->hkeyRoot, pRegistryEntry->pszKeyName,
			0, NULL, REG_OPTION_NON_VOLATILE, KEY_ALL_ACCESS, NULL, &hKey, NULL);

		hr = HRESULT_FROM_WIN32(ls);

		if (SUCCEEDED(hr))
		{
			LPBYTE pData = NULL;
			DWORD cbData = 0;
			hr = S_OK;

			switch (pRegistryEntry->dwType)
			{
			case REG_SZ:
				pData = (LPBYTE) pRegistryEntry->pszData;
				cbData = ((DWORD) wcslen(pRegistryEntry->pszData) + 1) * sizeof(WCHAR);
				break;

			case REG_DWORD:
				pData = (LPBYTE) &pRegistryEntry->dwData;
				cbData = sizeof(pRegistryEntry->dwData);
				break;

			default:
				hr = E_INVALIDARG;
				break;
			}

			if (SUCCEEDED(hr))
			{
				ls = RegSetValueExW(hKey, pRegistryEntry->pszValueName, 0,
					pRegistryEntry->dwType, pData, cbData);

				hr = HRESULT_FROM_WIN32(ls);
			}

			RegCloseKey(hKey);
		}
	}

	return hr;
}


HRESULT DeleteRegKeyOrValue(REGISTRY_ENTRY* re)
{
	if (!re->pszValueName)
	{
		LSTATUS ls = SHDeleteKey(re->hkeyRoot, re->pszKeyName);

		if (ls)
			return HRESULT_FROM_WIN32(ls);
	}
	else
	{
		LSTATUS ls = SHDeleteValue(re->hkeyRoot, re->pszKeyName, re->pszValueName);

		if (ls)
			return HRESULT_FROM_WIN32(ls);
	}

	return S_OK;
}
