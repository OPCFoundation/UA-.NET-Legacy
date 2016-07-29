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
    partial class ManageWrappedComServersDlg
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
            this.AddBTN = new System.Windows.Forms.Button();
            this.ButtonsPN = new System.Windows.Forms.Panel();
            this.EditBTN = new System.Windows.Forms.Button();
            this.RemoveBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.MainPN = new System.Windows.Forms.Panel();
            this.ServersLV = new System.Windows.Forms.ListView();
            this.NameCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProgIdCH = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TopPN = new System.Windows.Forms.Panel();
            this.ApplicationToManageCB = new System.Windows.Forms.ComboBox();
            this.NewApplicationBTN = new System.Windows.Forms.Button();
            this.ApplicationToManageLB = new System.Windows.Forms.Label();
            this.AccountsBTN = new System.Windows.Forms.Button();
            this.ButtonsPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // AddBTN
            // 
            this.AddBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddBTN.Location = new System.Drawing.Point(3, 6);
            this.AddBTN.Name = "AddBTN";
            this.AddBTN.Size = new System.Drawing.Size(75, 21);
            this.AddBTN.TabIndex = 0;
            this.AddBTN.Text = "Add...";
            this.AddBTN.UseVisualStyleBackColor = true;
            this.AddBTN.Click += new System.EventHandler(this.AddBTN_Click);
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.EditBTN);
            this.ButtonsPN.Controls.Add(this.AccountsBTN);
            this.ButtonsPN.Controls.Add(this.RemoveBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Controls.Add(this.AddBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 377);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(664, 32);
            this.ButtonsPN.TabIndex = 4;
            // 
            // EditBTN
            // 
            this.EditBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.EditBTN.Location = new System.Drawing.Point(84, 6);
            this.EditBTN.Name = "EditBTN";
            this.EditBTN.Size = new System.Drawing.Size(75, 21);
            this.EditBTN.TabIndex = 3;
            this.EditBTN.Text = "Edit...";
            this.EditBTN.UseVisualStyleBackColor = true;
            this.EditBTN.Click += new System.EventHandler(this.EditBTN_Click);
            // 
            // RemoveBTN
            // 
            this.RemoveBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.RemoveBTN.Location = new System.Drawing.Point(165, 6);
            this.RemoveBTN.Name = "RemoveBTN";
            this.RemoveBTN.Size = new System.Drawing.Size(75, 21);
            this.RemoveBTN.TabIndex = 2;
            this.RemoveBTN.Text = "Remove";
            this.RemoveBTN.UseVisualStyleBackColor = true;
            this.RemoveBTN.Click += new System.EventHandler(this.RemoveBTN_Click);
            // 
            // CancelBTN
            // 
            this.CancelBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelBTN.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelBTN.Location = new System.Drawing.Point(586, 6);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 21);
            this.CancelBTN.TabIndex = 1;
            this.CancelBTN.Text = "Close";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.ServersLV);
            this.MainPN.Controls.Add(this.TopPN);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3);
            this.MainPN.Size = new System.Drawing.Size(664, 377);
            this.MainPN.TabIndex = 6;
            // 
            // ServersLV
            // 
            this.ServersLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NameCH,
            this.ProgIdCH});
            this.ServersLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ServersLV.FullRowSelect = true;
            this.ServersLV.Location = new System.Drawing.Point(3, 30);
            this.ServersLV.MultiSelect = false;
            this.ServersLV.Name = "ServersLV";
            this.ServersLV.Size = new System.Drawing.Size(658, 344);
            this.ServersLV.TabIndex = 4;
            this.ServersLV.UseCompatibleStateImageBehavior = false;
            this.ServersLV.View = System.Windows.Forms.View.Details;
            // 
            // NameCH
            // 
            this.NameCH.Text = "Browse Name";
            this.NameCH.Width = 172;
            // 
            // ProgIdCH
            // 
            this.ProgIdCH.Text = "URL";
            this.ProgIdCH.Width = 394;
            // 
            // TopPN
            // 
            this.TopPN.Controls.Add(this.ApplicationToManageCB);
            this.TopPN.Controls.Add(this.NewApplicationBTN);
            this.TopPN.Controls.Add(this.ApplicationToManageLB);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(3, 3);
            this.TopPN.Name = "TopPN";
            this.TopPN.Size = new System.Drawing.Size(658, 27);
            this.TopPN.TabIndex = 31;
            // 
            // ApplicationToManageCB
            // 
            this.ApplicationToManageCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ApplicationToManageCB.FormattingEnabled = true;
            this.ApplicationToManageCB.Location = new System.Drawing.Point(115, 3);
            this.ApplicationToManageCB.Name = "ApplicationToManageCB";
            this.ApplicationToManageCB.Size = new System.Drawing.Size(462, 20);
            this.ApplicationToManageCB.TabIndex = 29;
            this.ApplicationToManageCB.DropDown += new System.EventHandler(this.ApplicationToManageCB_DropDown);
            this.ApplicationToManageCB.SelectedIndexChanged += new System.EventHandler(this.ApplicationToManageCB_SelectedIndexChanged);
            // 
            // NewApplicationBTN
            // 
            this.NewApplicationBTN.Location = new System.Drawing.Point(583, 2);
            this.NewApplicationBTN.Name = "NewApplicationBTN";
            this.NewApplicationBTN.Size = new System.Drawing.Size(74, 21);
            this.NewApplicationBTN.TabIndex = 30;
            this.NewApplicationBTN.Text = "New...";
            this.NewApplicationBTN.UseVisualStyleBackColor = true;
            this.NewApplicationBTN.Click += new System.EventHandler(this.NewApplicationBTN_Click);
            // 
            // ApplicationToManageLB
            // 
            this.ApplicationToManageLB.AutoSize = true;
            this.ApplicationToManageLB.Location = new System.Drawing.Point(3, 6);
            this.ApplicationToManageLB.Name = "ApplicationToManageLB";
            this.ApplicationToManageLB.Size = new System.Drawing.Size(106, 12);
            this.ApplicationToManageLB.TabIndex = 28;
            this.ApplicationToManageLB.Text = "Wrapper To Manage";
            // 
            // AccountsBTN
            // 
            this.AccountsBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AccountsBTN.Location = new System.Drawing.Point(343, 6);
            this.AccountsBTN.Name = "AccountsBTN";
            this.AccountsBTN.Size = new System.Drawing.Size(75, 21);
            this.AccountsBTN.TabIndex = 2;
            this.AccountsBTN.Text = "Accounts";
            this.AccountsBTN.UseVisualStyleBackColor = true;
            this.AccountsBTN.Click += new System.EventHandler(this.AccountsBTN_Click);
            // 
            // ManageWrappedComServersDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 409);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.Name = "ManageWrappedComServersDlg";
            this.Text = "Managed Wrapped COM Servers";
            this.ButtonsPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.TopPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button AddBTN;
        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.ListView ServersLV;
        private System.Windows.Forms.ColumnHeader ProgIdCH;
        private System.Windows.Forms.ColumnHeader NameCH;
        private System.Windows.Forms.Button RemoveBTN;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.ComboBox ApplicationToManageCB;
        private System.Windows.Forms.Button NewApplicationBTN;
        private System.Windows.Forms.Label ApplicationToManageLB;
        private System.Windows.Forms.Button EditBTN;
        private System.Windows.Forms.Button AccountsBTN;
    }
}
