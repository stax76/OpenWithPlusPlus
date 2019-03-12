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
	HRESULT hr = E_INVALIDARG;

	if (pRegistryEntry != NULL)
	{
		// create the key, or obtain its handle if it already exists
		HKEY hKey;
		LONG lr = RegCreateKeyExW(pRegistryEntry->hkeyRoot,
								  pRegistryEntry->pszKeyName, 
								  0, 
								  NULL, 
								  REG_OPTION_NON_VOLATILE,
								  KEY_ALL_ACCESS, 
								  NULL, 
								  &hKey, 
								  NULL);

		hr = HRESULT_FROM_WIN32(lr);

		if (SUCCEEDED(hr))
		{
			// extract the data from the struct according to its type
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
				// attempt to set the value
				lr = RegSetValueExW(hKey,
									pRegistryEntry->pszValueName,
									0,
									pRegistryEntry->dwType,
									pData,
									cbData);

				hr = HRESULT_FROM_WIN32(lr);
			}

			RegCloseKey(hKey);
		}
	}

	return hr;
}


HRESULT DeleteRegKeyOrValue(REGISTRY_ENTRY *re)
{
	if (re->pszValueName == NULL)
	{
		LONG lr = SHDeleteKey(re->hkeyRoot, re->pszKeyName);
		if (lr != ERROR_SUCCESS)
			return HRESULT_FROM_WIN32(lr);
	}
	else
	{
		LONG lr = SHDeleteValue(re->hkeyRoot, re->pszKeyName, re->pszValueName);
		if (lr != ERROR_SUCCESS)
			return HRESULT_FROM_WIN32(lr);
	}

	return E_FAIL;
}