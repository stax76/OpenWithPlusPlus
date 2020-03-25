
#pragma once


struct REGISTRY_ENTRY
{
    HKEY    hkeyRoot;
    LPCWSTR pszKeyName;
    LPCWSTR pszValueName;
    DWORD   dwType;
    LPCWSTR pszData;
    DWORD   dwData;
};


HRESULT DeleteRegKeyOrValue(REGISTRY_ENTRY *re);
HRESULT CreateRegKeyAndSetValue(REGISTRY_ENTRY *pRegistryEntry);

REGISTRY_ENTRY GetRegEntry(
	HKEY    hkeyRoot,
    LPCWSTR pszKeyName,
    LPCWSTR pszValueName,
    LPCWSTR pszData = NULL,
    DWORD   dwType = REG_SZ,
    DWORD   dwData = 0);
