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

using Opc.Ua.Server.Controls;
namespace Quickstarts.ComDataAccessServer
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
            this.MainPN = new System.Windows.Forms.Panel();
            this.AddressPN = new System.Windows.Forms.Panel();
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.ConfigMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Config_SelectServerMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Config_DeleteServerMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ServerDiagnosticsCTRL = new ServerDiagnosticsCtrl();
            this.MainPN.SuspendLayout();
            this.AddressPN.SuspendLayout();
            this.MainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.ServerDiagnosticsCTRL);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 24);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3);
            this.MainPN.Size = new System.Drawing.Size(699, 375);
            this.MainPN.TabIndex = 0;
            // 
            // AddressPN
            // 
            this.AddressPN.Controls.Add(this.MainMenu);
            this.AddressPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddressPN.Location = new System.Drawing.Point(0, 0);
            this.AddressPN.Name = "AddressPN";
            this.AddressPN.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddressPN.Size = new System.Drawing.Size(699, 24);
            this.AddressPN.TabIndex = 2;
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConfigMI});
            this.MainMenu.Location = new System.Drawing.Point(2, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(695, 24);
            this.MainMenu.TabIndex = 2;
            this.MainMenu.Text = "menuStrip1";
            // 
            // ConfigMI
            // 
            this.ConfigMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Config_SelectServerMI,
            this.Config_DeleteServerMI});
            this.ConfigMI.Name = "ConfigMI";
            this.ConfigMI.Size = new System.Drawing.Size(55, 20);
            this.ConfigMI.Text = "Config";
            // 
            // Config_SelectServerMI
            // 
            this.Config_SelectServerMI.Name = "Config_SelectServerMI";
            this.Config_SelectServerMI.Size = new System.Drawing.Size(233, 22);
            this.Config_SelectServerMI.Text = "Select COM Server to Wrap...";
            this.Config_SelectServerMI.Click += new System.EventHandler(this.Config_SelectServerMI_Click);
            // 
            // Config_DeleteServerMI
            // 
            this.Config_DeleteServerMI.Name = "Config_DeleteServerMI";
            this.Config_DeleteServerMI.Size = new System.Drawing.Size(233, 22);
            this.Config_DeleteServerMI.Text = "Delete Wrapped COM Server...";
            this.Config_DeleteServerMI.Click += new System.EventHandler(this.Config_DeleteServerMI_Click);
            // 
            // ServerDiagnosticsCTRL
            // 
            this.ServerDiagnosticsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerDiagnosticsCTRL.Location = new System.Drawing.Point(3, 3);
            this.ServerDiagnosticsCTRL.Name = "ServerDiagnosticsCTRL";
            this.ServerDiagnosticsCTRL.Size = new System.Drawing.Size(693, 369);
            this.ServerDiagnosticsCTRL.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 399);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.AddressPN);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "MainForm";
            this.Text = "UA Data Access Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.MainPN.ResumeLayout(false);
            this.AddressPN.ResumeLayout(false);
            this.AddressPN.PerformLayout();
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.Panel AddressPN;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem ConfigMI;
        private System.Windows.Forms.ToolStripMenuItem Config_SelectServerMI;
        private System.Windows.Forms.ToolStripMenuItem Config_DeleteServerMI;
        private ServerDiagnosticsCtrl ServerDiagnosticsCTRL;
    }
}
