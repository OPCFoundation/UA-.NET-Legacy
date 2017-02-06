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
#include "EnterEndpointUrlDlg.h"
#include "ComDaClientUtils.h"

using namespace Opc::Ua;
using namespace Opc::Ua::Configuration;
using namespace Quickstarts::ComDataAccessClient;

// Prompts the user to select a UA server to connect to.
String^ EnterEndpointUrlDlg::ShowDialog(String^ endpointUrl, bool% useSecurity)
{
	UseSecurityCK->Checked = useSecurity = true;

	// initialize the controls.
	EndpointUrlTB->Text = endpointUrl;
	
	// display the dialog.
	if (ShowDialog() != System::Windows::Forms::DialogResult::OK)
	{
		return nullptr;
	}

	return m_progId;
}

// DiscoverBTN_Click
System::Void EnterEndpointUrlDlg::OkBTN_Click(System::Object^  sender, System::EventArgs^  e) 
{
	try
	{
		// get the endpoint url.
		UriBuilder^ endpointUrl = gcnew UriBuilder(EndpointUrlTB->Text);
		bool useSecurity = UseSecurityCK->Checked;

        // assume that the server uses the standard form for discovery urls.
        if (endpointUrl->Scheme != Utils::UriSchemeOpcTcp)
        {
            if (!endpointUrl->Path->EndsWith("/discovery"))
            {
                endpointUrl->Path += "/discovery";
            }
        }

		// create the prog id.
        m_progId = ComDaClientUtils::CreateComServerForApplication(endpointUrl->ToString(), useSecurity);
	}
	catch (Exception^ e)
	{
		MessageBox::Show(e->Message);
	}
}
