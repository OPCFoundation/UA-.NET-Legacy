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

namespace Opc.Ua.StackTest
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.FileMI = new System.Windows.Forms.ToolStripMenuItem();
            this.FileLoadMI = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveMI = new System.Windows.Forms.ToolStripMenuItem();
            this.FileSaveAsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.FileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.TestMI = new System.Windows.Forms.ToolStripMenuItem();
            this.TestAllMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_TestSerializersMI = new System.Windows.Forms.ToolStripMenuItem();
            this.TestCancelMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.QuickTestMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_UseNativeStackMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_UseNativeEncodersMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_AlwaysCheckSizesMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TestPerformanceMI = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusStrip = new System.Windows.Forms.StatusStrip();
            this.TestCaseLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.TestCaseTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.TestIdLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.TestIdTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.IterationLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.IterationTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainPN = new System.Windows.Forms.SplitContainer();
            this.SessionsPanel = new System.Windows.Forms.SplitContainer();
            this.TestCasesCTRL = new Opc.Ua.StackTest.TestCasesCtrl();
            this.TestParametersCTRL = new Opc.Ua.StackTest.TestParametersCtrl();
            this.TestEventsCTRL = new Opc.Ua.StackTest.TestEventsCtrl();
            this.EndpointSelectorCTRL = new Opc.Ua.Client.Controls.EndpointSelectorCtrl();
            this.MainMenu.SuspendLayout();
            this.StatusStrip.SuspendLayout();
            this.MainPN.Panel1.SuspendLayout();
            this.MainPN.Panel2.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.SessionsPanel.Panel1.SuspendLayout();
            this.SessionsPanel.Panel2.SuspendLayout();
            this.SessionsPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMI,
            this.TestMI});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(879, 24);
            this.MainMenu.TabIndex = 1;
            this.MainMenu.Text = "MainMenu";
            // 
            // FileMI
            // 
            this.FileMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileLoadMI,
            this.FileSaveMI,
            this.FileSaveAsMI,
            this.toolStripMenuItem1,
            this.FileExit});
            this.FileMI.Name = "FileMI";
            this.FileMI.Size = new System.Drawing.Size(37, 20);
            this.FileMI.Text = "File";
            // 
            // FileLoadMI
            // 
            this.FileLoadMI.Name = "FileLoadMI";
            this.FileLoadMI.Size = new System.Drawing.Size(123, 22);
            this.FileLoadMI.Text = "Load...";
            this.FileLoadMI.Click += new System.EventHandler(this.FileLoadMI_Click);
            // 
            // FileSaveMI
            // 
            this.FileSaveMI.Name = "FileSaveMI";
            this.FileSaveMI.Size = new System.Drawing.Size(123, 22);
            this.FileSaveMI.Text = "Save";
            this.FileSaveMI.Click += new System.EventHandler(this.FileSaveMI_Click);
            // 
            // FileSaveAsMI
            // 
            this.FileSaveAsMI.Name = "FileSaveAsMI";
            this.FileSaveAsMI.Size = new System.Drawing.Size(123, 22);
            this.FileSaveAsMI.Text = "Save As...";
            this.FileSaveAsMI.Click += new System.EventHandler(this.FileSaveAsMI_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(120, 6);
            // 
            // FileExit
            // 
            this.FileExit.Name = "FileExit";
            this.FileExit.Size = new System.Drawing.Size(123, 22);
            this.FileExit.Text = "Exit";
            this.FileExit.Click += new System.EventHandler(this.FileExit_Click);
            // 
            // TestMI
            // 
            this.TestMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestAllMI,
            this.Test_TestSerializersMI,
            this.TestCancelMI,
            this.toolStripSeparator2,
            this.QuickTestMI,
            this.Test_UseNativeStackMI,
            this.Test_UseNativeEncodersMI,
            this.Test_AlwaysCheckSizesMI,
            this.toolStripSeparator1,
            this.TestPerformanceMI});
            this.TestMI.Name = "TestMI";
            this.TestMI.Size = new System.Drawing.Size(41, 20);
            this.TestMI.Text = "Test";
            // 
            // TestAllMI
            // 
            this.TestAllMI.Name = "TestAllMI";
            this.TestAllMI.Size = new System.Drawing.Size(229, 22);
            this.TestAllMI.Text = "Test All";
            this.TestAllMI.Click += new System.EventHandler(this.TestAllMI_Click);
            // 
            // Test_TestSerializersMI
            // 
            this.Test_TestSerializersMI.Name = "Test_TestSerializersMI";
            this.Test_TestSerializersMI.Size = new System.Drawing.Size(229, 22);
            this.Test_TestSerializersMI.Text = "Test Serializers";
            this.Test_TestSerializersMI.Click += new System.EventHandler(this.Test_TestSerializersMI_Click);
            // 
            // TestCancelMI
            // 
            this.TestCancelMI.Name = "TestCancelMI";
            this.TestCancelMI.Size = new System.Drawing.Size(229, 22);
            this.TestCancelMI.Text = "Cancel";
            this.TestCancelMI.Click += new System.EventHandler(this.TestCancelMI_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(226, 6);
            // 
            // QuickTestMI
            // 
            this.QuickTestMI.CheckOnClick = true;
            this.QuickTestMI.Name = "QuickTestMI";
            this.QuickTestMI.Size = new System.Drawing.Size(229, 22);
            this.QuickTestMI.Text = "Quick Test";
            // 
            // Test_UseNativeStackMI
            // 
            this.Test_UseNativeStackMI.CheckOnClick = true;
            this.Test_UseNativeStackMI.Name = "Test_UseNativeStackMI";
            this.Test_UseNativeStackMI.Size = new System.Drawing.Size(229, 22);
            this.Test_UseNativeStackMI.Text = "Use Native (ANSI C) Stack";
            this.Test_UseNativeStackMI.Visible = false;
            // 
            // Test_UseNativeEncodersMI
            // 
            this.Test_UseNativeEncodersMI.Checked = true;
            this.Test_UseNativeEncodersMI.CheckOnClick = true;
            this.Test_UseNativeEncodersMI.CheckState = System.Windows.Forms.CheckState.Checked;
            this.Test_UseNativeEncodersMI.Name = "Test_UseNativeEncodersMI";
            this.Test_UseNativeEncodersMI.Size = new System.Drawing.Size(229, 22);
            this.Test_UseNativeEncodersMI.Text = "Use Native (ANSI C) Encoders";
            this.Test_UseNativeEncodersMI.Click += new System.EventHandler(this.Test_UserNativeEncodersMI_CheckStateChanged);
            // 
            // Test_AlwaysCheckSizesMI
            // 
            this.Test_AlwaysCheckSizesMI.CheckOnClick = true;
            this.Test_AlwaysCheckSizesMI.Name = "Test_AlwaysCheckSizesMI";
            this.Test_AlwaysCheckSizesMI.Size = new System.Drawing.Size(229, 22);
            this.Test_AlwaysCheckSizesMI.Text = "Always Check Sizes";
            this.Test_AlwaysCheckSizesMI.Click += new System.EventHandler(this.Test_AlwaysCheckSizesMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            this.toolStripSeparator1.Visible = false;
            // 
            // TestPerformanceMI
            // 
            this.TestPerformanceMI.Name = "TestPerformanceMI";
            this.TestPerformanceMI.Size = new System.Drawing.Size(229, 22);
            this.TestPerformanceMI.Text = "Performance...";
            this.TestPerformanceMI.Visible = false;
            this.TestPerformanceMI.Click += new System.EventHandler(this.PerformanceTestMI_Click);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestCaseLB,
            this.TestCaseTB,
            this.TestIdLB,
            this.TestIdTB,
            this.IterationLB,
            this.IterationTB});
            this.StatusStrip.Location = new System.Drawing.Point(0, 500);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(879, 22);
            this.StatusStrip.TabIndex = 6;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // TestCaseLB
            // 
            this.TestCaseLB.Name = "TestCaseLB";
            this.TestCaseLB.Size = new System.Drawing.Size(60, 17);
            this.TestCaseLB.Text = "Test Case:";
            // 
            // TestCaseTB
            // 
            this.TestCaseTB.Name = "TestCaseTB";
            this.TestCaseTB.Size = new System.Drawing.Size(36, 17);
            this.TestCaseTB.Text = "None";
            // 
            // TestIdLB
            // 
            this.TestIdLB.Name = "TestIdLB";
            this.TestIdLB.Size = new System.Drawing.Size(46, 17);
            this.TestIdLB.Text = "Test ID:";
            // 
            // TestIdTB
            // 
            this.TestIdTB.Name = "TestIdTB";
            this.TestIdTB.Size = new System.Drawing.Size(12, 17);
            this.TestIdTB.Text = "-";
            // 
            // IterationLB
            // 
            this.IterationLB.Name = "IterationLB";
            this.IterationLB.Size = new System.Drawing.Size(54, 17);
            this.IterationLB.Text = "Iteration:";
            // 
            // IterationTB
            // 
            this.IterationTB.Name = "IterationTB";
            this.IterationTB.Size = new System.Drawing.Size(12, 17);
            this.IterationTB.Text = "-";
            // 
            // MainPN
            // 
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 54);
            this.MainPN.Name = "MainPN";
            this.MainPN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainPN.Panel1
            // 
            this.MainPN.Panel1.Controls.Add(this.SessionsPanel);
            // 
            // MainPN.Panel2
            // 
            this.MainPN.Panel2.Controls.Add(this.TestEventsCTRL);
            this.MainPN.Size = new System.Drawing.Size(879, 446);
            this.MainPN.SplitterDistance = 243;
            this.MainPN.TabIndex = 8;
            // 
            // SessionsPanel
            // 
            this.SessionsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SessionsPanel.Location = new System.Drawing.Point(0, 0);
            this.SessionsPanel.Name = "SessionsPanel";
            // 
            // SessionsPanel.Panel1
            // 
            this.SessionsPanel.Panel1.Controls.Add(this.TestCasesCTRL);
            // 
            // SessionsPanel.Panel2
            // 
            this.SessionsPanel.Panel2.Controls.Add(this.TestParametersCTRL);
            this.SessionsPanel.Size = new System.Drawing.Size(879, 243);
            this.SessionsPanel.SplitterDistance = 357;
            this.SessionsPanel.TabIndex = 5;
            // 
            // TestCasesCTRL
            // 
            this.TestCasesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestCasesCTRL.Instructions = null;
            this.TestCasesCTRL.Location = new System.Drawing.Point(0, 0);
            this.TestCasesCTRL.Name = "TestCasesCTRL";
            this.TestCasesCTRL.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.TestCasesCTRL.ParametersCTRL = this.TestParametersCTRL;
            this.TestCasesCTRL.Size = new System.Drawing.Size(357, 243);
            this.TestCasesCTRL.TabIndex = 0;
            // 
            // TestParametersCTRL
            // 
            this.TestParametersCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestParametersCTRL.Instructions = "Select test case to display results";
            this.TestParametersCTRL.Location = new System.Drawing.Point(0, 0);
            this.TestParametersCTRL.Name = "TestParametersCTRL";
            this.TestParametersCTRL.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.TestParametersCTRL.Size = new System.Drawing.Size(518, 243);
            this.TestParametersCTRL.TabIndex = 0;
            // 
            // TestEventsCTRL
            // 
            this.TestEventsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TestEventsCTRL.Instructions = null;
            this.TestEventsCTRL.Location = new System.Drawing.Point(0, 0);
            this.TestEventsCTRL.Name = "TestEventsCTRL";
            this.TestEventsCTRL.Padding = new System.Windows.Forms.Padding(2, 0, 2, 2);
            this.TestEventsCTRL.Size = new System.Drawing.Size(879, 199);
            this.TestEventsCTRL.TabIndex = 1;
            // 
            // EndpointSelectorCTRL
            // 
            this.EndpointSelectorCTRL.Dock = System.Windows.Forms.DockStyle.Top;
            this.EndpointSelectorCTRL.Location = new System.Drawing.Point(0, 24);
            this.EndpointSelectorCTRL.MaximumSize = new System.Drawing.Size(2048, 30);
            this.EndpointSelectorCTRL.MinimumSize = new System.Drawing.Size(100, 28);
            this.EndpointSelectorCTRL.Name = "EndpointSelectorCTRL";
            this.EndpointSelectorCTRL.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.EndpointSelectorCTRL.SelectedEndpoint = null;
            this.EndpointSelectorCTRL.Size = new System.Drawing.Size(879, 30);
            this.EndpointSelectorCTRL.TabIndex = 2;
            this.EndpointSelectorCTRL.Visible = false;
            this.EndpointSelectorCTRL.EndpointsChanged += new System.EventHandler(this.EndpointSelectorCTRL_OnChange);
            this.EndpointSelectorCTRL.ConnectEndpoint += new Opc.Ua.Client.Controls.ConnectEndpointEventHandler(this.EndpointSelectorCTRL_ConnectEndpoint);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(879, 522);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.EndpointSelectorCTRL);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "UA Test Harness Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.StatusStrip.ResumeLayout(false);
            this.StatusStrip.PerformLayout();
            this.MainPN.Panel1.ResumeLayout(false);
            this.MainPN.Panel2.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.SessionsPanel.Panel1.ResumeLayout(false);
            this.SessionsPanel.Panel2.ResumeLayout(false);
            this.SessionsPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MainMenu;
        private Opc.Ua.Client.Controls.EndpointSelectorCtrl EndpointSelectorCTRL;
        private System.Windows.Forms.SplitContainer SessionsPanel;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.ToolStripStatusLabel TestCaseLB;
        private System.Windows.Forms.SplitContainer MainPN;
        private System.Windows.Forms.ToolStripMenuItem FileMI;
        private System.Windows.Forms.ToolStripMenuItem FileLoadMI;
        private System.Windows.Forms.ToolStripMenuItem FileSaveMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem FileExit;
        private System.Windows.Forms.ToolStripMenuItem FileSaveAsMI;
        private System.Windows.Forms.ToolStripStatusLabel TestCaseTB;
        private TestCasesCtrl TestCasesCTRL;
        private TestParametersCtrl TestParametersCTRL;
        private TestEventsCtrl TestEventsCTRL;
        private System.Windows.Forms.ToolStripStatusLabel TestIdLB;
        private System.Windows.Forms.ToolStripStatusLabel TestIdTB;
        private System.Windows.Forms.ToolStripStatusLabel IterationLB;
        private System.Windows.Forms.ToolStripStatusLabel IterationTB;
        private System.Windows.Forms.ToolStripMenuItem TestMI;
        private System.Windows.Forms.ToolStripMenuItem TestCancelMI;
        private System.Windows.Forms.ToolStripMenuItem TestPerformanceMI;
        private System.Windows.Forms.ToolStripMenuItem TestAllMI;
        private System.Windows.Forms.ToolStripMenuItem QuickTestMI;
        private System.Windows.Forms.ToolStripMenuItem Test_UseNativeStackMI;
        private System.Windows.Forms.ToolStripMenuItem Test_UseNativeEncodersMI;
        private System.Windows.Forms.ToolStripMenuItem Test_AlwaysCheckSizesMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Test_TestSerializersMI;
    }
}
