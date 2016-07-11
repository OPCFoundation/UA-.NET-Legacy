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
    partial class CreateAuthorityDlg
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
            this.SubjectNameLB = new System.Windows.Forms.Label();
            this.SubjectNameTB = new System.Windows.Forms.TextBox();
            this.KeySizeLB = new System.Windows.Forms.Label();
            this.KeySizeCB = new System.Windows.Forms.ComboBox();
            this.LifeTimeInMonthsLB = new System.Windows.Forms.Label();
            this.LifeTimeInMonthsUD = new System.Windows.Forms.NumericUpDown();
            this.LifeTimeInMonthsUnitsLB = new System.Windows.Forms.Label();
            this.SubjectNameCK = new System.Windows.Forms.CheckBox();
            this.MainPN = new System.Windows.Forms.Panel();
            this.VerifyPasswordTB = new System.Windows.Forms.TextBox();
            this.VerifyPasswordLB = new System.Windows.Forms.Label();
            this.IssuerPasswordTB = new System.Windows.Forms.TextBox();
            this.IssuerPasswordLB = new System.Windows.Forms.Label();
            this.PasswordTB = new System.Windows.Forms.TextBox();
            this.PasswordLB = new System.Windows.Forms.Label();
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.IssuerKeyFilePathTB = new System.Windows.Forms.TextBox();
            this.IssuerKeyFilePathLB = new System.Windows.Forms.Label();
            this.OrganizationTB = new System.Windows.Forms.TextBox();
            this.OrganizationLB = new System.Windows.Forms.Label();
            this.CertificateStoreCTRL = new Opc.Ua.Client.Controls.CertificateStoreCtrl();
            this.ButtonsPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LifeTimeInMonthsUD)).BeginInit();
            this.MainPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.OkBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 296);
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
            // ApplicationNameLB
            // 
            this.ApplicationNameLB.AutoSize = true;
            this.ApplicationNameLB.Location = new System.Drawing.Point(4, 117);
            this.ApplicationNameLB.Name = "ApplicationNameLB";
            this.ApplicationNameLB.Size = new System.Drawing.Size(79, 13);
            this.ApplicationNameLB.TabIndex = 7;
            this.ApplicationNameLB.Text = "Authority Name";
            this.ApplicationNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ApplicationNameTB
            // 
            this.ApplicationNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplicationNameTB.Location = new System.Drawing.Point(94, 114);
            this.ApplicationNameTB.Name = "ApplicationNameTB";
            this.ApplicationNameTB.Size = new System.Drawing.Size(477, 20);
            this.ApplicationNameTB.TabIndex = 8;
            this.ApplicationNameTB.TextChanged += new System.EventHandler(this.ApplicationNameTB_TextChanged);
            // 
            // SubjectNameLB
            // 
            this.SubjectNameLB.AutoSize = true;
            this.SubjectNameLB.Location = new System.Drawing.Point(4, 169);
            this.SubjectNameLB.Name = "SubjectNameLB";
            this.SubjectNameLB.Size = new System.Drawing.Size(74, 13);
            this.SubjectNameLB.TabIndex = 11;
            this.SubjectNameLB.Text = "Subject Name";
            this.SubjectNameLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubjectNameTB
            // 
            this.SubjectNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.SubjectNameTB.Enabled = false;
            this.SubjectNameTB.Location = new System.Drawing.Point(95, 166);
            this.SubjectNameTB.Name = "SubjectNameTB";
            this.SubjectNameTB.Size = new System.Drawing.Size(454, 20);
            this.SubjectNameTB.TabIndex = 12;
            // 
            // KeySizeLB
            // 
            this.KeySizeLB.AutoSize = true;
            this.KeySizeLB.Location = new System.Drawing.Point(4, 195);
            this.KeySizeLB.Name = "KeySizeLB";
            this.KeySizeLB.Size = new System.Drawing.Size(48, 13);
            this.KeySizeLB.TabIndex = 15;
            this.KeySizeLB.Text = "Key Size";
            this.KeySizeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // KeySizeCB
            // 
            this.KeySizeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.KeySizeCB.FormattingEnabled = true;
            this.KeySizeCB.Location = new System.Drawing.Point(95, 192);
            this.KeySizeCB.Name = "KeySizeCB";
            this.KeySizeCB.Size = new System.Drawing.Size(120, 21);
            this.KeySizeCB.TabIndex = 16;
            // 
            // LifeTimeInMonthsLB
            // 
            this.LifeTimeInMonthsLB.AutoSize = true;
            this.LifeTimeInMonthsLB.Location = new System.Drawing.Point(4, 222);
            this.LifeTimeInMonthsLB.Name = "LifeTimeInMonthsLB";
            this.LifeTimeInMonthsLB.Size = new System.Drawing.Size(43, 13);
            this.LifeTimeInMonthsLB.TabIndex = 17;
            this.LifeTimeInMonthsLB.Text = "Lifetime";
            this.LifeTimeInMonthsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LifeTimeInMonthsUD
            // 
            this.LifeTimeInMonthsUD.Increment = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.LifeTimeInMonthsUD.Location = new System.Drawing.Point(97, 219);
            this.LifeTimeInMonthsUD.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.LifeTimeInMonthsUD.Name = "LifeTimeInMonthsUD";
            this.LifeTimeInMonthsUD.Size = new System.Drawing.Size(56, 20);
            this.LifeTimeInMonthsUD.TabIndex = 18;
            this.LifeTimeInMonthsUD.Value = new decimal(new int[] {
            60,
            0,
            0,
            0});
            // 
            // LifeTimeInMonthsUnitsLB
            // 
            this.LifeTimeInMonthsUnitsLB.AutoSize = true;
            this.LifeTimeInMonthsUnitsLB.Location = new System.Drawing.Point(159, 222);
            this.LifeTimeInMonthsUnitsLB.Name = "LifeTimeInMonthsUnitsLB";
            this.LifeTimeInMonthsUnitsLB.Size = new System.Drawing.Size(42, 13);
            this.LifeTimeInMonthsUnitsLB.TabIndex = 19;
            this.LifeTimeInMonthsUnitsLB.Text = "Months";
            this.LifeTimeInMonthsUnitsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SubjectNameCK
            // 
            this.SubjectNameCK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SubjectNameCK.AutoSize = true;
            this.SubjectNameCK.Location = new System.Drawing.Point(558, 169);
            this.SubjectNameCK.Name = "SubjectNameCK";
            this.SubjectNameCK.Size = new System.Drawing.Size(15, 14);
            this.SubjectNameCK.TabIndex = 13;
            this.SubjectNameCK.UseVisualStyleBackColor = true;
            this.SubjectNameCK.CheckedChanged += new System.EventHandler(this.DomainsCK_CheckedChanged);
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.VerifyPasswordTB);
            this.MainPN.Controls.Add(this.VerifyPasswordLB);
            this.MainPN.Controls.Add(this.IssuerPasswordTB);
            this.MainPN.Controls.Add(this.IssuerPasswordLB);
            this.MainPN.Controls.Add(this.PasswordTB);
            this.MainPN.Controls.Add(this.PasswordLB);
            this.MainPN.Controls.Add(this.BrowseBTN);
            this.MainPN.Controls.Add(this.IssuerKeyFilePathTB);
            this.MainPN.Controls.Add(this.IssuerKeyFilePathLB);
            this.MainPN.Controls.Add(this.OrganizationTB);
            this.MainPN.Controls.Add(this.OrganizationLB);
            this.MainPN.Controls.Add(this.CertificateStoreCTRL);
            this.MainPN.Controls.Add(this.SubjectNameCK);
            this.MainPN.Controls.Add(this.LifeTimeInMonthsUnitsLB);
            this.MainPN.Controls.Add(this.LifeTimeInMonthsUD);
            this.MainPN.Controls.Add(this.LifeTimeInMonthsLB);
            this.MainPN.Controls.Add(this.KeySizeCB);
            this.MainPN.Controls.Add(this.KeySizeLB);
            this.MainPN.Controls.Add(this.SubjectNameTB);
            this.MainPN.Controls.Add(this.SubjectNameLB);
            this.MainPN.Controls.Add(this.ApplicationNameTB);
            this.MainPN.Controls.Add(this.ApplicationNameLB);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Size = new System.Drawing.Size(577, 296);
            this.MainPN.TabIndex = 0;
            // 
            // VerifyPasswordTB
            // 
            this.VerifyPasswordTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.VerifyPasswordTB.Location = new System.Drawing.Point(94, 271);
            this.VerifyPasswordTB.Name = "VerifyPasswordTB";
            this.VerifyPasswordTB.PasswordChar = '*';
            this.VerifyPasswordTB.Size = new System.Drawing.Size(477, 20);
            this.VerifyPasswordTB.TabIndex = 1;
            // 
            // VerifyPasswordLB
            // 
            this.VerifyPasswordLB.AutoSize = true;
            this.VerifyPasswordLB.Location = new System.Drawing.Point(4, 273);
            this.VerifyPasswordLB.Name = "VerifyPasswordLB";
            this.VerifyPasswordLB.Size = new System.Drawing.Size(82, 13);
            this.VerifyPasswordLB.TabIndex = 0;
            this.VerifyPasswordLB.Text = "Verify Password";
            this.VerifyPasswordLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IssuerPasswordTB
            // 
            this.IssuerPasswordTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.IssuerPasswordTB.Location = new System.Drawing.Point(94, 88);
            this.IssuerPasswordTB.Name = "IssuerPasswordTB";
            this.IssuerPasswordTB.PasswordChar = '*';
            this.IssuerPasswordTB.Size = new System.Drawing.Size(478, 20);
            this.IssuerPasswordTB.TabIndex = 6;
            // 
            // IssuerPasswordLB
            // 
            this.IssuerPasswordLB.AutoSize = true;
            this.IssuerPasswordLB.Location = new System.Drawing.Point(4, 91);
            this.IssuerPasswordLB.Name = "IssuerPasswordLB";
            this.IssuerPasswordLB.Size = new System.Drawing.Size(70, 13);
            this.IssuerPasswordLB.TabIndex = 5;
            this.IssuerPasswordLB.Text = "CA Password";
            this.IssuerPasswordLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PasswordTB
            // 
            this.PasswordTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.PasswordTB.Location = new System.Drawing.Point(94, 245);
            this.PasswordTB.Name = "PasswordTB";
            this.PasswordTB.PasswordChar = '*';
            this.PasswordTB.Size = new System.Drawing.Size(477, 20);
            this.PasswordTB.TabIndex = 21;
            // 
            // PasswordLB
            // 
            this.PasswordLB.AutoSize = true;
            this.PasswordLB.Location = new System.Drawing.Point(4, 248);
            this.PasswordLB.Name = "PasswordLB";
            this.PasswordLB.Size = new System.Drawing.Size(53, 13);
            this.PasswordLB.TabIndex = 20;
            this.PasswordLB.Text = "Password";
            this.PasswordLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BrowseBTN
            // 
            this.BrowseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseBTN.Location = new System.Drawing.Point(497, 60);
            this.BrowseBTN.Name = "BrowseBTN";
            this.BrowseBTN.Size = new System.Drawing.Size(75, 23);
            this.BrowseBTN.TabIndex = 4;
            this.BrowseBTN.Text = "Browse...";
            this.BrowseBTN.UseVisualStyleBackColor = true;
            this.BrowseBTN.Click += new System.EventHandler(this.BrowseBTN_Click);
            // 
            // IssuerKeyFilePathTB
            // 
            this.IssuerKeyFilePathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.IssuerKeyFilePathTB.Location = new System.Drawing.Point(95, 62);
            this.IssuerKeyFilePathTB.Name = "IssuerKeyFilePathTB";
            this.IssuerKeyFilePathTB.Size = new System.Drawing.Size(398, 20);
            this.IssuerKeyFilePathTB.TabIndex = 3;
            // 
            // IssuerKeyFilePathLB
            // 
            this.IssuerKeyFilePathLB.AutoSize = true;
            this.IssuerKeyFilePathLB.Location = new System.Drawing.Point(4, 65);
            this.IssuerKeyFilePathLB.Name = "IssuerKeyFilePathLB";
            this.IssuerKeyFilePathLB.Size = new System.Drawing.Size(61, 13);
            this.IssuerKeyFilePathLB.TabIndex = 2;
            this.IssuerKeyFilePathLB.Text = "CA Key File";
            this.IssuerKeyFilePathLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // OrganizationTB
            // 
            this.OrganizationTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.OrganizationTB.Location = new System.Drawing.Point(94, 140);
            this.OrganizationTB.Name = "OrganizationTB";
            this.OrganizationTB.Size = new System.Drawing.Size(477, 20);
            this.OrganizationTB.TabIndex = 10;
            this.OrganizationTB.TextChanged += new System.EventHandler(this.ApplicationNameTB_TextChanged);
            // 
            // OrganizationLB
            // 
            this.OrganizationLB.AutoSize = true;
            this.OrganizationLB.Location = new System.Drawing.Point(4, 143);
            this.OrganizationLB.Name = "OrganizationLB";
            this.OrganizationLB.Size = new System.Drawing.Size(66, 13);
            this.OrganizationLB.TabIndex = 9;
            this.OrganizationLB.Text = "Organization";
            this.OrganizationLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CertificateStoreCTRL
            // 
            this.CertificateStoreCTRL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.CertificateStoreCTRL.LabelWidth = 91;
            this.CertificateStoreCTRL.Location = new System.Drawing.Point(4, 6);
            this.CertificateStoreCTRL.MinimumSize = new System.Drawing.Size(300, 51);
            this.CertificateStoreCTRL.Name = "CertificateStoreCTRL";
            this.CertificateStoreCTRL.Size = new System.Drawing.Size(568, 51);
            this.CertificateStoreCTRL.StorePath = "X:\\OPC\\Source\\UA311\\Source\\Utilities\\CertificateGenerator";
            this.CertificateStoreCTRL.TabIndex = 1;
            // 
            // CreateAuthorityDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(577, 327);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.MaximumSize = new System.Drawing.Size(1024, 1024);
            this.MinimumSize = new System.Drawing.Size(409, 290);
            this.Name = "CreateAuthorityDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create Certificate Authority";
            this.ButtonsPN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LifeTimeInMonthsUD)).EndInit();
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
        private System.Windows.Forms.Label SubjectNameLB;
        private System.Windows.Forms.TextBox SubjectNameTB;
        private System.Windows.Forms.Label KeySizeLB;
        private System.Windows.Forms.ComboBox KeySizeCB;
        private System.Windows.Forms.Label LifeTimeInMonthsLB;
        private System.Windows.Forms.NumericUpDown LifeTimeInMonthsUD;
        private System.Windows.Forms.Label LifeTimeInMonthsUnitsLB;
        private System.Windows.Forms.CheckBox SubjectNameCK;
        private System.Windows.Forms.Panel MainPN;
        private Opc.Ua.Client.Controls.CertificateStoreCtrl CertificateStoreCTRL;
        private System.Windows.Forms.TextBox OrganizationTB;
        private System.Windows.Forms.Label OrganizationLB;
        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.TextBox IssuerKeyFilePathTB;
        private System.Windows.Forms.Label IssuerKeyFilePathLB;
        private System.Windows.Forms.TextBox IssuerPasswordTB;
        private System.Windows.Forms.Label IssuerPasswordLB;
        private System.Windows.Forms.TextBox PasswordTB;
        private System.Windows.Forms.Label PasswordLB;
        private System.Windows.Forms.TextBox VerifyPasswordTB;
        private System.Windows.Forms.Label VerifyPasswordLB;
    }
}
