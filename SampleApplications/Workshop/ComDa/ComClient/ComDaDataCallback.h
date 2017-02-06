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

#pragma once

using namespace System;
using namespace System::Runtime::InteropServices;

namespace Quickstarts { namespace ComDataAccessClient {

ref class ComDaTester;

class ComDaDataCallback : public IOPCDataCallback
{
public:

	// Initializes the object.
	ComDaDataCallback(ComDaTester^ tester);

	// Cleans up.
	~ComDaDataCallback();

	//==========================================================================
    // IUnknown

	// QueryInterface
	STDMETHODIMP QueryInterface(REFIID iid, LPVOID* ppInterface);

	// AddRef
	STDMETHODIMP_(ULONG) AddRef();

	// Release
	STDMETHODIMP_(ULONG) Release();

	//==========================================================================
    // IOPCDataCallback

    // OnDataChange
    STDMETHODIMP OnDataChange(
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
    );

    // OnReadComplete
    STDMETHODIMP OnReadComplete(
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
    );

    // OnWriteComplete
    STDMETHODIMP OnWriteComplete(
        DWORD       dwTransid, 
        OPCHANDLE   hGroup, 
        HRESULT     hrMastererr, 
        DWORD       dwCount, 
        OPCHANDLE * pClienthandles, 
        HRESULT   * pErrors
    );

    // OnCancelComplete
    STDMETHODIMP OnCancelComplete(
        DWORD       dwTransid, 
        OPCHANDLE   hGroup);

private:

	ULONG m_ulRefs;
	GCHandle m_hTester;
};

}}
