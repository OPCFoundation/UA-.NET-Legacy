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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.IO;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using System.Diagnostics;

namespace Quickstarts.Sortiermaschine.Client
{
    /// <summary>
    /// The main form for a simple Quickstart Client application.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        private MainForm()
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();
        }

        /// <summary>
        /// Creates a form which uses the specified client configuration.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        public MainForm(ApplicationConfiguration configuration)
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();

            ConnectServerCTRL.Configuration = m_configuration = configuration;
            ConnectServerCTRL.ServerUrl = "opc.tcp://192.168.0.54:4840"; // IP-Adresse der Festo-CPX-CEC-Steuerung
            this.Text = m_configuration.ApplicationName;
            // Hier die Liste der Nodes Initaialisieren, für die ein MonitoredItem erstellt werden soll. In der Reihenfolge 
            // von Oben nach unten wie im MainForm abgeblide.
            nodes = new List<NodeId>();
            nodes.Add(new NodeId("|var|CPX-CEC-C1-V3.Application.Main_Ablauf.Flow", 2));
            nodes.Add(new NodeId("|var|CPX-CEC-C1-V3.Application.Main_Ablauf.PGreif", 2));
            nodes.Add(new NodeId("|var|CPX-CEC-C1-V3.Application.Main_Ablauf.HoehePuk", 2));
            nodes.Add(new NodeId("|var|CPX-CEC-C1-V3.Application.Main_Ablauf.Ausschusszaehler", 2));
            nodes.Add(new NodeId("|var|CPX-CEC-C1-V3.Application.Main_Ablauf.PukZaehler", 2));
        }
        #endregion

        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private Session m_session;
        private Subscription m_subscription;
        private bool m_connectedOnce;
        private List<NodeId> nodes;
        #endregion

        #region Private Methods
        #endregion

        #region Event Handlers
        /// <summary>
        /// Connects to a server.
        /// </summary>
        private void Server_ConnectMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectServerCTRL.Connect();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Disconnects from the current session.
        /// </summary>
        private void Server_DisconnectMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectServerCTRL.Disconnect();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Prompts the user to choose a server on another host.
        /// </summary>
        private void Server_DiscoverMI_Click(object sender, EventArgs e)
        {
            try
            {
                ConnectServerCTRL.Discover(null);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the application after connecting to or disconnecting from the server.
        /// </summary>
        private void Server_ConnectComplete(object sender, EventArgs e)
        {
            try
            {
                m_session = ConnectServerCTRL.Session;

                if (m_session == null)
                {
                    return;
                }

                // set a suitable initial state.
                if (m_session != null && !m_connectedOnce)
                {
                    m_connectedOnce = true;
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the application after a communicate error was detected.
        /// </summary>
        private void Server_ReconnectStarting(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the application after reconnecting to the server.
        /// </summary>
        private void Server_ReconnectComplete(object sender, EventArgs e)
        {
            try
            {
                m_session = ConnectServerCTRL.Session;

                foreach (Subscription subscription in m_session.Subscriptions)
                {
                    m_subscription = subscription;
                    break;
                }

            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Cleans up when the main form closes.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ConnectServerCTRL.Disconnect();
        }
        #endregion

        #region Event Handlers

        void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem_Notification), monitoredItem, e);
                return;
            }

            try
            {
                Control control = monitoredItem.Handle as Control;

                if (control == null)
                {
                    return;
                }

                MonitoredItemNotification datachange = e.NotificationValue as MonitoredItemNotification;

                if (datachange == null)
                {
                    return;
                }

                control.Text = datachange.Value.WrappedValue.ToString();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        #endregion

        private void MainForm_Load(object sender, EventArgs e)
        {
            LinkLabel.Link link = new LinkLabel.Link();
            link.LinkData = "http://www.hs-esslingen.de";
            linkLabel1.Links.Add(link);
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start(e.Link.LinkData as string);
        }
        /// <summary>
        /// Setzt den CounterWaste Wert im Server auf 0
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_session == null)
                {
                    return;
                }
                DisplayCounterWaste.Text = "0";
                WriteValue valueToWrite = new WriteValue();

                valueToWrite.NodeId = nodes[3];
                valueToWrite.AttributeId = Attributes.Value;
                valueToWrite.Value.Value = Convert.ToInt16("0");
                valueToWrite.Value.StatusCode = StatusCodes.Good;
                valueToWrite.Value.ServerTimestamp = DateTime.MinValue;
                valueToWrite.Value.SourceTimestamp = DateTime.MinValue;

                WriteValueCollection valuesToWrite = new WriteValueCollection();
                valuesToWrite.Add(valueToWrite);

                // write current value.
                StatusCodeCollection results = null;
                DiagnosticInfoCollection diagnosticInfos = null;

                m_session.Write(
                    null,
                    valuesToWrite,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, valuesToWrite);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, valuesToWrite);

                if (StatusCode.IsBad(results[0]))
                {
                    throw new ServiceResultException(results[0]);
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException("Error Writing Value", exception);
            }
        }

        /// <summary>
        /// Setzt den Counter Wert im Server auf 0
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_session == null)
                {
                    return;
                }
                DisplayCounter.Text = "0";
                WriteValue valueToWrite = new WriteValue();

                valueToWrite.NodeId = nodes[4];
                valueToWrite.AttributeId = Attributes.Value;
                valueToWrite.Value.Value = Convert.ToInt16("0");
                valueToWrite.Value.StatusCode = StatusCodes.Good;
                valueToWrite.Value.ServerTimestamp = DateTime.MinValue;
                valueToWrite.Value.SourceTimestamp = DateTime.MinValue;

                WriteValueCollection valuesToWrite = new WriteValueCollection();
                valuesToWrite.Add(valueToWrite);

                // write current value.
                StatusCodeCollection results = null;
                DiagnosticInfoCollection diagnosticInfos = null;

                m_session.Write(
                    null,
                    valuesToWrite,
                    out results,
                    out diagnosticInfos);

                ClientBase.ValidateResponse(results, valuesToWrite);
                ClientBase.ValidateDiagnosticInfos(diagnosticInfos, valuesToWrite);

                if (StatusCode.IsBad(results[0]))
                {
                    throw new ServiceResultException(results[0]);
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException("Error Writing Value", exception);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            int caseSwitch;
            if (String.IsNullOrEmpty(textBox2.Text))
            {
                textBox1.BackColor = Color.White;
                InputLampLabel1.Text = "Please enter a number between 1 and 3!";
            }
            else
            {
                caseSwitch = Int32.Parse(textBox2.Text);
                switch (caseSwitch)
                {

                    case 1:
                        textBox1.BackColor = Color.Green;
                        InputLampLabel1.Text = "Good";
                        break;

                    case 2:
                        textBox1.BackColor = Color.Yellow;
                        InputLampLabel1.Text = "Maintance";
                        break;

                    case 3:
                        textBox1.BackColor = Color.Red;
                        InputLampLabel1.Text = "Alert";
                        break;
                    default:
                        InputLampLabel1.Text = "invalid Input!";
                        break;
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_session == null)
                {
                    return;
                }

                if (m_subscription != null)
                {
                    m_session.RemoveSubscription(m_subscription);
                    m_subscription = null;
                }

                m_subscription = new Subscription();

                m_subscription.PublishingEnabled = true;
                m_subscription.PublishingInterval = 1000;
                m_subscription.Priority = 1;
                m_subscription.KeepAliveCount = 10;
                m_subscription.LifetimeCount = 20;
                m_subscription.MaxNotificationsPerPublish = 1000;

                m_session.AddSubscription(m_subscription);
                m_subscription.Create();

                Control[] controls = new Control[] 
                {
                    DisplayAirFlowRate,
                    DisplayHookPressure,
                    DisplayBoxHeight,
                    DisplayCounterWaste,
                    DisplayCounter
                };

                for (int ii = 0; ii < nodes.Count; ii++)
                {
                    controls[ii].Text = "---";

                    if (nodes[ii] != null)
                    {
                        MonitoredItem monitoredItem = new MonitoredItem();
                        monitoredItem.StartNodeId = nodes[ii];
                        monitoredItem.AttributeId = Attributes.Value;
                        monitoredItem.Handle = controls[ii];
                        monitoredItem.Notification += new MonitoredItemNotificationEventHandler(MonitoredItem_Notification);
                        m_subscription.AddItem(monitoredItem);
                    }
                }

                m_subscription.ApplyChanges();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

    }
}
