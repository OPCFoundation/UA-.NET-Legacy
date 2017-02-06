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

#include "ComDaClientUtils.h"

using namespace System;
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;

namespace Quickstarts { namespace ComDataAccessClient {

	/// <summary>
	/// Summary for CreateServerDlg
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class CreateServerDlg : public System::Windows::Forms::Form
	{
	public:
		CreateServerDlg(void)
		{
			InitializeComponent();
		}

		// Prompts the user to create a COM server proxy for a UA server.
		String^ ShowDialog(String^ hostname, bool% useSecurity);

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~CreateServerDlg()
		{
			if (components)
			{
				delete components;
			}
		}

	private:
		// The ProgID created by the dialog.
		String^ m_progId;

	private: System::Windows::Forms::Panel^  AddressPN;
	private: System::Windows::Forms::Button^  DiscoverBTN;
	private: System::Windows::Forms::ComboBox^  HostCB;
	protected: 


	private: System::Windows::Forms::CheckBox^  UseSecurityCK;
	private: System::Windows::Forms::Panel^  ButtonsPN;
	private: System::Windows::Forms::Button^  CancelBTN;
	private: System::Windows::Forms::Button^  OkBTN;
	private: System::Windows::Forms::ListView^  ServersLV;

	private: System::Windows::Forms::ColumnHeader^  NameCH;
	private: System::Windows::Forms::ColumnHeader^  UrlCH;
	private: System::Windows::Forms::Label^  HostsLB;
	private: System::Windows::Forms::Panel^  MainPN;



	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>
		System::ComponentModel::Container ^components;

#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
			this->AddressPN = (gcnew System::Windows::Forms::Panel());
			this->HostsLB = (gcnew System::Windows::Forms::Label());
			this->DiscoverBTN = (gcnew System::Windows::Forms::Button());
			this->HostCB = (gcnew System::Windows::Forms::ComboBox());
			this->UseSecurityCK = (gcnew System::Windows::Forms::CheckBox());
			this->ButtonsPN = (gcnew System::Windows::Forms::Panel());
			this->CancelBTN = (gcnew System::Windows::Forms::Button());
			this->OkBTN = (gcnew System::Windows::Forms::Button());
			this->ServersLV = (gcnew System::Windows::Forms::ListView());
			this->UrlCH = (gcnew System::Windows::Forms::ColumnHeader());
			this->NameCH = (gcnew System::Windows::Forms::ColumnHeader());
			this->MainPN = (gcnew System::Windows::Forms::Panel());
			this->AddressPN->SuspendLayout();
			this->ButtonsPN->SuspendLayout();
			this->MainPN->SuspendLayout();
			this->SuspendLayout();
			// 
			// AddressPN
			// 
			this->AddressPN->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
			this->AddressPN->Controls->Add(this->HostsLB);
			this->AddressPN->Controls->Add(this->DiscoverBTN);
			this->AddressPN->Controls->Add(this->HostCB);
			this->AddressPN->Dock = System::Windows::Forms::DockStyle::Top;
			this->AddressPN->Location = System::Drawing::Point(0, 0);
			this->AddressPN->Name = L"AddressPN";
			this->AddressPN->Padding = System::Windows::Forms::Padding(3);
			this->AddressPN->Size = System::Drawing::Size(731, 32);
			this->AddressPN->TabIndex = 2;
			// 
			// HostsLB
			// 
			this->HostsLB->AutoSize = true;
			this->HostsLB->Location = System::Drawing::Point(6, 8);
			this->HostsLB->Name = L"HostsLB";
			this->HostsLB->Size = System::Drawing::Size(83, 13);
			this->HostsLB->TabIndex = 4;
			this->HostsLB->Text = L"Computer Name";
			// 
			// DiscoverBTN
			// 
			this->DiscoverBTN->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
			this->DiscoverBTN->Location = System::Drawing::Point(649, 3);
			this->DiscoverBTN->Name = L"DiscoverBTN";
			this->DiscoverBTN->Size = System::Drawing::Size(75, 23);
			this->DiscoverBTN->TabIndex = 3;
			this->DiscoverBTN->Text = L"Discover";
			this->DiscoverBTN->UseVisualStyleBackColor = true;
			this->DiscoverBTN->Click += gcnew System::EventHandler(this, &CreateServerDlg::DiscoverBTN_Click);
			// 
			// HostCB
			// 
			this->HostCB->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
				| System::Windows::Forms::AnchorStyles::Right));
			this->HostCB->FormattingEnabled = true;
			this->HostCB->Location = System::Drawing::Point(95, 4);
			this->HostCB->Name = L"HostCB";
			this->HostCB->Size = System::Drawing::Size(548, 21);
			this->HostCB->TabIndex = 1;
			this->HostCB->Text = L"localhost";
			// 
			// UseSecurityCK
			// 
			this->UseSecurityCK->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->UseSecurityCK->AutoSize = true;
			this->UseSecurityCK->Checked = true;
			this->UseSecurityCK->CheckState = System::Windows::Forms::CheckState::Checked;
			this->UseSecurityCK->Location = System::Drawing::Point(84, 11);
			this->UseSecurityCK->Name = L"UseSecurityCK";
			this->UseSecurityCK->Size = System::Drawing::Size(86, 17);
			this->UseSecurityCK->TabIndex = 2;
			this->UseSecurityCK->Text = L"Use Security";
			this->UseSecurityCK->UseVisualStyleBackColor = true;
			// 
			// ButtonsPN
			// 
			this->ButtonsPN->Controls->Add(this->CancelBTN);
			this->ButtonsPN->Controls->Add(this->OkBTN);
			this->ButtonsPN->Controls->Add(this->UseSecurityCK);
			this->ButtonsPN->Dock = System::Windows::Forms::DockStyle::Bottom;
			this->ButtonsPN->Location = System::Drawing::Point(0, 451);
			this->ButtonsPN->Name = L"ButtonsPN";
			this->ButtonsPN->Size = System::Drawing::Size(731, 35);
			this->ButtonsPN->TabIndex = 3;
			// 
			// CancelBTN
			// 
			this->CancelBTN->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
			this->CancelBTN->DialogResult = System::Windows::Forms::DialogResult::Cancel;
			this->CancelBTN->Location = System::Drawing::Point(653, 7);
			this->CancelBTN->Name = L"CancelBTN";
			this->CancelBTN->Size = System::Drawing::Size(75, 23);
			this->CancelBTN->TabIndex = 1;
			this->CancelBTN->Text = L"Cancel";
			this->CancelBTN->UseVisualStyleBackColor = true;
			// 
			// OkBTN
			// 
			this->OkBTN->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Left));
			this->OkBTN->DialogResult = System::Windows::Forms::DialogResult::OK;
			this->OkBTN->Location = System::Drawing::Point(3, 7);
			this->OkBTN->Name = L"OkBTN";
			this->OkBTN->Size = System::Drawing::Size(75, 23);
			this->OkBTN->TabIndex = 0;
			this->OkBTN->Text = L"OK";
			this->OkBTN->UseVisualStyleBackColor = true;
			this->OkBTN->Click += gcnew System::EventHandler(this, &CreateServerDlg::OkBTN_Click);
			// 
			// ServersLV
			// 
			this->ServersLV->Columns->AddRange(gcnew cli::array< System::Windows::Forms::ColumnHeader^  >(2) {this->UrlCH, this->NameCH});
			this->ServersLV->Dock = System::Windows::Forms::DockStyle::Fill;
			this->ServersLV->FullRowSelect = true;
			this->ServersLV->Location = System::Drawing::Point(3, 3);
			this->ServersLV->MultiSelect = false;
			this->ServersLV->Name = L"ServersLV";
			this->ServersLV->Size = System::Drawing::Size(725, 413);
			this->ServersLV->TabIndex = 4;
			this->ServersLV->UseCompatibleStateImageBehavior = false;
			this->ServersLV->View = System::Windows::Forms::View::Details;
			// 
			// UrlCH
			// 
			this->UrlCH->DisplayIndex = 1;
			this->UrlCH->Text = L"Discovery URL";
			this->UrlCH->Width = 394;
			// 
			// NameCH
			// 
			this->NameCH->DisplayIndex = 0;
			this->NameCH->Text = L"Application Name";
			this->NameCH->Width = 172;
			// 
			// MainPN
			// 
			this->MainPN->Controls->Add(this->ServersLV);
			this->MainPN->Dock = System::Windows::Forms::DockStyle::Fill;
			this->MainPN->Location = System::Drawing::Point(0, 32);
			this->MainPN->Name = L"MainPN";
			this->MainPN->Padding = System::Windows::Forms::Padding(3);
			this->MainPN->Size = System::Drawing::Size(731, 419);
			this->MainPN->TabIndex = 5;
			// 
			// CreateServerDlg
			// 
			this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
			this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
			this->ClientSize = System::Drawing::Size(731, 486);
			this->Controls->Add(this->MainPN);
			this->Controls->Add(this->ButtonsPN);
			this->Controls->Add(this->AddressPN);
			this->Name = L"CreateServerDlg";
			this->Text = L"Select a UA Server to Connect to via COM";
			this->AddressPN->ResumeLayout(false);
			this->AddressPN->PerformLayout();
			this->ButtonsPN->ResumeLayout(false);
			this->ButtonsPN->PerformLayout();
			this->MainPN->ResumeLayout(false);
			this->ResumeLayout(false);

		}
#pragma endregion

private: System::Void DiscoverBTN_Click(System::Object^  sender, System::EventArgs^  e);
private: System::Void OkBTN_Click(System::Object^  sender, System::EventArgs^  e);
};
}}
