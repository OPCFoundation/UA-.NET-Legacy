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

namespace Quickstarts.ComDataAccessServer
{
    partial class SelectComServerDlg
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
            this.OkBTN = new System.Windows.Forms.Button();
            this.ButtonsPN = new System.Windows.Forms.Panel();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.MainPN = new System.Windows.Forms.Panel();
            this.ServersLV = new System.Windows.Forms.ListView();
            this.ProgIdCH = new System.Windows.Forms.ColumnHeader();
            this.NameCH = new System.Windows.Forms.ColumnHeader();
            this.AddressPN = new System.Windows.Forms.Panel();
            this.HostLB = new System.Windows.Forms.Label();
            this.HostCB = new System.Windows.Forms.ComboBox();
            this.RefreshBTN = new System.Windows.Forms.Button();
            this.ButtonsPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.AddressPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkBTN
            // 
            this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkBTN.Location = new System.Drawing.Point(3, 7);
            this.OkBTN.Name = "OkBTN";
            this.OkBTN.Size = new System.Drawing.Size(75, 23);
            this.OkBTN.TabIndex = 0;
            this.OkBTN.Text = "OK";
            this.OkBTN.UseVisualStyleBackColor = true;
            this.OkBTN.Click += new System.EventHandler(this.OkBTN_Click);
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Controls.Add(this.OkBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 408);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(664, 35);
            this.ButtonsPN.TabIndex = 4;
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(586, 7);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 1;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.ServersLV);
            this.MainPN.Controls.Add(this.AddressPN);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3);
            this.MainPN.Size = new System.Drawing.Size(664, 408);
            this.MainPN.TabIndex = 6;
            // 
            // ServersLV
            // 
            this.ServersLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ProgIdCH,
            this.NameCH});
            this.ServersLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServersLV.FullRowSelect = true;
            this.ServersLV.Location = new System.Drawing.Point(3, 35);
            this.ServersLV.MultiSelect = false;
            this.ServersLV.Name = "ServersLV";
            this.ServersLV.Size = new System.Drawing.Size(658, 370);
            this.ServersLV.TabIndex = 4;
            this.ServersLV.UseCompatibleStateImageBehavior = false;
            this.ServersLV.View = System.Windows.Forms.View.Details;
            this.ServersLV.DoubleClick += new System.EventHandler(this.OkBTN_Click);
            // 
            // ProgIdCH
            // 
            this.ProgIdCH.Text = "Prog ID";
            this.ProgIdCH.Width = 394;
            // 
            // NameCH
            // 
            this.NameCH.Text = "Server Name";
            this.NameCH.Width = 172;
            // 
            // AddressPN
            // 
            this.AddressPN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.AddressPN.Controls.Add(this.RefreshBTN);
            this.AddressPN.Controls.Add(this.HostLB);
            this.AddressPN.Controls.Add(this.HostCB);
            this.AddressPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.AddressPN.Location = new System.Drawing.Point(3, 3);
            this.AddressPN.Name = "AddressPN";
            this.AddressPN.Padding = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.AddressPN.Size = new System.Drawing.Size(658, 32);
            this.AddressPN.TabIndex = 5;
            // 
            // HostLB
            // 
            this.HostLB.AutoSize = true;
            this.HostLB.Location = new System.Drawing.Point(0, 7);
            this.HostLB.Name = "HostLB";
            this.HostLB.Size = new System.Drawing.Size(60, 13);
            this.HostLB.TabIndex = 2;
            this.HostLB.Text = "Host Name";
            this.HostLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // HostCB
            // 
            this.HostCB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.HostCB.FormattingEnabled = true;
            this.HostCB.Location = new System.Drawing.Point(66, 4);
            this.HostCB.Name = "HostCB";
            this.HostCB.Size = new System.Drawing.Size(502, 21);
            this.HostCB.TabIndex = 1;
            this.HostCB.SelectedIndexChanged += new System.EventHandler(this.HostCB_SelectedIndexChanged);
            // 
            // RefreshBTN
            // 
            this.RefreshBTN.Location = new System.Drawing.Point(574, 3);
            this.RefreshBTN.Name = "RefreshBTN";
            this.RefreshBTN.Size = new System.Drawing.Size(75, 23);
            this.RefreshBTN.TabIndex = 3;
            this.RefreshBTN.Text = "Refresh";
            this.RefreshBTN.UseVisualStyleBackColor = true;
            this.RefreshBTN.Click += new System.EventHandler(this.RefreshBTN_Click);
            // 
            // SelectComServerDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 443);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.Name = "SelectComServerDlg";
            this.Text = "Select a COM Server to Expose via UA";
            this.ButtonsPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.AddressPN.ResumeLayout(false);
            this.AddressPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.ListView ServersLV;
        private System.Windows.Forms.ColumnHeader ProgIdCH;
        private System.Windows.Forms.ColumnHeader NameCH;
        private System.Windows.Forms.Panel AddressPN;
        private System.Windows.Forms.Button RefreshBTN;
        private System.Windows.Forms.Label HostLB;
        private System.Windows.Forms.ComboBox HostCB;
    }
}
