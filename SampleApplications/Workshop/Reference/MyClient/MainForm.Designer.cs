/* ========================================================================
 * Copyright (c) 2005-2013 The Hoschule Esslingen, Inc. All rights reserved.
 *
 * Hoschule Esslingen MIT License 1.00
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

namespace Quickstarts.MyClient
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
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_DiscoverMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_ConnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_DisconnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_ContentsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.ConnectServerCTRL = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            this.BrowseCTRL = new Quickstarts.BrowseNodeCtrl();
            this.clientHeaderBranding1 = new Opc.Ua.Server.Controls.ClientHeaderBranding();
            this.subscribeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.ServerMI,
            this.HelpMI});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.MenuBar.Size = new System.Drawing.Size(1326, 35);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(50, 29);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 30);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // ServerMI
            // 
            this.ServerMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Server_DiscoverMI,
            this.Server_ConnectMI,
            this.Server_DisconnectMI,
            this.subscribeToolStripMenuItem});
            this.ServerMI.Name = "ServerMI";
            this.ServerMI.Size = new System.Drawing.Size(73, 29);
            this.ServerMI.Text = "Server";
            // 
            // Server_DiscoverMI
            // 
            this.Server_DiscoverMI.Name = "Server_DiscoverMI";
            this.Server_DiscoverMI.Size = new System.Drawing.Size(211, 30);
            this.Server_DiscoverMI.Text = "Discover...";
            this.Server_DiscoverMI.Click += new System.EventHandler(this.Server_DiscoverMI_Click);
            // 
            // Server_ConnectMI
            // 
            this.Server_ConnectMI.Name = "Server_ConnectMI";
            this.Server_ConnectMI.Size = new System.Drawing.Size(211, 30);
            this.Server_ConnectMI.Text = "Connect";
            this.Server_ConnectMI.Click += new System.EventHandler(this.Server_ConnectMI_Click);
            // 
            // Server_DisconnectMI
            // 
            this.Server_DisconnectMI.Name = "Server_DisconnectMI";
            this.Server_DisconnectMI.Size = new System.Drawing.Size(211, 30);
            this.Server_DisconnectMI.Text = "Disconnect";
            this.Server_DisconnectMI.Click += new System.EventHandler(this.Server_DisconnectMI_Click);
            // 
            // HelpMI
            // 
            this.HelpMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help_ContentsMI});
            this.HelpMI.Name = "HelpMI";
            this.HelpMI.Size = new System.Drawing.Size(61, 29);
            this.HelpMI.Text = "Help";
            // 
            // Help_ContentsMI
            // 
            this.Help_ContentsMI.Name = "Help_ContentsMI";
            this.Help_ContentsMI.Size = new System.Drawing.Size(168, 30);
            this.Help_ContentsMI.Text = "Contents";
            this.Help_ContentsMI.Click += new System.EventHandler(this.Help_ContentsMI_Click);
            // 
            // StatusBar
            // 
            this.StatusBar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.StatusBar.Location = new System.Drawing.Point(0, 818);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.StatusBar.Size = new System.Drawing.Size(1326, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // ConnectServerCTRL
            // 
            this.ConnectServerCTRL.Configuration = null;
            this.ConnectServerCTRL.DisableDomainCheck = false;
            this.ConnectServerCTRL.Dock = System.Windows.Forms.DockStyle.Top;
            this.ConnectServerCTRL.Location = new System.Drawing.Point(0, 150);
            this.ConnectServerCTRL.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.ConnectServerCTRL.MaximumSize = new System.Drawing.Size(3072, 35);
            this.ConnectServerCTRL.MinimumSize = new System.Drawing.Size(750, 35);
            this.ConnectServerCTRL.Name = "ConnectServerCTRL";
            this.ConnectServerCTRL.PreferredLocales = null;
            this.ConnectServerCTRL.ServerUrl = "";
            this.ConnectServerCTRL.SessionName = null;
            this.ConnectServerCTRL.Size = new System.Drawing.Size(1326, 35);
            this.ConnectServerCTRL.StatusStrip = this.StatusBar;
            this.ConnectServerCTRL.TabIndex = 6;
            this.ConnectServerCTRL.UserIdentity = null;
            this.ConnectServerCTRL.UseSecurity = true;
            this.ConnectServerCTRL.ReconnectStarting += new System.EventHandler(this.Server_ReconnectStarting);
            this.ConnectServerCTRL.ReconnectComplete += new System.EventHandler(this.Server_ReconnectComplete);
            this.ConnectServerCTRL.ConnectComplete += new System.EventHandler(this.Server_ConnectComplete);
            // 
            // BrowseCTRL
            // 
            this.BrowseCTRL.AttributesListCollapsed = false;
            this.BrowseCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BrowseCTRL.Location = new System.Drawing.Point(0, 185);
            this.BrowseCTRL.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.BrowseCTRL.Name = "BrowseCTRL";
            this.BrowseCTRL.Size = new System.Drawing.Size(1326, 633);
            this.BrowseCTRL.SplitterDistance = 387;
            this.BrowseCTRL.TabIndex = 5;
            this.BrowseCTRL.View = null;
            // 
            // clientHeaderBranding1
            // 
            this.clientHeaderBranding1.BackColor = System.Drawing.Color.White;
            this.clientHeaderBranding1.Dock = System.Windows.Forms.DockStyle.Top;
            this.clientHeaderBranding1.Location = new System.Drawing.Point(0, 35);
            this.clientHeaderBranding1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.clientHeaderBranding1.MaximumSize = new System.Drawing.Size(0, 115);
            this.clientHeaderBranding1.MinimumSize = new System.Drawing.Size(750, 115);
            this.clientHeaderBranding1.Name = "clientHeaderBranding1";
            this.clientHeaderBranding1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.clientHeaderBranding1.Size = new System.Drawing.Size(1326, 115);
            this.clientHeaderBranding1.TabIndex = 7;
            // 
            // subscribeToolStripMenuItem
            // 
            this.subscribeToolStripMenuItem.Name = "subscribeToolStripMenuItem";
            this.subscribeToolStripMenuItem.Size = new System.Drawing.Size(211, 30);
            this.subscribeToolStripMenuItem.Text = "Subscribe";
            this.subscribeToolStripMenuItem.Click += new System.EventHandler(this.subscribeToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1326, 840);
            this.Controls.Add(this.BrowseCTRL);
            this.Controls.Add(this.ConnectServerCTRL);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.clientHeaderBranding1);
            this.Controls.Add(this.MenuBar);
            this.MainMenuStrip = this.MenuBar;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Quickstart My Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem HelpMI;
        private System.Windows.Forms.ToolStripMenuItem Help_ContentsMI;
        private Opc.Ua.Client.Controls.ConnectServerCtrl ConnectServerCTRL;
        private BrowseNodeCtrl BrowseCTRL;
        private Opc.Ua.Server.Controls.ClientHeaderBranding clientHeaderBranding1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem subscribeToolStripMenuItem;
        private SubscriptionOutput outputWindow;
    }
}