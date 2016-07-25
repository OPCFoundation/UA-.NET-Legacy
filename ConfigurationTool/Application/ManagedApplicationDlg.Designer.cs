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
    partial class ManagedApplicationDlg
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
            this.ApplicationNameLB = new System.Windows.Forms.Label();
            this.ApplicationNameTB = new System.Windows.Forms.TextBox();
            this.ExecutableFileLB = new System.Windows.Forms.Label();
            this.ExecutableFileTB = new System.Windows.Forms.TextBox();
            this.ExecutableFileBTN = new System.Windows.Forms.Button();
            this.ConfigurationFileLB = new System.Windows.Forms.Label();
            this.ConfigurationFileTB = new System.Windows.Forms.TextBox();
            this.ConfigurationFileBTN = new System.Windows.Forms.Button();
            this.MainPN = new System.Windows.Forms.Panel();
            this.InstructionsTB = new System.Windows.Forms.TextBox();
            this.TrustListBTN = new System.Windows.Forms.Button();
            this.TrustListTB = new System.Windows.Forms.TextBox();
            this.TrustListLB = new System.Windows.Forms.Label();
            this.CertificateBTN = new System.Windows.Forms.Button();
            this.CertificateLB = new System.Windows.Forms.Label();
            this.CertificateTB = new System.Windows.Forms.TextBox();
            this.ButtonsPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.OkBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 222);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(777, 31);
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
            this.CancelBTN.Location = new System.Drawing.Point(698, 4);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // ApplicationNameLB
            // 
            this.ApplicationNameLB.AutoSize = true;
            this.ApplicationNameLB.Location = new System.Drawing.Point(3, 11);
            this.ApplicationNameLB.Name = "ApplicationNameLB";
            this.ApplicationNameLB.Size = new System.Drawing.Size(90, 13);
            this.ApplicationNameLB.TabIndex = 0;
            this.ApplicationNameLB.Text = "Application Name";
            this.ApplicationNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ApplicationNameTB
            // 
            this.ApplicationNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplicationNameTB.Location = new System.Drawing.Point(95, 8);
            this.ApplicationNameTB.Name = "ApplicationNameTB";
            this.ApplicationNameTB.Size = new System.Drawing.Size(678, 20);
            this.ApplicationNameTB.TabIndex = 1;
            // 
            // ExecutableFileLB
            // 
            this.ExecutableFileLB.AutoSize = true;
            this.ExecutableFileLB.Location = new System.Drawing.Point(3, 37);
            this.ExecutableFileLB.Name = "ExecutableFileLB";
            this.ExecutableFileLB.Size = new System.Drawing.Size(79, 13);
            this.ExecutableFileLB.TabIndex = 2;
            this.ExecutableFileLB.Text = "Executable File";
            this.ExecutableFileLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ExecutableFileTB
            // 
            this.ExecutableFileTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecutableFileTB.Location = new System.Drawing.Point(95, 34);
            this.ExecutableFileTB.Name = "ExecutableFileTB";
            this.ExecutableFileTB.Size = new System.Drawing.Size(598, 20);
            this.ExecutableFileTB.TabIndex = 3;
            // 
            // ExecutableFileBTN
            // 
            this.ExecutableFileBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ExecutableFileBTN.Location = new System.Drawing.Point(698, 32);
            this.ExecutableFileBTN.Name = "ExecutableFileBTN";
            this.ExecutableFileBTN.Size = new System.Drawing.Size(75, 23);
            this.ExecutableFileBTN.TabIndex = 4;
            this.ExecutableFileBTN.Text = "Browse...";
            this.ExecutableFileBTN.UseVisualStyleBackColor = true;
            this.ExecutableFileBTN.Click += new System.EventHandler(this.ExecutableBTN_Click);
            // 
            // ConfigurationFileLB
            // 
            this.ConfigurationFileLB.AutoSize = true;
            this.ConfigurationFileLB.Location = new System.Drawing.Point(3, 63);
            this.ConfigurationFileLB.Name = "ConfigurationFileLB";
            this.ConfigurationFileLB.Size = new System.Drawing.Size(88, 13);
            this.ConfigurationFileLB.TabIndex = 5;
            this.ConfigurationFileLB.Text = "Configuration File";
            this.ConfigurationFileLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ConfigurationFileTB
            // 
            this.ConfigurationFileTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigurationFileTB.Location = new System.Drawing.Point(95, 60);
            this.ConfigurationFileTB.Name = "ConfigurationFileTB";
            this.ConfigurationFileTB.Size = new System.Drawing.Size(598, 20);
            this.ConfigurationFileTB.TabIndex = 6;
            // 
            // ConfigurationFileBTN
            // 
            this.ConfigurationFileBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ConfigurationFileBTN.Location = new System.Drawing.Point(698, 58);
            this.ConfigurationFileBTN.Name = "ConfigurationFileBTN";
            this.ConfigurationFileBTN.Size = new System.Drawing.Size(75, 23);
            this.ConfigurationFileBTN.TabIndex = 7;
            this.ConfigurationFileBTN.Text = "Browse...";
            this.ConfigurationFileBTN.UseVisualStyleBackColor = true;
            this.ConfigurationFileBTN.Click += new System.EventHandler(this.ConfigurationBTN_Click);
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.InstructionsTB);
            this.MainPN.Controls.Add(this.TrustListBTN);
            this.MainPN.Controls.Add(this.TrustListTB);
            this.MainPN.Controls.Add(this.TrustListLB);
            this.MainPN.Controls.Add(this.CertificateBTN);
            this.MainPN.Controls.Add(this.CertificateLB);
            this.MainPN.Controls.Add(this.CertificateTB);
            this.MainPN.Controls.Add(this.ConfigurationFileBTN);
            this.MainPN.Controls.Add(this.ConfigurationFileTB);
            this.MainPN.Controls.Add(this.ConfigurationFileLB);
            this.MainPN.Controls.Add(this.ExecutableFileBTN);
            this.MainPN.Controls.Add(this.ExecutableFileTB);
            this.MainPN.Controls.Add(this.ExecutableFileLB);
            this.MainPN.Controls.Add(this.ApplicationNameTB);
            this.MainPN.Controls.Add(this.ApplicationNameLB);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Size = new System.Drawing.Size(777, 222);
            this.MainPN.TabIndex = 0;
            // 
            // InstructionsTB
            // 
            this.InstructionsTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.InstructionsTB.Location = new System.Drawing.Point(4, 138);
            this.InstructionsTB.Multiline = true;
            this.InstructionsTB.Name = "InstructionsTB";
            this.InstructionsTB.ReadOnly = true;
            this.InstructionsTB.Size = new System.Drawing.Size(769, 78);
            this.InstructionsTB.TabIndex = 14;
            // 
            // TrustListBTN
            // 
            this.TrustListBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TrustListBTN.Location = new System.Drawing.Point(698, 110);
            this.TrustListBTN.Name = "TrustListBTN";
            this.TrustListBTN.Size = new System.Drawing.Size(75, 23);
            this.TrustListBTN.TabIndex = 13;
            this.TrustListBTN.Text = "Browse...";
            this.TrustListBTN.UseVisualStyleBackColor = true;
            this.TrustListBTN.Click += new System.EventHandler(this.TrustListBTN_Click);
            // 
            // TrustListTB
            // 
            this.TrustListTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.TrustListTB.Location = new System.Drawing.Point(95, 112);
            this.TrustListTB.Name = "TrustListTB";
            this.TrustListTB.ReadOnly = true;
            this.TrustListTB.Size = new System.Drawing.Size(598, 20);
            this.TrustListTB.TabIndex = 12;
            // 
            // TrustListLB
            // 
            this.TrustListLB.AutoSize = true;
            this.TrustListLB.Location = new System.Drawing.Point(3, 115);
            this.TrustListLB.Name = "TrustListLB";
            this.TrustListLB.Size = new System.Drawing.Size(50, 13);
            this.TrustListLB.TabIndex = 11;
            this.TrustListLB.Text = "Trust List";
            this.TrustListLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CertificateBTN
            // 
            this.CertificateBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CertificateBTN.Location = new System.Drawing.Point(698, 84);
            this.CertificateBTN.Name = "CertificateBTN";
            this.CertificateBTN.Size = new System.Drawing.Size(75, 23);
            this.CertificateBTN.TabIndex = 10;
            this.CertificateBTN.Text = "Browse...";
            this.CertificateBTN.UseVisualStyleBackColor = true;
            this.CertificateBTN.Click += new System.EventHandler(this.CertificateBTN_Click);
            // 
            // CertificateLB
            // 
            this.CertificateLB.AutoSize = true;
            this.CertificateLB.Location = new System.Drawing.Point(3, 89);
            this.CertificateLB.Name = "CertificateLB";
            this.CertificateLB.Size = new System.Drawing.Size(54, 13);
            this.CertificateLB.TabIndex = 8;
            this.CertificateLB.Text = "Certificate";
            this.CertificateLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CertificateTB
            // 
            this.CertificateTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CertificateTB.Location = new System.Drawing.Point(95, 86);
            this.CertificateTB.Name = "CertificateTB";
            this.CertificateTB.ReadOnly = true;
            this.CertificateTB.Size = new System.Drawing.Size(598, 20);
            this.CertificateTB.TabIndex = 9;
            // 
            // CreateApplicationDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(777, 253);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.MaximumSize = new System.Drawing.Size(1024, 1024);
            this.MinimumSize = new System.Drawing.Size(409, 100);
            this.Name = "CreateApplicationDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modify Application Information";
            this.ButtonsPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Label ApplicationNameLB;
        private System.Windows.Forms.TextBox ApplicationNameTB;
        private System.Windows.Forms.Label ExecutableFileLB;
        private System.Windows.Forms.TextBox ExecutableFileTB;
        private System.Windows.Forms.Button ExecutableFileBTN;
        private System.Windows.Forms.Label ConfigurationFileLB;
        private System.Windows.Forms.TextBox ConfigurationFileTB;
        private System.Windows.Forms.Button ConfigurationFileBTN;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.TextBox CertificateTB;
        private System.Windows.Forms.Label CertificateLB;
        private System.Windows.Forms.Button TrustListBTN;
        private System.Windows.Forms.TextBox TrustListTB;
        private System.Windows.Forms.Label TrustListLB;
        private System.Windows.Forms.Button CertificateBTN;
        private System.Windows.Forms.TextBox InstructionsTB;
    }
}
