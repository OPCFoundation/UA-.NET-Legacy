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
    partial class AcceptCertificateDlg
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ErrorTextLB = new System.Windows.Forms.Label();
            this.CertificateInfoCB = new System.Windows.Forms.GroupBox();
            this.IssuerTB = new System.Windows.Forms.Label();
            this.ValidToTB = new System.Windows.Forms.Label();
            this.ValidFromTB = new System.Windows.Forms.Label();
            this.ThumbprintTB = new System.Windows.Forms.Label();
            this.SubjectTB = new System.Windows.Forms.Label();
            this.AvailableResponsesGB = new System.Windows.Forms.GroupBox();
            this.AlwaysAcceptAllRB = new System.Windows.Forms.RadioButton();
            this.AlwaysAcceptSingleRB = new System.Windows.Forms.RadioButton();
            this.OneTimeAcceptRB = new System.Windows.Forms.RadioButton();
            this.AlwaysRejectRB = new System.Windows.Forms.RadioButton();
            this.OneTimeRejectRB = new System.Windows.Forms.RadioButton();
            this.ButtonsPN = new System.Windows.Forms.Panel();
            this.OK = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.CertificateInfoCB.SuspendLayout();
            this.AvailableResponsesGB.SuspendLayout();
            this.ButtonsPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Subject";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Issuer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Valid To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valid From";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Thumbprint";
            // 
            // ErrorTextLB
            // 
            this.ErrorTextLB.AutoSize = true;
            this.ErrorTextLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ErrorTextLB.ForeColor = System.Drawing.Color.Red;
            this.ErrorTextLB.Location = new System.Drawing.Point(7, 9);
            this.ErrorTextLB.Name = "ErrorTextLB";
            this.ErrorTextLB.Size = new System.Drawing.Size(447, 20);
            this.ErrorTextLB.TabIndex = 5;
            this.ErrorTextLB.Text = "A client used an untrusted certificate to establish a connection";
            // 
            // CertificateInfoCB
            // 
            this.CertificateInfoCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CertificateInfoCB.Controls.Add(this.SubjectTB);
            this.CertificateInfoCB.Controls.Add(this.ThumbprintTB);
            this.CertificateInfoCB.Controls.Add(this.ValidFromTB);
            this.CertificateInfoCB.Controls.Add(this.ValidToTB);
            this.CertificateInfoCB.Controls.Add(this.IssuerTB);
            this.CertificateInfoCB.Controls.Add(this.label5);
            this.CertificateInfoCB.Controls.Add(this.label1);
            this.CertificateInfoCB.Controls.Add(this.label2);
            this.CertificateInfoCB.Controls.Add(this.label4);
            this.CertificateInfoCB.Controls.Add(this.label3);
            this.CertificateInfoCB.Location = new System.Drawing.Point(2, 37);
            this.CertificateInfoCB.Name = "CertificateInfoCB";
            this.CertificateInfoCB.Size = new System.Drawing.Size(529, 144);
            this.CertificateInfoCB.TabIndex = 6;
            this.CertificateInfoCB.TabStop = false;
            this.CertificateInfoCB.Text = "Certificate Information";
            // 
            // IssuerTB
            // 
            this.IssuerTB.AutoSize = true;
            this.IssuerTB.Location = new System.Drawing.Point(70, 48);
            this.IssuerTB.Name = "IssuerTB";
            this.IssuerTB.Size = new System.Drawing.Size(49, 13);
            this.IssuerTB.TabIndex = 5;
            this.IssuerTB.Text = "IssuerTB";
            // 
            // ValidToTB
            // 
            this.ValidToTB.AutoSize = true;
            this.ValidToTB.Location = new System.Drawing.Point(70, 72);
            this.ValidToTB.Name = "ValidToTB";
            this.ValidToTB.Size = new System.Drawing.Size(57, 13);
            this.ValidToTB.TabIndex = 6;
            this.ValidToTB.Text = "ValidToTB";
            // 
            // ValidFromTB
            // 
            this.ValidFromTB.AutoSize = true;
            this.ValidFromTB.Location = new System.Drawing.Point(70, 96);
            this.ValidFromTB.Name = "ValidFromTB";
            this.ValidFromTB.Size = new System.Drawing.Size(67, 13);
            this.ValidFromTB.TabIndex = 7;
            this.ValidFromTB.Text = "ValidFromTB";
            // 
            // ThumbprintTB
            // 
            this.ThumbprintTB.AutoSize = true;
            this.ThumbprintTB.Location = new System.Drawing.Point(70, 120);
            this.ThumbprintTB.Name = "ThumbprintTB";
            this.ThumbprintTB.Size = new System.Drawing.Size(74, 13);
            this.ThumbprintTB.TabIndex = 8;
            this.ThumbprintTB.Text = "ThumbprintTB";
            // 
            // SubjectTB
            // 
            this.SubjectTB.AutoSize = true;
            this.SubjectTB.Location = new System.Drawing.Point(70, 24);
            this.SubjectTB.Name = "SubjectTB";
            this.SubjectTB.Size = new System.Drawing.Size(57, 13);
            this.SubjectTB.TabIndex = 7;
            this.SubjectTB.Text = "SubjectTB";
            // 
            // AvailableResponsesGB
            // 
            this.AvailableResponsesGB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AvailableResponsesGB.Controls.Add(this.OneTimeRejectRB);
            this.AvailableResponsesGB.Controls.Add(this.AlwaysRejectRB);
            this.AvailableResponsesGB.Controls.Add(this.OneTimeAcceptRB);
            this.AvailableResponsesGB.Controls.Add(this.AlwaysAcceptSingleRB);
            this.AvailableResponsesGB.Controls.Add(this.AlwaysAcceptAllRB);
            this.AvailableResponsesGB.Location = new System.Drawing.Point(2, 187);
            this.AvailableResponsesGB.Name = "AvailableResponsesGB";
            this.AvailableResponsesGB.Size = new System.Drawing.Size(529, 147);
            this.AvailableResponsesGB.TabIndex = 7;
            this.AvailableResponsesGB.TabStop = false;
            this.AvailableResponsesGB.Text = "Available Responses";
            // 
            // AlwaysAcceptAllRB
            // 
            this.AlwaysAcceptAllRB.AutoSize = true;
            this.AlwaysAcceptAllRB.Location = new System.Drawing.Point(9, 23);
            this.AlwaysAcceptAllRB.Name = "AlwaysAcceptAllRB";
            this.AlwaysAcceptAllRB.Size = new System.Drawing.Size(483, 17);
            this.AlwaysAcceptAllRB.TabIndex = 0;
            this.AlwaysAcceptAllRB.TabStop = true;
            this.AlwaysAcceptAllRB.Text = "Always accept the certificate and allow it to be used to connect to all UA server" +
    "s on the machine.";
            this.AlwaysAcceptAllRB.UseVisualStyleBackColor = true;
            // 
            // AlwaysAcceptSingleRB
            // 
            this.AlwaysAcceptSingleRB.AutoSize = true;
            this.AlwaysAcceptSingleRB.Location = new System.Drawing.Point(9, 46);
            this.AlwaysAcceptSingleRB.Name = "AlwaysAcceptSingleRB";
            this.AlwaysAcceptSingleRB.Size = new System.Drawing.Size(427, 17);
            this.AlwaysAcceptSingleRB.TabIndex = 1;
            this.AlwaysAcceptSingleRB.TabStop = true;
            this.AlwaysAcceptSingleRB.Text = "Always accept the certificate but only allow it to be used to connect to this UA " +
    "server.";
            this.AlwaysAcceptSingleRB.UseVisualStyleBackColor = true;
            // 
            // OneTimeAcceptRB
            // 
            this.OneTimeAcceptRB.AutoSize = true;
            this.OneTimeAcceptRB.Location = new System.Drawing.Point(9, 69);
            this.OneTimeAcceptRB.Name = "OneTimeAcceptRB";
            this.OneTimeAcceptRB.Size = new System.Drawing.Size(381, 17);
            this.OneTimeAcceptRB.TabIndex = 2;
            this.OneTimeAcceptRB.TabStop = true;
            this.OneTimeAcceptRB.Text = "Temporarily accept the certificate for use with this UA server until it restarts." +
    " ";
            this.OneTimeAcceptRB.UseVisualStyleBackColor = true;
            // 
            // AlwaysRejectRB
            // 
            this.AlwaysRejectRB.AutoSize = true;
            this.AlwaysRejectRB.Location = new System.Drawing.Point(9, 115);
            this.AlwaysRejectRB.Name = "AlwaysRejectRB";
            this.AlwaysRejectRB.Size = new System.Drawing.Size(155, 17);
            this.AlwaysRejectRB.TabIndex = 3;
            this.AlwaysRejectRB.TabStop = true;
            this.AlwaysRejectRB.Text = "Always reject the certficate.";
            this.AlwaysRejectRB.UseVisualStyleBackColor = true;
            // 
            // OneTimeRejectRB
            // 
            this.OneTimeRejectRB.AutoSize = true;
            this.OneTimeRejectRB.Location = new System.Drawing.Point(9, 92);
            this.OneTimeRejectRB.Name = "OneTimeRejectRB";
            this.OneTimeRejectRB.Size = new System.Drawing.Size(359, 17);
            this.OneTimeRejectRB.TabIndex = 4;
            this.OneTimeRejectRB.TabStop = true;
            this.OneTimeRejectRB.Text = "Reject the certificate this time (will be prompted the next time it is used).";
            this.OneTimeRejectRB.UseVisualStyleBackColor = true;
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Controls.Add(this.OK);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 335);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(534, 31);
            this.ButtonsPN.TabIndex = 8;
            // 
            // OK
            // 
            this.OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OK.Location = new System.Drawing.Point(3, 5);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 0;
            this.OK.Text = "OK";
            this.OK.UseVisualStyleBackColor = true;
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(456, 5);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 1;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // AcceptCertificateDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 366);
            this.Controls.Add(this.ButtonsPN);
            this.Controls.Add(this.AvailableResponsesGB);
            this.Controls.Add(this.CertificateInfoCB);
            this.Controls.Add(this.ErrorTextLB);
            this.MinimumSize = new System.Drawing.Size(550, 402);
            this.Name = "AcceptCertificateDlg";
            this.Text = "Certificate Validation Error";
            this.CertificateInfoCB.ResumeLayout(false);
            this.CertificateInfoCB.PerformLayout();
            this.AvailableResponsesGB.ResumeLayout(false);
            this.AvailableResponsesGB.PerformLayout();
            this.ButtonsPN.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ErrorTextLB;
        private System.Windows.Forms.GroupBox CertificateInfoCB;
        private System.Windows.Forms.Label SubjectTB;
        private System.Windows.Forms.Label ThumbprintTB;
        private System.Windows.Forms.Label ValidFromTB;
        private System.Windows.Forms.Label ValidToTB;
        private System.Windows.Forms.Label IssuerTB;
        private System.Windows.Forms.GroupBox AvailableResponsesGB;
        private System.Windows.Forms.RadioButton AlwaysAcceptSingleRB;
        private System.Windows.Forms.RadioButton AlwaysAcceptAllRB;
        private System.Windows.Forms.RadioButton OneTimeRejectRB;
        private System.Windows.Forms.RadioButton AlwaysRejectRB;
        private System.Windows.Forms.RadioButton OneTimeAcceptRB;
        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Button OK;
    }
}
