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
    partial class AccessRuleDlg
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
            this.MainPN = new System.Windows.Forms.Panel();
            this.AccessRightCB = new System.Windows.Forms.ComboBox();
            this.AccessRightLB = new System.Windows.Forms.Label();
            this.BrowseBTN = new System.Windows.Forms.Button();
            this.IdentityNameTB = new System.Windows.Forms.TextBox();
            this.AccessTypeCB = new System.Windows.Forms.ComboBox();
            this.AccessTypeLB = new System.Windows.Forms.Label();
            this.IdentityLB = new System.Windows.Forms.Label();
            this.ButtonsPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.OkBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 82);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(442, 31);
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
            this.CancelBTN.Location = new System.Drawing.Point(363, 4);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.AccessRightCB);
            this.MainPN.Controls.Add(this.AccessRightLB);
            this.MainPN.Controls.Add(this.BrowseBTN);
            this.MainPN.Controls.Add(this.IdentityNameTB);
            this.MainPN.Controls.Add(this.AccessTypeCB);
            this.MainPN.Controls.Add(this.AccessTypeLB);
            this.MainPN.Controls.Add(this.IdentityLB);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Size = new System.Drawing.Size(442, 82);
            this.MainPN.TabIndex = 1;
            // 
            // AccessRightCB
            // 
            this.AccessRightCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccessRightCB.FormattingEnabled = true;
            this.AccessRightCB.Location = new System.Drawing.Point(87, 31);
            this.AccessRightCB.Name = "AccessRightCB";
            this.AccessRightCB.Size = new System.Drawing.Size(183, 21);
            this.AccessRightCB.TabIndex = 3;
            // 
            // AccessRightLB
            // 
            this.AccessRightLB.AutoSize = true;
            this.AccessRightLB.Location = new System.Drawing.Point(5, 35);
            this.AccessRightLB.Name = "AccessRightLB";
            this.AccessRightLB.Size = new System.Drawing.Size(70, 13);
            this.AccessRightLB.TabIndex = 2;
            this.AccessRightLB.Text = "Access Right";
            this.AccessRightLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BrowseBTN
            // 
            this.BrowseBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BrowseBTN.Location = new System.Drawing.Point(412, 57);
            this.BrowseBTN.Name = "BrowseBTN";
            this.BrowseBTN.Size = new System.Drawing.Size(25, 22);
            this.BrowseBTN.TabIndex = 6;
            this.BrowseBTN.Text = "...";
            this.BrowseBTN.UseVisualStyleBackColor = true;
            this.BrowseBTN.Click += new System.EventHandler(this.BrowseBTN_Click);
            // 
            // IdentityNameTB
            // 
            this.IdentityNameTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.IdentityNameTB.Location = new System.Drawing.Point(87, 58);
            this.IdentityNameTB.Name = "IdentityNameTB";
            this.IdentityNameTB.Size = new System.Drawing.Size(319, 20);
            this.IdentityNameTB.TabIndex = 5;
            // 
            // AccessTypeCB
            // 
            this.AccessTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccessTypeCB.FormattingEnabled = true;
            this.AccessTypeCB.Location = new System.Drawing.Point(87, 5);
            this.AccessTypeCB.Name = "AccessTypeCB";
            this.AccessTypeCB.Size = new System.Drawing.Size(183, 21);
            this.AccessTypeCB.TabIndex = 1;
            // 
            // AccessTypeLB
            // 
            this.AccessTypeLB.AutoSize = true;
            this.AccessTypeLB.Location = new System.Drawing.Point(5, 9);
            this.AccessTypeLB.Name = "AccessTypeLB";
            this.AccessTypeLB.Size = new System.Drawing.Size(69, 13);
            this.AccessTypeLB.TabIndex = 0;
            this.AccessTypeLB.Text = "Access Type";
            this.AccessTypeLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IdentityLB
            // 
            this.IdentityLB.AutoSize = true;
            this.IdentityLB.Location = new System.Drawing.Point(5, 61);
            this.IdentityLB.Name = "IdentityLB";
            this.IdentityLB.Size = new System.Drawing.Size(41, 13);
            this.IdentityLB.TabIndex = 4;
            this.IdentityLB.Text = "Identity";
            this.IdentityLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AccessRuleDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 113);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.MaximumSize = new System.Drawing.Size(1024, 151);
            this.MinimumSize = new System.Drawing.Size(450, 145);
            this.Name = "AccessRuleDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Application Access Right";
            this.ButtonsPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.Label AccessTypeLB;
        private System.Windows.Forms.Label IdentityLB;
        private System.Windows.Forms.Button BrowseBTN;
        private System.Windows.Forms.TextBox IdentityNameTB;
        private System.Windows.Forms.ComboBox AccessTypeCB;
        private System.Windows.Forms.Label AccessRightLB;
        private System.Windows.Forms.ComboBox AccessRightCB;
    }
}
