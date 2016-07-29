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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IdentityModel.Tokens;
using System.IdentityModel.Claims;
using System.IdentityModel;
using System.IdentityModel.Selectors;
using System.Windows.Forms;
using System.IO;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Client.Controls;

namespace DsatsDemoClient
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
            ConnectServerCTRL.ServerUrl = "opc.tcp://localhost:61000/DsatsDemoServer";
            this.Text = m_configuration.ApplicationName;
        }
        #endregion

        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private Session m_session;
        private Subscription m_subscription;
        private FilterDeclaration m_filter;
        private bool m_connectedOnce;
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
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                    EventsLV.IsSubscribed = false;
                    EventsLV.DisplayConditions = true;
                    EventsLV.ChangeArea(Opc.Ua.ObjectIds.Server, false);

                    FilterDeclaration filter = new FilterDeclaration();

                    ushort namespaceIndex = (ushort)m_session.NamespaceUris.GetIndex(DsatsDemo.Namespaces.DsatsDemo);

                    filter.EventTypeId = ExpandedNodeId.ToNodeId(DsatsDemo.ObjectTypeIds.LockConditionType, m_session.NamespaceUris);

                    filter.AddSimpleField(String.Empty, BuiltInType.NodeId, false);
                    filter.AddSimpleField(Opc.Ua.BrowseNames.EventId, BuiltInType.ByteString, false);
                    filter.AddSimpleField(Opc.Ua.BrowseNames.EventType, BuiltInType.NodeId, false);
                    filter.AddSimpleField(Opc.Ua.BrowseNames.ConditionName, BuiltInType.String, true);
       
                    filter.AddSimpleField(new QualifiedName[] { 
                        new QualifiedName(DsatsDemo.BrowseNames.LockState, namespaceIndex),
                        new QualifiedName(Opc.Ua.BrowseNames.CurrentState) },
                        BuiltInType.String,
                        ValueRanks.Scalar,
                        true);

                    filter.AddSimpleField(new QualifiedName(DsatsDemo.BrowseNames.ClientUserId, namespaceIndex), BuiltInType.String, true);
                    filter.AddSimpleField(new QualifiedName(DsatsDemo.BrowseNames.SubjectName, namespaceIndex), BuiltInType.String, true);
                    filter.AddSimpleField(new QualifiedName(DsatsDemo.BrowseNames.SessionId, namespaceIndex), BuiltInType.NodeId, true);

                    EventsLV.ChangeFilter(filter, true);
                    
                    m_filter = filter;

                    PhaseCB.Items.Clear();

                    BrowseDescription nodeToBrowse = new BrowseDescription();
                    nodeToBrowse.NodeId = new NodeId(DsatsDemo.Objects.Rig_Phases, namespaceIndex);
                    nodeToBrowse.ReferenceTypeId = Opc.Ua.ReferenceTypeIds.HierarchicalReferences;
                    nodeToBrowse.IncludeSubtypes = true;
                    nodeToBrowse.BrowseDirection = BrowseDirection.Forward;
                    nodeToBrowse.ResultMask = (uint)BrowseResultMask.All;

                    DataValue value = m_session.ReadValue(new NodeId(DsatsDemo.Variables.Rig_CurrentPhase, namespaceIndex));
                    NodeId currentPhase = value.GetValue<NodeId>(null);

                    ReferenceDescriptionCollection references = ClientUtils.Browse(m_session, nodeToBrowse, false);

                    if (references != null)
                    {
                        for (int ii = 0; ii < references.Count; ii++)
                        {
                            PhaseCB.Items.Add(references[ii]);

                            if (currentPhase == references[ii].NodeId)
                            {
                                PhaseCB.SelectedIndex = ii;
                            }
                        }
                    }

                    m_connectedOnce = true;
                }

                EventsLV.IsSubscribed = true;
                EventsLV.ChangeSession(m_session, true);
                EventsLV.ConditionRefresh();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                if (m_session == null)
                {
                    return;
                }

                MonitoredItemNotification notification = e.NotificationValue as MonitoredItemNotification;

                if (notification == null)
                {
                    return;
                }

                ListViewItem.ListViewSubItem item = (ListViewItem.ListViewSubItem)monitoredItem.Handle;
                item.Text = Utils.Format("{0}", notification.Value.WrappedValue);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Updates the application after a communicate error was detected.
        /// </summary>
        private void Server_ReconnectStarting(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                foreach (Subscription subscription in m_session.Subscriptions)
                {
                    m_subscription = subscription;
                    break;
                }
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
            ConnectServerCTRL.Disconnect();
        }
        #endregion

        private void Lock_RequestMI_Click(object sender, EventArgs e)
        {
            try
            {
                VariantCollection row = EventsLV.GetSelectedEvent(0);

                for (int ii = 1; row != null; ii++)
                {
                    NodeId conditionId = row[0].Value as NodeId;

                    if (conditionId != null)
                    {
                        m_session.Call(conditionId, ExpandedNodeId.ToNodeId(DsatsDemo.MethodIds.LockConditionType_Request, m_session.NamespaceUris));
                    }

                    row = EventsLV.GetSelectedEvent(ii);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lock_ReleaseMI_Click(object sender, EventArgs e)
        {
            try
            {
                VariantCollection row = EventsLV.GetSelectedEvent(0);

                for (int ii = 1; row != null; ii++)
                {
                    NodeId conditionId = row[0].Value as NodeId;

                    if (conditionId != null)
                    {
                        m_session.Call(conditionId, ExpandedNodeId.ToNodeId(DsatsDemo.MethodIds.LockConditionType_Release, m_session.NamespaceUris));
                    }

                    row = EventsLV.GetSelectedEvent(ii);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Lock_ApproveMI_Click(object sender, EventArgs e)
        {
            try
            {
                VariantCollection row = EventsLV.GetSelectedEvent(0);

                for (int ii = 1; row != null; ii++)
                {
                    NodeId conditionId = row[0].Value as NodeId;

                    if (conditionId != null)
                    {
                        m_session.Call(conditionId, ExpandedNodeId.ToNodeId(DsatsDemo.MethodIds.LockConditionType_Approve, m_session.NamespaceUris));
                    }

                    row = EventsLV.GetSelectedEvent(ii);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_session != null)
                {
                    m_session.UpdateSession(new UserIdentity(UserNameTB.Text, PasswordTB.Text), null);
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ChangeBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_session != null)
                {
                    ReferenceDescription reference = PhaseCB.SelectedItem as ReferenceDescription;

                    if (reference != null)
                    {
                        NodeId objectId = ExpandedNodeId.ToNodeId(DsatsDemo.ObjectIds.Rig, m_session.NamespaceUris);
                        NodeId methodId = ExpandedNodeId.ToNodeId(DsatsDemo.MethodIds.Rig_ChangePhase, m_session.NamespaceUris);
                        m_session.Call(objectId, methodId, (NodeId)reference.NodeId);
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Private Methods
        #endregion

        #region Event Handlers
        #endregion
    }
}
