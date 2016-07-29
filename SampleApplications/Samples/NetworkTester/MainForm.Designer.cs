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

namespace Opc.Ua.NetworkTester
{
    partial class MainForm
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
            this.ListenerUrlTB = new System.Windows.Forms.TextBox();
            this.ListeningUrlLB = new System.Windows.Forms.Label();
            this.ServerUrlLB = new System.Windows.Forms.Label();
            this.ServerUrlTB = new System.Windows.Forms.TextBox();
            this.StartBTN = new System.Windows.Forms.Button();
            this.StopBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ListenerUrlTB
            // 
            this.ListenerUrlTB.Location = new System.Drawing.Point(85, 6);
            this.ListenerUrlTB.Name = "ListenerUrlTB";
            this.ListenerUrlTB.Size = new System.Drawing.Size(191, 20);
            this.ListenerUrlTB.TabIndex = 0;
            // 
            // ListeningUrlLB
            // 
            this.ListeningUrlLB.AutoSize = true;
            this.ListeningUrlLB.Location = new System.Drawing.Point(5, 9);
            this.ListeningUrlLB.Name = "ListeningUrlLB";
            this.ListeningUrlLB.Size = new System.Drawing.Size(74, 13);
            this.ListeningUrlLB.TabIndex = 1;
            this.ListeningUrlLB.Text = "Listening URL";
            this.ListeningUrlLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerUrlLB
            // 
            this.ServerUrlLB.AutoSize = true;
            this.ServerUrlLB.Location = new System.Drawing.Point(5, 35);
            this.ServerUrlLB.Name = "ServerUrlLB";
            this.ServerUrlLB.Size = new System.Drawing.Size(63, 13);
            this.ServerUrlLB.TabIndex = 2;
            this.ServerUrlLB.Text = "Server URL";
            this.ServerUrlLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ServerUrlTB
            // 
            this.ServerUrlTB.Location = new System.Drawing.Point(85, 32);
            this.ServerUrlTB.Name = "ServerUrlTB";
            this.ServerUrlTB.Size = new System.Drawing.Size(191, 20);
            this.ServerUrlTB.TabIndex = 3;
            // 
            // StartBTN
            // 
            this.StartBTN.Location = new System.Drawing.Point(8, 68);
            this.StartBTN.Name = "StartBTN";
            this.StartBTN.Size = new System.Drawing.Size(75, 22);
            this.StartBTN.TabIndex = 4;
            this.StartBTN.Text = "Start";
            this.StartBTN.UseVisualStyleBackColor = true;
            this.StartBTN.Click += new System.EventHandler(this.StartBTN_Click);
            // 
            // StopBTN
            // 
            this.StopBTN.Location = new System.Drawing.Point(201, 68);
            this.StopBTN.Name = "StopBTN";
            this.StopBTN.Size = new System.Drawing.Size(75, 22);
            this.StopBTN.TabIndex = 5;
            this.StopBTN.Text = "Stop";
            this.StopBTN.UseVisualStyleBackColor = true;
            this.StopBTN.Click += new System.EventHandler(this.StopBTN_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 96);
            this.Controls.Add(this.StopBTN);
            this.Controls.Add(this.StartBTN);
            this.Controls.Add(this.ServerUrlTB);
            this.Controls.Add(this.ServerUrlLB);
            this.Controls.Add(this.ListeningUrlLB);
            this.Controls.Add(this.ListenerUrlTB);
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Network Tester";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ListenerUrlTB;
        private System.Windows.Forms.Label ListeningUrlLB;
        private System.Windows.Forms.Label ServerUrlLB;
        private System.Windows.Forms.TextBox ServerUrlTB;
        private System.Windows.Forms.Button StartBTN;
        private System.Windows.Forms.Button StopBTN;
    }
}
