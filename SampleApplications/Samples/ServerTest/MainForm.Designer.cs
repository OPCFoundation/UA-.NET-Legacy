/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
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

namespace Opc.Ua.ServerTest
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
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.FileMI = new System.Windows.Forms.ToolStripMenuItem();
            this.File_LoadMI = new System.Windows.Forms.ToolStripMenuItem();
            this.File_SaveMI = new System.Windows.Forms.ToolStripMenuItem();
            this.File_RecentFilesMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.File_Separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.File_ExitMI = new System.Windows.Forms.ToolStripMenuItem();
            this.TestMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_BrowseRootsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_BrowseWriteableMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.Test_NoDisplayUpdateMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_ContinuousMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Test_UseNativeStackMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_UseNativeEncodersMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Test_AlwaysCheckSizesMI = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.TestCaseLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.TestCaseTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.IterationLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.IterationTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.EndpointLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.EndpointTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.TestCaseProgressCTRL = new System.Windows.Forms.ToolStripProgressBar();
            this.StopBTN = new System.Windows.Forms.ToolStripStatusLabel();
            this.TestsCompletedLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.TestsCompletedTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.TopPN = new System.Windows.Forms.Panel();
            this.EndpointsCTRL = new Opc.Ua.Client.Controls.EndpointSelectorCtrl();
            this.ResultsTB = new System.Windows.Forms.RichTextBox();
            this.MainPN = new System.Windows.Forms.Panel();
            this.TestCasesCTRL = new Opc.Ua.ServerTest.TestCaseTreeCtrl();
            this.CheckNodeIdMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.MenuBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileMI,
            this.TestMI});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(1234, 24);
            this.MenuBar.TabIndex = 0;
            this.MenuBar.Text = "menuStrip1";
            // 
            // FileMI
            // 
            this.FileMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.File_LoadMI,
            this.File_SaveMI,
            this.File_RecentFilesMI,
            this.File_Separator1,
            this.File_ExitMI});
            this.FileMI.Name = "FileMI";
            this.FileMI.Size = new System.Drawing.Size(37, 20);
            this.FileMI.Text = "File";
            // 
            // File_LoadMI
            // 
            this.File_LoadMI.Name = "File_LoadMI";
            this.File_LoadMI.Size = new System.Drawing.Size(152, 22);
            this.File_LoadMI.Text = "Load...";
            this.File_LoadMI.Click += new System.EventHandler(this.File_LoadMI_Click);
            // 
            // File_SaveMI
            // 
            this.File_SaveMI.Name = "File_SaveMI";
            this.File_SaveMI.Size = new System.Drawing.Size(152, 22);
            this.File_SaveMI.Text = "Save...";
            this.File_SaveMI.Click += new System.EventHandler(this.File_SaveMI_Click);
            // 
            // File_RecentFilesMI
            // 
            this.File_RecentFilesMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.File_RecentFilesMI.Name = "File_RecentFilesMI";
            this.File_RecentFilesMI.Size = new System.Drawing.Size(152, 22);
            this.File_RecentFilesMI.Text = "Recent Files";
            this.File_RecentFilesMI.MouseEnter += new System.EventHandler(this.File_RecentFilesMI_MouseEnter);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(57, 6);
            // 
            // File_Separator1
            // 
            this.File_Separator1.Name = "File_Separator1";
            this.File_Separator1.Size = new System.Drawing.Size(149, 6);
            // 
            // File_ExitMI
            // 
            this.File_ExitMI.Name = "File_ExitMI";
            this.File_ExitMI.Size = new System.Drawing.Size(152, 22);
            this.File_ExitMI.Text = "Exit";
            this.File_ExitMI.Click += new System.EventHandler(this.File_ExitMI_Click);
            // 
            // TestMI
            // 
            this.TestMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Test_BrowseRootsMI,
            this.Test_BrowseWriteableMI,
            this.toolStripSeparator1,
            this.Test_NoDisplayUpdateMI,
            this.Test_ContinuousMI,
            this.toolStripSeparator2,
            this.Test_UseNativeStackMI,
            this.Test_UseNativeEncodersMI,
            this.Test_AlwaysCheckSizesMI,
            this.toolStripSeparator3,
            this.CheckNodeIdMI});
            this.TestMI.Name = "TestMI";
            this.TestMI.Size = new System.Drawing.Size(41, 20);
            this.TestMI.Text = "Test";
            this.TestMI.DropDownOpening += new System.EventHandler(this.TestMI_DropDownOpening);
            // 
            // Test_BrowseRootsMI
            // 
            this.Test_BrowseRootsMI.Name = "Test_BrowseRootsMI";
            this.Test_BrowseRootsMI.Size = new System.Drawing.Size(246, 22);
            this.Test_BrowseRootsMI.Text = "Select Root Nodes...";
            this.Test_BrowseRootsMI.Click += new System.EventHandler(this.Test_BrowseRootsMI_Click);
            // 
            // Test_BrowseWriteableMI
            // 
            this.Test_BrowseWriteableMI.Name = "Test_BrowseWriteableMI";
            this.Test_BrowseWriteableMI.Size = new System.Drawing.Size(246, 22);
            this.Test_BrowseWriteableMI.Text = "Select Writeable Nodes...";
            this.Test_BrowseWriteableMI.Click += new System.EventHandler(this.Test_BrowseWriteableMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(243, 6);
            // 
            // Test_NoDisplayUpdateMI
            // 
            this.Test_NoDisplayUpdateMI.CheckOnClick = true;
            this.Test_NoDisplayUpdateMI.Name = "Test_NoDisplayUpdateMI";
            this.Test_NoDisplayUpdateMI.Size = new System.Drawing.Size(246, 22);
            this.Test_NoDisplayUpdateMI.Text = "Don\'t Update Display DuringTest";
            // 
            // Test_ContinuousMI
            // 
            this.Test_ContinuousMI.CheckOnClick = true;
            this.Test_ContinuousMI.Name = "Test_ContinuousMI";
            this.Test_ContinuousMI.Size = new System.Drawing.Size(246, 22);
            this.Test_ContinuousMI.Text = "Run Tests Continuously";
            this.Test_ContinuousMI.CheckStateChanged += new System.EventHandler(this.Test_ContinuousMI_CheckStateChanged);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(243, 6);
            // 
            // Test_UseNativeStackMI
            // 
            this.Test_UseNativeStackMI.CheckOnClick = true;
            this.Test_UseNativeStackMI.Name = "Test_UseNativeStackMI";
            this.Test_UseNativeStackMI.Size = new System.Drawing.Size(246, 22);
            this.Test_UseNativeStackMI.Text = "Use Native (ANSI C) Stack";
            this.Test_UseNativeStackMI.Click += new System.EventHandler(this.Test_UseNativeStackMI_Click);
            // 
            // Test_UseNativeEncodersMI
            // 
            this.Test_UseNativeEncodersMI.CheckOnClick = true;
            this.Test_UseNativeEncodersMI.Name = "Test_UseNativeEncodersMI";
            this.Test_UseNativeEncodersMI.Size = new System.Drawing.Size(246, 22);
            this.Test_UseNativeEncodersMI.Text = "Use Native (ANSI C) Encoders";
            this.Test_UseNativeEncodersMI.CheckStateChanged += new System.EventHandler(this.Test_UseNativeEncodersMI_CheckStateChanged);
            // 
            // Test_AlwaysCheckSizesMI
            // 
            this.Test_AlwaysCheckSizesMI.CheckOnClick = true;
            this.Test_AlwaysCheckSizesMI.Name = "Test_AlwaysCheckSizesMI";
            this.Test_AlwaysCheckSizesMI.Size = new System.Drawing.Size(246, 22);
            this.Test_AlwaysCheckSizesMI.Text = "Always Check Sizes";
            this.Test_AlwaysCheckSizesMI.Click += new System.EventHandler(this.Test_AlwaysCheckSizesMI_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TestCaseLB,
            this.TestCaseTB,
            this.IterationLB,
            this.IterationTB,
            this.EndpointLB,
            this.EndpointTB,
            this.TestCaseProgressCTRL,
            this.StopBTN,
            this.TestsCompletedLB,
            this.TestsCompletedTB});
            this.StatusBar.Location = new System.Drawing.Point(0, 530);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(1234, 24);
            this.StatusBar.TabIndex = 1;
            this.StatusBar.Text = "statusStrip1";
            // 
            // TestCaseLB
            // 
            this.TestCaseLB.Name = "TestCaseLB";
            this.TestCaseLB.Size = new System.Drawing.Size(57, 19);
            this.TestCaseLB.Text = "Test Case";
            this.TestCaseLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TestCaseTB
            // 
            this.TestCaseTB.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TestCaseTB.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.TestCaseTB.Name = "TestCaseTB";
            this.TestCaseTB.Size = new System.Drawing.Size(26, 19);
            this.TestCaseTB.Text = "---";
            this.TestCaseTB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IterationLB
            // 
            this.IterationLB.Name = "IterationLB";
            this.IterationLB.Size = new System.Drawing.Size(51, 19);
            this.IterationLB.Text = "Iteration";
            // 
            // IterationTB
            // 
            this.IterationTB.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.IterationTB.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.IterationTB.Name = "IterationTB";
            this.IterationTB.Size = new System.Drawing.Size(26, 19);
            this.IterationTB.Text = "---";
            // 
            // EndpointLB
            // 
            this.EndpointLB.Name = "EndpointLB";
            this.EndpointLB.Size = new System.Drawing.Size(55, 19);
            this.EndpointLB.Text = "Endpoint";
            // 
            // EndpointTB
            // 
            this.EndpointTB.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.EndpointTB.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.EndpointTB.Name = "EndpointTB";
            this.EndpointTB.Size = new System.Drawing.Size(26, 19);
            this.EndpointTB.Text = "---";
            // 
            // TestCaseProgressCTRL
            // 
            this.TestCaseProgressCTRL.Margin = new System.Windows.Forms.Padding(1, 5, 1, 3);
            this.TestCaseProgressCTRL.Maximum = 10000;
            this.TestCaseProgressCTRL.Name = "TestCaseProgressCTRL";
            this.TestCaseProgressCTRL.Size = new System.Drawing.Size(200, 16);
            // 
            // StopBTN
            // 
            this.StopBTN.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.StopBTN.BorderStyle = System.Windows.Forms.Border3DStyle.Raised;
            this.StopBTN.Margin = new System.Windows.Forms.Padding(3, 3, 0, 1);
            this.StopBTN.Name = "StopBTN";
            this.StopBTN.Size = new System.Drawing.Size(60, 20);
            this.StopBTN.Text = "Stop Test";
            this.StopBTN.MouseUp += new System.Windows.Forms.MouseEventHandler(this.StopBTN_MouseUp);
            this.StopBTN.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Stop_MouseDown);
            this.StopBTN.Click += new System.EventHandler(this.Stop_Click);
            // 
            // TestsCompletedLB
            // 
            this.TestsCompletedLB.Name = "TestsCompletedLB";
            this.TestsCompletedLB.Size = new System.Drawing.Size(96, 19);
            this.TestsCompletedLB.Text = "Tests Completed";
            // 
            // TestsCompletedTB
            // 
            this.TestsCompletedTB.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.TestsCompletedTB.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.TestsCompletedTB.Name = "TestsCompletedTB";
            this.TestsCompletedTB.Size = new System.Drawing.Size(26, 19);
            this.TestsCompletedTB.Text = "---";
            // 
            // TopPN
            // 
            this.TopPN.Controls.Add(this.EndpointsCTRL);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(0, 24);
            this.TopPN.Name = "TopPN";
            this.TopPN.Size = new System.Drawing.Size(1234, 29);
            this.TopPN.TabIndex = 2;
            // 
            // EndpointsCTRL
            // 
            this.EndpointsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointsCTRL.Location = new System.Drawing.Point(0, 0);
            this.EndpointsCTRL.MaximumSize = new System.Drawing.Size(2048, 28);
            this.EndpointsCTRL.MinimumSize = new System.Drawing.Size(100, 28);
            this.EndpointsCTRL.Name = "EndpointsCTRL";
            this.EndpointsCTRL.Padding = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.EndpointsCTRL.SelectedEndpoint = null;
            this.EndpointsCTRL.Size = new System.Drawing.Size(1234, 28);
            this.EndpointsCTRL.TabIndex = 0;
            this.EndpointsCTRL.ConnectEndpoint += new Opc.Ua.Client.Controls.ConnectEndpointEventHandler(this.EndpointsCTRL_ConnectEndpoint);
            // 
            // ResultsTB
            // 
            this.ResultsTB.DetectUrls = false;
            this.ResultsTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResultsTB.Location = new System.Drawing.Point(416, 0);
            this.ResultsTB.Name = "ResultsTB";
            this.ResultsTB.Size = new System.Drawing.Size(818, 477);
            this.ResultsTB.TabIndex = 0;
            this.ResultsTB.Text = "";
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.ResultsTB);
            this.MainPN.Controls.Add(this.TestCasesCTRL);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 53);
            this.MainPN.Name = "MainPN";
            this.MainPN.Size = new System.Drawing.Size(1234, 477);
            this.MainPN.TabIndex = 4;
            // 
            // TestCasesCTRL
            // 
            this.TestCasesCTRL.Dock = System.Windows.Forms.DockStyle.Left;
            this.TestCasesCTRL.EnableDragging = false;
            this.TestCasesCTRL.Location = new System.Drawing.Point(0, 0);
            this.TestCasesCTRL.MinimumSize = new System.Drawing.Size(416, 0);
            this.TestCasesCTRL.Name = "TestCasesCTRL";
            this.TestCasesCTRL.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.TestCasesCTRL.Size = new System.Drawing.Size(416, 477);
            this.TestCasesCTRL.TabIndex = 0;
            // 
            // CheckNodeIdMI
            // 
            this.CheckNodeIdMI.Name = "CheckNodeIdMI";
            this.CheckNodeIdMI.Size = new System.Drawing.Size(246, 22);
            this.CheckNodeIdMI.Text = "Check NodeId...";
            this.CheckNodeIdMI.Click += new System.EventHandler(this.CheckNodeIdMI_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(243, 6);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 554);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.TopPN);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "Server Test Application";
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.TopPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.Panel TopPN;
        private Opc.Ua.Client.Controls.EndpointSelectorCtrl EndpointsCTRL;
        private Opc.Ua.ServerTest.TestCaseTreeCtrl TestCasesCTRL;
        private System.Windows.Forms.RichTextBox ResultsTB;
        private System.Windows.Forms.ToolStripMenuItem FileMI;
        private System.Windows.Forms.ToolStripMenuItem File_ExitMI;
        private System.Windows.Forms.ToolStripMenuItem TestMI;
        private System.Windows.Forms.ToolStripStatusLabel TestCaseLB;
        private System.Windows.Forms.ToolStripStatusLabel TestCaseTB;
        private System.Windows.Forms.ToolStripProgressBar TestCaseProgressCTRL;
        private System.Windows.Forms.ToolStripMenuItem File_LoadMI;
        private System.Windows.Forms.ToolStripMenuItem File_SaveMI;
        private System.Windows.Forms.ToolStripSeparator File_Separator1;
        private System.Windows.Forms.ToolStripMenuItem File_RecentFilesMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem Test_BrowseRootsMI;
        private System.Windows.Forms.ToolStripStatusLabel StopBTN;
        private System.Windows.Forms.ToolStripMenuItem Test_ContinuousMI;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.ToolStripStatusLabel EndpointLB;
        private System.Windows.Forms.ToolStripStatusLabel EndpointTB;
        private System.Windows.Forms.ToolStripStatusLabel IterationLB;
        private System.Windows.Forms.ToolStripStatusLabel IterationTB;
        private System.Windows.Forms.ToolStripStatusLabel TestsCompletedLB;
        private System.Windows.Forms.ToolStripStatusLabel TestsCompletedTB;
        private System.Windows.Forms.ToolStripMenuItem Test_UseNativeEncodersMI;
        private System.Windows.Forms.ToolStripMenuItem Test_AlwaysCheckSizesMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem Test_UseNativeStackMI;
        private System.Windows.Forms.ToolStripMenuItem Test_NoDisplayUpdateMI;
        private System.Windows.Forms.ToolStripMenuItem Test_BrowseWriteableMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem CheckNodeIdMI;
    }
}
