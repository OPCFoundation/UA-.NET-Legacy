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

#include "ComDaDataCallback.h"

using namespace System;
using namespace System::Collections::Generic;
using namespace System::Threading;
using namespace Opc::Ua;

namespace Quickstarts { namespace ComDataAccessClient {

ref class MainForm;

ref class ComDaTester
{
public:
		// Initializes the object.
		ComDaTester(void);
	
		// gets or sets the update rate.
        property int UpdateRate
        {
            int get() { return m_updateRate; }
            void set(int value) { m_updateRate = value; }
        }
	
		// gets or sets the item count.
        property int ItemCount
        {
            int get() { return m_itemCount; }
            void set(int value) { m_itemCount = value; }
        }

		// returns the number of callbacks that have arrived.
        property int CallbackCount
        {
            int get() { return m_callbackCount; }
        }

		// returns the total number of item updates that have arrived.
        property int TotalItemUpdateCount
        {
            int get() { return m_totalItemUpdateCount; }
        }

		// returns the time of the first callback.
        property DateTime FirstCallbackTime
        {
            DateTime get() { return m_firstCallbackTime; }
        }

		// returns the time of the last callback.
        property DateTime LastCallbackTime
        {
            DateTime get() { return m_lastCallbackTime; }
        }

        // Gets the statistic collected since the last update.
        void GetStatistics(
            int% callbackCount,
            int% totalItemUpdateCount,
            DateTime% firstCallbackTime,
            DateTime% lastCallbackTime,
            int% minItemUpdateCount,
            int% maxItemUpdateCount);

		// starts the connectivity against the server an reports the results to the form.
        void StartConnectivityTest(MainForm^ form, String^ progId);

		// starts the performance test against the server an reports the results to the form.
        void StartPerformanceTest(MainForm^ form, String^ progId);

        // stops the test.
        void StopTest()
        {
            try
            {
                Monitor::Enter(m_lock);

                if (m_event != nullptr)
                {
                    m_event->Set();
                }
            }
            finally
            {
                Monitor::Exit(m_lock);
            }
        }

		// reports a message for the test.
		void ReportMessage(String^ message, ... array<Object^>^ args);

		// returns the messages that have been reported since the last time GetMessages() was called.
		array<String^>^ GetMessages();

		// handles a data change notification from the server.
		void OnDataChange( 
			DWORD dwCount, 
			OPCHANDLE* phClientItems, 
			VARIANT* pvValues, 
			HRESULT* pErrors);

private:
	
        Object^ m_lock;
        List<String^>^ m_messages;
        int m_updateRate;
        int m_itemCount;
        int m_callbackCount;
		int m_totalItemUpdateCount;
        DateTime m_firstCallbackTime;
        DateTime m_lastCallbackTime;
        array<int>^ m_itemUpdateCounts;
		ComDaDataCallback* m_ipCallback;
        ManualResetEvent^ m_event;
};

}}
