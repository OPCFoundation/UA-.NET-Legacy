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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.TrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Separator01 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.StartTimeLB = new System.Windows.Forms.Label();
            this.CurrentTimeLB = new System.Windows.Forms.Label();
            this.StartTimeTB = new System.Windows.Forms.TextBox();
            this.CurrentTimeTB = new System.Windows.Forms.TextBox();
            this.PopupMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrayIcon
            // 
            this.TrayIcon.ContextMenuStrip = this.PopupMenu;
            this.TrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("TrayIcon.Icon")));
            this.TrayIcon.Text = "UA Server";
            this.TrayIcon.Visible = true;
            this.TrayIcon.DoubleClick += new System.EventHandler(this.TrayIcon_DoubleClick);
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowMI,
            this.Separator01,
            this.ExitMI});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(101, 54);
            // 
            // ShowMI
            // 
            this.ShowMI.Name = "ShowMI";
            this.ShowMI.Size = new System.Drawing.Size(100, 22);
            this.ShowMI.Text = "Show";
            this.ShowMI.Click += new System.EventHandler(this.ShowMI_Click);
            // 
            // Separator01
            // 
            this.Separator01.Name = "Separator01";
            this.Separator01.Size = new System.Drawing.Size(97, 6);
            // 
            // ExitMI
            // 
            this.ExitMI.Name = "ExitMI";
            this.ExitMI.Size = new System.Drawing.Size(100, 22);
            this.ExitMI.Text = "Exit";
            this.ExitMI.Click += new System.EventHandler(this.ExitMI_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 1000;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // StartTimeLB
            // 
            this.StartTimeLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTimeLB.AutoSize = true;
            this.StartTimeLB.Location = new System.Drawing.Point(4, 9);
            this.StartTimeLB.Name = "StartTimeLB";
            this.StartTimeLB.Size = new System.Drawing.Size(55, 13);
            this.StartTimeLB.TabIndex = 4;
            this.StartTimeLB.Text = "Start Time";
            this.StartTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CurrentTimeLB
            // 
            this.CurrentTimeLB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTimeLB.AutoSize = true;
            this.CurrentTimeLB.Location = new System.Drawing.Point(4, 33);
            this.CurrentTimeLB.Name = "CurrentTimeLB";
            this.CurrentTimeLB.Size = new System.Drawing.Size(67, 13);
            this.CurrentTimeLB.TabIndex = 6;
            this.CurrentTimeLB.Text = "Current Time";
            this.CurrentTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StartTimeTB
            // 
            this.StartTimeTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.StartTimeTB.BackColor = System.Drawing.SystemColors.Window;
            this.StartTimeTB.Location = new System.Drawing.Point(73, 5);
            this.StartTimeTB.Name = "StartTimeTB";
            this.StartTimeTB.ReadOnly = true;
            this.StartTimeTB.Size = new System.Drawing.Size(136, 20);
            this.StartTimeTB.TabIndex = 5;
            // 
            // CurrentTimeTB
            // 
            this.CurrentTimeTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrentTimeTB.BackColor = System.Drawing.SystemColors.Window;
            this.CurrentTimeTB.Location = new System.Drawing.Point(73, 29);
            this.CurrentTimeTB.Name = "CurrentTimeTB";
            this.CurrentTimeTB.ReadOnly = true;
            this.CurrentTimeTB.Size = new System.Drawing.Size(136, 20);
            this.CurrentTimeTB.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 54);
            this.Controls.Add(this.StartTimeLB);
            this.Controls.Add(this.CurrentTimeLB);
            this.Controls.Add(this.StartTimeTB);
            this.Controls.Add(this.CurrentTimeTB);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(220, 88);
            this.Name = "MainForm";
            this.ShowInTaskbar = false;
            this.Text = "UA Test Server";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.PopupMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon TrayIcon;
        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripMenuItem ExitMI;
        private System.Windows.Forms.ToolStripMenuItem ShowMI;
        private System.Windows.Forms.ToolStripSeparator Separator01;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Label StartTimeLB;
        private System.Windows.Forms.Label CurrentTimeLB;
        private System.Windows.Forms.TextBox StartTimeTB;
        private System.Windows.Forms.TextBox CurrentTimeTB;
    }
}
