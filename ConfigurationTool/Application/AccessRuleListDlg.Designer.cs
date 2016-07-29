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
    partial class AccessRuleListDlg
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
            this.ApplyBTN = new System.Windows.Forms.Button();
            this.ApplyAllBTN = new System.Windows.Forms.Button();
            this.OkBTN = new System.Windows.Forms.Button();
            this.CancelBTN = new System.Windows.Forms.Button();
            this.MainPN = new System.Windows.Forms.Panel();
            this.BottomPN = new System.Windows.Forms.Panel();
            this.InstructionsTB = new System.Windows.Forms.RichTextBox();
            this.TopPN = new System.Windows.Forms.Panel();
            this.ObjectPathTB = new System.Windows.Forms.TextBox();
            this.ObjectTypeLB = new System.Windows.Forms.Label();
            this.ObjectPathLB = new System.Windows.Forms.Label();
            this.ObjectTypeCB = new System.Windows.Forms.ComboBox();
            this.AccessRulesCTRL = new Opc.Ua.Configuration.AccessRulesListCtrl();
            this.ButtonsPN.SuspendLayout();
            this.MainPN.SuspendLayout();
            this.BottomPN.SuspendLayout();
            this.TopPN.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonsPN
            // 
            this.ButtonsPN.Controls.Add(this.ApplyBTN);
            this.ButtonsPN.Controls.Add(this.ApplyAllBTN);
            this.ButtonsPN.Controls.Add(this.OkBTN);
            this.ButtonsPN.Controls.Add(this.CancelBTN);
            this.ButtonsPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonsPN.Location = new System.Drawing.Point(0, 259);
            this.ButtonsPN.Name = "ButtonsPN";
            this.ButtonsPN.Size = new System.Drawing.Size(691, 31);
            this.ButtonsPN.TabIndex = 0;
            // 
            // ApplyBTN
            // 
            this.ApplyBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplyBTN.Location = new System.Drawing.Point(529, 4);
            this.ApplyBTN.Name = "ApplyBTN";
            this.ApplyBTN.Size = new System.Drawing.Size(75, 23);
            this.ApplyBTN.TabIndex = 8;
            this.ApplyBTN.Text = "Apply";
            this.ApplyBTN.UseVisualStyleBackColor = true;
            this.ApplyBTN.Click += new System.EventHandler(this.OkBTN_Click);
            // 
            // ApplyAllBTN
            // 
            this.ApplyAllBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ApplyAllBTN.Location = new System.Drawing.Point(6, 4);
            this.ApplyAllBTN.Name = "ApplyAllBTN";
            this.ApplyAllBTN.Size = new System.Drawing.Size(117, 23);
            this.ApplyAllBTN.TabIndex = 7;
            this.ApplyAllBTN.Text = "Apply to All Objects...";
            this.ApplyAllBTN.UseVisualStyleBackColor = true;
            this.ApplyAllBTN.Click += new System.EventHandler(this.ApplyAllBTN_Click);
            // 
            // OkBTN
            // 
            this.OkBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBTN.Location = new System.Drawing.Point(448, 4);
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
            this.CancelBTN.Location = new System.Drawing.Point(610, 4);
            this.CancelBTN.Name = "CancelBTN";
            this.CancelBTN.Size = new System.Drawing.Size(75, 23);
            this.CancelBTN.TabIndex = 0;
            this.CancelBTN.Text = "Cancel";
            this.CancelBTN.UseVisualStyleBackColor = true;
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.AccessRulesCTRL);
            this.MainPN.Controls.Add(this.BottomPN);
            this.MainPN.Controls.Add(this.TopPN);
            this.MainPN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPN.Location = new System.Drawing.Point(0, 0);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.MainPN.Size = new System.Drawing.Size(691, 259);
            this.MainPN.TabIndex = 1;
            // 
            // BottomPN
            // 
            this.BottomPN.Controls.Add(this.InstructionsTB);
            this.BottomPN.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPN.Location = new System.Drawing.Point(3, 188);
            this.BottomPN.Name = "BottomPN";
            this.BottomPN.Padding = new System.Windows.Forms.Padding(3);
            this.BottomPN.Size = new System.Drawing.Size(685, 71);
            this.BottomPN.TabIndex = 8;
            // 
            // InstructionsTB
            // 
            this.InstructionsTB.BackColor = System.Drawing.Color.LemonChiffon;
            this.InstructionsTB.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.InstructionsTB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InstructionsTB.Location = new System.Drawing.Point(3, 3);
            this.InstructionsTB.Name = "InstructionsTB";
            this.InstructionsTB.ReadOnly = true;
            this.InstructionsTB.Size = new System.Drawing.Size(679, 65);
            this.InstructionsTB.TabIndex = 7;
            this.InstructionsTB.Text = "";
            // 
            // TopPN
            // 
            this.TopPN.Controls.Add(this.ObjectPathTB);
            this.TopPN.Controls.Add(this.ObjectTypeLB);
            this.TopPN.Controls.Add(this.ObjectPathLB);
            this.TopPN.Controls.Add(this.ObjectTypeCB);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(3, 3);
            this.TopPN.Name = "TopPN";
            this.TopPN.Size = new System.Drawing.Size(685, 54);
            this.TopPN.TabIndex = 7;
            // 
            // ObjectPathTB
            // 
            this.ObjectPathTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ObjectPathTB.Location = new System.Drawing.Point(114, 30);
            this.ObjectPathTB.Name = "ObjectPathTB";
            this.ObjectPathTB.ReadOnly = true;
            this.ObjectPathTB.Size = new System.Drawing.Size(568, 20);
            this.ObjectPathTB.TabIndex = 3;
            // 
            // ObjectTypeLB
            // 
            this.ObjectTypeLB.AutoSize = true;
            this.ObjectTypeLB.Location = new System.Drawing.Point(2, 6);
            this.ObjectTypeLB.Name = "ObjectTypeLB";
            this.ObjectTypeLB.Size = new System.Drawing.Size(108, 13);
            this.ObjectTypeLB.TabIndex = 0;
            this.ObjectTypeLB.Text = "Secured Object Type";
            // 
            // ObjectPathLB
            // 
            this.ObjectPathLB.AutoSize = true;
            this.ObjectPathLB.Location = new System.Drawing.Point(2, 33);
            this.ObjectPathLB.Name = "ObjectPathLB";
            this.ObjectPathLB.Size = new System.Drawing.Size(106, 13);
            this.ObjectPathLB.TabIndex = 2;
            this.ObjectPathLB.Text = "Secured Object Path";
            // 
            // ObjectTypeCB
            // 
            this.ObjectTypeCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ObjectTypeCB.FormattingEnabled = true;
            this.ObjectTypeCB.Location = new System.Drawing.Point(114, 3);
            this.ObjectTypeCB.Name = "ObjectTypeCB";
            this.ObjectTypeCB.Size = new System.Drawing.Size(121, 21);
            this.ObjectTypeCB.TabIndex = 1;
            this.ObjectTypeCB.SelectedIndexChanged += new System.EventHandler(this.ObjectTypeCB_SelectedIndexChanged);
            // 
            // AccessRulesCTRL
            // 
            this.AccessRulesCTRL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AccessRulesCTRL.Instructions = null;
            this.AccessRulesCTRL.Location = new System.Drawing.Point(3, 57);
            this.AccessRulesCTRL.Name = "AccessRulesCTRL";
            this.AccessRulesCTRL.Size = new System.Drawing.Size(685, 131);
            this.AccessRulesCTRL.TabIndex = 4;
            // 
            // AccessRuleListDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(691, 290);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.ButtonsPN);
            this.MaximumSize = new System.Drawing.Size(1024, 1024);
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "AccessRuleListDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Manage Access Rules for Secured Object";
            this.ButtonsPN.ResumeLayout(false);
            this.MainPN.ResumeLayout(false);
            this.BottomPN.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.TopPN.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ButtonsPN;
        private System.Windows.Forms.Button OkBTN;
        private System.Windows.Forms.Button CancelBTN;
        private System.Windows.Forms.Panel MainPN;
        private AccessRulesListCtrl AccessRulesCTRL;
        private System.Windows.Forms.TextBox ObjectPathTB;
        private System.Windows.Forms.Label ObjectTypeLB;
        private System.Windows.Forms.Label ObjectPathLB;
        private System.Windows.Forms.ComboBox ObjectTypeCB;
        private System.Windows.Forms.Button ApplyBTN;
        private System.Windows.Forms.Button ApplyAllBTN;
        private System.Windows.Forms.Panel BottomPN;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.RichTextBox InstructionsTB;
    }
}
