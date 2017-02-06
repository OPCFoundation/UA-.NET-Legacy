/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

#include "StdAfx.h"
#include "ComDaTester.h"
#include "ComDaDataCallback.h"

using namespace System;
using namespace System::Runtime::InteropServices;
using namespace Quickstarts::ComDataAccessClient;

//==========================================================================
// ComDaDataCallback

ComDaDataCallback::ComDaDataCallback(ComDaTester^ tester)
{
	m_ulRefs = 1;
	m_hTester = GCHandle::Alloc(tester);
}

ComDaDataCallback::~ComDaDataCallback()
{
	if (m_hTester.IsAllocated)
	{
		m_hTester.Free();
	}
}

//==========================================================================
// IUnknown

// QueryInterface
HRESULT ComDaDataCallback::QueryInterface(REFIID iid, LPVOID* ppInterface) 
{
	if (ppInterface == NULL)
	{
		return E_INVALIDARG;
	}

	if (iid == IID_IUnknown)
	{
		*ppInterface = dynamic_cast<IUnknown*>(this);
		AddRef();
		return S_OK;
	}

	if (iid == IID_IOPCDataCallback)
	{
		*ppInterface = dynamic_cast<IOPCDataCallback*>(this);
		AddRef();
		return S_OK;
	}

	return E_NOINTERFACE;
}

// AddRef
ULONG ComDaDataCallback::AddRef()
{
    return InterlockedIncrement((LONG*)&m_ulRefs); 
}

// Release
ULONG ComDaDataCallback::Release()
{
    ULONG ulRefs = InterlockedDecrement((LONG*)&m_ulRefs); 

    if (ulRefs == 0) 
    { 
        delete this; 
        return 0; 
    } 

    return ulRefs; 
}

//==========================================================================
// IOPCDataCallback

// OnDataChange
HRESULT ComDaDataCallback::OnDataChange(
    DWORD       dwTransid, 
    OPCHANDLE   hGroup, 
    HRESULT     hrMasterquality,
    HRESULT     hrMastererror,
    DWORD       dwCount, 
    OPCHANDLE * phClientItems, 
    VARIANT   * pvValues, 
    WORD      * pwQualities,
	::FILETIME  * pftTimeStamps,
    HRESULT   * pErrors
)
{
	ComDaTester^ tester = (ComDaTester^)m_hTester.Target;

	try
	{
		tester->OnDataChange(
			dwCount, 
			phClientItems, 
			pvValues, 
			pErrors);
	}
	catch (Exception^ e)
	{
		tester->ReportMessage(e->Message);
	}
	
	return S_OK;
}

// OnReadComplete
HRESULT ComDaDataCallback::OnReadComplete(
    DWORD       dwTransid, 
    OPCHANDLE   hGroup, 
    HRESULT     hrMasterquality,
    HRESULT     hrMastererror,
    DWORD       dwCount, 
    OPCHANDLE * phClientItems, 
    VARIANT   * pvValues, 
    WORD      * pwQualities,
    ::FILETIME  * pftTimeStamps,
    HRESULT   * pErrors
)
{
	return S_OK;
}

// OnWriteComplete
HRESULT ComDaDataCallback::OnWriteComplete(
    DWORD       dwTransid, 
    OPCHANDLE   hGroup, 
    HRESULT     hrMastererr, 
    DWORD       dwCount, 
    OPCHANDLE * pClienthandles, 
    HRESULT   * pErrors
)
{
	return S_OK;
}

// OnCancelComplete
HRESULT ComDaDataCallback::OnCancelComplete(
    DWORD       dwTransid, 
    OPCHANDLE   hGroup
)
{
	return S_OK;
}
