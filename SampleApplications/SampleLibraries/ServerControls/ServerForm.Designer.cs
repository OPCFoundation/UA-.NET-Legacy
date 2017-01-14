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

namespace Opc.Ua.Server.Controls
{
    partial class ServerForm 
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
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.ServerDiagnosticsCTRL = new Opc.Ua.Server.Controls.ServerDiagnosticsCtrl();
            this.TopMenuBar = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TopMenuBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.Text = "TrayIcon";
            this.TrayIcon.Visible = true;
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            this.TrayIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TrayIcon_MouseMove);
            // 
            // ServerDiagnosticsCTRL
            // 
            this.ServerDiagnosticsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServerDiagnosticsCTRL.Location = new System.Drawing.Point(0, 24);
            this.ServerDiagnosticsCTRL.Name = "ServerDiagnosticsCTRL";
            this.ServerDiagnosticsCTRL.Size = new System.Drawing.Size(739, 458);
            this.ServerDiagnosticsCTRL.TabIndex = 0;
            // 
            // MainMenu
            // 
            this.TopMenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.TopMenuBar.Location = new System.Drawing.Point(0, 0);
            this.TopMenuBar.Name = "MainMenu";
            this.TopMenuBar.Size = new System.Drawing.Size(739, 24);
            this.TopMenuBar.TabIndex = 2;
            this.TopMenuBar.Text = "MainMenu";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(92, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.contentsToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // contentsToolStripMenuItem
            // 
            this.contentsToolStripMenuItem.Name = "contentsToolStripMenuItem";
            this.contentsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.contentsToolStripMenuItem.Text = "&Contents";
            this.contentsToolStripMenuItem.Click += new System.EventHandler(this.contentsToolStripMenuItem_Click);
            // 
            // ServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(739, 482);
            this.Controls.Add(this.ServerDiagnosticsCTRL);
            this.Controls.Add(this.TopMenuBar);
            this.MainMenuStrip = this.TopMenuBar;
            this.Name = "ServerForm";
            this.Text = "Quickstart Empty Server";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ServerForm_FormClosed);
            this.Resize += new System.EventHandler(this.ServerForm_Resize);
            this.TopMenuBar.ResumeLayout(false);
            this.TopMenuBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ServerDiagnosticsCtrl ServerDiagnosticsCTRL;
        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem contentsToolStripMenuItem;
        public System.Windows.Forms.MenuStrip TopMenuBar;
    }
}
