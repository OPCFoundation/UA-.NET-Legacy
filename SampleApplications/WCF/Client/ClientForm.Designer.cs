/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
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

namespace Opc.Ua.Sample
{
    partial class ClientForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.ServerStatusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.PublishingStatusLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.PublishingStatusTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.LastMessageTimeLB = new System.Windows.Forms.ToolStripStatusLabel();
            this.LastMessageTimeTB = new System.Windows.Forms.ToolStripStatusLabel();
            this.BrowseTV = new System.Windows.Forms.TreeView();
            this.AttributesLV = new System.Windows.Forms.ListView();
            this.AttributeCH = new System.Windows.Forms.ColumnHeader();
            this.ValueCH = new System.Windows.Forms.ColumnHeader();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SubscriptionMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Subscription_CreateMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Subscription_MonitorValueMI = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdatesLV = new System.Windows.Forms.ListView();
            this.ClientHandleCH = new System.Windows.Forms.ColumnHeader();
            this.NameCH = new System.Windows.Forms.ColumnHeader();
            this.LastValueCH = new System.Windows.Forms.ColumnHeader();
            this.StatusCH = new System.Windows.Forms.ColumnHeader();
            this.TimestampCH = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLB,
            this.ServerStatusTB,
            this.PublishingStatusLB,
            this.PublishingStatusTB,
            this.LastMessageTimeLB,
            this.LastMessageTimeTB});
            this.statusStrip1.Location = new System.Drawing.Point(0, 496);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(885, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLB
            // 
            this.StatusLB.Name = "StatusLB";
            this.StatusLB.Size = new System.Drawing.Size(77, 17);
            this.StatusLB.Text = "Server Status:";
            // 
            // ServerStatusTB
            // 
            this.ServerStatusTB.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.ServerStatusTB.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.ServerStatusTB.Name = "ServerStatusTB";
            this.ServerStatusTB.Size = new System.Drawing.Size(50, 17);
            this.ServerStatusTB.Text = "Running";
            // 
            // PublishingStatusLB
            // 
            this.PublishingStatusLB.Name = "PublishingStatusLB";
            this.PublishingStatusLB.Size = new System.Drawing.Size(92, 17);
            this.PublishingStatusLB.Text = "Publishing Status:";
            // 
            // PublishingStatusTB
            // 
            this.PublishingStatusTB.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.PublishingStatusTB.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.PublishingStatusTB.Name = "PublishingStatusTB";
            this.PublishingStatusTB.Size = new System.Drawing.Size(51, 17);
            this.PublishingStatusTB.Text = "Disabled";
            // 
            // LastMessageTimeLB
            // 
            this.LastMessageTimeLB.Name = "LastMessageTimeLB";
            this.LastMessageTimeLB.Size = new System.Drawing.Size(101, 17);
            this.LastMessageTimeLB.Text = "Last Message Time:";
            // 
            // LastMessageTimeTB
            // 
            this.LastMessageTimeTB.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.LastMessageTimeTB.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.LastMessageTimeTB.Name = "LastMessageTimeTB";
            this.LastMessageTimeTB.Size = new System.Drawing.Size(23, 17);
            this.LastMessageTimeTB.Text = "---";
            // 
            // BrowseTV
            // 
            this.BrowseTV.Dock = System.Windows.Forms.DockStyle.Left;
            this.BrowseTV.Location = new System.Drawing.Point(0, 24);
            this.BrowseTV.Name = "BrowseTV";
            this.BrowseTV.Size = new System.Drawing.Size(323, 289);
            this.BrowseTV.TabIndex = 1;
            this.BrowseTV.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.BrowseTV_BeforeExpand);
            this.BrowseTV.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.BrowseTV_AfterSelect);
            // 
            // AttributesLV
            // 
            this.AttributesLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.AttributeCH,
            this.ValueCH});
            this.AttributesLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AttributesLV.FullRowSelect = true;
            this.AttributesLV.Location = new System.Drawing.Point(323, 24);
            this.AttributesLV.Name = "AttributesLV";
            this.AttributesLV.Size = new System.Drawing.Size(562, 289);
            this.AttributesLV.TabIndex = 2;
            this.AttributesLV.UseCompatibleStateImageBehavior = false;
            this.AttributesLV.View = System.Windows.Forms.View.Details;
            // 
            // AttributeCH
            // 
            this.AttributeCH.Text = "Attribute";
            this.AttributeCH.Width = 150;
            // 
            // ValueCH
            // 
            this.ValueCH.Text = "Value";
            this.ValueCH.Width = 300;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SubscriptionMI});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(885, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SubscriptionMI
            // 
            this.SubscriptionMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Subscription_CreateMI,
            this.Subscription_MonitorValueMI});
            this.SubscriptionMI.Name = "SubscriptionMI";
            this.SubscriptionMI.Size = new System.Drawing.Size(77, 20);
            this.SubscriptionMI.Text = "Subscription";
            // 
            // Subscription_CreateMI
            // 
            this.Subscription_CreateMI.Name = "Subscription_CreateMI";
            this.Subscription_CreateMI.Size = new System.Drawing.Size(152, 22);
            this.Subscription_CreateMI.Text = "Create";
            this.Subscription_CreateMI.Click += new System.EventHandler(this.Subscription_CreateMI_Click);
            // 
            // Subscription_MonitorValueMI
            // 
            this.Subscription_MonitorValueMI.Name = "Subscription_MonitorValueMI";
            this.Subscription_MonitorValueMI.Size = new System.Drawing.Size(152, 22);
            this.Subscription_MonitorValueMI.Text = "Monitor Value";
            this.Subscription_MonitorValueMI.Click += new System.EventHandler(this.SubscriptionMI_MonitoreValueMI_Click);
            // 
            // UpdatesLV
            // 
            this.UpdatesLV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ClientHandleCH,
            this.NameCH,
            this.LastValueCH,
            this.StatusCH,
            this.TimestampCH});
            this.UpdatesLV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.UpdatesLV.FullRowSelect = true;
            this.UpdatesLV.Location = new System.Drawing.Point(0, 313);
            this.UpdatesLV.Name = "UpdatesLV";
            this.UpdatesLV.Size = new System.Drawing.Size(885, 183);
            this.UpdatesLV.TabIndex = 4;
            this.UpdatesLV.UseCompatibleStateImageBehavior = false;
            this.UpdatesLV.View = System.Windows.Forms.View.Details;
            // 
            // ClientHandleCH
            // 
            this.ClientHandleCH.Text = "ID";
            this.ClientHandleCH.Width = 40;
            // 
            // NameCH
            // 
            this.NameCH.Text = "Name";
            this.NameCH.Width = 150;
            // 
            // LastValueCH
            // 
            this.LastValueCH.Text = "Value";
            this.LastValueCH.Width = 200;
            // 
            // StatusCH
            // 
            this.StatusCH.Text = "Status";
            this.StatusCH.Width = 100;
            // 
            // TimestampCH
            // 
            this.TimestampCH.Text = "Timestamp";
            this.TimestampCH.Width = 100;
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 518);
            this.Controls.Add(this.AttributesLV);
            this.Controls.Add(this.BrowseTV);
            this.Controls.Add(this.UpdatesLV);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ClientForm";
            this.Text = "Sample Client";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLB;
        private System.Windows.Forms.TreeView BrowseTV;
        private System.Windows.Forms.ListView AttributesLV;
        private System.Windows.Forms.ColumnHeader AttributeCH;
        private System.Windows.Forms.ColumnHeader ValueCH;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SubscriptionMI;
        private System.Windows.Forms.ToolStripMenuItem Subscription_CreateMI;
        private System.Windows.Forms.ToolStripStatusLabel ServerStatusTB;
        private System.Windows.Forms.ToolStripStatusLabel PublishingStatusLB;
        private System.Windows.Forms.ToolStripStatusLabel PublishingStatusTB;
        private System.Windows.Forms.ToolStripStatusLabel LastMessageTimeLB;
        private System.Windows.Forms.ToolStripStatusLabel LastMessageTimeTB;
        private System.Windows.Forms.ToolStripMenuItem Subscription_MonitorValueMI;
        private System.Windows.Forms.ListView UpdatesLV;
        private System.Windows.Forms.ColumnHeader ClientHandleCH;
        private System.Windows.Forms.ColumnHeader NameCH;
        private System.Windows.Forms.ColumnHeader LastValueCH;
        private System.Windows.Forms.ColumnHeader StatusCH;
        private System.Windows.Forms.ColumnHeader TimestampCH;
    }
}
