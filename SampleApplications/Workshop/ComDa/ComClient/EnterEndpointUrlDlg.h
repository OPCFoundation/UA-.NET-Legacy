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
using namespace System::ComponentModel;
using namespace System::Collections;
using namespace System::Windows::Forms;
using namespace System::Data;
using namespace System::Drawing;

namespace Quickstarts { namespace ComDataAccessClient {

	/// <summary>
	/// Summary for EnterEndpointUrlDlg
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class EnterEndpointUrlDlg : public System::Windows::Forms::Form
	{
	public:
		EnterEndpointUrlDlg(void)
		{
			InitializeComponent();
		}

		// Prompts the user to create a COM server proxy for a UA server.
		String^ ShowDialog(String^ endpointUrl, bool% useSecurity);

	private:
		// The ProgID created by the dialog.
		String^ m_progId;

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~EnterEndpointUrlDlg()
		{
			if (components)
			{
				delete components;
			}
		}
    private: System::Windows::Forms::Panel^  ButtonsPN;
    protected: 
    private: System::Windows::Forms::Button^  CancelBTN;
    private: System::Windows::Forms::Button^  OkBTN;
    private: System::Windows::Forms::CheckBox^  UseSecurityCK;
    private: System::Windows::Forms::TextBox^  EndpointUrlTB;
    private: System::Windows::Forms::Label^  EndpointUrlLB;



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
            this->ButtonsPN = (gcnew System::Windows::Forms::Panel());
            this->CancelBTN = (gcnew System::Windows::Forms::Button());
            this->OkBTN = (gcnew System::Windows::Forms::Button());
            this->UseSecurityCK = (gcnew System::Windows::Forms::CheckBox());
            this->EndpointUrlTB = (gcnew System::Windows::Forms::TextBox());
            this->EndpointUrlLB = (gcnew System::Windows::Forms::Label());
            this->ButtonsPN->SuspendLayout();
            this->SuspendLayout();
            // 
            // ButtonsPN
            // 
            this->ButtonsPN->Controls->Add(this->CancelBTN);
            this->ButtonsPN->Controls->Add(this->OkBTN);
            this->ButtonsPN->Controls->Add(this->UseSecurityCK);
            this->ButtonsPN->Dock = System::Windows::Forms::DockStyle::Bottom;
            this->ButtonsPN->Location = System::Drawing::Point(0, 30);
            this->ButtonsPN->Name = L"ButtonsPN";
            this->ButtonsPN->Size = System::Drawing::Size(466, 35);
            this->ButtonsPN->TabIndex = 0;
            // 
            // CancelBTN
            // 
            this->CancelBTN->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Bottom | System::Windows::Forms::AnchorStyles::Right));
            this->CancelBTN->DialogResult = System::Windows::Forms::DialogResult::Cancel;
            this->CancelBTN->Location = System::Drawing::Point(388, 7);
            this->CancelBTN->Name = L"CancelBTN";
            this->CancelBTN->Size = System::Drawing::Size(75, 23);
            this->CancelBTN->TabIndex = 0;
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
            this->OkBTN->Click += gcnew System::EventHandler(this, &EnterEndpointUrlDlg::OkBTN_Click);
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
            // EndpointUrlTB
            // 
            this->EndpointUrlTB->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right));
            this->EndpointUrlTB->Location = System::Drawing::Point(80, 6);
            this->EndpointUrlTB->Name = L"EndpointUrlTB";
            this->EndpointUrlTB->Size = System::Drawing::Size(383, 20);
            this->EndpointUrlTB->TabIndex = 2;
            // 
            // EndpointUrlLB
            // 
            this->EndpointUrlLB->AutoSize = true;
            this->EndpointUrlLB->Location = System::Drawing::Point(0, 9);
            this->EndpointUrlLB->Name = L"EndpointUrlLB";
            this->EndpointUrlLB->Size = System::Drawing::Size(74, 13);
            this->EndpointUrlLB->TabIndex = 1;
            this->EndpointUrlLB->Text = L"Endpoint URL";
            // 
            // EnterEndpointUrlDlg
            // 
            this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
            this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
            this->ClientSize = System::Drawing::Size(466, 65);
            this->Controls->Add(this->EndpointUrlLB);
            this->Controls->Add(this->EndpointUrlTB);
            this->Controls->Add(this->ButtonsPN);
            this->MaximumSize = System::Drawing::Size(1000, 101);
            this->MinimumSize = System::Drawing::Size(400, 101);
            this->Name = L"EnterEndpointUrlDlg";
            this->Text = L"Enter the URL of a UA Server Endpoint";
            this->ButtonsPN->ResumeLayout(false);
            this->ButtonsPN->PerformLayout();
            this->ResumeLayout(false);
            this->PerformLayout();

        }
#pragma endregion
    private: System::Void OkBTN_Click(System::Object^  sender, System::EventArgs^  e);
};
}}
