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
#include "MainForm.h"
#include "CreateServerDlg.h"
#include "EnterEndpointUrlDlg.h"
#include "ComDaClientUtils.h"

using namespace Opc::Ua;
using namespace Opc::Ua::Configuration;
using namespace Quickstarts::ComDataAccessClient;

// UrlCB_DropDown
System::Void MainForm::UrlCB_DropDown(System::Object^  sender, System::EventArgs^  e) 
{
	// refresh the contents of the list.
	try
	{
		Cursor = Cursors::WaitCursor;

		UrlCB->Items->Clear();

		List<String^>^ proxies = ComDaClientUtils::EnumerateComServerOnLocalhost();

		for (int ii = 0; ii < proxies->Count; ii++)
		{
			UrlCB->Items->Add(proxies[ii]);
		}
	}
	catch (Exception^ e)
	{
		LogTB->AppendText(e->Message);
	}
	finally
	{
		Cursor = Cursors::Default;
	}
}

// ConnectBTN_Click
System::Void MainForm::ConnectBTN_Click(System::Object^  sender, System::EventArgs^  e) 
{
	try
	{
		UpdateTimerCTRL->Enabled = true;
        StopBTN->Visible = true;
		LogTB->Clear();

		String^ progId = UrlCB->Text;

		if (UrlCB->SelectedIndex != -1)
		{
			progId = (String^)UrlCB->SelectedItem;
		}

        m_tester->UpdateRate = (int)UpdateRateCTRL->Value;
        m_tester->ItemCount = (int)ItemCountCTRL->Value;

		WaitCallback^ callback = nullptr;

		if (PerformanceTestMI->Checked)
		{		
			LogTB->AppendText("Starting COM server performance test.\r\n");
			callback = gcnew WaitCallback(&Quickstarts::ComDataAccessClient::MainForm::DoPerformanceTest);
		}
		else
		{		
			LogTB->AppendText("Starting COM server connectivity test.\r\n");
			callback = gcnew WaitCallback(&Quickstarts::ComDataAccessClient::MainForm::DoConnectivityTest);
		}

		ThreadPool::QueueUserWorkItem(callback, gcnew DoSequenceCallData(this, progId));
	}
	catch (Exception^ e)
	{
		LogTB->AppendText(e->Message + "\r\n");
	}
}

// Server_DiscoverMI_Click
System::Void MainForm::Server_DiscoverMI_Click(System::Object^  sender, System::EventArgs^  e) 
{
	try
	{
		// prompt user to select create a new COM server for a UA server.
		CreateServerDlg^ dialog = gcnew CreateServerDlg();

		bool useSecurity = true;
		String^ progId = dialog->ShowDialog("localhost", useSecurity);

		// add selection to drop down.
		if (progId != nullptr)
		{
			UrlCB->SelectedIndex = UrlCB->Items->Add(progId);
		}
	}
	catch (Exception^ e)
	{
		MessageBox::Show(e->Message);
	}
}

// Server_CreateFromUrlMI_Click
System::Void MainForm::Server_CreateFromUrlMI_Click(System::Object^  sender, System::EventArgs^  e) 
{
	try
	{
		// prompt user to select create a new COM server for a UA server.
		EnterEndpointUrlDlg^ dialog = gcnew EnterEndpointUrlDlg();

		bool useSecurity = true;
		String^ progId = dialog->ShowDialog("", useSecurity);

		// add selection to drop down.
		if (progId != nullptr)
		{
			UrlCB->SelectedIndex = UrlCB->Items->Add(progId);
		}
	}
	catch (Exception^ e)
	{
		MessageBox::Show(e->Message);
	}
}

// Server_ClearOutputMI_Click
System::Void MainForm::Server_ClearOutputMI_Click(System::Object^  sender, System::EventArgs^  e)
{
	 LogTB->Clear();
}

System::Void MainForm::StopBTN_Click(System::Object^  sender, System::EventArgs^  e)
{
	try
	{
        this->m_tester->StopTest();
		UpdateTimerCTRL->Enabled = false;
        StopBTN->Visible = false;
	}
	catch (Exception^ e)
	{
		MessageBox::Show(e->Message);
	}
}

// UpdateTimerCTRL_Tick
System::Void MainForm::UpdateTimerCTRL_Tick(System::Object^  sender, System::EventArgs^  e)
{
	try
	{
        int callbackCount = 0;
        int totalItemUpdateCount = 0;
        DateTime firstCallbackTime = DateTime::MinValue;
        DateTime lastCallbackTime = DateTime::MinValue;
        int minItemUpdateCount = 0;
        int maxItemUpdateCount = 0;

        this->m_tester->GetStatistics(
            callbackCount,
            totalItemUpdateCount,
            firstCallbackTime,
            lastCallbackTime,
            minItemUpdateCount,
            maxItemUpdateCount);

		array<String^>^ messages = m_tester->GetMessages();

		for (int ii = 0; ii < messages->Length; ii++)
		{
			this->LogTB->AppendText(messages[ii]);
			this->LogTB->AppendText(Environment::NewLine);
		}

        CallbackCountTB->Text = String::Format("{0}", callbackCount);
		TotalItemUpdateCountTB->Text = String::Format("{0}", totalItemUpdateCount);

	    TimeSpan delta = (lastCallbackTime - firstCallbackTime);

        if (delta.TotalMilliseconds > 0)
        {
            this->LogTB->AppendText(Utils::Format("{0}: Checking Update Counts. Min={1}, Max={2}", DateTime::UtcNow.ToString("mm:ss.fff"), minItemUpdateCount, maxItemUpdateCount));
            this->LogTB->AppendText(Environment::NewLine);

	        CallbackRateTB->Text = String::Format("{0}", delta.TotalSeconds); 
	        TotalItemUpdateRateTB->Text = String::Format("{0}", ((double)totalItemUpdateCount)/delta.TotalSeconds); 
        }
        else
        {	
            CallbackRateTB->Text = String::Empty;
            TotalItemUpdateRateTB->Text = String::Empty;
        }
	}
	catch (Exception^ e)
	{
		MessageBox::Show(e->Message);
	}
}
