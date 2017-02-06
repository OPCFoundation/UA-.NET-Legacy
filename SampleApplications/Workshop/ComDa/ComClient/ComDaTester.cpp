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
#include "MainForm.h"
#include "ComDaDataCallback.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Runtime::InteropServices;
using namespace Quickstarts::ComDataAccessClient;

// Constructor
ComDaTester::ComDaTester(void)
{
	m_lock = gcnew Object();
    m_updateRate = 1000;
    m_itemCount = 1000;
}

// GetStatistics
void ComDaTester::GetStatistics(
    int% callbackCount,
    int% totalItemUpdateCount,
    DateTime% firstCallbackTime,
    DateTime% lastCallbackTime,
    int% minItemUpdateCount,
    int% maxItemUpdateCount)
{
    try
    {
		Monitor::Enter(m_lock);

        callbackCount = m_callbackCount;
        totalItemUpdateCount = m_totalItemUpdateCount;
        firstCallbackTime = m_firstCallbackTime;
        lastCallbackTime = m_lastCallbackTime;
        minItemUpdateCount = Int32::MaxValue;
        maxItemUpdateCount = 0;

        if (m_itemUpdateCounts != nullptr)
        {
            for (int ii = 0; ii < m_itemUpdateCounts->Length; ii++)
            {
                if (minItemUpdateCount > m_itemUpdateCounts[ii])
                {
                    minItemUpdateCount = m_itemUpdateCounts[ii];
                }

                if (maxItemUpdateCount < m_itemUpdateCounts[ii])
                {
                    maxItemUpdateCount = m_itemUpdateCounts[ii];
                }
            }
        }

        m_totalItemUpdateCount = 0;
        m_firstCallbackTime = m_lastCallbackTime;
        m_lastCallbackTime = DateTime::MinValue;
        m_itemUpdateCounts = gcnew array<int>(m_itemCount);
    }
    finally
    {
		Monitor::Exit(m_lock);
    }
}

// StartConnectivityTest
void ComDaTester::StartConnectivityTest(MainForm^ form, String^ progId)
{
	HRESULT hResult = S_OK;
	LPWSTR szProgId = (LPWSTR)Marshal::StringToCoTaskMemUni(progId).ToPointer();
	IOPCServer* ipServer = NULL;
	IOPCItemMgt* ipGroup = NULL;
	IConnectionPointContainer* ipCPC = NULL;
	IConnectionPoint* ipCP = NULL;
	ComDaDataCallback* ipCallback = NULL;
	DWORD dwAdvise = NULL;

	try
	{
		m_callbackCount = 0;
		m_totalItemUpdateCount = 0;

		// initialize COM.
		hResult = CoInitializeEx(NULL, COINIT_MULTITHREADED);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not initialize the multi-threaded apartment.", hResult);
		}

		ReportMessage("Multi-threaded COM initialized.");

		// convert the ProgID to a CLSID.
		CLSID tClsid;
		hResult = CLSIDFromProgID((LPOLESTR)szProgId, &tClsid);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not lookup CLSID from ProgID.", hResult);
		}

		ReportMessage("Found CLSID.");

		// need to access the category manager.
		ipServer = (IOPCServer*)ComDaClientUtils::CreateInstance(tClsid, IID_IOPCServer);

		ReportMessage("Connected to server.");

		OPCHANDLE hGroup = NULL;
		DWORD dwRevisedUpdateRate = 0;

		// add group to server.
		hResult = ipServer->AddGroup(
			L"",
			TRUE,
			1000, // 1 second update rate.
			NULL,
			NULL,
			NULL,
			LOCALE_SYSTEM_DEFAULT,
			&hGroup,
			&dwRevisedUpdateRate,
			IID_IOPCItemMgt,
			(IUnknown**)&ipGroup
		);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not create group on server.", hResult);
		}

		ReportMessage("Added group.");

		// set up connection point.
		hResult = ipGroup->QueryInterface(IID_IConnectionPointContainer, (void**)&ipCPC);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not get group's connection point container.", hResult);
		}

		hResult = ipCPC->FindConnectionPoint(IID_IOPCDataCallback, &ipCP);
		
		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not get find the IOPCDataCallback connection point.", hResult);
		}

		ipCPC->Release();
		ipCPC = NULL;

		// create the callback object.
		ipCallback = new ComDaDataCallback(this);

		hResult = ipCP->Advise(ipCallback, &dwAdvise);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not establish a callback.", hResult);
		}

		ReportMessage("Established data callbacks.");

		// add items.
		DWORD          dwCount  = 2;
		OPCITEMDEF*    pItems   = (OPCITEMDEF*)CoTaskMemAlloc(dwCount*sizeof(OPCITEMDEF));
		OPCITEMRESULT* pResults = NULL;
		HRESULT*       pErrors  = NULL;

		memset(pItems, 0, sizeof(OPCITEMDEF)*dwCount);

		pItems[0].szItemID            = L"i*2259"; // "/Server/ServerStatus/State"
		pItems[0].szAccessPath        = NULL;
		pItems[0].bActive             = TRUE;
		pItems[0].hClient             = 1;
		pItems[0].vtRequestedDataType = VT_BSTR;
		pItems[0].dwBlobSize          = 0;
		pItems[0].pBlob               = NULL;

		pItems[1].szItemID            = L"i*2258"; // "/Server/ServerStatus/CurrentTime"
		pItems[1].szAccessPath        = NULL;
		pItems[1].bActive             = TRUE;
		pItems[1].hClient             = 2;
		pItems[1].vtRequestedDataType = VT_BSTR;
		pItems[1].dwBlobSize          = 0;
		pItems[1].pBlob               = NULL;

		// add items to group on server.
		hResult = ipGroup->AddItems(dwCount, pItems, &pResults, &pErrors);

		if (FAILED(hResult))
		{
			CoTaskMemFree(pItems);
			throw gcnew COMException("Could not add items to group.", hResult);
		}

		// check for item level errors.
		if (hResult == S_FALSE)
		{
			for (DWORD ii = 0; ii < dwCount; ii++)
			{
				String^ message = String::Format("AddItem '{0}' failed. Error=0x{1:X8}", Marshal::PtrToStringUni((IntPtr)pItems[ii].szItemID), pErrors[ii]);
				ReportMessage(message);
			}
		}

		ReportMessage("Added items to group.");

		// must always free the blob that the server may return.
		for (DWORD ii = 0; ii < dwCount; ii++)
		{
			if (pResults[ii].dwBlobSize > 0)
			{
				CoTaskMemFree(pResults[ii].pBlob);
			}
		}

		// free other memory.
		CoTaskMemFree(pItems);
		CoTaskMemFree(pResults);
		CoTaskMemFree(pErrors);

		// sleep waiting for callbacks.
		ReportMessage("Waiting for callbacks.");
		Sleep(10000);
		ReportMessage("Waiting finished. Cleaning up.");

		// cleanup.
		ipCP->Unadvise(dwAdvise);
		dwAdvise = 0;

		ipCP->Release();
		ipCP = NULL;

		ipCallback->Release();
		ipCallback = NULL;

		ipGroup->Release();
		ipGroup = NULL;

		ipServer->RemoveGroup(hGroup, FALSE);
		ipServer->Release();
		ipServer = NULL;

		ReportMessage("Sequence completed successfully.");
	}
	catch (Exception^ e)
	{
		ReportMessage(e->Message);
	}
	finally
	{
		CoTaskMemFree(szProgId);

		if (dwAdvise != 0)
		{
			ipCP->Unadvise(dwAdvise);
		}

		if (ipCallback != NULL) ipCallback->Release();
		if (ipCP != NULL) ipCP->Release();
		if (ipCPC != NULL) ipCPC->Release();
		if (ipGroup != NULL) ipGroup->Release();
		if (ipServer != NULL) ipServer->Release();

		// clean up COM
		CoUninitialize();
	}
}

// StartPerformanceTest
void ComDaTester::StartPerformanceTest(MainForm^ form, String^ progId)
{	HRESULT hResult = S_OK;
	LPWSTR szProgId = (LPWSTR)Marshal::StringToCoTaskMemUni(progId).ToPointer();
	IOPCServer* ipServer = NULL;
	IOPCItemMgt* ipGroup = NULL;
	IConnectionPointContainer* ipCPC = NULL;
	IConnectionPoint* ipCP = NULL;
	ComDaDataCallback* ipCallback = NULL;
	DWORD dwAdvise = NULL;

	try
	{
		m_callbackCount = 0;
		m_totalItemUpdateCount = 0;

		// initialize COM.
		hResult = CoInitializeEx(NULL, COINIT_MULTITHREADED);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not initialize the multi-threaded apartment.", hResult);
		}

		ReportMessage("Multi-threaded COM initialized.");

		// convert the ProgID to a CLSID.
		CLSID tClsid;
		hResult = CLSIDFromProgID((LPOLESTR)szProgId, &tClsid);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not lookup CLSID from ProgID.", hResult);
		}

		ReportMessage("Found CLSID.");

		// need to access the category manager.
		ipServer = (IOPCServer*)ComDaClientUtils::CreateInstance(tClsid, IID_IOPCServer);

		ReportMessage("Connected to server.");

		OPCHANDLE hGroup = NULL;
		DWORD dwRevisedUpdateRate = 0;

		// add group to server.
		hResult = ipServer->AddGroup(
			L"",
			TRUE,
			m_updateRate, 
			NULL,
			NULL,
			NULL,
			LOCALE_SYSTEM_DEFAULT,
			&hGroup,
			&dwRevisedUpdateRate,
			IID_IOPCItemMgt,
			(IUnknown**)&ipGroup
		);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not create group on server.", hResult);
		}

		ReportMessage("Added group.");

		// set up connection point.
		hResult = ipGroup->QueryInterface(IID_IConnectionPointContainer, (void**)&ipCPC);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not get group's connection point container.", hResult);
		}

		hResult = ipCPC->FindConnectionPoint(IID_IOPCDataCallback, &ipCP);
		
		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not get find the IOPCDataCallback connection point.", hResult);
		}

		ipCPC->Release();
		ipCPC = NULL;

		// create the callback object.
		ipCallback = new ComDaDataCallback(this);

		hResult = ipCP->Advise(ipCallback, &dwAdvise);

		if (FAILED(hResult))
		{
			throw gcnew COMException("Could not establish a callback.", hResult);
		}

		ReportMessage("Established data callbacks.");

		DateTime startTime = HiResClock::UtcNow;

		// add items.
		DWORD          dwCount  = m_itemCount;
		OPCITEMDEF*    pItems   = (OPCITEMDEF*)CoTaskMemAlloc(dwCount*sizeof(OPCITEMDEF));
		OPCITEMRESULT* pResults = NULL;
		HRESULT*       pErrors  = NULL;

		memset(pItems, 0, sizeof(OPCITEMDEF)*dwCount);

		for (DWORD ii = 0; ii < dwCount; ii++)
		{
			String^ itemId = String::Format("ns*2;i*{0}", (int)((1<<24) + ii));

			pItems[ii].szItemID            = (LPWSTR)Marshal::StringToCoTaskMemUni(itemId).ToPointer();
			pItems[ii].szAccessPath        = NULL;
			pItems[ii].bActive             = TRUE;
			pItems[ii].hClient             = ii;
			pItems[ii].vtRequestedDataType = VT_EMPTY;
			pItems[ii].dwBlobSize          = 0;
			pItems[ii].pBlob               = NULL;
		}

		// add items to group on server.
		hResult = ipGroup->AddItems(dwCount, pItems, &pResults, &pErrors);

		if (FAILED(hResult))
		{
			for (DWORD ii = 0; ii < dwCount; ii++)
			{
				CoTaskMemFree(pItems[ii].szItemID);
			}

			CoTaskMemFree(pItems);
			throw gcnew COMException("Could not add items to group.", hResult);
		}

		DateTime endTime = HiResClock::UtcNow;

		// check for item level errors.
		if (hResult == S_FALSE)
		{
			for (DWORD ii = 0; ii < dwCount; ii++)
			{
				ReportMessage("AddItem '{0}' failed. Error=0x{1:X8}", Marshal::PtrToStringUni((IntPtr)pItems[ii].szItemID), pErrors[ii]);
			}
		}

		ReportMessage("Added items to group. Total Time={0}ms", (endTime - startTime).TotalMilliseconds);

		// must always free the blob that the server may return.
		for (DWORD ii = 0; ii < dwCount; ii++)
		{
			if (pResults[ii].dwBlobSize > 0)
			{
				CoTaskMemFree(pResults[ii].pBlob);
			}
		}

		// free other memory.
		for (DWORD ii = 0; ii < dwCount; ii++)
		{
			CoTaskMemFree(pItems[ii].szItemID);
		}

		CoTaskMemFree(pItems);
		CoTaskMemFree(pResults);
		CoTaskMemFree(pErrors);

		// sleep waiting for callbacks.
		ReportMessage("Waiting for callbacks.");

        // create wait object.
	    try
	    {
		    Monitor::Enter(m_lock);
    		
            if (m_event == nullptr)
            {
                m_event = gcnew ManualResetEvent(false);
            }

            m_event->Reset();
        }
	    finally
	    {
		    Monitor::Exit(m_lock);
	    }

        m_event->WaitOne(Timeout::Infinite, false);

		ReportMessage("Waiting finished. Cleaning up.");

		// cleanup.
		ipCP->Unadvise(dwAdvise);
		dwAdvise = 0;

		ipCP->Release();
		ipCP = NULL;

		ipCallback->Release();
		ipCallback = NULL;

		ipGroup->Release();
		ipGroup = NULL;

		ipServer->RemoveGroup(hGroup, FALSE);
		ipServer->Release();
		ipServer = NULL;

		ReportMessage("Sequence completed successfully.");
	}
	catch (Exception^ e)
	{
		ReportMessage(e->Message);
	}
	finally
	{
		CoTaskMemFree(szProgId);

		if (dwAdvise != 0)
		{
			ipCP->Unadvise(dwAdvise);
		}

		if (ipCallback != NULL) ipCallback->Release();
		if (ipCP != NULL) ipCP->Release();
		if (ipCPC != NULL) ipCPC->Release();
		if (ipGroup != NULL) ipGroup->Release();
		if (ipServer != NULL) ipServer->Release();

		// clean up COM
		CoUninitialize();
	}
}

// ReportMessage
void ComDaTester::ReportMessage(String^ message, ... array<Object^>^ args)
{
	try
	{
		Monitor::Enter(m_lock);
		
		if (m_messages == nullptr)
		{
			m_messages = gcnew List<String^>();
		}

		if (args != nullptr && args->Length > 0)
		{
			m_messages->Add(String::Format(message, args));
		}
		else
		{
			m_messages->Add(message);
		}
	}
	finally
	{
		Monitor::Exit(m_lock);
	}
}

// GetMessages
array<String^>^ ComDaTester::GetMessages()
{
	try
	{
		Monitor::Enter(m_lock);

		array<String^>^ messages = nullptr;
		
		if (m_messages != nullptr)
		{
			messages = m_messages->ToArray();
			m_messages->Clear();
		}

		return messages;
	}
	finally
	{
		Monitor::Exit(m_lock);
	}
}

// handles a data change notification from the server.
void ComDaTester::OnDataChange( 
	DWORD dwCount, 
	OPCHANDLE* phClientItems, 
	VARIANT* pvValues, 
	HRESULT* pErrors)
{
	try
	{
        Monitor::Enter(m_lock);

		if (m_callbackCount == 1)
		{
			m_firstCallbackTime = DateTime::UtcNow;
			m_totalItemUpdateCount = 0;
		}

		m_callbackCount++;
		m_lastCallbackTime = DateTime::UtcNow;

		for (DWORD ii = 0; ii < dwCount; ii++)
		{
			m_totalItemUpdateCount++;

			String^ message = nullptr;

			if (FAILED(pErrors[ii]))
			{
				ReportMessage("DataChange failed. ClientHandle={0}, Error=0x{1:X8}", phClientItems[ii], pErrors[ii]);
				continue;
			}

			if (dwCount <= 2)
			{
				Object^ value = Marshal::GetObjectForNativeVariant((IntPtr)&(pvValues[ii]));
				ReportMessage("DataChange received. ClientHandle={0}, Value={1}", phClientItems[ii], value);
			}

            if (m_itemUpdateCounts != nullptr && (int)phClientItems[ii] < m_itemUpdateCounts->Length)
            {
                m_itemUpdateCounts[phClientItems[ii]]++;
            }
		}

        // ReportMessage("{0}: OnDataChange. {3}, Count={1}/{2}", DateTime::UtcNow.ToString("mm:ss.fff"), dwCount, m_totalItemUpdateCount, (m_lastCallbackTime - m_firstCallbackTime).TotalMilliseconds);
	}
	finally
	{
		Monitor::Exit(m_lock);
	}
}
