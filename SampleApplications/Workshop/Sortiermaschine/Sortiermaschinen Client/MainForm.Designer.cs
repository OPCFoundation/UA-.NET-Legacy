/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
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

namespace Quickstarts.Sortiermaschine.Client
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.MenuBar = new System.Windows.Forms.MenuStrip();
            this.ServerMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_DiscoverMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_ConnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Server_DisconnectMI = new System.Windows.Forms.ToolStripMenuItem();
            this.HelpMI = new System.Windows.Forms.ToolStripMenuItem();
            this.Help_ContentsMI = new System.Windows.Forms.ToolStripMenuItem();
            this.MainPN = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.InputLamp = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.ResetCounter = new System.Windows.Forms.Button();
            this.ResetCounterWaste = new System.Windows.Forms.Button();
            this.DisplayCounter = new System.Windows.Forms.Label();
            this.Counter = new System.Windows.Forms.Label();
            this.DisplayHookPressure = new System.Windows.Forms.Label();
            this.HookPressure = new System.Windows.Forms.Label();
            this.DisplayCounterWaste = new System.Windows.Forms.Label();
            this.CounterWaste = new System.Windows.Forms.Label();
            this.DisplayBoxHeight = new System.Windows.Forms.Label();
            this.BoxHeight = new System.Windows.Forms.Label();
            this.DisplayAirFlowRate = new System.Windows.Forms.Label();
            this.AirFlowRate = new System.Windows.Forms.Label();
            this.SortiermaschineLB = new System.Windows.Forms.Label();
            this.SortiermaschineCB = new System.Windows.Forms.ComboBox();
            this.ConnectServerCTRL = new Opc.Ua.Client.Controls.ConnectServerCtrl();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.InputLampLabel1 = new System.Windows.Forms.Label();
            this.MenuBar.SuspendLayout();
            this.MainPN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // MenuBar
            // 
            this.MenuBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ServerMI,
            this.HelpMI});
            this.MenuBar.Location = new System.Drawing.Point(0, 0);
            this.MenuBar.Name = "MenuBar";
            this.MenuBar.Size = new System.Drawing.Size(884, 24);
            this.MenuBar.TabIndex = 1;
            this.MenuBar.Text = "menuStrip1";
            // 
            // ServerMI
            // 
            this.ServerMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Server_DiscoverMI,
            this.Server_ConnectMI,
            this.Server_DisconnectMI});
            this.ServerMI.Name = "ServerMI";
            this.ServerMI.Size = new System.Drawing.Size(51, 20);
            this.ServerMI.Text = "Server";
            // 
            // Server_DiscoverMI
            // 
            this.Server_DiscoverMI.Name = "Server_DiscoverMI";
            this.Server_DiscoverMI.Size = new System.Drawing.Size(133, 22);
            this.Server_DiscoverMI.Text = "Discover...";
            this.Server_DiscoverMI.Click += new System.EventHandler(this.Server_DiscoverMI_Click);
            // 
            // Server_ConnectMI
            // 
            this.Server_ConnectMI.Name = "Server_ConnectMI";
            this.Server_ConnectMI.Size = new System.Drawing.Size(133, 22);
            this.Server_ConnectMI.Text = "Connect";
            this.Server_ConnectMI.Click += new System.EventHandler(this.Server_ConnectMI_Click);
            // 
            // Server_DisconnectMI
            // 
            this.Server_DisconnectMI.Name = "Server_DisconnectMI";
            this.Server_DisconnectMI.Size = new System.Drawing.Size(133, 22);
            this.Server_DisconnectMI.Text = "Disconnect";
            this.Server_DisconnectMI.Click += new System.EventHandler(this.Server_DisconnectMI_Click);
            // 
            // HelpMI
            // 
            this.HelpMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Help_ContentsMI});
            this.HelpMI.Name = "HelpMI";
            this.HelpMI.Size = new System.Drawing.Size(44, 20);
            this.HelpMI.Text = "Help";
            // 
            // Help_ContentsMI
            // 
            this.Help_ContentsMI.Name = "Help_ContentsMI";
            this.Help_ContentsMI.Size = new System.Drawing.Size(122, 22);
            this.Help_ContentsMI.Text = "Contents";
            // 
            // MainPN
            // 
            this.MainPN.Controls.Add(this.InputLampLabel1);
            this.MainPN.Controls.Add(this.textBox1);
            this.MainPN.Controls.Add(this.InputLamp);
            this.MainPN.Controls.Add(this.label2);
            this.MainPN.Controls.Add(this.textBox2);
            this.MainPN.Controls.Add(this.button3);
            this.MainPN.Controls.Add(this.SortiermaschineCB);
            this.MainPN.Controls.Add(this.ResetCounter);
            this.MainPN.Controls.Add(this.ResetCounterWaste);
            this.MainPN.Controls.Add(this.DisplayCounter);
            this.MainPN.Controls.Add(this.Counter);
            this.MainPN.Controls.Add(this.DisplayHookPressure);
            this.MainPN.Controls.Add(this.HookPressure);
            this.MainPN.Controls.Add(this.DisplayCounterWaste);
            this.MainPN.Controls.Add(this.CounterWaste);
            this.MainPN.Controls.Add(this.DisplayBoxHeight);
            this.MainPN.Controls.Add(this.BoxHeight);
            this.MainPN.Controls.Add(this.DisplayAirFlowRate);
            this.MainPN.Controls.Add(this.AirFlowRate);
            this.MainPN.Controls.Add(this.SortiermaschineLB);
            this.MainPN.Location = new System.Drawing.Point(0, 156);
            this.MainPN.Name = "MainPN";
            this.MainPN.Padding = new System.Windows.Forms.Padding(2, 2, 2, 0);
            this.MainPN.Size = new System.Drawing.Size(884, 365);
            this.MainPN.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(250, 171);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(111, 20);
            this.textBox1.TabIndex = 20;
            // 
            // InputLamp
            // 
            this.InputLamp.AutoSize = true;
            this.InputLamp.Location = new System.Drawing.Point(12, 178);
            this.InputLamp.Name = "InputLamp";
            this.InputLamp.Size = new System.Drawing.Size(57, 13);
            this.InputLamp.TabIndex = 19;
            this.InputLamp.Text = "InputLamp";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(125, 178);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 13);
            this.label2.TabIndex = 18;
            this.label2.Text = "0";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(144, 171);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 20);
            this.textBox2.TabIndex = 16;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(144, 16);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // ResetCounter
            // 
            this.ResetCounter.Location = new System.Drawing.Point(144, 125);
            this.ResetCounter.Name = "ResetCounter";
            this.ResetCounter.Size = new System.Drawing.Size(75, 23);
            this.ResetCounter.TabIndex = 13;
            this.ResetCounter.Text = "Reset";
            this.ResetCounter.UseVisualStyleBackColor = true;
            this.ResetCounter.Click += new System.EventHandler(this.button2_Click);
            // 
            // ResetCounterWaste
            // 
            this.ResetCounterWaste.Location = new System.Drawing.Point(144, 105);
            this.ResetCounterWaste.Name = "ResetCounterWaste";
            this.ResetCounterWaste.Size = new System.Drawing.Size(75, 23);
            this.ResetCounterWaste.TabIndex = 7;
            this.ResetCounterWaste.Text = "Reset";
            this.ResetCounterWaste.UseVisualStyleBackColor = true;
            this.ResetCounterWaste.Click += new System.EventHandler(this.button1_Click);
            // 
            // DisplayCounter
            // 
            this.DisplayCounter.AutoSize = true;
            this.DisplayCounter.Location = new System.Drawing.Point(125, 130);
            this.DisplayCounter.Name = "DisplayCounter";
            this.DisplayCounter.Size = new System.Drawing.Size(13, 13);
            this.DisplayCounter.TabIndex = 12;
            this.DisplayCounter.Text = "0";
            // 
            // Counter
            // 
            this.Counter.AutoSize = true;
            this.Counter.Location = new System.Drawing.Point(12, 130);
            this.Counter.Name = "Counter";
            this.Counter.Size = new System.Drawing.Size(44, 13);
            this.Counter.TabIndex = 11;
            this.Counter.Text = "Counter";
            // 
            // DisplayHookPressure
            // 
            this.DisplayHookPressure.AutoSize = true;
            this.DisplayHookPressure.Location = new System.Drawing.Point(125, 70);
            this.DisplayHookPressure.Name = "DisplayHookPressure";
            this.DisplayHookPressure.Size = new System.Drawing.Size(13, 13);
            this.DisplayHookPressure.TabIndex = 10;
            this.DisplayHookPressure.Text = "0";
            // 
            // HookPressure
            // 
            this.HookPressure.AutoSize = true;
            this.HookPressure.Location = new System.Drawing.Point(12, 70);
            this.HookPressure.Name = "HookPressure";
            this.HookPressure.Size = new System.Drawing.Size(77, 13);
            this.HookPressure.TabIndex = 9;
            this.HookPressure.Text = "Hook Pressure";
            // 
            // DisplayCounterWaste
            // 
            this.DisplayCounterWaste.AutoSize = true;
            this.DisplayCounterWaste.Location = new System.Drawing.Point(125, 110);
            this.DisplayCounterWaste.Name = "DisplayCounterWaste";
            this.DisplayCounterWaste.Size = new System.Drawing.Size(13, 13);
            this.DisplayCounterWaste.TabIndex = 8;
            this.DisplayCounterWaste.Text = "0";
            // 
            // CounterWaste
            // 
            this.CounterWaste.AutoSize = true;
            this.CounterWaste.Location = new System.Drawing.Point(12, 110);
            this.CounterWaste.Name = "CounterWaste";
            this.CounterWaste.Size = new System.Drawing.Size(78, 13);
            this.CounterWaste.TabIndex = 7;
            this.CounterWaste.Text = "Counter Waste";
            // 
            // DisplayBoxHeight
            // 
            this.DisplayBoxHeight.AutoSize = true;
            this.DisplayBoxHeight.Location = new System.Drawing.Point(125, 90);
            this.DisplayBoxHeight.Name = "DisplayBoxHeight";
            this.DisplayBoxHeight.Size = new System.Drawing.Size(13, 13);
            this.DisplayBoxHeight.TabIndex = 6;
            this.DisplayBoxHeight.Text = "0";
            // 
            // BoxHeight
            // 
            this.BoxHeight.AutoSize = true;
            this.BoxHeight.Location = new System.Drawing.Point(12, 90);
            this.BoxHeight.Name = "BoxHeight";
            this.BoxHeight.Size = new System.Drawing.Size(57, 13);
            this.BoxHeight.TabIndex = 5;
            this.BoxHeight.Text = "Box height";
            // 
            // DisplayAirFlowRate
            // 
            this.DisplayAirFlowRate.AutoSize = true;
            this.DisplayAirFlowRate.Location = new System.Drawing.Point(125, 50);
            this.DisplayAirFlowRate.Name = "DisplayAirFlowRate";
            this.DisplayAirFlowRate.Size = new System.Drawing.Size(13, 13);
            this.DisplayAirFlowRate.TabIndex = 4;
            this.DisplayAirFlowRate.Text = "0";
            // 
            // AirFlowRate
            // 
            this.AirFlowRate.AutoSize = true;
            this.AirFlowRate.Location = new System.Drawing.Point(12, 50);
            this.AirFlowRate.Name = "AirFlowRate";
            this.AirFlowRate.Size = new System.Drawing.Size(62, 13);
            this.AirFlowRate.TabIndex = 3;
            this.AirFlowRate.Text = "Air flow rate";
            // 
            // SortiermaschineLB
            // 
            this.SortiermaschineLB.AutoSize = true;
            this.SortiermaschineLB.Location = new System.Drawing.Point(12, 16);
            this.SortiermaschineLB.Name = "SortiermaschineLB";
            this.SortiermaschineLB.Size = new System.Drawing.Size(82, 13);
            this.SortiermaschineLB.TabIndex = 1;
            this.SortiermaschineLB.Text = "Sortiermaschine";
            // 
            // SortiermaschineCB
            // 
            this.SortiermaschineCB.FormattingEnabled = true;
            this.SortiermaschineCB.Location = new System.Drawing.Point(544, 13);
            this.SortiermaschineCB.Name = "SortiermaschineCB";
            this.SortiermaschineCB.Size = new System.Drawing.Size(164, 21);
            this.SortiermaschineCB.TabIndex = 2;
            this.SortiermaschineCB.SelectedIndexChanged += new System.EventHandler(this.SortiermaschineCB_SelectedIndexChanged);
            // 
            // ConnectServerCTRL
            // 
            this.ConnectServerCTRL.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.ConnectServerCTRL.Configuration = null;
            this.ConnectServerCTRL.DisableDomainCheck = false;
            this.ConnectServerCTRL.Location = new System.Drawing.Point(0, 127);
            this.ConnectServerCTRL.MaximumSize = new System.Drawing.Size(2048, 23);
            this.ConnectServerCTRL.MinimumSize = new System.Drawing.Size(500, 23);
            this.ConnectServerCTRL.Name = "ConnectServerCTRL";
            this.ConnectServerCTRL.PreferredLocales = null;
            this.ConnectServerCTRL.ServerUrl = "";
            this.ConnectServerCTRL.SessionName = null;
            this.ConnectServerCTRL.Size = new System.Drawing.Size(884, 23);
            this.ConnectServerCTRL.StatusStrip = this.StatusBar;
            this.ConnectServerCTRL.TabIndex = 4;
            this.ConnectServerCTRL.UserIdentity = null;
            this.ConnectServerCTRL.UseSecurity = true;
            this.ConnectServerCTRL.ReconnectStarting += new System.EventHandler(this.Server_ReconnectStarting);
            this.ConnectServerCTRL.ReconnectComplete += new System.EventHandler(this.Server_ReconnectComplete);
            this.ConnectServerCTRL.ConnectComplete += new System.EventHandler(this.Server_ConnectComplete);
            // 
            // StatusBar
            // 
            this.StatusBar.Location = new System.Drawing.Point(0, 524);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(884, 22);
            this.StatusBar.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.ErrorImage")));
            this.pictureBox1.Image = global::Quickstarts.Sortiermaschinen.Client.Properties.Resources.HsLogo;
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 36);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(204, 85);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(222, 108);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(107, 13);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "www.hs-esslingen.de";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // InputLampLabel1
            // 
            this.InputLampLabel1.AutoSize = true;
            this.InputLampLabel1.Location = new System.Drawing.Point(367, 174);
            this.InputLampLabel1.Name = "InputLampLabel1";
            this.InputLampLabel1.Size = new System.Drawing.Size(89, 13);
            this.InputLampLabel1.TabIndex = 21;
            this.InputLampLabel1.Text = "InputLampLabel1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 546);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.MainPN);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.MenuBar);
            this.Controls.Add(this.ConnectServerCTRL);
            this.MainMenuStrip = this.MenuBar;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Quickstart Sortiermaschine Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MenuBar.ResumeLayout(false);
            this.MenuBar.PerformLayout();
            this.MainPN.ResumeLayout(false);
            this.MainPN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuBar;
        private System.Windows.Forms.ToolStripMenuItem ServerMI;
        private System.Windows.Forms.ToolStripMenuItem Server_DiscoverMI;
        private System.Windows.Forms.ToolStripMenuItem Server_ConnectMI;
        private System.Windows.Forms.ToolStripMenuItem Server_DisconnectMI;
        private System.Windows.Forms.Panel MainPN;
        private System.Windows.Forms.ToolStripMenuItem HelpMI;
        private System.Windows.Forms.ToolStripMenuItem Help_ContentsMI;
        private System.Windows.Forms.Label DisplayHookPressure;
        private System.Windows.Forms.Label HookPressure;
        private System.Windows.Forms.Label DisplayCounterWaste;
        private System.Windows.Forms.Label CounterWaste;
        private System.Windows.Forms.Label DisplayBoxHeight;
        private System.Windows.Forms.Label BoxHeight;
        private System.Windows.Forms.Label DisplayAirFlowRate;
        private System.Windows.Forms.Label AirFlowRate;
        private System.Windows.Forms.ComboBox SortiermaschineCB;
        private System.Windows.Forms.Label SortiermaschineLB;
        private Opc.Ua.Client.Controls.ConnectServerCtrl ConnectServerCTRL;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label DisplayCounter;
        private System.Windows.Forms.Label Counter;
        private System.Windows.Forms.Button ResetCounter;
        private System.Windows.Forms.Button ResetCounterWaste;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label InputLamp;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label InputLampLabel1;
    }
}
