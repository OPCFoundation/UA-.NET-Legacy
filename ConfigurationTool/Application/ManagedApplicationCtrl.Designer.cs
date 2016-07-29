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
    partial class ManagedApplicationCtrl
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
            this.NewApplicationBTN = new System.Windows.Forms.Button();
            this.EditApplicationBTN = new System.Windows.Forms.Button();
            this.ApplicationToManageCB = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // NewApplicationBTN
            // 
            this.NewApplicationBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NewApplicationBTN.Location = new System.Drawing.Point(442, 0);
            this.NewApplicationBTN.Name = "NewApplicationBTN";
            this.NewApplicationBTN.Size = new System.Drawing.Size(74, 23);
            this.NewApplicationBTN.TabIndex = 31;
            this.NewApplicationBTN.Text = "Find...";
            this.NewApplicationBTN.UseVisualStyleBackColor = true;
            this.NewApplicationBTN.Click += new System.EventHandler(this.NewApplicationBTN_Click);
            // 
            // EditApplicationBTN
            // 
            this.EditApplicationBTN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EditApplicationBTN.Location = new System.Drawing.Point(522, 0);
            this.EditApplicationBTN.Name = "EditApplicationBTN";
            this.EditApplicationBTN.Size = new System.Drawing.Size(74, 23);
            this.EditApplicationBTN.TabIndex = 30;
            this.EditApplicationBTN.Text = "Edit...";
            this.EditApplicationBTN.UseVisualStyleBackColor = true;
            this.EditApplicationBTN.Click += new System.EventHandler(this.EditApplicationBTN_Click);
            // 
            // ApplicationToManageCB
            // 
            this.ApplicationToManageCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplicationToManageCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ApplicationToManageCB.FormattingEnabled = true;
            this.ApplicationToManageCB.Location = new System.Drawing.Point(0, 1);
            this.ApplicationToManageCB.Name = "ApplicationToManageCB";
            this.ApplicationToManageCB.Size = new System.Drawing.Size(436, 21);
            this.ApplicationToManageCB.TabIndex = 29;
            this.ApplicationToManageCB.SelectedIndexChanged += new System.EventHandler(this.ApplicationToManageCB_SelectedIndexChanged);
            // 
            // ManagedApplicationCtrl
            // 
            this.Controls.Add(this.NewApplicationBTN);
            this.Controls.Add(this.EditApplicationBTN);
            this.Controls.Add(this.ApplicationToManageCB);
            this.MaximumSize = new System.Drawing.Size(4096, 24);
            this.MinimumSize = new System.Drawing.Size(300, 24);
            this.Name = "ManagedApplicationCtrl";
            this.Size = new System.Drawing.Size(600, 24);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NewApplicationBTN;
        private System.Windows.Forms.Button EditApplicationBTN;
        private System.Windows.Forms.ComboBox ApplicationToManageCB;

    }
}
