namespace AmqpBrokerTester
{
    partial class BrokerTesterForm
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
            this.ParametersPanel = new System.Windows.Forms.TableLayoutPanel();
            this.ReceiverTextBox = new System.Windows.Forms.TextBox();
            this.ReceiverLabel = new System.Windows.Forms.Label();
            this.SenderTextBox = new System.Windows.Forms.TextBox();
            this.SenderLabel = new System.Windows.Forms.Label();
            this.MessageTextBox = new System.Windows.Forms.TextBox();
            this.MessageLabel = new System.Windows.Forms.Label();
            this.AmqpNodeNameTextBox = new System.Windows.Forms.TextBox();
            this.AmqpNodeNameLabel = new System.Windows.Forms.Label();
            this.ReceiveKeyTextBox = new System.Windows.Forms.TextBox();
            this.SendKeyTextBox = new System.Windows.Forms.TextBox();
            this.ReceiveKeyLabel = new System.Windows.Forms.Label();
            this.EndpointUrlLabel = new System.Windows.Forms.Label();
            this.SendKeyLabel = new System.Windows.Forms.Label();
            this.EndpointUrlTextBox = new System.Windows.Forms.TextBox();
            this.MessageLogPanel = new System.Windows.Forms.SplitContainer();
            this.SendLogTextBox = new System.Windows.Forms.RichTextBox();
            this.ReceiveLogTextBox = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.ButtonPanel = new System.Windows.Forms.Panel();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.ParametersPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MessageLogPanel)).BeginInit();
            this.MessageLogPanel.Panel1.SuspendLayout();
            this.MessageLogPanel.Panel2.SuspendLayout();
            this.MessageLogPanel.SuspendLayout();
            this.ButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ParametersPanel
            // 
            this.ParametersPanel.ColumnCount = 2;
            this.ParametersPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ParametersPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.ParametersPanel.Controls.Add(this.ReceiverTextBox, 1, 4);
            this.ParametersPanel.Controls.Add(this.ReceiverLabel, 0, 4);
            this.ParametersPanel.Controls.Add(this.SenderTextBox, 1, 2);
            this.ParametersPanel.Controls.Add(this.SenderLabel, 0, 2);
            this.ParametersPanel.Controls.Add(this.MessageTextBox, 1, 6);
            this.ParametersPanel.Controls.Add(this.MessageLabel, 0, 6);
            this.ParametersPanel.Controls.Add(this.AmqpNodeNameTextBox, 1, 1);
            this.ParametersPanel.Controls.Add(this.AmqpNodeNameLabel, 0, 1);
            this.ParametersPanel.Controls.Add(this.ReceiveKeyTextBox, 1, 5);
            this.ParametersPanel.Controls.Add(this.SendKeyTextBox, 1, 3);
            this.ParametersPanel.Controls.Add(this.ReceiveKeyLabel, 0, 5);
            this.ParametersPanel.Controls.Add(this.EndpointUrlLabel, 0, 0);
            this.ParametersPanel.Controls.Add(this.SendKeyLabel, 0, 3);
            this.ParametersPanel.Controls.Add(this.EndpointUrlTextBox, 1, 0);
            this.ParametersPanel.Controls.Add(this.ButtonPanel, 0, 7);
            this.ParametersPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ParametersPanel.Location = new System.Drawing.Point(0, 0);
            this.ParametersPanel.Name = "ParametersPanel";
            this.ParametersPanel.RowCount = 8;
            this.ParametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ParametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ParametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ParametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ParametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ParametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ParametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ParametersPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.ParametersPanel.Size = new System.Drawing.Size(1008, 214);
            this.ParametersPanel.TabIndex = 0;
            // 
            // ReceiverTextBox
            // 
            this.ReceiverTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiverTextBox.Location = new System.Drawing.Point(83, 107);
            this.ReceiverTextBox.Name = "ReceiverTextBox";
            this.ReceiverTextBox.Size = new System.Drawing.Size(922, 20);
            this.ReceiverTextBox.TabIndex = 14;
            // 
            // ReceiverLabel
            // 
            this.ReceiverLabel.AutoSize = true;
            this.ReceiverLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReceiverLabel.Location = new System.Drawing.Point(3, 104);
            this.ReceiverLabel.Name = "ReceiverLabel";
            this.ReceiverLabel.Size = new System.Drawing.Size(74, 26);
            this.ReceiverLabel.TabIndex = 13;
            this.ReceiverLabel.Text = "Receiver";
            this.ReceiverLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SenderTextBox
            // 
            this.SenderTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SenderTextBox.Location = new System.Drawing.Point(83, 55);
            this.SenderTextBox.Name = "SenderTextBox";
            this.SenderTextBox.Size = new System.Drawing.Size(922, 20);
            this.SenderTextBox.TabIndex = 12;
            // 
            // SenderLabel
            // 
            this.SenderLabel.AutoSize = true;
            this.SenderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SenderLabel.Location = new System.Drawing.Point(3, 52);
            this.SenderLabel.Name = "SenderLabel";
            this.SenderLabel.Size = new System.Drawing.Size(74, 26);
            this.SenderLabel.TabIndex = 11;
            this.SenderLabel.Text = "Sender";
            this.SenderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MessageTextBox
            // 
            this.MessageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MessageTextBox.Location = new System.Drawing.Point(83, 159);
            this.MessageTextBox.Name = "MessageTextBox";
            this.MessageTextBox.Size = new System.Drawing.Size(922, 20);
            this.MessageTextBox.TabIndex = 10;
            // 
            // MessageLabel
            // 
            this.MessageLabel.AutoSize = true;
            this.MessageLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLabel.Location = new System.Drawing.Point(3, 156);
            this.MessageLabel.Name = "MessageLabel";
            this.MessageLabel.Size = new System.Drawing.Size(74, 26);
            this.MessageLabel.TabIndex = 9;
            this.MessageLabel.Text = "Message";
            this.MessageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // AmqpNodeNameTextBox
            // 
            this.AmqpNodeNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.AmqpNodeNameTextBox.Location = new System.Drawing.Point(83, 29);
            this.AmqpNodeNameTextBox.Name = "AmqpNodeNameTextBox";
            this.AmqpNodeNameTextBox.Size = new System.Drawing.Size(922, 20);
            this.AmqpNodeNameTextBox.TabIndex = 7;
            // 
            // AmqpNodeNameLabel
            // 
            this.AmqpNodeNameLabel.AutoSize = true;
            this.AmqpNodeNameLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AmqpNodeNameLabel.Location = new System.Drawing.Point(3, 26);
            this.AmqpNodeNameLabel.Name = "AmqpNodeNameLabel";
            this.AmqpNodeNameLabel.Size = new System.Drawing.Size(74, 26);
            this.AmqpNodeNameLabel.TabIndex = 6;
            this.AmqpNodeNameLabel.Text = "Queue Name";
            this.AmqpNodeNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ReceiveKeyTextBox
            // 
            this.ReceiveKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ReceiveKeyTextBox.Location = new System.Drawing.Point(83, 133);
            this.ReceiveKeyTextBox.Name = "ReceiveKeyTextBox";
            this.ReceiveKeyTextBox.Size = new System.Drawing.Size(922, 20);
            this.ReceiveKeyTextBox.TabIndex = 5;
            // 
            // SendKeyTextBox
            // 
            this.SendKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SendKeyTextBox.Location = new System.Drawing.Point(83, 81);
            this.SendKeyTextBox.Name = "SendKeyTextBox";
            this.SendKeyTextBox.Size = new System.Drawing.Size(922, 20);
            this.SendKeyTextBox.TabIndex = 4;
            // 
            // ReceiveKeyLabel
            // 
            this.ReceiveKeyLabel.AutoSize = true;
            this.ReceiveKeyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReceiveKeyLabel.Location = new System.Drawing.Point(3, 130);
            this.ReceiveKeyLabel.Name = "ReceiveKeyLabel";
            this.ReceiveKeyLabel.Size = new System.Drawing.Size(74, 26);
            this.ReceiveKeyLabel.TabIndex = 2;
            this.ReceiveKeyLabel.Text = "Receive Key";
            this.ReceiveKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EndpointUrlLabel
            // 
            this.EndpointUrlLabel.AutoSize = true;
            this.EndpointUrlLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EndpointUrlLabel.Location = new System.Drawing.Point(3, 0);
            this.EndpointUrlLabel.Name = "EndpointUrlLabel";
            this.EndpointUrlLabel.Size = new System.Drawing.Size(74, 26);
            this.EndpointUrlLabel.TabIndex = 0;
            this.EndpointUrlLabel.Text = "Endpoint URL";
            this.EndpointUrlLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // SendKeyLabel
            // 
            this.SendKeyLabel.AutoSize = true;
            this.SendKeyLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendKeyLabel.Location = new System.Drawing.Point(3, 78);
            this.SendKeyLabel.Name = "SendKeyLabel";
            this.SendKeyLabel.Size = new System.Drawing.Size(74, 26);
            this.SendKeyLabel.TabIndex = 1;
            this.SendKeyLabel.Text = "Send Key";
            this.SendKeyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EndpointUrlTextBox
            // 
            this.EndpointUrlTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EndpointUrlTextBox.Location = new System.Drawing.Point(83, 3);
            this.EndpointUrlTextBox.Name = "EndpointUrlTextBox";
            this.EndpointUrlTextBox.Size = new System.Drawing.Size(922, 20);
            this.EndpointUrlTextBox.TabIndex = 3;
            // 
            // MessageLogPanel
            // 
            this.MessageLogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MessageLogPanel.Location = new System.Drawing.Point(0, 214);
            this.MessageLogPanel.Name = "MessageLogPanel";
            // 
            // MessageLogPanel.Panel1
            // 
            this.MessageLogPanel.Panel1.Controls.Add(this.SendLogTextBox);
            // 
            // MessageLogPanel.Panel2
            // 
            this.MessageLogPanel.Panel2.Controls.Add(this.ReceiveLogTextBox);
            this.MessageLogPanel.Size = new System.Drawing.Size(1008, 515);
            this.MessageLogPanel.SplitterDistance = 502;
            this.MessageLogPanel.TabIndex = 1;
            // 
            // SendLogTextBox
            // 
            this.SendLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SendLogTextBox.Location = new System.Drawing.Point(0, 0);
            this.SendLogTextBox.Name = "SendLogTextBox";
            this.SendLogTextBox.ReadOnly = true;
            this.SendLogTextBox.Size = new System.Drawing.Size(502, 515);
            this.SendLogTextBox.TabIndex = 0;
            this.SendLogTextBox.Text = "";
            this.SendLogTextBox.WordWrap = false;
            // 
            // ReceiveLogTextBox
            // 
            this.ReceiveLogTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReceiveLogTextBox.Location = new System.Drawing.Point(0, 0);
            this.ReceiveLogTextBox.Name = "ReceiveLogTextBox";
            this.ReceiveLogTextBox.ReadOnly = true;
            this.ReceiveLogTextBox.Size = new System.Drawing.Size(502, 515);
            this.ReceiveLogTextBox.TabIndex = 0;
            this.ReceiveLogTextBox.Text = "";
            this.ReceiveLogTextBox.WordWrap = false;
            // 
            // SendButton
            // 
            this.SendButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.SendButton.Location = new System.Drawing.Point(75, 0);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 29);
            this.SendButton.TabIndex = 9;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ButtonPanel
            // 
            this.ParametersPanel.SetColumnSpan(this.ButtonPanel, 2);
            this.ButtonPanel.Controls.Add(this.SendButton);
            this.ButtonPanel.Controls.Add(this.ConnectButton);
            this.ButtonPanel.Location = new System.Drawing.Point(3, 185);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(1002, 29);
            this.ButtonPanel.TabIndex = 15;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.ConnectButton.Location = new System.Drawing.Point(0, 0);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(75, 29);
            this.ConnectButton.TabIndex = 10;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // BrokerTesterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 729);
            this.Controls.Add(this.MessageLogPanel);
            this.Controls.Add(this.ParametersPanel);
            this.Name = "BrokerTesterForm";
            this.Text = "Broker Tester";
            this.ParametersPanel.ResumeLayout(false);
            this.ParametersPanel.PerformLayout();
            this.MessageLogPanel.Panel1.ResumeLayout(false);
            this.MessageLogPanel.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MessageLogPanel)).EndInit();
            this.MessageLogPanel.ResumeLayout(false);
            this.ButtonPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel ParametersPanel;
        private System.Windows.Forms.TextBox ReceiveKeyTextBox;
        private System.Windows.Forms.TextBox SendKeyTextBox;
        private System.Windows.Forms.Label ReceiveKeyLabel;
        private System.Windows.Forms.Label EndpointUrlLabel;
        private System.Windows.Forms.Label SendKeyLabel;
        private System.Windows.Forms.TextBox EndpointUrlTextBox;
        private System.Windows.Forms.TextBox MessageTextBox;
        private System.Windows.Forms.Label MessageLabel;
        private System.Windows.Forms.TextBox AmqpNodeNameTextBox;
        private System.Windows.Forms.Label AmqpNodeNameLabel;
        private System.Windows.Forms.SplitContainer MessageLogPanel;
        private System.Windows.Forms.RichTextBox SendLogTextBox;
        private System.Windows.Forms.RichTextBox ReceiveLogTextBox;
        private System.Windows.Forms.TextBox ReceiverTextBox;
        private System.Windows.Forms.Label ReceiverLabel;
        private System.Windows.Forms.TextBox SenderTextBox;
        private System.Windows.Forms.Label SenderLabel;
        private System.Windows.Forms.Panel ButtonPanel;
        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button SendButton;
    }
}

