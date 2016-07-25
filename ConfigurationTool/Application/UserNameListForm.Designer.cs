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
    partial class UserNameListForm
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
            this.components = new System.ComponentModel.Container();
            this.UserNameListView = new System.Windows.Forms.ListView();
            this.CloseButton = new System.Windows.Forms.Button();
            this.listContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createUserCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.changePasswordPToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.deleteDToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // UserNameListView
            // 
            this.UserNameListView.Location = new System.Drawing.Point(12, 12);
            this.UserNameListView.Name = "UserNameListView";
            this.UserNameListView.Size = new System.Drawing.Size(445, 238);
            this.UserNameListView.TabIndex = 0;
            this.UserNameListView.UseCompatibleStateImageBehavior = false;
            this.UserNameListView.View = System.Windows.Forms.View.List;
            this.UserNameListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListView_MouseClick);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(382, 256);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 1;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // listContextMenuStrip
            // 
            this.listContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createUserCToolStripMenuItem,
            this.toolStripSeparator2,
            this.changePasswordPToolStripMenuItem,
            this.toolStripSeparator1,
            this.deleteDToolStripMenuItem});
            this.listContextMenuStrip.Name = "listContextMenuStrip";
            this.listContextMenuStrip.Size = new System.Drawing.Size(220, 82);
            // 
            // createUserCToolStripMenuItem
            // 
            this.createUserCToolStripMenuItem.Name = "createUserCToolStripMenuItem";
            this.createUserCToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.createUserCToolStripMenuItem.Text = "Create User(&C)";
            this.createUserCToolStripMenuItem.Click += new System.EventHandler(this.CreateUserMI_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
            // 
            // changePasswordPToolStripMenuItem
            // 
            this.changePasswordPToolStripMenuItem.Name = "changePasswordPToolStripMenuItem";
            this.changePasswordPToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.changePasswordPToolStripMenuItem.Text = "Change NewPassword(&P)";
            this.changePasswordPToolStripMenuItem.Click += new System.EventHandler(this.ChangePasswordMI_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // deleteDToolStripMenuItem
            // 
            this.deleteDToolStripMenuItem.Name = "deleteDToolStripMenuItem";
            this.deleteDToolStripMenuItem.Size = new System.Drawing.Size(219, 22);
            this.deleteDToolStripMenuItem.Text = "Delete User(&D)";
            this.deleteDToolStripMenuItem.Click += new System.EventHandler(this.DeleteMI_Click);
            // 
            // UserNameListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(469, 284);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.UserNameListView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "UserNameListForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User List";
            this.Shown += new System.EventHandler(this.UserNameListForm_Shown);
            this.listContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView UserNameListView;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.ContextMenuStrip listContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem changePasswordPToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createUserCToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem deleteDToolStripMenuItem;
    }
}