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

namespace Opc.Ua.Configuration
{
    partial class EditComServerDlg
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
            this.ButtonsPN = new System.Windows.Forms.Panel();
            this.OkBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.ProgIdLB = new System.Windows.Forms.Label();
            this.ProgIdTB = new System.Windows.Forms.TextBox();
            this.ReconnectTimeLB = new System.Windows.Forms.Label();
            this.ReconnectTimeUD = new System.Windows.Forms.NumericUpDown();
            this.LifeTimeInMonthsUnitsLB = new System.Windows.Forms.Label();
            this.MainPN = new System.Windows.Forms.Panel();
            this.SeperatorsTB = new System.Windows.Forms.TextBox();
            this.SeperatorsLB = new System.Windows.Forms.Label();
            this.ClsidTB = new System.Windows.Forms.TextBox();
            this.ClsidLB = new System.Windows.Forms.Label();
            this.HostNameTB = new System.Windows.Forms.TextBox();
            this.HostNameLB = new System.Windows.Forms.Label();
            this.BrowseNameTB = new System.Windows.Forms.TextBox();
            this.BrowseNameLB = new System.Windows.Forms.Label();
            this.ServerTypeTB = new System.Windows.Forms.TextBox();
            this.ServerTypeLB = new System.Windows.Forms.Label();
            this.ButtonsPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ReconnectTimeUD)).BeginInit();
            this.MainPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.OkBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 186);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(577, 31);
            this.ButtonsPN.TabIndex = 0;
            // 
            // OkBTN
            // 
            this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkBTN.Location = new System.Drawing.Point(4, 4);
            this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
            this.OkBTN.TabIndex = 1;
            this.OkBTN.Text = "OK";
            this.OkBTN.UseVisualStyleBackColor = true;
            this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(498, 4);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // ProgIdLB
            // 
            this.ProgIdLB.AutoSize = true;
            this.ProgIdLB.Location = new System.Drawing.Point(7, 87);
            this.ProgIdLB.Name = "ProgIdLB";
            this.ProgIdLB.Size = new System.Drawing.Size(43, 13);
            this.ProgIdLB.TabIndex = 4;
            this.ProgIdLB.Text = "Prog ID";
            this.ProgIdLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ProgIdTB
            // 
            this.ProgIdTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ProgIdTB.Location = new System.Drawing.Point(98, 84);
            this.ProgIdTB.Name = "ProgIdTB";
            this.ProgIdTB.Size = new System.Drawing.Size(475, 20);
            this.ProgIdTB.TabIndex = 5;
            // 
            // ReconnectTimeLB
            // 
            this.ReconnectTimeLB.AutoSize = true;
            this.ReconnectTimeLB.Location = new System.Drawing.Point(7, 165);
            this.ReconnectTimeLB.Name = "ReconnectTimeLB";
            this.ReconnectTimeLB.Size = new System.Drawing.Size(86, 13);
            this.ReconnectTimeLB.TabIndex = 10;
            this.ReconnectTimeLB.Text = "Reconnect Time";
            this.ReconnectTimeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReconnectTimeUD
            // 
            this.ReconnectTimeUD.Increment = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.ReconnectTimeUD.Location = new System.Drawing.Point(99, 163);
            this.ReconnectTimeUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.ReconnectTimeUD.Name = "ReconnectTimeUD";
            this.ReconnectTimeUD.Size = new System.Drawing.Size(56, 20);
            this.ReconnectTimeUD.TabIndex = 11;
            this.ReconnectTimeUD.Value = new decimal(new int[] {
            600,
            0,
            0,
            0});
            // 
            // LifeTimeInMonthsUnitsLB
            // 
            this.LifeTimeInMonthsUnitsLB.AutoSize = true;
            this.LifeTimeInMonthsUnitsLB.Location = new System.Drawing.Point(163, 165);
            this.LifeTimeInMonthsUnitsLB.Name = "LifeTimeInMonthsUnitsLB";
            this.LifeTimeInMonthsUnitsLB.Size = new System.Drawing.Size(49, 13);
            this.LifeTimeInMonthsUnitsLB.TabIndex = 12;
            this.LifeTimeInMonthsUnitsLB.Text = "Seconds";
            this.LifeTimeInMonthsUnitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.ServerTypeTB);
            this.MainPN.Controls.Add(this.ServerTypeLB);
            this.MainPN.Controls.Add(this.SeperatorsTB);
            this.MainPN.Controls.Add(this.SeperatorsLB);
            this.MainPN.Controls.Add(this.ClsidTB);
            this.MainPN.Controls.Add(this.ClsidLB);
            this.MainPN.Controls.Add(this.HostNameTB);
            this.MainPN.Controls.Add(this.HostNameLB);
            this.MainPN.Controls.Add(this.BrowseNameTB);
            this.MainPN.Controls.Add(this.BrowseNameLB);
            this.MainPN.Controls.Add(this.LifeTimeInMonthsUnitsLB);
            this.MainPN.Controls.Add(this.ReconnectTimeUD);
            this.MainPN.Controls.Add(this.ReconnectTimeLB);
            this.MainPN.Controls.Add(this.ProgIdTB);
            this.MainPN.Controls.Add(this.ProgIdLB);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Size = new System.Drawing.Size(577, 186);
            this.MainPN.TabIndex = 1;
            // 
            // SeperatorsTB
            // 
            this.SeperatorsTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SeperatorsTB.Location = new System.Drawing.Point(98, 136);
            this.SeperatorsTB.Name = "SeperatorsTB";
            this.SeperatorsTB.Size = new System.Drawing.Size(475, 20);
            this.SeperatorsTB.TabIndex = 9;
            // 
            // SeperatorsLB
            // 
            this.SeperatorsLB.AutoSize = true;
            this.SeperatorsLB.Location = new System.Drawing.Point(7, 139);
            this.SeperatorsLB.Name = "SeperatorsLB";
            this.SeperatorsLB.Size = new System.Drawing.Size(83, 13);
            this.SeperatorsLB.TabIndex = 8;
            this.SeperatorsLB.Text = "Seperator Chars";
            this.SeperatorsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ClsidTB
            // 
            this.ClsidTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ClsidTB.Location = new System.Drawing.Point(98, 110);
            this.ClsidTB.Name = "ClsidTB";
            this.ClsidTB.Size = new System.Drawing.Size(475, 20);
            this.ClsidTB.TabIndex = 7;
            // 
            // ClsidLB
            // 
            this.ClsidLB.AutoSize = true;
            this.ClsidLB.Location = new System.Drawing.Point(7, 113);
            this.ClsidLB.Name = "ClsidLB";
            this.ClsidLB.Size = new System.Drawing.Size(38, 13);
            this.ClsidLB.TabIndex = 6;
            this.ClsidLB.Text = "CLSID";
            this.ClsidLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HostNameTB
            // 
            this.HostNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HostNameTB.Location = new System.Drawing.Point(98, 58);
            this.HostNameTB.Name = "HostNameTB";
            this.HostNameTB.Size = new System.Drawing.Size(475, 20);
            this.HostNameTB.TabIndex = 3;
            // 
            // HostNameLB
            // 
            this.HostNameLB.AutoSize = true;
            this.HostNameLB.Location = new System.Drawing.Point(7, 61);
            this.HostNameLB.Name = "HostNameLB";
            this.HostNameLB.Size = new System.Drawing.Size(60, 13);
            this.HostNameLB.TabIndex = 2;
            this.HostNameLB.Text = "Host Name";
            this.HostNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BrowseNameTB
            // 
            this.BrowseNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseNameTB.Location = new System.Drawing.Point(98, 32);
            this.BrowseNameTB.Name = "BrowseNameTB";
            this.BrowseNameTB.Size = new System.Drawing.Size(475, 20);
            this.BrowseNameTB.TabIndex = 1;
            // 
            // BrowseNameLB
            // 
            this.BrowseNameLB.AutoSize = true;
            this.BrowseNameLB.Location = new System.Drawing.Point(7, 35);
            this.BrowseNameLB.Name = "BrowseNameLB";
            this.BrowseNameLB.Size = new System.Drawing.Size(73, 13);
            this.BrowseNameLB.TabIndex = 0;
            this.BrowseNameLB.Text = "Browse Name";
            this.BrowseNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerTypeTB
            // 
            this.ServerTypeTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ServerTypeTB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerTypeTB.Location = new System.Drawing.Point(98, 6);
            this.ServerTypeTB.Name = "ServerTypeTB";
            this.ServerTypeTB.ReadOnly = true;
            this.ServerTypeTB.Size = new System.Drawing.Size(475, 20);
            this.ServerTypeTB.TabIndex = 14;
            // 
            // ServerTypeLB
            // 
            this.ServerTypeLB.AutoSize = true;
            this.ServerTypeLB.Location = new System.Drawing.Point(7, 8);
            this.ServerTypeLB.Name = "ServerTypeLB";
            this.ServerTypeLB.Size = new System.Drawing.Size(65, 13);
            this.ServerTypeLB.TabIndex = 13;
            this.ServerTypeLB.Text = "Server Type";
            this.ServerTypeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EditComServerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 217);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.MaximumSize = new System.Drawing.Size(1024, 1024);
            this.MinimumSize = new System.Drawing.Size(409, 255);
            this.Name = "EditComServerDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Wrapped COM Server";
            this.ButtonsPN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ReconnectTimeUD)).EndInit();
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Label ProgIdLB;
        private System.Windows.Forms.TextBox ProgIdTB;
        private System.Windows.Forms.Label ReconnectTimeLB;
        private System.Windows.Forms.NumericUpDown ReconnectTimeUD;
        private System.Windows.Forms.Label LifeTimeInMonthsUnitsLB;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.TextBox SeperatorsTB;
        private System.Windows.Forms.Label SeperatorsLB;
        private System.Windows.Forms.TextBox ClsidTB;
        private System.Windows.Forms.Label ClsidLB;
        private System.Windows.Forms.TextBox HostNameTB;
        private System.Windows.Forms.Label HostNameLB;
        private System.Windows.Forms.TextBox BrowseNameTB;
        private System.Windows.Forms.Label BrowseNameLB;
        private System.Windows.Forms.TextBox ServerTypeTB;
        private System.Windows.Forms.Label ServerTypeLB;
    }
}
