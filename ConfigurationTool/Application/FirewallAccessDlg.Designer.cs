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
    partial class FirewallAccessDlg
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
            this.RemoveBTN = new System.Windows.Forms.Button();
            this.AddBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.MainPN = new System.Windows.Forms.Panel();
            this.PortsInUseLB = new System.Windows.Forms.Label();
            this.AccessGrantedLB = new System.Windows.Forms.Label();
            this.ApplicationAccessGrantedCK = new System.Windows.Forms.CheckBox();
            this.PortsLV = new System.Windows.Forms.ListView();
            this.PortCH = new System.Windows.Forms.ColumnHeader();
            this.PortsPN = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ButtonsPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.PortsPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.RemoveBTN);
            this.ButtonsPN.Controls.Add(this.AddBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 279);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(434, 31);
            this.ButtonsPN.TabIndex = 0;
            // 
            // RemoveBTN
            // 
            this.RemoveBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveBTN.Location = new System.Drawing.Point(85, 4);
            this.RemoveBTN.Name = "RemoveBTN";
            this.RemoveBTN.Size = new System.Drawing.Size(75, 23);
            this.RemoveBTN.TabIndex = 2;
            this.RemoveBTN.Text = "Remove";
            this.RemoveBTN.UseVisualStyleBackColor = true;
            this.RemoveBTN.Click += new System.EventHandler(this.RemoveBTN_Click);
            // 
            // AddBTN
            // 
            this.AddBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddBTN.Location = new System.Drawing.Point(4, 4);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(75, 23);
            this.AddBTN.TabIndex = 1;
            this.AddBTN.Text = "Add...";
            this.AddBTN.UseVisualStyleBackColor = true;
            this.AddBTN.Click += new System.EventHandler(this.AddTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(355, 4);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Done";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.PortsPN);
            this.MainPN.Controls.Add(this.PortsInUseLB);
            this.MainPN.Controls.Add(this.AccessGrantedLB);
            this.MainPN.Controls.Add(this.ApplicationAccessGrantedCK);
            this.MainPN.Controls.Add(this.PortsLV);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Size = new System.Drawing.Size(434, 279);
            this.MainPN.TabIndex = 1;
            // 
            // PortsInUseLB
            // 
            this.PortsInUseLB.AutoSize = true;
            this.PortsInUseLB.Location = new System.Drawing.Point(3, 37);
            this.PortsInUseLB.Name = "PortsInUseLB";
            this.PortsInUseLB.Size = new System.Drawing.Size(128, 13);
            this.PortsInUseLB.TabIndex = 3;
            this.PortsInUseLB.Text = "Ports Used by Application";
            // 
            // AccessGrantedLB
            // 
            this.AccessGrantedLB.AutoSize = true;
            this.AccessGrantedLB.Location = new System.Drawing.Point(3, 9);
            this.AccessGrantedLB.Name = "AccessGrantedLB";
            this.AccessGrantedLB.Size = new System.Drawing.Size(138, 13);
            this.AccessGrantedLB.TabIndex = 2;
            this.AccessGrantedLB.Text = "Application Access Granted";
            // 
            // ApplicationAccessGrantedCK
            // 
            this.ApplicationAccessGrantedCK.AutoSize = true;
            this.ApplicationAccessGrantedCK.Location = new System.Drawing.Point(150, 9);
            this.ApplicationAccessGrantedCK.Name = "ApplicationAccessGrantedCK";
            this.ApplicationAccessGrantedCK.Size = new System.Drawing.Size(15, 14);
            this.ApplicationAccessGrantedCK.TabIndex = 1;
            this.ApplicationAccessGrantedCK.UseVisualStyleBackColor = true;
            this.ApplicationAccessGrantedCK.CheckedChanged += new System.EventHandler(this.ApplicationAccessGrantedCK_CheckedChanged);
            // 
            // PortsLV
            // 
            this.PortsLV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PortsLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PortCH});
            this.PortsLV.FullRowSelect = true;
            this.PortsLV.Location = new System.Drawing.Point(4, 60);
            this.PortsLV.Name = "PortsLV";
            this.PortsLV.Size = new System.Drawing.Size(426, 216);
            this.PortsLV.TabIndex = 0;
            this.PortsLV.UseCompatibleStateImageBehavior = false;
            this.PortsLV.View = System.Windows.Forms.View.Details;
            // 
            // PortCH
            // 
            this.PortCH.Text = "Open Port";
            this.PortCH.Width = 400;
            // 
            // PortsPN
            // 
            this.PortsPN.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PortsPN.Controls.Add(this.checkBox1);
            this.PortsPN.Location = new System.Drawing.Point(147, 32);
            this.PortsPN.Name = "PortsPN";
            this.PortsPN.Size = new System.Drawing.Size(283, 22);
            this.PortsPN.TabIndex = 7;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // FirewallAccessDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 310);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.MaximumSize = new System.Drawing.Size(1024, 2048);
            this.MinimumSize = new System.Drawing.Size(450, 145);
            this.Name = "FirewallAccessDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Open Firewall Ports";
            this.ButtonsPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.PortsPN.ResumeLayout(false);
            this.PortsPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.Button RemoveBTN;
        private System.Windows.Forms.ListView PortsLV;
        private System.Windows.Forms.ColumnHeader PortCH;
        private System.Windows.Forms.CheckBox ApplicationAccessGrantedCK;
        private System.Windows.Forms.Label PortsInUseLB;
        private System.Windows.Forms.Label AccessGrantedLB;
        private System.Windows.Forms.FlowLayoutPanel PortsPN;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}
