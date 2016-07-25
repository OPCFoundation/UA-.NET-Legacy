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
    partial class CreateSslBindingDlg
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
            this.ButtonsPN = new System.Windows.Forms.Panel();
            this.OkBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.MainPN = new System.Windows.Forms.Panel();
            this.LayoutPN = new System.Windows.Forms.TableLayoutPanel();
            this.CertificateStoreBTN = new System.Windows.Forms.Button();
            this.CertificateStoreTB = new System.Windows.Forms.TextBox();
            this.CertificateStoreLB = new System.Windows.Forms.Label();
            this.PortLB = new System.Windows.Forms.Label();
            this.IPAddressTB = new System.Windows.Forms.TextBox();
            this.IPAddressLB = new System.Windows.Forms.Label();
            this.CertificateLB = new System.Windows.Forms.Label();
            this.CertificateTB = new System.Windows.Forms.TextBox();
            this.CertificateBTN = new System.Windows.Forms.Button();
            this.PortUD = new System.Windows.Forms.NumericUpDown();
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewBindingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteBindingMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ButtonsPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.LayoutPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUD)).BeginInit();
            this.PopupMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.OkBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 115);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(464, 31);
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
            this.CancelBTN.Location = new System.Drawing.Point(385, 4);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.LayoutPN);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.MainPN.Size = new System.Drawing.Size(464, 115);
            this.MainPN.TabIndex = 1;
            // 
            // LayoutPN
            // 
            this.LayoutPN.ColumnCount = 3;
            this.LayoutPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.LayoutPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.LayoutPN.Controls.Add(this.CertificateStoreBTN, 2, 3);
            this.LayoutPN.Controls.Add(this.CertificateStoreTB, 1, 3);
            this.LayoutPN.Controls.Add(this.CertificateStoreLB, 0, 3);
            this.LayoutPN.Controls.Add(this.PortLB, 0, 1);
            this.LayoutPN.Controls.Add(this.IPAddressTB, 1, 0);
            this.LayoutPN.Controls.Add(this.IPAddressLB, 0, 0);
            this.LayoutPN.Controls.Add(this.CertificateLB, 0, 2);
            this.LayoutPN.Controls.Add(this.CertificateTB, 1, 2);
            this.LayoutPN.Controls.Add(this.CertificateBTN, 2, 2);
            this.LayoutPN.Controls.Add(this.PortUD, 1, 1);
            this.LayoutPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LayoutPN.Location = new System.Drawing.Point(3, 3);
            this.LayoutPN.Name = "LayoutPN";
            this.LayoutPN.RowCount = 5;
            this.LayoutPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.LayoutPN.Size = new System.Drawing.Size(458, 112);
            this.LayoutPN.TabIndex = 0;
            // 
            // CertificateStoreBTN
            // 
            this.CertificateStoreBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.CertificateStoreBTN.Enabled = false;
            this.CertificateStoreBTN.Location = new System.Drawing.Point(427, 84);
            this.CertificateStoreBTN.Name = "CertificateStoreBTN";
            this.CertificateStoreBTN.Size = new System.Drawing.Size(28, 23);
            this.CertificateStoreBTN.TabIndex = 9;
            this.CertificateStoreBTN.Text = "...";
            this.CertificateStoreBTN.UseVisualStyleBackColor = true;
            this.CertificateStoreBTN.Click += new System.EventHandler(this.CertificateStoreBTN_Click);
            // 
            // CertificateStoreTB
            // 
            this.CertificateStoreTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CertificateStoreTB.Location = new System.Drawing.Point(91, 84);
            this.CertificateStoreTB.Name = "CertificateStoreTB";
            this.CertificateStoreTB.Size = new System.Drawing.Size(330, 20);
            this.CertificateStoreTB.TabIndex = 8;
            // 
            // CertificateStoreLB
            // 
            this.CertificateStoreLB.AutoSize = true;
            this.CertificateStoreLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CertificateStoreLB.Location = new System.Drawing.Point(3, 81);
            this.CertificateStoreLB.Name = "CertificateStoreLB";
            this.CertificateStoreLB.Size = new System.Drawing.Size(82, 29);
            this.CertificateStoreLB.TabIndex = 7;
            this.CertificateStoreLB.Text = "Certificate Store";
            this.CertificateStoreLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PortLB
            // 
            this.PortLB.AutoSize = true;
            this.PortLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PortLB.Location = new System.Drawing.Point(3, 26);
            this.PortLB.Name = "PortLB";
            this.PortLB.Size = new System.Drawing.Size(82, 26);
            this.PortLB.TabIndex = 2;
            this.PortLB.Text = "Port";
            this.PortLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IPAddressTB
            // 
            this.IPAddressTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPAddressTB.Location = new System.Drawing.Point(91, 3);
            this.IPAddressTB.Name = "IPAddressTB";
            this.IPAddressTB.Size = new System.Drawing.Size(330, 20);
            this.IPAddressTB.TabIndex = 1;
            // 
            // IPAddressLB
            // 
            this.IPAddressLB.AutoSize = true;
            this.IPAddressLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPAddressLB.Location = new System.Drawing.Point(3, 0);
            this.IPAddressLB.Name = "IPAddressLB";
            this.IPAddressLB.Size = new System.Drawing.Size(82, 26);
            this.IPAddressLB.TabIndex = 0;
            this.IPAddressLB.Text = "IP Address";
            this.IPAddressLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CertificateLB
            // 
            this.CertificateLB.AutoSize = true;
            this.CertificateLB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CertificateLB.Location = new System.Drawing.Point(3, 52);
            this.CertificateLB.Name = "CertificateLB";
            this.CertificateLB.Size = new System.Drawing.Size(82, 29);
            this.CertificateLB.TabIndex = 4;
            this.CertificateLB.Text = "Certificate";
            this.CertificateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CertificateTB
            // 
            this.CertificateTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CertificateTB.Location = new System.Drawing.Point(91, 55);
            this.CertificateTB.Name = "CertificateTB";
            this.CertificateTB.Size = new System.Drawing.Size(330, 20);
            this.CertificateTB.TabIndex = 5;
            // 
            // CertificateBTN
            // 
            this.CertificateBTN.Dock = System.Windows.Forms.DockStyle.Left;
            this.CertificateBTN.Location = new System.Drawing.Point(427, 55);
            this.CertificateBTN.Name = "CertificateBTN";
            this.CertificateBTN.Size = new System.Drawing.Size(28, 23);
            this.CertificateBTN.TabIndex = 6;
            this.CertificateBTN.Text = "...";
            this.CertificateBTN.UseVisualStyleBackColor = true;
            this.CertificateBTN.Click += new System.EventHandler(this.CertificateBTN_Click);
            // 
            // PortUD
            // 
            this.PortUD.Dock = System.Windows.Forms.DockStyle.Left;
            this.PortUD.Location = new System.Drawing.Point(91, 29);
            this.PortUD.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PortUD.Name = "PortUD";
            this.PortUD.Size = new System.Drawing.Size(120, 20);
            this.PortUD.TabIndex = 3;
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewBindingMI,
            this.DeleteBindingMI});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(117, 48);
            // 
            // NewBindingMI
            // 
            this.NewBindingMI.Name = "NewBindingMI";
            this.NewBindingMI.Size = new System.Drawing.Size(116, 22);
            this.NewBindingMI.Text = "New...";
            // 
            // DeleteBindingMI
            // 
            this.DeleteBindingMI.Name = "DeleteBindingMI";
            this.DeleteBindingMI.Size = new System.Drawing.Size(116, 22);
            this.DeleteBindingMI.Text = "Delete...";
            // 
            // CreateSslBindingDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 146);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.MaximumSize = new System.Drawing.Size(1024, 184);
            this.MinimumSize = new System.Drawing.Size(480, 184);
            this.Name = "CreateSslBindingDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create SSL/TLS Binding";
            this.ButtonsPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.LayoutPN.ResumeLayout(false);
            this.LayoutPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PortUD)).EndInit();
            this.PopupMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripMenuItem DeleteBindingMI;
        private System.Windows.Forms.ToolStripMenuItem NewBindingMI;
        private System.Windows.Forms.TableLayoutPanel LayoutPN;
        private System.Windows.Forms.TextBox IPAddressTB;
        private System.Windows.Forms.Label IPAddressLB;
        private System.Windows.Forms.Label CertificateLB;
        private System.Windows.Forms.TextBox CertificateTB;
        private System.Windows.Forms.Button CertificateBTN;
        private System.Windows.Forms.Label PortLB;
        private System.Windows.Forms.NumericUpDown PortUD;
        private System.Windows.Forms.Button CertificateStoreBTN;
        private System.Windows.Forms.TextBox CertificateStoreTB;
        private System.Windows.Forms.Label CertificateStoreLB;
    }
}
