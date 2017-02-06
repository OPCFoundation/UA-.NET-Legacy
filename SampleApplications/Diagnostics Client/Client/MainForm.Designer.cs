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

namespace Opc.Ua.Client.Diagnostic
{
  partial class MainForm
  {
    ///	<summary>
    ///	Required designer	variable.
    ///	</summary>
    private System.ComponentModel.IContainer components = null;

    ///	<summary>
    ///	Clean	up any resources being used.
    ///	</summary>
    ///	<param name="disposing">true if	managed	resources	should be	disposed;	otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region	Windows	Form Designer	generated	code

    ///	<summary>
    ///	Required method	for	Designer support - do	not	modify
    ///	the	contents of	this method	with the code	editor.
    ///	</summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      this.Panel1 = new System.Windows.Forms.Panel();
      this.ServerListView = new System.Windows.Forms.ListView();
      this.ServerPopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
      this.serverStatusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.serverCapbilitiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.serverDiagnosticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.sessionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
      this.EndpointSelectorCTRL = new Opc.Ua.Client.Controls.EndpointSelectorCtrl();
      this.OutputTextBox = new System.Windows.Forms.TextBox();
      this.Panel1.SuspendLayout();
      this.ServerPopupMenu.SuspendLayout();
      this.SuspendLayout();
      // 
      // Panel1
      // 
      this.Panel1.Controls.Add(this.ServerListView);
      this.Panel1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.Panel1.Location = new System.Drawing.Point(0, 27);
      this.Panel1.Name = "Panel1";
      this.Panel1.Size = new System.Drawing.Size(1016, 373);
      this.Panel1.TabIndex = 1;
      // 
      // ServerListView
      // 
      this.ServerListView.ContextMenuStrip = this.ServerPopupMenu;
      this.ServerListView.Dock = System.Windows.Forms.DockStyle.Fill;
      this.ServerListView.FullRowSelect = true;
      this.ServerListView.Location = new System.Drawing.Point(0, 0);
      this.ServerListView.Name = "ServerListView";
      this.ServerListView.Size = new System.Drawing.Size(1016, 373);
      this.ServerListView.TabIndex = 0;
      this.ServerListView.UseCompatibleStateImageBehavior = false;
      this.ServerListView.View = System.Windows.Forms.View.Details;
      // 
      // ServerPopupMenu
      // 
      this.ServerPopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverStatusToolStripMenuItem,
            this.serverCapbilitiesToolStripMenuItem,
            this.serverDiagnosticsToolStripMenuItem,
            this.sessionsToolStripMenuItem,
            this.disconnectToolStripMenuItem,
            this.deleteToolStripMenuItem,
            this.connectToolStripMenuItem});
      this.ServerPopupMenu.Name = "ServerPopupMenu";
      this.ServerPopupMenu.Size = new System.Drawing.Size(196, 180);
      this.ServerPopupMenu.Opening += new System.ComponentModel.CancelEventHandler(this.OnMenuOpening);
      // 
      // serverStatusToolStripMenuItem
      // 
      this.serverStatusToolStripMenuItem.Name = "serverStatusToolStripMenuItem";
      this.serverStatusToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
      this.serverStatusToolStripMenuItem.Text = "ServerStatusType";
      this.serverStatusToolStripMenuItem.Click += new System.EventHandler(this.serverStatusToolStripMenuItem_Click);
      // 
      // serverCapbilitiesToolStripMenuItem
      // 
      this.serverCapbilitiesToolStripMenuItem.Name = "serverCapbilitiesToolStripMenuItem";
      this.serverCapbilitiesToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
      this.serverCapbilitiesToolStripMenuItem.Text = "ServerCapabilitiesType";
      this.serverCapbilitiesToolStripMenuItem.Click += new System.EventHandler(this.serverCapbilitiesToolStripMenuItem_Click);
      // 
      // serverDiagnosticsToolStripMenuItem
      // 
      this.serverDiagnosticsToolStripMenuItem.Name = "serverDiagnosticsToolStripMenuItem";
      this.serverDiagnosticsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
      this.serverDiagnosticsToolStripMenuItem.Text = "ServerDiagnosticsType";
      this.serverDiagnosticsToolStripMenuItem.Click += new System.EventHandler(this.serverDiagnosticsToolStripMenuItem_Click);
      // 
      // sessionsToolStripMenuItem
      // 
      this.sessionsToolStripMenuItem.Name = "sessionsToolStripMenuItem";
      this.sessionsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
      this.sessionsToolStripMenuItem.Text = "Sessions";
      this.sessionsToolStripMenuItem.Click += new System.EventHandler(this.sessionsToolStripMenuItem_Click);
      // 
      // disconnectToolStripMenuItem
      // 
      this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
      this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
      this.disconnectToolStripMenuItem.Text = "Disconnect";
      this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
      // 
      // deleteToolStripMenuItem
      // 
      this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
      this.deleteToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
      this.deleteToolStripMenuItem.Text = "Delete";
      this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
      // 
      // connectToolStripMenuItem
      // 
      this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
      this.connectToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
      this.connectToolStripMenuItem.Text = "Connect";
      this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
      // 
      // toolStripMenuItem1
      // 
      this.toolStripMenuItem1.Name = "toolStripMenuItem1";
      this.toolStripMenuItem1.Size = new System.Drawing.Size(6, 6);
      // 
      // EndpointSelectorCTRL
      // 
      this.EndpointSelectorCTRL.Dock = System.Windows.Forms.DockStyle.Top;
      this.EndpointSelectorCTRL.Location = new System.Drawing.Point(0, 0);
      this.EndpointSelectorCTRL.MaximumSize = new System.Drawing.Size(2048, 27);
      this.EndpointSelectorCTRL.MinimumSize = new System.Drawing.Size(100, 27);
      this.EndpointSelectorCTRL.Name = "EndpointSelectorCTRL";
      this.EndpointSelectorCTRL.Padding = new System.Windows.Forms.Padding(1, 0, 0, 0);
      this.EndpointSelectorCTRL.SelectedEndpoint = null;
      this.EndpointSelectorCTRL.Size = new System.Drawing.Size(1016, 27);
      this.EndpointSelectorCTRL.TabIndex = 2;
      this.EndpointSelectorCTRL.EndpointsChanged += new System.EventHandler(this.EndpointSelectorCTRL_OnChange);
      this.EndpointSelectorCTRL.ConnectEndpoint += new Opc.Ua.Client.Controls.ConnectEndpointEventHandler(this.EndpointSelectorCTRL_ConnectEndpoint);
      // 
      // OutputTextBox
      // 
      this.OutputTextBox.Location = new System.Drawing.Point(0, 0);
      this.OutputTextBox.Name = "OutputTextBox";
      this.OutputTextBox.Size = new System.Drawing.Size(100, 20);
      this.OutputTextBox.TabIndex = 0;
      // 
      // MainForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1016, 400);
      this.Controls.Add(this.Panel1);
      this.Controls.Add(this.EndpointSelectorCTRL);
      this.Name = "MainForm";
      this.Text = "UA Sample Diagnostic Client";
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
      this.Panel1.ResumeLayout(false);
      this.ServerPopupMenu.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private Opc.Ua.Client.Controls.EndpointSelectorCtrl EndpointSelectorCTRL;
    private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
    private System.Windows.Forms.Panel Panel1;
    public System.Windows.Forms.ListView ServerListView;
    public System.Windows.Forms.TextBox OutputTextBox;
    private System.Windows.Forms.ContextMenuStrip ServerPopupMenu;
    private System.Windows.Forms.ToolStripMenuItem serverStatusToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem serverCapbilitiesToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem serverDiagnosticsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem sessionsToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
  }
}
