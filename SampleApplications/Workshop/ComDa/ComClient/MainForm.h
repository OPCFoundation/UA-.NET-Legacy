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
#include "ComDaTester.h"

namespace Quickstarts { namespace ComDataAccessClient {

	using namespace System;
	using namespace System::Collections::Generic;
	using namespace System::ComponentModel;
	using namespace System::Collections;
	using namespace System::Windows::Forms;
	using namespace System::Data;
	using namespace System::Drawing;
	using namespace System::Threading;


	/// <summary>
	/// Summary for MainForm
	///
	/// WARNING: If you change the name of this class, you will need to change the
	///          'Resource File Name' property for the managed resource compiler tool
	///          associated with all .resx files this class depends on.  Otherwise,
	///          the designers will not be able to interact properly with localized
	///          resources associated with this form.
	/// </summary>
	public ref class MainForm : public System::Windows::Forms::Form
	{
	public:
		MainForm(void)
		{
			InitializeComponent();	

			m_tester = gcnew ComDaTester();

			List<String^>^ proxies = ComDaClientUtils::EnumerateComServerOnLocalhost();

			for (int ii = 0; ii < proxies->Count; ii++)
			{
				UrlCB->Items->Add(proxies[ii]);
			}

			if (UrlCB->Items->Count > 0)
			{
				UrlCB->SelectedIndex = 0;
			}
		}
	private: System::Windows::Forms::ToolStripMenuItem^  PerformanceTestMI;
    private: System::Windows::Forms::NumericUpDown^  UpdateRateCTRL;
    private: System::Windows::Forms::Label^  ItemCountLB;
    private: System::Windows::Forms::Label^  UpdateRateLB;
    private: System::Windows::Forms::Label^  TotalItemUpdateRateLB;


    private: System::Windows::Forms::Label^  CallbackRateLB;

    private: System::Windows::Forms::NumericUpDown^  ItemCountCTRL;
    private: System::Windows::Forms::Button^  StopBTN;
    public: 

	public: 

	public: 

	private:
		// The object that runs the tests supported by the client.
		ComDaTester^ m_tester;

		// Stores the arguments required to start the sequence.
		ref class DoSequenceCallData
		{
		public: 
			
			DoSequenceCallData(MainForm^ form, String^ progId)
			{
				Form = form;
				ProgId = progId;
			}

			MainForm^ Form;
			String^ ProgId;
		};

		// Runs the connectivity test in a background thread.
		static System::Void DoConnectivityTest(System::Object^ state) 
		{
			DoSequenceCallData^ calldata = (DoSequenceCallData^)state;

			try
			{
				calldata->Form->m_tester->StartConnectivityTest(calldata->Form, calldata->ProgId);
			}
			catch (Exception^ e)
			{
				calldata->Form->m_tester->ReportMessage(e->Message);
			}
		}

		// Runs the performance test in a background thread.
		static System::Void DoPerformanceTest(System::Object^ state) 
		{
			DoSequenceCallData^ calldata = (DoSequenceCallData^)state;

			try
			{
				calldata->Form->m_tester->StartPerformanceTest(calldata->Form, calldata->ProgId);
			}
			catch (Exception^ e)
			{
				calldata->Form->m_tester->ReportMessage(e->Message);
			}
		}

	protected:
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		~MainForm()
		{
			if (components)
			{
				delete components;
			}
		}
	private: System::Windows::Forms::MenuStrip^  MainMenu;
	private: System::Windows::Forms::ToolStripMenuItem^  ServerMI;
	private: System::Windows::Forms::ToolStripMenuItem^  Server_DiscoverMI;



	private: System::Windows::Forms::Panel^  AddressPN;
	private: System::Windows::Forms::Button^  ConnectBTN;

	private: System::Windows::Forms::ComboBox^  UrlCB;
	private: System::Windows::Forms::ToolStripMenuItem^  Server_ClearOutputMI;
	private: System::Windows::Forms::Label^  ProdIdLB;
	private: System::Windows::Forms::Panel^  MainPN;
    private: System::Windows::Forms::ToolStripMenuItem^  Server_CreateFromUrlMI;
private: System::Windows::Forms::TextBox^  TotalItemUpdateRateTB;



private: System::Windows::Forms::TextBox^  CallbackRateTB;



	private: System::Windows::Forms::RichTextBox^  LogTB;
private: System::Windows::Forms::TextBox^  TotalItemUpdateCountTB;

private: System::Windows::Forms::Label^  TotalItemUpdateCountLB;
private: System::Windows::Forms::TextBox^  CallbackCountTB;


private: System::Windows::Forms::Label^  CallbackCountLB;

private: System::Windows::Forms::Timer^  UpdateTimerCTRL;
private: System::ComponentModel::IContainer^  components;



	protected: 

	private:
		/// <summary>
		/// Required designer variable.
		/// </summary>


#pragma region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		void InitializeComponent(void)
		{
            this->components = (gcnew System::ComponentModel::Container());
            this->MainMenu = (gcnew System::Windows::Forms::MenuStrip());
            this->ServerMI = (gcnew System::Windows::Forms::ToolStripMenuItem());
            this->Server_DiscoverMI = (gcnew System::Windows::Forms::ToolStripMenuItem());
            this->Server_CreateFromUrlMI = (gcnew System::Windows::Forms::ToolStripMenuItem());
            this->Server_ClearOutputMI = (gcnew System::Windows::Forms::ToolStripMenuItem());
            this->PerformanceTestMI = (gcnew System::Windows::Forms::ToolStripMenuItem());
            this->AddressPN = (gcnew System::Windows::Forms::Panel());
            this->StopBTN = (gcnew System::Windows::Forms::Button());
            this->ProdIdLB = (gcnew System::Windows::Forms::Label());
            this->ConnectBTN = (gcnew System::Windows::Forms::Button());
            this->UrlCB = (gcnew System::Windows::Forms::ComboBox());
            this->MainPN = (gcnew System::Windows::Forms::Panel());
            this->TotalItemUpdateRateLB = (gcnew System::Windows::Forms::Label());
            this->CallbackRateLB = (gcnew System::Windows::Forms::Label());
            this->ItemCountCTRL = (gcnew System::Windows::Forms::NumericUpDown());
            this->UpdateRateCTRL = (gcnew System::Windows::Forms::NumericUpDown());
            this->ItemCountLB = (gcnew System::Windows::Forms::Label());
            this->UpdateRateLB = (gcnew System::Windows::Forms::Label());
            this->TotalItemUpdateRateTB = (gcnew System::Windows::Forms::TextBox());
            this->CallbackRateTB = (gcnew System::Windows::Forms::TextBox());
            this->LogTB = (gcnew System::Windows::Forms::RichTextBox());
            this->TotalItemUpdateCountTB = (gcnew System::Windows::Forms::TextBox());
            this->TotalItemUpdateCountLB = (gcnew System::Windows::Forms::Label());
            this->CallbackCountTB = (gcnew System::Windows::Forms::TextBox());
            this->CallbackCountLB = (gcnew System::Windows::Forms::Label());
            this->UpdateTimerCTRL = (gcnew System::Windows::Forms::Timer(this->components));
            this->MainMenu->SuspendLayout();
            this->AddressPN->SuspendLayout();
            this->MainPN->SuspendLayout();
            (cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->ItemCountCTRL))->BeginInit();
            (cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->UpdateRateCTRL))->BeginInit();
            this->SuspendLayout();
            // 
            // MainMenu
            // 
            this->MainMenu->Items->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(1) {this->ServerMI});
            this->MainMenu->Location = System::Drawing::Point(0, 0);
            this->MainMenu->Name = L"MainMenu";
            this->MainMenu->Size = System::Drawing::Size(608, 24);
            this->MainMenu->TabIndex = 1;
            this->MainMenu->Text = L"MainMenu";
            // 
            // ServerMI
            // 
            this->ServerMI->DropDownItems->AddRange(gcnew cli::array< System::Windows::Forms::ToolStripItem^  >(4) {this->Server_DiscoverMI, 
                this->Server_CreateFromUrlMI, this->Server_ClearOutputMI, this->PerformanceTestMI});
            this->ServerMI->Name = L"ServerMI";
            this->ServerMI->Size = System::Drawing::Size(61, 20);
            this->ServerMI->Text = L"Options";
            // 
            // Server_DiscoverMI
            // 
            this->Server_DiscoverMI->Name = L"Server_DiscoverMI";
            this->Server_DiscoverMI->Size = System::Drawing::Size(188, 22);
            this->Server_DiscoverMI->Text = L"Discover UA Servers...";
            this->Server_DiscoverMI->Click += gcnew System::EventHandler(this, &MainForm::Server_DiscoverMI_Click);
            // 
            // Server_CreateFromUrlMI
            // 
            this->Server_CreateFromUrlMI->Name = L"Server_CreateFromUrlMI";
            this->Server_CreateFromUrlMI->Size = System::Drawing::Size(188, 22);
            this->Server_CreateFromUrlMI->Text = L"Enter UA Server URL...";
            this->Server_CreateFromUrlMI->Click += gcnew System::EventHandler(this, &MainForm::Server_CreateFromUrlMI_Click);
            // 
            // Server_ClearOutputMI
            // 
            this->Server_ClearOutputMI->Name = L"Server_ClearOutputMI";
            this->Server_ClearOutputMI->Size = System::Drawing::Size(188, 22);
            this->Server_ClearOutputMI->Text = L"Clear Output";
            this->Server_ClearOutputMI->Click += gcnew System::EventHandler(this, &MainForm::Server_ClearOutputMI_Click);
            // 
            // PerformanceTestMI
            // 
            this->PerformanceTestMI->CheckOnClick = true;
            this->PerformanceTestMI->Name = L"PerformanceTestMI";
            this->PerformanceTestMI->Size = System::Drawing::Size(188, 22);
            this->PerformanceTestMI->Text = L"Performance Test";
            // 
            // AddressPN
            // 
            this->AddressPN->BorderStyle = System::Windows::Forms::BorderStyle::Fixed3D;
            this->AddressPN->Controls->Add(this->StopBTN);
            this->AddressPN->Controls->Add(this->ProdIdLB);
            this->AddressPN->Controls->Add(this->ConnectBTN);
            this->AddressPN->Controls->Add(this->UrlCB);
            this->AddressPN->Dock = System::Windows::Forms::DockStyle::Top;
            this->AddressPN->Location = System::Drawing::Point(0, 24);
            this->AddressPN->Name = L"AddressPN";
            this->AddressPN->Padding = System::Windows::Forms::Padding(3);
            this->AddressPN->Size = System::Drawing::Size(608, 32);
            this->AddressPN->TabIndex = 2;
            // 
            // StopBTN
            // 
            this->StopBTN->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
            this->StopBTN->Location = System::Drawing::Point(526, 3);
            this->StopBTN->Name = L"StopBTN";
            this->StopBTN->Size = System::Drawing::Size(75, 23);
            this->StopBTN->TabIndex = 16;
            this->StopBTN->Text = L"Stop";
            this->StopBTN->UseVisualStyleBackColor = true;
            this->StopBTN->Visible = false;
            this->StopBTN->Click += gcnew System::EventHandler(this, &MainForm::StopBTN_Click);
            // 
            // ProdIdLB
            // 
            this->ProdIdLB->AutoSize = true;
            this->ProdIdLB->Location = System::Drawing::Point(6, 7);
            this->ProdIdLB->Name = L"ProdIdLB";
            this->ProdIdLB->Size = System::Drawing::Size(101, 13);
            this->ProdIdLB->TabIndex = 4;
            this->ProdIdLB->Text = L"COM Server ProgID";
            // 
            // ConnectBTN
            // 
            this->ConnectBTN->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Right));
            this->ConnectBTN->Location = System::Drawing::Point(526, 3);
            this->ConnectBTN->Name = L"ConnectBTN";
            this->ConnectBTN->Size = System::Drawing::Size(75, 23);
            this->ConnectBTN->TabIndex = 3;
            this->ConnectBTN->Text = L"Connect";
            this->ConnectBTN->UseVisualStyleBackColor = true;
            this->ConnectBTN->Click += gcnew System::EventHandler(this, &MainForm::ConnectBTN_Click);
            // 
            // UrlCB
            // 
            this->UrlCB->Anchor = static_cast<System::Windows::Forms::AnchorStyles>(((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right));
            this->UrlCB->FormattingEnabled = true;
            this->UrlCB->Location = System::Drawing::Point(113, 4);
            this->UrlCB->Name = L"UrlCB";
            this->UrlCB->Size = System::Drawing::Size(407, 21);
            this->UrlCB->TabIndex = 1;
            this->UrlCB->DropDown += gcnew System::EventHandler(this, &MainForm::UrlCB_DropDown);
            // 
            // MainPN
            // 
            this->MainPN->Controls->Add(this->TotalItemUpdateRateLB);
            this->MainPN->Controls->Add(this->CallbackRateLB);
            this->MainPN->Controls->Add(this->ItemCountCTRL);
            this->MainPN->Controls->Add(this->UpdateRateCTRL);
            this->MainPN->Controls->Add(this->ItemCountLB);
            this->MainPN->Controls->Add(this->UpdateRateLB);
            this->MainPN->Controls->Add(this->TotalItemUpdateRateTB);
            this->MainPN->Controls->Add(this->CallbackRateTB);
            this->MainPN->Controls->Add(this->LogTB);
            this->MainPN->Controls->Add(this->TotalItemUpdateCountTB);
            this->MainPN->Controls->Add(this->TotalItemUpdateCountLB);
            this->MainPN->Controls->Add(this->CallbackCountTB);
            this->MainPN->Controls->Add(this->CallbackCountLB);
            this->MainPN->Dock = System::Windows::Forms::DockStyle::Fill;
            this->MainPN->Location = System::Drawing::Point(0, 56);
            this->MainPN->Name = L"MainPN";
            this->MainPN->Padding = System::Windows::Forms::Padding(3);
            this->MainPN->Size = System::Drawing::Size(608, 426);
            this->MainPN->TabIndex = 3;
            // 
            // TotalItemUpdateRateLB
            // 
            this->TotalItemUpdateRateLB->AutoSize = true;
            this->TotalItemUpdateRateLB->Location = System::Drawing::Point(380, 34);
            this->TotalItemUpdateRateLB->Name = L"TotalItemUpdateRateLB";
            this->TotalItemUpdateRateLB->Size = System::Drawing::Size(91, 13);
            this->TotalItemUpdateRateLB->TabIndex = 15;
            this->TotalItemUpdateRateLB->Text = L"Item Update Rate";
            // 
            // CallbackRateLB
            // 
            this->CallbackRateLB->AutoSize = true;
            this->CallbackRateLB->Location = System::Drawing::Point(380, 9);
            this->CallbackRateLB->Name = L"CallbackRateLB";
            this->CallbackRateLB->Size = System::Drawing::Size(74, 13);
            this->CallbackRateLB->TabIndex = 14;
            this->CallbackRateLB->Text = L"Callback Rate";
            // 
            // ItemCountCTRL
            // 
            this->ItemCountCTRL->Increment = System::Decimal(gcnew cli::array< System::Int32 >(4) {1000, 0, 0, 0});
            this->ItemCountCTRL->Location = System::Drawing::Point(104, 32);
            this->ItemCountCTRL->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) {100000, 0, 0, 0});
            this->ItemCountCTRL->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) {100, 0, 0, 0});
            this->ItemCountCTRL->Name = L"ItemCountCTRL";
            this->ItemCountCTRL->Size = System::Drawing::Size(58, 20);
            this->ItemCountCTRL->TabIndex = 13;
            this->ItemCountCTRL->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) {1000, 0, 0, 0});
            // 
            // UpdateRateCTRL
            // 
            this->UpdateRateCTRL->Increment = System::Decimal(gcnew cli::array< System::Int32 >(4) {100, 0, 0, 0});
            this->UpdateRateCTRL->Location = System::Drawing::Point(104, 7);
            this->UpdateRateCTRL->Maximum = System::Decimal(gcnew cli::array< System::Int32 >(4) {10000, 0, 0, 0});
            this->UpdateRateCTRL->Minimum = System::Decimal(gcnew cli::array< System::Int32 >(4) {100, 0, 0, 0});
            this->UpdateRateCTRL->Name = L"UpdateRateCTRL";
            this->UpdateRateCTRL->Size = System::Drawing::Size(58, 20);
            this->UpdateRateCTRL->TabIndex = 12;
            this->UpdateRateCTRL->Value = System::Decimal(gcnew cli::array< System::Int32 >(4) {200, 0, 0, 0});
            // 
            // ItemCountLB
            // 
            this->ItemCountLB->AutoSize = true;
            this->ItemCountLB->Location = System::Drawing::Point(8, 34);
            this->ItemCountLB->Name = L"ItemCountLB";
            this->ItemCountLB->Size = System::Drawing::Size(58, 13);
            this->ItemCountLB->TabIndex = 11;
            this->ItemCountLB->Text = L"Item Count";
            // 
            // UpdateRateLB
            // 
            this->UpdateRateLB->AutoSize = true;
            this->UpdateRateLB->Location = System::Drawing::Point(8, 9);
            this->UpdateRateLB->Name = L"UpdateRateLB";
            this->UpdateRateLB->Size = System::Drawing::Size(90, 13);
            this->UpdateRateLB->TabIndex = 10;
            this->UpdateRateLB->Text = L"Update Rate (ms)";
            // 
            // TotalItemUpdateRateTB
            // 
            this->TotalItemUpdateRateTB->Location = System::Drawing::Point(477, 30);
            this->TotalItemUpdateRateTB->Name = L"TotalItemUpdateRateTB";
            this->TotalItemUpdateRateTB->Size = System::Drawing::Size(123, 20);
            this->TotalItemUpdateRateTB->TabIndex = 9;
            // 
            // CallbackRateTB
            // 
            this->CallbackRateTB->Location = System::Drawing::Point(477, 7);
            this->CallbackRateTB->Name = L"CallbackRateTB";
            this->CallbackRateTB->Size = System::Drawing::Size(123, 20);
            this->CallbackRateTB->TabIndex = 6;
            // 
            // LogTB
            // 
            this->LogTB->Anchor = static_cast<System::Windows::Forms::AnchorStyles>((((System::Windows::Forms::AnchorStyles::Top | System::Windows::Forms::AnchorStyles::Bottom) 
                | System::Windows::Forms::AnchorStyles::Left) 
                | System::Windows::Forms::AnchorStyles::Right));
            this->LogTB->Location = System::Drawing::Point(6, 57);
            this->LogTB->Name = L"LogTB";
            this->LogTB->Size = System::Drawing::Size(596, 363);
            this->LogTB->TabIndex = 5;
            this->LogTB->Text = L"";
            // 
            // TotalItemUpdateCountTB
            // 
            this->TotalItemUpdateCountTB->Location = System::Drawing::Point(277, 30);
            this->TotalItemUpdateCountTB->Name = L"TotalItemUpdateCountTB";
            this->TotalItemUpdateCountTB->Size = System::Drawing::Size(85, 20);
            this->TotalItemUpdateCountTB->TabIndex = 4;
            // 
            // TotalItemUpdateCountLB
            // 
            this->TotalItemUpdateCountLB->AutoSize = true;
            this->TotalItemUpdateCountLB->Location = System::Drawing::Point(183, 34);
            this->TotalItemUpdateCountLB->Name = L"TotalItemUpdateCountLB";
            this->TotalItemUpdateCountLB->Size = System::Drawing::Size(96, 13);
            this->TotalItemUpdateCountLB->TabIndex = 3;
            this->TotalItemUpdateCountLB->Text = L"Item Update Count";
            // 
            // CallbackCountTB
            // 
            this->CallbackCountTB->Location = System::Drawing::Point(277, 7);
            this->CallbackCountTB->Name = L"CallbackCountTB";
            this->CallbackCountTB->Size = System::Drawing::Size(85, 20);
            this->CallbackCountTB->TabIndex = 2;
            // 
            // CallbackCountLB
            // 
            this->CallbackCountLB->AutoSize = true;
            this->CallbackCountLB->Location = System::Drawing::Point(183, 11);
            this->CallbackCountLB->Name = L"CallbackCountLB";
            this->CallbackCountLB->Size = System::Drawing::Size(79, 13);
            this->CallbackCountLB->TabIndex = 1;
            this->CallbackCountLB->Text = L"Callback Count";
            // 
            // UpdateTimerCTRL
            // 
            this->UpdateTimerCTRL->Interval = 1000;
            this->UpdateTimerCTRL->Tick += gcnew System::EventHandler(this, &MainForm::UpdateTimerCTRL_Tick);
            // 
            // MainForm
            // 
            this->AutoScaleDimensions = System::Drawing::SizeF(6, 13);
            this->AutoScaleMode = System::Windows::Forms::AutoScaleMode::Font;
            this->ClientSize = System::Drawing::Size(608, 482);
            this->Controls->Add(this->MainPN);
            this->Controls->Add(this->AddressPN);
            this->Controls->Add(this->MainMenu);
            this->MainMenuStrip = this->MainMenu;
            this->Name = L"MainForm";
            this->Text = L"UA COM Data Access Client";
            this->MainMenu->ResumeLayout(false);
            this->MainMenu->PerformLayout();
            this->AddressPN->ResumeLayout(false);
            this->AddressPN->PerformLayout();
            this->MainPN->ResumeLayout(false);
            this->MainPN->PerformLayout();
            (cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->ItemCountCTRL))->EndInit();
            (cli::safe_cast<System::ComponentModel::ISupportInitialize^  >(this->UpdateRateCTRL))->EndInit();
            this->ResumeLayout(false);
            this->PerformLayout();

        }
#pragma endregion

private: System::Void UrlCB_DropDown(System::Object^  sender, System::EventArgs^ e);
private: System::Void ConnectBTN_Click(System::Object^  sender, System::EventArgs^ e) ;
private: System::Void Server_DiscoverMI_Click(System::Object^  sender, System::EventArgs^ e) ;
private: System::Void Server_ClearOutputMI_Click(System::Object^  sender, System::EventArgs^ e);
private: System::Void Server_CreateFromUrlMI_Click(System::Object^  sender, System::EventArgs^ e);
private: System::Void UpdateTimerCTRL_Tick(System::Object^  sender, System::EventArgs^  e);
private: System::Void StopBTN_Click(System::Object^  sender, System::EventArgs^  e);
};
}}
