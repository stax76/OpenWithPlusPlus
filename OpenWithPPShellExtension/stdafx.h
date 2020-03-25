
#pragma once

#ifndef STRICT
#define STRICT
#endif

#define _ATL_APARTMENT_THREADED
#define _ATL_NO_AUTOMATIC_NAMESPACE

#define _ATL_CSTRING_EXPLICIT_CONSTRUCTORS

#include <atlbase.h>
#include <atlcom.h>

using namespace ATL;

#include <shlobj.h>
#include <shlwapi.h>

#define PRODUCT_NAME L"OpenWithPP"
