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
#include "CreateServerDlg.h"

using namespace Opc::Ua;
using namespace Opc::Ua::Configuration;
using namespace Quickstarts::ComDataAccessClient;

// Prompts the user to select a UA server to connect to.
String^ CreateServerDlg::ShowDialog(String^ hostname, bool% useSecurity)
{
	UseSecurityCK->Checked = useSecurity = true;

	// initialize the controls.
	HostCB->Text = hostname;
	DiscoverBTN_Click(this, nullptr); 
	
	// display the dialog.
	if (ShowDialog() != System::Windows::Forms::DialogResult::OK)
	{
		return nullptr;
	}

	return m_progId;
}

// DiscoverBTN_Click
System::Void CreateServerDlg::DiscoverBTN_Click(System::Object^  sender, System::EventArgs^  e) 
{
	try
	{
		// get the host name.
		String^ hostname = HostCB->Text;

		if (HostCB->SelectedIndex != -1)
		{
			hostname = (String^)HostCB->SelectedItem;
		}

		// fetch the descriptions.
		List<ApplicationDescription^>^ servers = ComDaClientUtils::EnumerateUaServersOnHost(hostname);

		// update the list view.
		ServersLV->Items->Clear();

		for (int ii = 0; ii < servers->Count; ii++)
		{
			for (int jj = 0; jj < servers[ii]->DiscoveryUrls->Count; jj++)
			{
				ListViewItem^ item = gcnew ListViewItem(servers[ii]->DiscoveryUrls[jj]);
				item->SubItems->Add(servers[ii]->ApplicationName->Text);
				ServersLV->Items->Add(item);
			}
		}

		// resize the columns.
		for (int ii = 0; ii < ServersLV->Columns->Count; ii++)
		{
			ServersLV->Columns[ii]->Width = -2;
		}
	}
	catch (Exception^ e)
	{
		MessageBox::Show(e->Message);
	}
}

System::Void CreateServerDlg::OkBTN_Click(System::Object^  sender, System::EventArgs^  e)
 {
	try
	{
		if (ServersLV->SelectedItems->Count == 0)
		{
			return;
		}

		String^ url = ServersLV->SelectedItems[0]->Text;
		bool useSecurity = UseSecurityCK->Checked;

		// register a new prog id for the server.
		m_progId = ComDaClientUtils::CreateComServerForApplication(url, useSecurity);

		DialogResult = System::Windows::Forms::DialogResult::OK;
	}
	catch (Exception^ e)
	{
		MessageBox::Show(e->Message);
	}
 }
