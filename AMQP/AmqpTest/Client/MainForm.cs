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
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;

namespace AmqpTestClient
{
    /// <summary>
    /// The main form for a simple Quickstart Client application.
    /// </summary>
    public partial class MainForm : Form
    {
        private int m_counter;
        private Subscription m_subscription;

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

            ConnectServerCTRL.SetAvailableUrls(new string[]
            {
                "opc.tcp://localhost:62546",
                "opc.amqp://opcfoundation-prototyping.org/Server1",
                "opc.amqp://opcfoundation-prototyping.servicebus.windows.net/MyServer"
            });

            ConnectServerCTRL.ServerUrl = "opc.amqp://opcfoundation-prototyping.org/Server1";
            this.Text = m_configuration.ApplicationName;
        }
        #endregion

        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private Session m_session;
        private bool m_connectedOnce;
        #endregion

        #region Private Methods
        #endregion

        #region Event Handlers
        /// <summary>
        /// Connects to a server.
        /// </summary>
        private async void Server_ConnectMI_Click(object sender, EventArgs e)
        {
            try
            {
                await ConnectServerCTRL.ConnectAsync();
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Disconnects from the current session.
        /// </summary>
        private async void Server_DisconnectMI_Click(object sender, EventArgs e)
        {
            try
            {
                await ConnectServerCTRL.DisconnectAsync();
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

                // set a suitable initial state.
                if (m_session != null && !m_connectedOnce)
                {
                    m_connectedOnce = true;
                }

                // browse the instances in the server.
                BrowseCTRL.Initialize(m_session, ObjectIds.ObjectsFolder, ReferenceTypeIds.Organizes, ReferenceTypeIds.Aggregates);

                if (m_session == null)
                {
                    LogTextBox.Clear();
                }

                if (m_session != null)
                {
                    m_subscription = new Subscription();

                    m_subscription.Handle = this;
                    m_subscription.PublishingEnabled = true;
                    m_subscription.PublishingInterval = 500;
                    m_subscription.KeepAliveCount = 10;
                    m_subscription.LifetimeCount = 100;
                    m_subscription.MaxNotificationsPerPublish = 1000;
                    m_subscription.TimestampsToReturn = TimestampsToReturn.Both;

                    m_session.AddSubscription(m_subscription);
                    m_subscription.Create();

                    var monitoredItem = new MonitoredItem();

                    monitoredItem.StartNodeId = VariableIds.Server_ServerStatus_CurrentTime;
                    monitoredItem.AttributeId = Attributes.Value;
                    monitoredItem.SamplingInterval = 5000;
                    monitoredItem.QueueSize = 1000;
                    monitoredItem.DiscardOldest = true;

                    monitoredItem.Notification += new MonitoredItemNotificationEventHandler(MonitoredItem_Notification);

                    m_subscription.AddItem(monitoredItem);
                    m_subscription.ApplyChanges();
                }
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the display with a new value for a monitored variable. 
        /// </summary>
        private void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem_Notification), monitoredItem, e);
                return;
            }

            try
            {
                if (!Object.ReferenceEquals(monitoredItem.Subscription, m_subscription))
                {
                    return;
                }

                MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;

                if (notification == null)
                {
                    return;
                }

                m_counter++;

                if (m_counter % 8 == 0)
                {
                    LogTextBox.Clear();
                }

                LogTextBox.AppendText(String.Format(
                    "[DataValue] {0} {1} {2}", 
                    notification.Value.ServerTimestamp.ToLocalTime().ToString("HH:mm:ss.fff"),
                    notification.Value.StatusCode, 
                    notification.Value.WrappedValue.ToString()));

                LogTextBox.AppendText(Environment.NewLine);
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
            try
            {
                BrowseCTRL.ChangeSession(null);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Updates the application after reconnecting to the server.
        /// </summary>
        private void Server_ReconnectComplete(object sender, EventArgs e)
        {
            try
            {
                m_session = ConnectServerCTRL.Session;
                BrowseCTRL.ChangeSession(m_session);
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        /// <summary>
        /// Cleans up when the main form closes.
        /// </summary>
        private async void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            await ConnectServerCTRL.DisconnectAsync();
        }
        #endregion
    }
}
