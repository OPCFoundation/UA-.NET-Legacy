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
    partial class ManageAccessRulesDlg
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
            this.CancelBTN = new System.Windows.Forms.Button();
            this.MainPN = new System.Windows.Forms.Panel();
            this.BackSplitPN = new System.Windows.Forms.SplitContainer();
            this.panel3 = new System.Windows.Forms.Panel();
            this.ChangePermissionsLB = new System.Windows.Forms.Label();
            this.FrontSplitPN = new System.Windows.Forms.SplitContainer();
            this.panel2 = new System.Windows.Forms.Panel();
            this.UpdateConfigurationLB = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReadConfigurationLB = new System.Windows.Forms.Label();
            this.RightPN = new System.Windows.Forms.Panel();
            this.InstructionsTB = new System.Windows.Forms.TextBox();
            this.ChangeTrustListPermissionBTN = new System.Windows.Forms.Button();
            this.ChangeApplicationPermissionBTN = new System.Windows.Forms.Button();
            this.ConfigureRightsCTRL = new Opc.Ua.Configuration.AccountAccessRightsListCtrl();
            this.WriteRightsCTRL = new Opc.Ua.Configuration.AccountAccessRightsListCtrl();
            this.ReadRightsCTRL = new Opc.Ua.Configuration.AccountAccessRightsListCtrl();
            this.ButtonsPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.BackSplitPN.Panel1.SuspendLayout();
            this.BackSplitPN.Panel2.SuspendLayout();
            this.BackSplitPN.SuspendLayout();
            this.panel3.SuspendLayout();
            this.FrontSplitPN.Panel1.SuspendLayout();
            this.FrontSplitPN.Panel2.SuspendLayout();
            this.FrontSplitPN.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.RightPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 579);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(820, 31);
            this.ButtonsPN.TabIndex = 0;
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(741, 4);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Done";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.BackSplitPN);
            this.MainPN.Controls.Add(this.RightPN);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.MainPN.Size = new System.Drawing.Size(820, 579);
            this.MainPN.TabIndex = 1;
            // 
            // BackSplitPN
            // 
            this.BackSplitPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BackSplitPN.Location = new System.Drawing.Point(3, 3);
            this.BackSplitPN.Margin = new System.Windows.Forms.Padding(0);
            this.BackSplitPN.Name = "BackSplitPN";
            this.BackSplitPN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // BackSplitPN.Panel1
            // 
            this.BackSplitPN.Panel1.Controls.Add(this.ConfigureRightsCTRL);
            this.BackSplitPN.Panel1.Controls.Add(this.panel3);
            // 
            // BackSplitPN.Panel2
            // 
            this.BackSplitPN.Panel2.Controls.Add(this.FrontSplitPN);
            this.BackSplitPN.Size = new System.Drawing.Size(573, 576);
            this.BackSplitPN.SplitterDistance = 187;
            this.BackSplitPN.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.ChangePermissionsLB);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(573, 24);
            this.panel3.TabIndex = 0;
            // 
            // ChangePermissionsLB
            // 
            this.ChangePermissionsLB.AutoSize = true;
            this.ChangePermissionsLB.Location = new System.Drawing.Point(3, 4);
            this.ChangePermissionsLB.Name = "ChangePermissionsLB";
            this.ChangePermissionsLB.Size = new System.Drawing.Size(250, 13);
            this.ChangePermissionsLB.TabIndex = 0;
            this.ChangePermissionsLB.Text = "Accounts which are allowed to Change Permissions";
            // 
            // FrontSplitPN
            // 
            this.FrontSplitPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FrontSplitPN.Location = new System.Drawing.Point(0, 0);
            this.FrontSplitPN.Margin = new System.Windows.Forms.Padding(0);
            this.FrontSplitPN.Name = "FrontSplitPN";
            this.FrontSplitPN.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // FrontSplitPN.Panel1
            // 
            this.FrontSplitPN.Panel1.Controls.Add(this.WriteRightsCTRL);
            this.FrontSplitPN.Panel1.Controls.Add(this.panel2);
            // 
            // FrontSplitPN.Panel2
            // 
            this.FrontSplitPN.Panel2.Controls.Add(this.ReadRightsCTRL);
            this.FrontSplitPN.Panel2.Controls.Add(this.panel1);
            this.FrontSplitPN.Size = new System.Drawing.Size(573, 385);
            this.FrontSplitPN.SplitterDistance = 190;
            this.FrontSplitPN.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.UpdateConfigurationLB);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(573, 24);
            this.panel2.TabIndex = 0;
            // 
            // UpdateConfigurationLB
            // 
            this.UpdateConfigurationLB.AutoSize = true;
            this.UpdateConfigurationLB.Location = new System.Drawing.Point(3, 4);
            this.UpdateConfigurationLB.Name = "UpdateConfigurationLB";
            this.UpdateConfigurationLB.Size = new System.Drawing.Size(255, 13);
            this.UpdateConfigurationLB.TabIndex = 0;
            this.UpdateConfigurationLB.Text = "Accounts which are allowed to Update Configuration";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ReadConfigurationLB);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(573, 24);
            this.panel1.TabIndex = 0;
            // 
            // ReadConfigurationLB
            // 
            this.ReadConfigurationLB.AutoSize = true;
            this.ReadConfigurationLB.Location = new System.Drawing.Point(3, 4);
            this.ReadConfigurationLB.Name = "ReadConfigurationLB";
            this.ReadConfigurationLB.Size = new System.Drawing.Size(246, 13);
            this.ReadConfigurationLB.TabIndex = 0;
            this.ReadConfigurationLB.Text = "Accounts which are allowed to Read Configuration";
            // 
            // RightPN
            // 
            this.RightPN.Controls.Add(this.InstructionsTB);
            this.RightPN.Controls.Add(this.ChangeTrustListPermissionBTN);
            this.RightPN.Controls.Add(this.ChangeApplicationPermissionBTN);
            this.RightPN.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPN.Location = new System.Drawing.Point(576, 3);
            this.RightPN.Name = "RightPN";
            this.RightPN.Padding = new System.Windows.Forms.Padding(6, 6, 2, 0);
            this.RightPN.Size = new System.Drawing.Size(241, 576);
            this.RightPN.TabIndex = 17;
            // 
            // InstructionsTB
            // 
            this.InstructionsTB.BackColor = System.Drawing.Color.LemonChiffon;
            this.InstructionsTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.InstructionsTB.Location = new System.Drawing.Point(6, 85);
            this.InstructionsTB.Multiline = true;
            this.InstructionsTB.Name = "InstructionsTB";
            this.InstructionsTB.ReadOnly = true;
            this.InstructionsTB.Size = new System.Drawing.Size(233, 491);
            this.InstructionsTB.TabIndex = 3;
            this.InstructionsTB.Text = "This is a test";
            // 
            // ChangeTrustListPermissionBTN
            // 
            this.ChangeTrustListPermissionBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeTrustListPermissionBTN.Location = new System.Drawing.Point(6, 53);
            this.ChangeTrustListPermissionBTN.Name = "ChangeTrustListPermissionBTN";
            this.ChangeTrustListPermissionBTN.Size = new System.Drawing.Size(235, 23);
            this.ChangeTrustListPermissionBTN.TabIndex = 2;
            this.ChangeTrustListPermissionBTN.Text = "Change Trust List Permissions...";
            this.ChangeTrustListPermissionBTN.UseVisualStyleBackColor = true;
            this.ChangeTrustListPermissionBTN.Click += new System.EventHandler(this.ChangeTrustListPermissionBTN_Click);
            // 
            // ChangeApplicationPermissionBTN
            // 
            this.ChangeApplicationPermissionBTN.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ChangeApplicationPermissionBTN.Location = new System.Drawing.Point(6, 24);
            this.ChangeApplicationPermissionBTN.Name = "ChangeApplicationPermissionBTN";
            this.ChangeApplicationPermissionBTN.Size = new System.Drawing.Size(235, 23);
            this.ChangeApplicationPermissionBTN.TabIndex = 0;
            this.ChangeApplicationPermissionBTN.Text = "Change Application Permissions...";
            this.ChangeApplicationPermissionBTN.UseVisualStyleBackColor = true;
            this.ChangeApplicationPermissionBTN.Click += new System.EventHandler(this.ChangeApplicationPermissionBTN_Click);
            // 
            // ConfigureRightsCTRL
            // 
            this.ConfigureRightsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConfigureRightsCTRL.Instructions = null;
            this.ConfigureRightsCTRL.Location = new System.Drawing.Point(0, 24);
            this.ConfigureRightsCTRL.Name = "ConfigureRightsCTRL";
            this.ConfigureRightsCTRL.Size = new System.Drawing.Size(573, 163);
            this.ConfigureRightsCTRL.TabIndex = 1;
            // 
            // WriteRightsCTRL
            // 
            this.WriteRightsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.WriteRightsCTRL.Instructions = null;
            this.WriteRightsCTRL.Location = new System.Drawing.Point(0, 24);
            this.WriteRightsCTRL.Name = "WriteRightsCTRL";
            this.WriteRightsCTRL.Size = new System.Drawing.Size(573, 166);
            this.WriteRightsCTRL.TabIndex = 1;
            // 
            // ReadRightsCTRL
            // 
            this.ReadRightsCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReadRightsCTRL.Instructions = null;
            this.ReadRightsCTRL.Location = new System.Drawing.Point(0, 24);
            this.ReadRightsCTRL.Name = "ReadRightsCTRL";
            this.ReadRightsCTRL.Size = new System.Drawing.Size(573, 167);
            this.ReadRightsCTRL.TabIndex = 1;
            // 
            // ManageAccessRulesDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 610);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.MaximumSize = new System.Drawing.Size(1024, 1024);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "ManageAccessRulesDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Application Access Rules";
            this.ButtonsPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.BackSplitPN.Panel1.ResumeLayout(false);
            this.BackSplitPN.Panel2.ResumeLayout(false);
            this.BackSplitPN.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.FrontSplitPN.Panel1.ResumeLayout(false);
            this.FrontSplitPN.Panel2.ResumeLayout(false);
            this.FrontSplitPN.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.RightPN.ResumeLayout(false);
            this.RightPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button CancelBTN;
        private AccountAccessRightsListCtrl ConfigureRightsCTRL;
        private AccountAccessRightsListCtrl WriteRightsCTRL;
        private AccountAccessRightsListCtrl ReadRightsCTRL;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.Label ReadConfigurationLB;
        private System.Windows.Forms.Label UpdateConfigurationLB;
        private System.Windows.Forms.Label ChangePermissionsLB;
        private System.Windows.Forms.SplitContainer BackSplitPN;
        private System.Windows.Forms.SplitContainer FrontSplitPN;
        private System.Windows.Forms.Button ChangeTrustListPermissionBTN;
        private System.Windows.Forms.Button ChangeApplicationPermissionBTN;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox InstructionsTB;
        private System.Windows.Forms.Panel RightPN;
    }
}
