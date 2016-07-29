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

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.IO;
using Opc.Ua;
using Opc.Ua.Client;

namespace Quickstarts.UaTestClient
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
        }
        
        /// <summary>
        /// Creates a form which uses the specified client configuration.
        /// </summary>
        /// <param name="configuration">The configuration to use.</param>
        public MainForm(ApplicationConfiguration configuration)
        {
            InitializeComponent();

            // save the configuration.
            m_configuration = configuration;
            this.Text = m_configuration.ApplicationName;

            // find the client certificate.
            m_clientCertificate = m_configuration.SecurityConfiguration.ApplicationCertificate.Find(true);  
            
            // set up a callback to handle certificate validation errors.
            m_configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
        }
        #endregion
        
        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private X509Certificate2 m_clientCertificate;
        private Session m_session;
        private Subscription m_subscription;
        private SessionReconnectHandler m_reconnectHandler;
        private NodeId m_objectNode;
        private NodeId m_methodNode;
        #endregion

        #region Private Methods
        /// <summary>
        /// Finds the endpoint that best matches the current settings.
        /// </summary>
        private EndpointDescription SelectEndpoint()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                // determine the URL that was selected.
                string discoveryUrl = UrlCB.Text;

                if (UrlCB.SelectedIndex >= 0)
                {
                    discoveryUrl = (string)UrlCB.SelectedItem;
                }

                // return the selected endpoint.
                return FormUtils.SelectEndpoint(discoveryUrl, UseSecurityCK.Checked);
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }
        #endregion

        #region Event Handlers
        /// <summary>
        /// Connects to a server.
        /// </summary>
        private void Server_ConnectMI_Click(object sender, EventArgs e)
        {            
            try
            {
                // disconnect any existing session.
                Server_DisconnectMI_Click(sender, e);

                InitialStateTB.Text = "1";
                FinalStateTB.Text = "100";

                // create the session.
                EndpointDescription endpointDescription = SelectEndpoint();
                EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(m_configuration);
                ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
                
                m_session = Session.Create(
                    m_configuration,
                    endpoint,
                    true,
                    m_configuration.ApplicationName,
                    60000,
                    null,
                    null);

                // set up keep alive callback.
                m_session.KeepAliveInterval = 2000;
                m_session.KeepAlive += new KeepAliveEventHandler(Session_KeepAlive);

                // this client has built-in knowledge of the information model used by the server.
                NamespaceTable wellKnownNamespaceUris = new NamespaceTable();
                wellKnownNamespaceUris.Append(Namespaces.Methods);

                string[] browsePaths = new string[] 
                {
                    "1:My Process/1:State",
                    "1:My Process",
                    "1:My Process/1:Start"
                };

                List<NodeId> nodes = FormUtils.TranslateBrowsePaths(
                    m_session,
                    ObjectIds.ObjectsFolder,
                    wellKnownNamespaceUris,
                    browsePaths);
                
                // subscribe to the state if available.
                if (nodes.Count > 0 && !NodeId.IsNull(nodes[0]))
                {
                    m_subscription = new Subscription();

                    m_subscription.PublishingEnabled = true;
                    m_subscription.PublishingInterval = 1000;
                    m_subscription.Priority = 1;
                    m_subscription.KeepAliveCount = 10;
                    m_subscription.LifetimeCount = 20;
                    m_subscription.MaxNotificationsPerPublish = 1000;

                    m_session.AddSubscription(m_subscription);
                    m_subscription.Create();

                    MonitoredItem monitoredItem = new MonitoredItem();
                    monitoredItem.StartNodeId = nodes[0];
                    monitoredItem.AttributeId = Attributes.Value;
                    monitoredItem.Notification += new MonitoredItemNotificationEventHandler(MonitoredItem_Notification);
                    m_subscription.AddItem(monitoredItem);

                    m_subscription.ApplyChanges();
                }
                
                // save the object/method
                if (nodes.Count > 2)
                {
                    m_objectNode = nodes[1];
                    m_methodNode = nodes[2];
                }

                ConnectedLB.Text = "Connected";
                ServerUrlLB.Text = endpointDescription.EndpointUrl;
                LastKeepAliveTimeLB.Text = "---";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Disconnects from the current session.
        /// </summary>
        private void Server_ReconnectComplete(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new EventHandler(Server_ReconnectComplete), sender, e);
                return;
            }

            try
            {
                // ignore callbacks from discarded objects.
                if (!Object.ReferenceEquals(sender, m_reconnectHandler))
                {
                    return;
                }

                m_session = m_reconnectHandler.Session;

                m_reconnectHandler.Dispose();
                m_reconnectHandler = null;

                ConnectedLB.Text = "Connected";
                LastKeepAliveTimeLB.Text = "---";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles a keep alive notification for a session by updating the status bar.
        /// </summary>
        private void Session_KeepAlive(Session session, KeepAliveEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new KeepAliveEventHandler(Session_KeepAlive), session, e);
                return;
            }

            try
            {
                // check for events from discarded sessions.
                if (!Object.ReferenceEquals(session, m_session))
                {
                    return;
                }

                if (ServiceResult.IsBad(e.Status))
                {
                    if (m_reconnectHandler == null)
                    {
                        LastKeepAliveTimeLB.Text = e.Status.ToString();
                        LastKeepAliveTimeLB.ForeColor = Color.Red;

                        ConnectedLB.Text = "Reconnecting";

                        m_reconnectHandler = new SessionReconnectHandler();
                        m_reconnectHandler.BeginReconnect(m_session, 10000, Server_ReconnectComplete);
                    }

                    return;
                }

                LastKeepAliveTimeLB.Text = Utils.Format("{0:HH:mm:ss}", e.CurrentTime.ToLocalTime());
                LastKeepAliveTimeLB.ForeColor = Color.Empty;
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cleans up when the main form closes.
        /// </summary>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (m_reconnectHandler != null)
            {
                m_reconnectHandler.Dispose();
                m_reconnectHandler = null;
            }

            if (m_session != null)
            {
                m_session.Close(1000);
                m_session = null;
            }
        }
        
        /// <summary>
        /// Disconnects from the current session.
        /// </summary>
        private void Server_DisconnectMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_session != null)
                {
                    m_session.Close(10000);
                    m_session = null;
                }

                ConnectedLB.Text = "Disconnected";
                ServerUrlLB.Text = "---";
                LastKeepAliveTimeLB.Text = "---";
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        /// <summary>
        /// Prompts the user to accept an untrusted certificate.
        /// </summary>
        private void CertificateValidator_CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new CertificateValidationEventHandler(CertificateValidator_CertificateValidation), sender, e);
                return;
            }

            try
            {
                DialogResult result = MessageBox.Show(
                    e.Certificate.Subject,
                    "Untrusted Certificate", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Warning);

                e.Accept = (result == DialogResult.Yes);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Server_DiscoverMI_Click(object sender, EventArgs e)
        {
            try
            {
                string endpointUrl = new Opc.Ua.Client.Controls.DiscoverServerDlg().ShowDialog(m_configuration, null);

                if (endpointUrl != null)
                {
                    UrlCB.SelectedIndex = -1;
                    UrlCB.Text = endpointUrl;
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the DropDown event of the UrlCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void UrlCB_DropDown(object sender, EventArgs e)
        {
            UrlCB.Items.Clear();

            // create a table of application descriptions that match the drop down entries.
            List<ApplicationDescription> lookupTable = new List<ApplicationDescription>();
            UrlCB.Tag = lookupTable;
            
            try
            {
                Cursor = Cursors.WaitCursor;

                try
                {
                    IList<string> serverUrls = FormUtils.DiscoverServers(m_configuration);

                    // populate the drop down list with the discovery URLs for the available servers.
                    for (int ii = 0; ii < serverUrls.Count; ii++)
                    {
                        // remove duplicates.
                        int index = UrlCB.FindStringExact(serverUrls[ii]);

                        if (index < 0)
                        {
                            UrlCB.Items.Add(serverUrls[ii]);
                        }
                    }
                }
                finally
                {
                    Cursor = Cursors.Default;
                } 
            }
            catch (Exception)
            {
                // add the default URLs even if the LDS is not running.
                UrlCB.Items.Add("http://localhost:62540/Quickstarts/MethodsServer");
                UrlCB.Items.Add("opc.tcp://localhost:62541/Quickstarts/MethodsServer");
            }
        }

        private void StartBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_session == null)
                {
                    return;
                }

                uint initialState = Convert.ToUInt32(InitialStateTB.Text);
                uint finalState = Convert.ToUInt32(FinalStateTB.Text);

                RevisedInitialStateTB.Text = String.Empty;
                RevisedFinalStateTB.Text = String.Empty;

                IList<object> outputArguments = m_session.Call(
                    m_objectNode,
                    m_methodNode,
                    initialState,
                    finalState);

                if (outputArguments != null && outputArguments.Count > 1)
                {
                    RevisedInitialStateTB.Text = String.Format("{0}", outputArguments[0]);
                    RevisedFinalStateTB.Text = String.Format("{0}", outputArguments[1]);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void MonitoredItem_Notification(MonitoredItem monitoredItem, MonitoredItemNotificationEventArgs e)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MonitoredItemNotificationEventHandler(MonitoredItem_Notification), monitoredItem, e);
                return;
            }

            try
            {
                MonitoredItemNotification datachange = e.NotificationValue as MonitoredItemNotification;

                if (datachange == null)
                {
                    return;
                }

                CurrentStateTB.Text = datachange.Value.WrappedValue.ToString();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion
    }
}
