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

namespace Quickstarts.UaTestClient
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
            this.components = new System.ComponentModel.Container();
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.ServerMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_DiscoverMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_ConnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_DisconnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_ContentsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ConnectedLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.ServerUrlLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.LastKeepAliveTimeLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.AddressPN = new System.Windows.Forms.Panel();
            this.ConnectBTN = new System.Windows.Forms.Button();
            this.UseSecurityCK = new System.Windows.Forms.CheckBox();
            this.UrlCB = new System.Windows.Forms.ComboBox();
            this.MainPN = new System.Windows.Forms.Panel();
            this.ConsoleTB = new System.Windows.Forms.RichTextBox();
            this.BrowsingMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Browse_MonitorMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Browse_WriteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MonitoringMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Monitoring_DeleteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringModeMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_DisabledMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_SamplingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_MonitoringMode_ReportingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingIntervalMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_FastMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_1000MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_2500MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_SamplingInterval_5000MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_DeadbandMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_NoneMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_AbsoluteMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_5MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_10MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Absolute_25MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_PercentageMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_1MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_5MI = new System.Windows.Forms.ToolStripMenuItem();
            this.Monitoring_Deadband_Percentage_10MI = new System.Windows.Forms.ToolStripMenuItem();
            this.InitialStateLB = new System.Windows.Forms.Label();
            this.FinalStateLB = new System.Windows.Forms.Label();
            this.RevisedFinalStateLB = new System.Windows.Forms.Label();
            this.RevisedInitialStateLB = new System.Windows.Forms.Label();
            this.InitialStateTB = new System.Windows.Forms.TextBox();
            this.FinalStateTB = new System.Windows.Forms.TextBox();
            this.RevisedInitialStateTB = new System.Windows.Forms.TextBox();
            this.RevisedFinalStateTB = new System.Windows.Forms.TextBox();
            this.CurrentStateLB = new System.Windows.Forms.Label();
            this.CurrentStateTB = new System.Windows.Forms.TextBox();
            this.StartBTN = new System.Windows.Forms.Button();
            this.MenuBar.SuspendLayout();
            this.StatusBar.SuspendLayout();
            this.AddressPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.BrowsingMenu.SuspendLayout();
            this.MonitoringMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerMI,
            this.HelpMI});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(884, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "menuStrip1";
            // 
            // ServerMI
            // 
            this.ServerMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Server_DiscoverMI,
            this.Server_ConnectMI,
            this.Server_DisconnectMI});
            this.ServerMI.Name = "ServerMI";
            this.ServerMI.Size = new System.Drawing.Size(51, 20);
            this.ServerMI.Text = "Server";
            // 
            // Server_ConnectMI
            // 
            this.Server_ConnectMI.Name = "Server_ConnectMI";
            this.Server_ConnectMI.Size = new System.Drawing.Size(133, 22);
            this.Server_ConnectMI.Text = "Connect";
            this.Server_ConnectMI.Click += new System.EventHandler(this.Server_ConnectMI_Click);
            // 
            // Server_DisconnectMI
            // 
            this.Server_DisconnectMI.Name = "Server_DisconnectMI";
            this.Server_DisconnectMI.Size = new System.Drawing.Size(133, 22);
            this.Server_DisconnectMI.Text = "Disconnect";
            this.Server_DisconnectMI.Click += new System.EventHandler(this.Server_DisconnectMI_Click);
            // 
            // HelpMI
            // 
            this.HelpMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help_ContentsMI});
            this.HelpMI.Name = "HelpMI";
            this.HelpMI.Size = new System.Drawing.Size(44, 20);
            this.HelpMI.Text = "Help";
            // 
            // Help_ContentsMI
            // 
            this.Help_ContentsMI.Name = "Help_ContentsMI";
            this.Help_ContentsMI.Size = new System.Drawing.Size(122, 22);
            this.Help_ContentsMI.Text = "Contents";
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectedLB,
            this.ServerUrlLB,
            this.LastKeepAliveTimeLB});
            this.StatusBar.Location = new System.Drawing.Point(0, 524);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(884, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // ConnectedLB
            // 
            this.ConnectedLB.Name = "ConnectedLB";
            this.ConnectedLB.Size = new System.Drawing.Size(79, 17);
            this.ConnectedLB.Text = "Disconnected";
            // 
            // ServerUrlLB
            // 
            this.ServerUrlLB.Name = "ServerUrlLB";
            this.ServerUrlLB.Size = new System.Drawing.Size(22, 17);
            this.ServerUrlLB.Text = "---";
            // 
            // LastKeepAliveTimeLB
            // 
            this.LastKeepAliveTimeLB.Name = "LastKeepAliveTimeLB";
            this.LastKeepAliveTimeLB.Size = new System.Drawing.Size(49, 17);
            this.LastKeepAliveTimeLB.Text = "00:00:00";
            // 
            // AddressPN
            // 
            this.AddressPN.Controls.Add(this.ConnectBTN);
            this.AddressPN.Controls.Add(this.UseSecurityCK);
            this.AddressPN.Controls.Add(this.UrlCB);
            this.AddressPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddressPN.Location = new System.Drawing.Point(0, 24);
            this.AddressPN.Name = "AddressPN";
            this.AddressPN.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddressPN.Size = new System.Drawing.Size(884, 24);
            this.AddressPN.TabIndex = 1;
            // 
            // ConnectBTN
            // 
            this.ConnectBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConnectBTN.Location = new System.Drawing.Point(807, 0);
            this.ConnectBTN.Name = "ConnectBTN";
            this.ConnectBTN.Size = new System.Drawing.Size(75, 23);
            this.ConnectBTN.TabIndex = 3;
            this.ConnectBTN.Text = "Connect";
            this.ConnectBTN.UseVisualStyleBackColor = true;
            this.ConnectBTN.Click += new System.EventHandler(this.Server_ConnectMI_Click);
            // 
            // UseSecurityCK
            // 
            this.UseSecurityCK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UseSecurityCK.AutoSize = true;
            this.UseSecurityCK.Checked = true;
            this.UseSecurityCK.CheckState = System.Windows.Forms.CheckState.Checked;
            this.UseSecurityCK.Location = new System.Drawing.Point(719, 3);
            this.UseSecurityCK.Name = "UseSecurityCK";
            this.UseSecurityCK.Size = new System.Drawing.Size(86, 17);
            this.UseSecurityCK.TabIndex = 2;
            this.UseSecurityCK.Text = "Use Security";
            this.UseSecurityCK.UseVisualStyleBackColor = true;
            // 
            // UrlCB
            // 
            this.UrlCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.UrlCB.FormattingEnabled = true;
            this.UrlCB.Location = new System.Drawing.Point(2, 1);
            this.UrlCB.Name = "UrlCB";
            this.UrlCB.Size = new System.Drawing.Size(707, 21);
            this.UrlCB.TabIndex = 1;
            this.UrlCB.Text = "http://localhost:62541/Quickstarts/MethodsServer";
            this.UrlCB.DropDown += new System.EventHandler(this.UrlCB_DropDown);
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.StartBTN);
            this.MainPN.Controls.Add(this.CurrentStateTB);
            this.MainPN.Controls.Add(this.CurrentStateLB);
            this.MainPN.Controls.Add(this.RevisedFinalStateTB);
            this.MainPN.Controls.Add(this.RevisedInitialStateTB);
            this.MainPN.Controls.Add(this.FinalStateTB);
            this.MainPN.Controls.Add(this.InitialStateTB);
            this.MainPN.Controls.Add(this.RevisedFinalStateLB);
            this.MainPN.Controls.Add(this.RevisedInitialStateLB);
            this.MainPN.Controls.Add(this.FinalStateLB);
            this.MainPN.Controls.Add(this.InitialStateLB);
            this.MainPN.Controls.Add(this.ConsoleTB);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 48);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.MainPN.Size = new System.Drawing.Size(884, 476);
            this.MainPN.TabIndex = 3;
            // 
            // ConsoleTB
            // 
            this.ConsoleTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleTB.Location = new System.Drawing.Point(2, 2);
            this.ConsoleTB.Name = "ConsoleTB";
            this.ConsoleTB.ReadOnly = true;
            this.ConsoleTB.Size = new System.Drawing.Size(880, 474);
            this.ConsoleTB.TabIndex = 0;
            this.ConsoleTB.Text = "";
            // 
            // BrowsingMenu
            // 
            this.BrowsingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Browse_MonitorMI,
            this.Browse_WriteMI});
            this.BrowsingMenu.Name = "BrowsingMenu";
            this.BrowsingMenu.Size = new System.Drawing.Size(118, 48);
            // 
            // Browse_MonitorMI
            // 
            this.Browse_MonitorMI.Name = "Browse_MonitorMI";
            this.Browse_MonitorMI.Size = new System.Drawing.Size(117, 22);
            this.Browse_MonitorMI.Text = "Monitor";
            // 
            // Browse_WriteMI
            // 
            this.Browse_WriteMI.Name = "Browse_WriteMI";
            this.Browse_WriteMI.Size = new System.Drawing.Size(117, 22);
            this.Browse_WriteMI.Text = "Write...";
            // 
            // MonitoringMenu
            // 
            this.MonitoringMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_DeleteMI,
            this.Monitoring_MonitoringModeMI,
            this.Monitoring_SamplingIntervalMI,
            this.Monitoring_DeadbandMI});
            this.MonitoringMenu.Name = "MonitoringMenu";
            this.MonitoringMenu.Size = new System.Drawing.Size(169, 92);
            // 
            // Monitoring_DeleteMI
            // 
            this.Monitoring_DeleteMI.Name = "Monitoring_DeleteMI";
            this.Monitoring_DeleteMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_DeleteMI.Text = "Delete";
            // 
            // Monitoring_MonitoringModeMI
            // 
            this.Monitoring_MonitoringModeMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_MonitoringMode_DisabledMI,
            this.Monitoring_MonitoringMode_SamplingMI,
            this.Monitoring_MonitoringMode_ReportingMI});
            this.Monitoring_MonitoringModeMI.Name = "Monitoring_MonitoringModeMI";
            this.Monitoring_MonitoringModeMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_MonitoringModeMI.Text = "Monitoring Mode";
            // 
            // Monitoring_MonitoringMode_DisabledMI
            // 
            this.Monitoring_MonitoringMode_DisabledMI.Name = "Monitoring_MonitoringMode_DisabledMI";
            this.Monitoring_MonitoringMode_DisabledMI.Size = new System.Drawing.Size(126, 22);
            this.Monitoring_MonitoringMode_DisabledMI.Text = "Disabled";
            // 
            // Monitoring_MonitoringMode_SamplingMI
            // 
            this.Monitoring_MonitoringMode_SamplingMI.Name = "Monitoring_MonitoringMode_SamplingMI";
            this.Monitoring_MonitoringMode_SamplingMI.Size = new System.Drawing.Size(126, 22);
            this.Monitoring_MonitoringMode_SamplingMI.Text = "Sampling";
            // 
            // Monitoring_MonitoringMode_ReportingMI
            // 
            this.Monitoring_MonitoringMode_ReportingMI.Name = "Monitoring_MonitoringMode_ReportingMI";
            this.Monitoring_MonitoringMode_ReportingMI.Size = new System.Drawing.Size(126, 22);
            this.Monitoring_MonitoringMode_ReportingMI.Text = "Reporting";
            // 
            // Monitoring_SamplingIntervalMI
            // 
            this.Monitoring_SamplingIntervalMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_SamplingInterval_FastMI,
            this.Monitoring_SamplingInterval_1000MI,
            this.Monitoring_SamplingInterval_2500MI,
            this.Monitoring_SamplingInterval_5000MI});
            this.Monitoring_SamplingIntervalMI.Name = "Monitoring_SamplingIntervalMI";
            this.Monitoring_SamplingIntervalMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_SamplingIntervalMI.Text = "Samping Interval";
            // 
            // Monitoring_SamplingInterval_FastMI
            // 
            this.Monitoring_SamplingInterval_FastMI.Name = "Monitoring_SamplingInterval_FastMI";
            this.Monitoring_SamplingInterval_FastMI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_FastMI.Text = "Fast as Possible";
            // 
            // Monitoring_SamplingInterval_1000MI
            // 
            this.Monitoring_SamplingInterval_1000MI.Name = "Monitoring_SamplingInterval_1000MI";
            this.Monitoring_SamplingInterval_1000MI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_1000MI.Text = "1000ms";
            // 
            // Monitoring_SamplingInterval_2500MI
            // 
            this.Monitoring_SamplingInterval_2500MI.Name = "Monitoring_SamplingInterval_2500MI";
            this.Monitoring_SamplingInterval_2500MI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_2500MI.Text = "2500ms";
            // 
            // Monitoring_SamplingInterval_5000MI
            // 
            this.Monitoring_SamplingInterval_5000MI.Name = "Monitoring_SamplingInterval_5000MI";
            this.Monitoring_SamplingInterval_5000MI.Size = new System.Drawing.Size(155, 22);
            this.Monitoring_SamplingInterval_5000MI.Text = "5000ms";
            // 
            // Monitoring_DeadbandMI
            // 
            this.Monitoring_DeadbandMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_NoneMI,
            this.Monitoring_Deadband_AbsoluteMI,
            this.Monitoring_Deadband_PercentageMI});
            this.Monitoring_DeadbandMI.Name = "Monitoring_DeadbandMI";
            this.Monitoring_DeadbandMI.Size = new System.Drawing.Size(168, 22);
            this.Monitoring_DeadbandMI.Text = "Deadband";
            // 
            // Monitoring_Deadband_NoneMI
            // 
            this.Monitoring_Deadband_NoneMI.Name = "Monitoring_Deadband_NoneMI";
            this.Monitoring_Deadband_NoneMI.Size = new System.Drawing.Size(133, 22);
            this.Monitoring_Deadband_NoneMI.Text = "None";
            // 
            // Monitoring_Deadband_AbsoluteMI
            // 
            this.Monitoring_Deadband_AbsoluteMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_Absolute_5MI,
            this.Monitoring_Deadband_Absolute_10MI,
            this.Monitoring_Deadband_Absolute_25MI});
            this.Monitoring_Deadband_AbsoluteMI.Name = "Monitoring_Deadband_AbsoluteMI";
            this.Monitoring_Deadband_AbsoluteMI.Size = new System.Drawing.Size(133, 22);
            this.Monitoring_Deadband_AbsoluteMI.Text = "Absolute";
            // 
            // Monitoring_Deadband_Absolute_5MI
            // 
            this.Monitoring_Deadband_Absolute_5MI.Name = "Monitoring_Deadband_Absolute_5MI";
            this.Monitoring_Deadband_Absolute_5MI.Size = new System.Drawing.Size(86, 22);
            this.Monitoring_Deadband_Absolute_5MI.Text = "5";
            // 
            // Monitoring_Deadband_Absolute_10MI
            // 
            this.Monitoring_Deadband_Absolute_10MI.Name = "Monitoring_Deadband_Absolute_10MI";
            this.Monitoring_Deadband_Absolute_10MI.Size = new System.Drawing.Size(86, 22);
            this.Monitoring_Deadband_Absolute_10MI.Text = "10";
            // 
            // Monitoring_Deadband_Absolute_25MI
            // 
            this.Monitoring_Deadband_Absolute_25MI.Name = "Monitoring_Deadband_Absolute_25MI";
            this.Monitoring_Deadband_Absolute_25MI.Size = new System.Drawing.Size(86, 22);
            this.Monitoring_Deadband_Absolute_25MI.Text = "25";
            // 
            // Monitoring_Deadband_PercentageMI
            // 
            this.Monitoring_Deadband_PercentageMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Monitoring_Deadband_Percentage_1MI,
            this.Monitoring_Deadband_Percentage_5MI,
            this.Monitoring_Deadband_Percentage_10MI});
            this.Monitoring_Deadband_PercentageMI.Name = "Monitoring_Deadband_PercentageMI";
            this.Monitoring_Deadband_PercentageMI.Size = new System.Drawing.Size(133, 22);
            this.Monitoring_Deadband_PercentageMI.Text = "Percentage";
            // 
            // Monitoring_Deadband_Percentage_1MI
            // 
            this.Monitoring_Deadband_Percentage_1MI.Name = "Monitoring_Deadband_Percentage_1MI";
            this.Monitoring_Deadband_Percentage_1MI.Size = new System.Drawing.Size(96, 22);
            this.Monitoring_Deadband_Percentage_1MI.Text = "1%";
            // 
            // Monitoring_Deadband_Percentage_5MI
            // 
            this.Monitoring_Deadband_Percentage_5MI.Name = "Monitoring_Deadband_Percentage_5MI";
            this.Monitoring_Deadband_Percentage_5MI.Size = new System.Drawing.Size(96, 22);
            this.Monitoring_Deadband_Percentage_5MI.Text = "5%";
            // 
            // Monitoring_Deadband_Percentage_10MI
            // 
            this.Monitoring_Deadband_Percentage_10MI.Name = "Monitoring_Deadband_Percentage_10MI";
            this.Monitoring_Deadband_Percentage_10MI.Size = new System.Drawing.Size(96, 22);
            this.Monitoring_Deadband_Percentage_10MI.Text = "10%";
            // 
            // InitialStateLB
            // 
            this.InitialStateLB.AutoSize = true;
            this.InitialStateLB.Location = new System.Drawing.Point(54, 33);
            this.InitialStateLB.Name = "InitialStateLB";
            this.InitialStateLB.Size = new System.Drawing.Size(59, 13);
            this.InitialStateLB.TabIndex = 1;
            this.InitialStateLB.Text = "Initial State";
            // 
            // FinalStateLB
            // 
            this.FinalStateLB.AutoSize = true;
            this.FinalStateLB.Location = new System.Drawing.Point(54, 59);
            this.FinalStateLB.Name = "FinalStateLB";
            this.FinalStateLB.Size = new System.Drawing.Size(57, 13);
            this.FinalStateLB.TabIndex = 2;
            this.FinalStateLB.Text = "Final State";
            // 
            // RevisedFinalStateLB
            // 
            this.RevisedFinalStateLB.AutoSize = true;
            this.RevisedFinalStateLB.Location = new System.Drawing.Point(54, 111);
            this.RevisedFinalStateLB.Name = "RevisedFinalStateLB";
            this.RevisedFinalStateLB.Size = new System.Drawing.Size(99, 13);
            this.RevisedFinalStateLB.TabIndex = 4;
            this.RevisedFinalStateLB.Text = "Revised Final State";
            // 
            // RevisedInitialStateLB
            // 
            this.RevisedInitialStateLB.AutoSize = true;
            this.RevisedInitialStateLB.Location = new System.Drawing.Point(54, 85);
            this.RevisedInitialStateLB.Name = "RevisedInitialStateLB";
            this.RevisedInitialStateLB.Size = new System.Drawing.Size(101, 13);
            this.RevisedInitialStateLB.TabIndex = 3;
            this.RevisedInitialStateLB.Text = "Revised Initial State";
            // 
            // InitialStateTB
            // 
            this.InitialStateTB.Location = new System.Drawing.Point(161, 30);
            this.InitialStateTB.Name = "InitialStateTB";
            this.InitialStateTB.Size = new System.Drawing.Size(100, 20);
            this.InitialStateTB.TabIndex = 5;
            // 
            // FinalStateTB
            // 
            this.FinalStateTB.Location = new System.Drawing.Point(161, 56);
            this.FinalStateTB.Name = "FinalStateTB";
            this.FinalStateTB.Size = new System.Drawing.Size(100, 20);
            this.FinalStateTB.TabIndex = 6;
            // 
            // RevisedInitialStateTB
            // 
            this.RevisedInitialStateTB.Location = new System.Drawing.Point(161, 82);
            this.RevisedInitialStateTB.Name = "RevisedInitialStateTB";
            this.RevisedInitialStateTB.ReadOnly = true;
            this.RevisedInitialStateTB.Size = new System.Drawing.Size(100, 20);
            this.RevisedInitialStateTB.TabIndex = 7;
            // 
            // RevisedFinalStateTB
            // 
            this.RevisedFinalStateTB.Location = new System.Drawing.Point(161, 108);
            this.RevisedFinalStateTB.Name = "RevisedFinalStateTB";
            this.RevisedFinalStateTB.ReadOnly = true;
            this.RevisedFinalStateTB.Size = new System.Drawing.Size(100, 20);
            this.RevisedFinalStateTB.TabIndex = 8;
            // 
            // CurrentStateLB
            // 
            this.CurrentStateLB.AutoSize = true;
            this.CurrentStateLB.Location = new System.Drawing.Point(54, 137);
            this.CurrentStateLB.Name = "CurrentStateLB";
            this.CurrentStateLB.Size = new System.Drawing.Size(69, 13);
            this.CurrentStateLB.TabIndex = 9;
            this.CurrentStateLB.Text = "Current State";
            // 
            // CurrentStateTB
            // 
            this.CurrentStateTB.Location = new System.Drawing.Point(161, 134);
            this.CurrentStateTB.Name = "CurrentStateTB";
            this.CurrentStateTB.ReadOnly = true;
            this.CurrentStateTB.Size = new System.Drawing.Size(100, 20);
            this.CurrentStateTB.TabIndex = 10;
            // 
            // StartBTN
            // 
            this.StartBTN.Location = new System.Drawing.Point(125, 179);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(75, 23);
            this.StartBTN.TabIndex = 11;
            this.StartBTN.Text = "Start";
            this.StartBTN.UseVisualStyleBackColor = true;
            this.StartBTN.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // Server_DiscoverMI
            // 
            this.Server_DiscoverMI.Name = "Server_DiscoverMI";
            this.Server_DiscoverMI.Size = new System.Drawing.Size(152, 22);
            this.Server_DiscoverMI.Text = "Discover...";
            this.Server_DiscoverMI.Click += new System.EventHandler(this.Server_DiscoverMI_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 546);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.AddressPN);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.Text = "Quickstarts UA Test Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            this.AddressPN.ResumeLayout(false);
            this.AddressPN.PerformLayout();
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.BrowsingMenu.ResumeLayout(false);
            this.MonitoringMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripMenuItem ServerMI;
        private System.Windows.Forms.ToolStripMenuItem Server_DiscoverMI;
        private System.Windows.Forms.ToolStripMenuItem Server_ConnectMI;
        private System.Windows.Forms.ToolStripMenuItem Server_DisconnectMI;
        private System.Windows.Forms.ToolStripStatusLabel ConnectedLB;
        private System.Windows.Forms.ToolStripStatusLabel ServerUrlLB;
        private System.Windows.Forms.ToolStripStatusLabel LastKeepAliveTimeLB;
        private System.Windows.Forms.Panel AddressPN;
        private System.Windows.Forms.Button ConnectBTN;
        private System.Windows.Forms.CheckBox UseSecurityCK;
        private System.Windows.Forms.ComboBox UrlCB;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.ToolStripMenuItem HelpMI;
        private System.Windows.Forms.ToolStripMenuItem Help_ContentsMI;
        private System.Windows.Forms.ContextMenuStrip BrowsingMenu;
        private System.Windows.Forms.ToolStripMenuItem Browse_MonitorMI;
        private System.Windows.Forms.ToolStripMenuItem Browse_WriteMI;
        private System.Windows.Forms.ContextMenuStrip MonitoringMenu;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeleteMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringModeMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_DisabledMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_SamplingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_MonitoringMode_ReportingMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingIntervalMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_FastMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_1000MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_2500MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_SamplingInterval_5000MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_DeadbandMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_NoneMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_AbsoluteMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_5MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_10MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Absolute_25MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_PercentageMI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_1MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_5MI;
        private System.Windows.Forms.ToolStripMenuItem Monitoring_Deadband_Percentage_10MI;
        private System.Windows.Forms.RichTextBox ConsoleTB;
        private System.Windows.Forms.Button StartBTN;
        private System.Windows.Forms.TextBox CurrentStateTB;
        private System.Windows.Forms.Label CurrentStateLB;
        private System.Windows.Forms.TextBox RevisedFinalStateTB;
        private System.Windows.Forms.TextBox RevisedInitialStateTB;
        private System.Windows.Forms.TextBox FinalStateTB;
        private System.Windows.Forms.TextBox InitialStateTB;
        private System.Windows.Forms.Label RevisedFinalStateLB;
        private System.Windows.Forms.Label RevisedInitialStateLB;
        private System.Windows.Forms.Label FinalStateLB;
        private System.Windows.Forms.Label InitialStateLB;
    }
}
