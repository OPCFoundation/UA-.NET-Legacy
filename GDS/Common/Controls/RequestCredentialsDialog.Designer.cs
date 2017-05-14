/* Copyright (c) 1996-2016, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

namespace Opc.Ua.Gds
{
    partial class RequestCredentialsDialog
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
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.CloseButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.ServersGroupBox = new System.Windows.Forms.GroupBox();
            this.CredentialServicesListBox = new System.Windows.Forms.ListBox();
            this.SelectedServerGroupBox = new System.Windows.Forms.GroupBox();
            this.CredentialServiceTextBox = new System.Windows.Forms.TextBox();
            this.MainPN = new System.Windows.Forms.TableLayoutPanel();
            this.RequestedRolesLabel = new System.Windows.Forms.Label();
            this.ApplicationUriLabel = new System.Windows.Forms.Label();
            this.RequestedRolesTextBox = new System.Windows.Forms.TextBox();
            this.ApplicationUriTextBox = new System.Windows.Forms.TextBox();
            this.EncryptSecretCheckBox = new System.Windows.Forms.CheckBox();
            this.EncryptSecretLabel = new System.Windows.Forms.Label();
            this.CredentialIdLabel = new System.Windows.Forms.Label();
            this.CredentialSecretLabel = new System.Windows.Forms.Label();
            this.GrantedRolesLabel = new System.Windows.Forms.Label();
            this.CredentialIdTextBox = new System.Windows.Forms.TextBox();
            this.CredentialSecretTextBox = new System.Windows.Forms.TextBox();
            this.GrantedRolesTextBox = new System.Windows.Forms.TextBox();
            this.ButtonPanel.SuspendLayout();
            this.MainPanel.SuspendLayout();
            this.ServersGroupBox.SuspendLayout();
            this.SelectedServerGroupBox.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Controls.Add(this.CloseButton);
            this.ButtonPanel.Controls.Add(this.OkButton);
            this.ButtonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonPanel.Location = new System.Drawing.Point(0, 265);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(664, 30);
            this.ButtonPanel.TabIndex = 0;
            // 
            // CloseButton
            // 
            this.CloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CloseButton.Location = new System.Drawing.Point(586, 3);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 24);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Cancel";
            this.CloseButton.UseVisualStyleBackColor = true;
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OkButton.Location = new System.Drawing.Point(3, 3);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(75, 24);
            this.OkButton.TabIndex = 0;
            this.OkButton.Text = "Apply";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.ServersGroupBox);
            this.MainPanel.Controls.Add(this.SelectedServerGroupBox);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.MainPanel.Size = new System.Drawing.Size(664, 265);
            this.MainPanel.TabIndex = 1;
            // 
            // ServersGroupBox
            // 
            this.ServersGroupBox.Controls.Add(this.MainPN);
            this.ServersGroupBox.Controls.Add(this.CredentialServicesListBox);
            this.ServersGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServersGroupBox.Location = new System.Drawing.Point(3, 47);
            this.ServersGroupBox.Name = "ServersGroupBox";
            this.ServersGroupBox.Size = new System.Drawing.Size(658, 218);
            this.ServersGroupBox.TabIndex = 3;
            this.ServersGroupBox.TabStop = false;
            this.ServersGroupBox.Text = "Available Credential Services";
            // 
            // CredentialServicesListBox
            // 
            this.CredentialServicesListBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CredentialServicesListBox.FormattingEnabled = true;
            this.CredentialServicesListBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "0"});
            this.CredentialServicesListBox.Location = new System.Drawing.Point(3, 16);
            this.CredentialServicesListBox.Name = "CredentialServicesListBox";
            this.CredentialServicesListBox.Size = new System.Drawing.Size(652, 43);
            this.CredentialServicesListBox.TabIndex = 0;
            this.CredentialServicesListBox.SelectedIndexChanged += new System.EventHandler(this.ServersListBox_SelectedIndexChanged);
            // 
            // SelectedServerGroupBox
            // 
            this.SelectedServerGroupBox.Controls.Add(this.CredentialServiceTextBox);
            this.SelectedServerGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.SelectedServerGroupBox.Location = new System.Drawing.Point(3, 3);
            this.SelectedServerGroupBox.Name = "SelectedServerGroupBox";
            this.SelectedServerGroupBox.Size = new System.Drawing.Size(658, 44);
            this.SelectedServerGroupBox.TabIndex = 4;
            this.SelectedServerGroupBox.TabStop = false;
            this.SelectedServerGroupBox.Text = "Selected Credential Service";
            // 
            // ServerUrlTextBox
            // 
            this.CredentialServiceTextBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.CredentialServiceTextBox.Location = new System.Drawing.Point(3, 16);
            this.CredentialServiceTextBox.Name = "ServerUrlTextBox";
            this.CredentialServiceTextBox.Size = new System.Drawing.Size(652, 20);
            this.CredentialServiceTextBox.TabIndex = 3;
            this.CredentialServiceTextBox.TextChanged += new System.EventHandler(this.ServerUrlTextBox_TextChanged);
            // 
            // MainPN
            // 
            this.MainPN.AutoSize = true;
            this.MainPN.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPN.ColumnCount = 2;
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.MainPN.Controls.Add(this.GrantedRolesTextBox, 1, 7);
            this.MainPN.Controls.Add(this.CredentialSecretTextBox, 1, 6);
            this.MainPN.Controls.Add(this.CredentialIdTextBox, 1, 5);
            this.MainPN.Controls.Add(this.GrantedRolesLabel, 0, 7);
            this.MainPN.Controls.Add(this.CredentialSecretLabel, 0, 6);
            this.MainPN.Controls.Add(this.CredentialIdLabel, 0, 5);
            this.MainPN.Controls.Add(this.EncryptSecretLabel, 0, 4);
            this.MainPN.Controls.Add(this.RequestedRolesLabel, 0, 3);
            this.MainPN.Controls.Add(this.ApplicationUriLabel, 0, 2);
            this.MainPN.Controls.Add(this.RequestedRolesTextBox, 1, 3);
            this.MainPN.Controls.Add(this.ApplicationUriTextBox, 1, 2);
            this.MainPN.Controls.Add(this.EncryptSecretCheckBox, 1, 4);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(3, 59);
            this.MainPN.Name = "MainPN";
            this.MainPN.RowCount = 9;
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.MainPN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.MainPN.Size = new System.Drawing.Size(652, 156);
            this.MainPN.TabIndex = 2;
            // 
            // RequestedRolesLabel
            // 
            this.RequestedRolesLabel.AutoSize = true;
            this.RequestedRolesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestedRolesLabel.Location = new System.Drawing.Point(3, 34);
            this.RequestedRolesLabel.Name = "RequestedRolesLabel";
            this.RequestedRolesLabel.Size = new System.Drawing.Size(89, 24);
            this.RequestedRolesLabel.TabIndex = 3;
            this.RequestedRolesLabel.Text = "Requested Roles";
            this.RequestedRolesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ApplicationUriLabel
            // 
            this.ApplicationUriLabel.AutoSize = true;
            this.ApplicationUriLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplicationUriLabel.Location = new System.Drawing.Point(3, 10);
            this.ApplicationUriLabel.Name = "ApplicationUriLabel";
            this.ApplicationUriLabel.Size = new System.Drawing.Size(89, 24);
            this.ApplicationUriLabel.TabIndex = 1;
            this.ApplicationUriLabel.Text = "Application URI";
            this.ApplicationUriLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RequestedRolesTextBox
            // 
            this.RequestedRolesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RequestedRolesTextBox.Location = new System.Drawing.Point(97, 36);
            this.RequestedRolesTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.RequestedRolesTextBox.Name = "RequestedRolesTextBox";
            this.RequestedRolesTextBox.Size = new System.Drawing.Size(553, 20);
            this.RequestedRolesTextBox.TabIndex = 4;
            this.RequestedRolesTextBox.Text = "---";
            // 
            // ApplicationUriTextBox
            // 
            this.ApplicationUriTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ApplicationUriTextBox.Location = new System.Drawing.Point(97, 12);
            this.ApplicationUriTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.ApplicationUriTextBox.Name = "ApplicationUriTextBox";
            this.ApplicationUriTextBox.Size = new System.Drawing.Size(553, 20);
            this.ApplicationUriTextBox.TabIndex = 2;
            // 
            // EncryptSecretCheckBox
            // 
            this.EncryptSecretCheckBox.AutoSize = true;
            this.EncryptSecretCheckBox.Location = new System.Drawing.Point(97, 64);
            this.EncryptSecretCheckBox.Margin = new System.Windows.Forms.Padding(2, 6, 2, 5);
            this.EncryptSecretCheckBox.Name = "EncryptSecretCheckBox";
            this.EncryptSecretCheckBox.Size = new System.Drawing.Size(15, 14);
            this.EncryptSecretCheckBox.TabIndex = 6;
            this.EncryptSecretCheckBox.UseVisualStyleBackColor = true;
            this.EncryptSecretCheckBox.Visible = false;
            // 
            // EncryptSecretLabel
            // 
            this.EncryptSecretLabel.AutoSize = true;
            this.EncryptSecretLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EncryptSecretLabel.Location = new System.Drawing.Point(3, 58);
            this.EncryptSecretLabel.Name = "EncryptSecretLabel";
            this.EncryptSecretLabel.Size = new System.Drawing.Size(89, 25);
            this.EncryptSecretLabel.TabIndex = 5;
            this.EncryptSecretLabel.Text = "Encrypt Secret";
            this.EncryptSecretLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.EncryptSecretLabel.Visible = false;
            // 
            // CredentialIdLabel
            // 
            this.CredentialIdLabel.AutoSize = true;
            this.CredentialIdLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CredentialIdLabel.Location = new System.Drawing.Point(3, 83);
            this.CredentialIdLabel.Name = "CredentialIdLabel";
            this.CredentialIdLabel.Size = new System.Drawing.Size(89, 24);
            this.CredentialIdLabel.TabIndex = 7;
            this.CredentialIdLabel.Text = "Credential ID";
            this.CredentialIdLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CredentialIdLabel.Visible = false;
            // 
            // CredentialSecretLabel
            // 
            this.CredentialSecretLabel.AutoSize = true;
            this.CredentialSecretLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CredentialSecretLabel.Location = new System.Drawing.Point(3, 107);
            this.CredentialSecretLabel.Name = "CredentialSecretLabel";
            this.CredentialSecretLabel.Size = new System.Drawing.Size(89, 24);
            this.CredentialSecretLabel.TabIndex = 8;
            this.CredentialSecretLabel.Text = "Credential Secret";
            this.CredentialSecretLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.CredentialSecretLabel.Visible = false;
            // 
            // GrantedRolesLabel
            // 
            this.GrantedRolesLabel.AutoSize = true;
            this.GrantedRolesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrantedRolesLabel.Location = new System.Drawing.Point(3, 131);
            this.GrantedRolesLabel.Name = "GrantedRolesLabel";
            this.GrantedRolesLabel.Size = new System.Drawing.Size(89, 24);
            this.GrantedRolesLabel.TabIndex = 9;
            this.GrantedRolesLabel.Text = "Granted Roles";
            this.GrantedRolesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.GrantedRolesLabel.Visible = false;
            // 
            // CredentialIdTextBox
            // 
            this.CredentialIdTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CredentialIdTextBox.Location = new System.Drawing.Point(97, 85);
            this.CredentialIdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CredentialIdTextBox.Name = "CredentialIdTextBox";
            this.CredentialIdTextBox.Size = new System.Drawing.Size(553, 20);
            this.CredentialIdTextBox.TabIndex = 10;
            this.CredentialIdTextBox.Text = "---";
            // 
            // CredentialSecretTextBox
            // 
            this.CredentialSecretTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CredentialSecretTextBox.Location = new System.Drawing.Point(97, 109);
            this.CredentialSecretTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CredentialSecretTextBox.Name = "CredentialSecretTextBox";
            this.CredentialSecretTextBox.Size = new System.Drawing.Size(553, 20);
            this.CredentialSecretTextBox.TabIndex = 11;
            this.CredentialSecretTextBox.Text = "---";
            // 
            // GrantedRolesTextBox
            // 
            this.GrantedRolesTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrantedRolesTextBox.Location = new System.Drawing.Point(97, 133);
            this.GrantedRolesTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.GrantedRolesTextBox.Name = "GrantedRolesTextBox";
            this.GrantedRolesTextBox.Size = new System.Drawing.Size(553, 20);
            this.GrantedRolesTextBox.TabIndex = 12;
            this.GrantedRolesTextBox.Text = "---";
            // 
            // RequestCredentialsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 295);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.ButtonPanel);
            this.MaximumSize = new System.Drawing.Size(800, 800);
            this.MinimizeBox = false;
            this.Name = "RequestCredentialsDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Request OAuth2 Credentials";
            this.ButtonPanel.ResumeLayout(false);
            this.MainPanel.ResumeLayout(false);
            this.ServersGroupBox.ResumeLayout(false);
            this.ServersGroupBox.PerformLayout();
            this.SelectedServerGroupBox.ResumeLayout(false);
            this.SelectedServerGroupBox.PerformLayout();
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.ListBox CredentialServicesListBox;
        private System.Windows.Forms.GroupBox ServersGroupBox;
        private System.Windows.Forms.GroupBox SelectedServerGroupBox;
        private System.Windows.Forms.TextBox CredentialServiceTextBox;
        private System.Windows.Forms.TableLayoutPanel MainPN;
        private System.Windows.Forms.Label GrantedRolesLabel;
        private System.Windows.Forms.Label CredentialSecretLabel;
        private System.Windows.Forms.Label CredentialIdLabel;
        private System.Windows.Forms.Label EncryptSecretLabel;
        private System.Windows.Forms.Label RequestedRolesLabel;
        private System.Windows.Forms.Label ApplicationUriLabel;
        private System.Windows.Forms.TextBox RequestedRolesTextBox;
        private System.Windows.Forms.TextBox ApplicationUriTextBox;
        private System.Windows.Forms.CheckBox EncryptSecretCheckBox;
        private System.Windows.Forms.TextBox GrantedRolesTextBox;
        private System.Windows.Forms.TextBox CredentialSecretTextBox;
        private System.Windows.Forms.TextBox CredentialIdTextBox;
    }
}
