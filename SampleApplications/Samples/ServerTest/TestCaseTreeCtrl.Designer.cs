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

namespace Opc.Ua.ServerTest
{
    partial class TestCaseTreeCtrl
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
            this.PopupMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.BreakpointMI = new System.Windows.Forms.ToolStripMenuItem();
            this.TopPN = new System.Windows.Forms.Panel();
            this.EndpointSelectionCB = new System.Windows.Forms.ComboBox();
            this.CoverageCTRL = new System.Windows.Forms.NumericUpDown();
            this.ConverageLB = new System.Windows.Forms.Label();
            this.NoneBTN = new System.Windows.Forms.Button();
            this.IterationsCTRL = new System.Windows.Forms.NumericUpDown();
            this.IterartionsLB = new System.Windows.Forms.Label();
            this.AllBTN = new System.Windows.Forms.Button();
            this.PopupMenu.SuspendLayout();
            this.TopPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoverageCTRL)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationsCTRL)).BeginInit();
            this.SuspendLayout();
            // 
            // NodesTV
            // 
            this.NodesTV.CheckBoxes = true;
            this.NodesTV.ContextMenuStrip = this.PopupMenu;
            this.NodesTV.LineColor = System.Drawing.Color.Black;
            this.NodesTV.Location = new System.Drawing.Point(0, 25);
            this.NodesTV.Size = new System.Drawing.Size(451, 372);
            this.NodesTV.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.NodesTV_NodeMouseClick);
            // 
            // PopupMenu
            // 
            this.PopupMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BreakpointMI});
            this.PopupMenu.Name = "PopupMenu";
            this.PopupMenu.Size = new System.Drawing.Size(132, 26);
            // 
            // BreakpointMI
            // 
            this.BreakpointMI.CheckOnClick = true;
            this.BreakpointMI.Name = "BreakpointMI";
            this.BreakpointMI.Size = new System.Drawing.Size(131, 22);
            this.BreakpointMI.Text = "Breakpoint";
            this.BreakpointMI.CheckedChanged += new System.EventHandler(this.BreakpointMI_CheckedChanged);
            // 
            // TopPN
            // 
            this.TopPN.Controls.Add(this.EndpointSelectionCB);
            this.TopPN.Controls.Add(this.CoverageCTRL);
            this.TopPN.Controls.Add(this.ConverageLB);
            this.TopPN.Controls.Add(this.NoneBTN);
            this.TopPN.Controls.Add(this.IterationsCTRL);
            this.TopPN.Controls.Add(this.IterartionsLB);
            this.TopPN.Controls.Add(this.AllBTN);
            this.TopPN.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPN.Location = new System.Drawing.Point(0, 0);
            this.TopPN.Name = "TopPN";
            this.TopPN.Size = new System.Drawing.Size(451, 25);
            this.TopPN.TabIndex = 3;
            // 
            // EndpointSelectionCB
            // 
            this.EndpointSelectionCB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndpointSelectionCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.EndpointSelectionCB.FormattingEnabled = true;
            this.EndpointSelectionCB.Location = new System.Drawing.Point(303, 1);
            this.EndpointSelectionCB.Name = "EndpointSelectionCB";
            this.EndpointSelectionCB.Size = new System.Drawing.Size(145, 21);
            this.EndpointSelectionCB.TabIndex = 8;
            this.EndpointSelectionCB.SelectedIndexChanged += new System.EventHandler(this.EndpointSelectionCB_SelectedIndexChanged);
            // 
            // CoverageCTRL
            // 
            this.CoverageCTRL.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CoverageCTRL.Location = new System.Drawing.Point(249, 2);
            this.CoverageCTRL.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.CoverageCTRL.Name = "CoverageCTRL";
            this.CoverageCTRL.Size = new System.Drawing.Size(48, 20);
            this.CoverageCTRL.TabIndex = 7;
            this.CoverageCTRL.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.CoverageCTRL.ValueChanged += new System.EventHandler(this.CoverageCTRL_ValueChanged);
            // 
            // ConverageLB
            // 
            this.ConverageLB.AutoSize = true;
            this.ConverageLB.Location = new System.Drawing.Point(195, 5);
            this.ConverageLB.Name = "ConverageLB";
            this.ConverageLB.Size = new System.Drawing.Size(53, 13);
            this.ConverageLB.TabIndex = 6;
            this.ConverageLB.Text = "Coverage";
            this.ConverageLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NoneBTN
            // 
            this.NoneBTN.Location = new System.Drawing.Point(48, 0);
            this.NoneBTN.Name = "NoneBTN";
            this.NoneBTN.Size = new System.Drawing.Size(42, 23);
            this.NoneBTN.TabIndex = 4;
            this.NoneBTN.Text = "None";
            this.NoneBTN.UseVisualStyleBackColor = true;
            this.NoneBTN.Click += new System.EventHandler(this.NoneBTN_Click);
            // 
            // IterationsCTRL
            // 
            this.IterationsCTRL.Location = new System.Drawing.Point(150, 2);
            this.IterationsCTRL.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IterationsCTRL.Name = "IterationsCTRL";
            this.IterationsCTRL.Size = new System.Drawing.Size(41, 20);
            this.IterationsCTRL.TabIndex = 4;
            this.IterationsCTRL.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.IterationsCTRL.ValueChanged += new System.EventHandler(this.IterationsCTRL_ValueChanged);
            // 
            // IterartionsLB
            // 
            this.IterartionsLB.AutoSize = true;
            this.IterartionsLB.Location = new System.Drawing.Point(96, 5);
            this.IterartionsLB.Name = "IterartionsLB";
            this.IterartionsLB.Size = new System.Drawing.Size(50, 13);
            this.IterartionsLB.TabIndex = 4;
            this.IterartionsLB.Text = "Iterations";
            this.IterartionsLB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AllBTN
            // 
            this.AllBTN.Location = new System.Drawing.Point(0, 0);
            this.AllBTN.Name = "AllBTN";
            this.AllBTN.Size = new System.Drawing.Size(42, 23);
            this.AllBTN.TabIndex = 3;
            this.AllBTN.Text = "All";
            this.AllBTN.UseVisualStyleBackColor = true;
            this.AllBTN.Click += new System.EventHandler(this.AllBTN_Click);
            // 
            // TestCaseTreeCtrl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Controls.Add(this.TopPN);
            this.Name = "TestCaseTreeCtrl";
            this.Size = new System.Drawing.Size(451, 397);
            this.Controls.SetChildIndex(this.TopPN, 0);
            this.Controls.SetChildIndex(this.NodesTV, 0);
            this.PopupMenu.ResumeLayout(false);
            this.TopPN.ResumeLayout(false);
            this.TopPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CoverageCTRL)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.IterationsCTRL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip PopupMenu;
        private System.Windows.Forms.ToolStripMenuItem BreakpointMI;
        private System.Windows.Forms.Panel TopPN;
        private System.Windows.Forms.Button NoneBTN;
        private System.Windows.Forms.NumericUpDown IterationsCTRL;
        private System.Windows.Forms.Label IterartionsLB;
        private System.Windows.Forms.Button AllBTN;
        private System.Windows.Forms.NumericUpDown CoverageCTRL;
        private System.Windows.Forms.Label ConverageLB;
        private System.Windows.Forms.ComboBox EndpointSelectionCB;

    }
}
