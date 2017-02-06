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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Sample
{
    public partial class ClientForm : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the form and creates a session with the server.
        /// </summary>
        public ClientForm()
        {
            InitializeComponent();

            ServerStatusTB.Text = "Unknown";
            PublishingStatusTB.Text = "Stopped";

            // The server certificate is stored locally in this example.
            // It can be retrieved automatically using the UA discovery endpoint.
            
            /*
            X509Certificate2 serverCertificate = SecurityUtils.Find(
                StoreName.My,
                StoreLocation.CurrentUser,
                "My Server Name");

            // The client object will create the WCF channel when a method is called.
            m_client = MyClient.Create("http://localhost:40000/UA/SampleServer", serverCertificate);
            // m_client = MyClient.Create("net.tcp://localhost:40001/UA/SampleServer", serverCertificate);
            // m_client = MyClient.Create("net.pipe://localhost/40000/UA/SampleServer", serverCertificate);
            */
            
            X509Certificate2 serverCertificate = SecurityUtils.Find(
                StoreName.My,
                StoreLocation.LocalMachine,
                "UA Sample Server");
             
            m_client = MyClient.Create("http://localhost:51211/UA/SampleServer", serverCertificate);
            
            // connecting the the full UA sample application will require that the UA sample application be placed in the
            // LocalMachine/TrustedPeople store. This can be done via the Certificate control panel which can be accessed by:
            //
            // 1) run mmc.exe
            // 2) select 'add snap-in'
            // 3) select 'add'
            // 4) select 'Certificates'
            // 5) select 'Computer Account'
            // 6) click next/ok.

            m_client.CreateSession();
            ServerStatusTB.Text = "Connected";

            TreeNode root = new TreeNode("Root");

            ReferenceDescription reference = new ReferenceDescription();

            reference.ReferenceTypeId = new NodeId(ReferenceTypes.Organizes);
            reference.IsForward = true;
            reference.NodeId = new ExpandedNodeId(Objects.RootFolder);
            reference.BrowseName = new QualifiedName("Root");
            reference.DisplayName = new LocalizedText("Root");
            reference.NodeClass = NodeClass.Object_1;
            reference.TypeDefinition = new ExpandedNodeId(ObjectTypes.FolderType);

            root.Tag = reference;
            root.Nodes.Add(new TreeNode());

            BrowseTV.Nodes.Add(root);
        }
        #endregion

        #region MonitoredItem Class
        /// <summary>
        /// Stores the state for a monitored item.
        /// </summary>
        private class MonitoredItem
        {
            public uint MonitoredItemId;
            public ReadValueId  ItemToMonitor;
            public MonitoringMode MonitoringMode;
            public MonitoringParameters Parameters;
        }
        #endregion

        #region Private Fields
        private MyClient m_client;
        private uint m_subscriptionId;
        private double m_publishingInterval;
        private uint m_keepAliveCount;
        private uint m_lifetimeCount;
        private uint m_monitoredItemCount;
        private Dictionary<uint, MonitoredItem> m_monitoredItems = new Dictionary<uint, MonitoredItem>();
        #endregion

        #region Private Methods
        /// <summary>
        /// Follows hierarchial references from the current node and updates the tree.
        /// </summary>
        private void Browse(TreeNode parent)
        {
            parent.Nodes.Clear();

            ReferenceDescription start = parent.Tag as ReferenceDescription;

            ListOfBrowseDescription nodesToBrowse = new ListOfBrowseDescription();

            BrowseDescription nodeToBrowse = new BrowseDescription();

            nodeToBrowse.NodeId = new NodeId(start.NodeId);
            nodeToBrowse.BrowseDirection = BrowseDirection.Forward_0;
            nodeToBrowse.ReferenceTypeId = new NodeId(ReferenceTypes.HierarchicalReferences);
            nodeToBrowse.IncludeSubtypes = true;
            nodeToBrowse.ResultMask = (uint)DataTypes.EnumToMask(BrowseResultMask.All_63);
            nodeToBrowse.NodeClassMask = 0;

            nodesToBrowse.Add(nodeToBrowse);

            ListOfBrowseResult results;
            ListOfDiagnosticInfo diagnosticInfos;

            m_client.Browse(
                m_client.CreateRequestHeader(),
                null,
                0,
                nodesToBrowse,
                out results,
                out diagnosticInfos);

            if (results != null && results.Count > 0)
            {
                BrowseResult result = results[0];

                if (result.References != null)
                {
                    foreach (ReferenceDescription reference in result.References)
                    {
                        TreeNode child = new TreeNode(reference.DisplayName.Text);
                        child.Tag = reference;
                        child.Nodes.Add(new TreeNode());
                        parent.Nodes.Add(child);
                    }
                }
            }
        }

        /// <summary>
        /// Reads the attribute values for the current node and displays them.
        /// </summary>
        public void ReadAttributes(TreeNode parent)
        {
            ReferenceDescription start = parent.Tag as ReferenceDescription;

            ListOfReadValueId nodesToRead = new ListOfReadValueId();

            foreach (uint attributeId in Attributes.GetIdentifiers())
            {
                ReadValueId nodeToRead = new ReadValueId();

                nodeToRead.NodeId = new NodeId(start.NodeId);
                nodeToRead.AttributeId = attributeId;
                
                nodesToRead.Add(nodeToRead);
            }

            ListOfDataValue results;
            ListOfDiagnosticInfo diagnosticInfos;

            m_client.Read(
                m_client.CreateRequestHeader(),
                0,
                TimestampsToReturn.Both_2,
                nodesToRead,
                out results,
                out diagnosticInfos);

            if (results != null)
            {
                AttributesLV.Items.Clear();

                for (int ii = 0; ii < nodesToRead.Count; ii++)
                {
                    ReadValueId nodeToRead = nodesToRead[ii];
                    DataValue dataValue = results[ii];

                    if (dataValue.StatusCode == StatusCodes.BadAttributeIdInvalid)
                    {
                        continue;
                    }

                    ListViewItem item = new ListViewItem(Attributes.GetBrowseName(nodeToRead.AttributeId));

                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
                    item.SubItems[1].Text = dataValue.ToString();

                    AttributesLV.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Starts monitoring the value of the currently selected item.
        /// </summary>
        public void CreateMonitoredItem(ReferenceDescription node)
        {
            ListOfMonitoredItemCreateRequest itemsToCreate = new ListOfMonitoredItemCreateRequest();

            MonitoredItemCreateRequest itemToCreate = new MonitoredItemCreateRequest();

            itemToCreate.ItemToMonitor = new ReadValueId();
            itemToCreate.ItemToMonitor.NodeId = new NodeId(node.NodeId);
            itemToCreate.ItemToMonitor.AttributeId = Attributes.Value;
            itemToCreate.MonitoringMode = MonitoringMode.Reporting_2;
            itemToCreate.RequestedParameters = new MonitoringParameters();
            itemToCreate.RequestedParameters.ClientHandle = ++m_monitoredItemCount;
            itemToCreate.RequestedParameters.SamplingInterval = 1000;
            itemToCreate.RequestedParameters.QueueSize = 0;
            itemToCreate.RequestedParameters.DiscardOldest = true;
            itemToCreate.RequestedParameters.Filter = new ExtensionObject();

            itemsToCreate.Add(itemToCreate);

            ListOfMonitoredItemCreateResult results;
            ListOfDiagnosticInfo diagnosticInfos;

            m_client.CreateMonitoredItems(
                m_client.CreateRequestHeader(),
                m_subscriptionId,
                TimestampsToReturn.Both_2,
                itemsToCreate,
                out results,
                out diagnosticInfos);

            if (results != null)
            {
                // update the list view.
                MonitoredItemCreateResult result = results[0];

                ListViewItem item = new ListViewItem(itemToCreate.RequestedParameters.ClientHandle.ToString());

                item.SubItems.Add(new ListViewItem.ListViewSubItem());
                item.SubItems[1].Text = node.DisplayName.Text;

                item.SubItems.Add(new ListViewItem.ListViewSubItem());
                item.SubItems[2].Text = "<Unknown>";

                item.SubItems.Add(new ListViewItem.ListViewSubItem());
                item.SubItems[3].Text = String.Format("{0}", result.StatusCode);

                item.SubItems.Add(new ListViewItem.ListViewSubItem());
                item.SubItems[4].Text = String.Format("{0:HH:mm:ss}", DateTime.Now);

                UpdatesLV.Items.Add(item);

                // save the monitored item.
                MonitoredItem monitoredItem = new MonitoredItem();

                monitoredItem.MonitoredItemId = result.MonitoredItemId;
                monitoredItem.ItemToMonitor = itemToCreate.ItemToMonitor;
                monitoredItem.MonitoringMode = itemToCreate.MonitoringMode;
                monitoredItem.Parameters = itemToCreate.RequestedParameters;

                monitoredItem.Parameters.SamplingInterval = result.RevisedSamplingInterval;
                monitoredItem.Parameters.QueueSize = result.RevisedQueueSize;

                m_monitoredItems.Add(itemToCreate.RequestedParameters.ClientHandle, monitoredItem);

                item.Tag = monitoredItem;
            }
        }

        /// <summary>
        /// Creates a new subscription.
        /// </summary>
        public void CreateSubscription()
        {
            if (m_subscriptionId != 0)
            {
                return;
            }

            m_client.CreateSubscription(
                m_client.CreateRequestHeader(),
                1000,
                100,
                3,
                0,
                true,
                0,
                out m_subscriptionId,
                out m_publishingInterval,
                out m_lifetimeCount,
                out m_keepAliveCount);

            PublishingStatusTB.Text = "Enabled";

            ThreadPool.QueueUserWorkItem(Publish);
        }

        /// <summary>
        /// Sends publish requests in the background for the currently active subscription.
        /// </summary>
        public void Publish(object state)
        {
            try
            {
                uint subscriptionId;
                ListOfUInt32 availableSequenceNumbers;
                bool moreNotifications;
                NotificationMessage notificationMessage;
                ListOfStatusCode results;
                ListOfDiagnosticInfo diagnosticInfos;

                m_client.Publish(
                    m_client.CreateRequestHeader(),
                    new ListOfSubscriptionAcknowledgement(),
                    out subscriptionId,
                    out availableSequenceNumbers,
                    out moreNotifications,
                    out notificationMessage,
                    out results,
                    out diagnosticInfos);

                LastMessageTimeTB.Text = String.Format("{0:HH:mm:ss}", notificationMessage.PublishTime.ToLocalTime());

                foreach (ExtensionObject extension in notificationMessage.NotificationData)
                {
                    if (extension.TypeId == new ExpandedNodeId(Objects.DataChangeNotification_Encoding_DefaultXml))
                    {
                        DataChangeNotification body = (DataChangeNotification)extension.ParseBody(typeof(DataChangeNotification));

                        foreach (MonitoredItemNotification notification in body.MonitoredItems)
                        {
                            UpdateValue(notification);
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

            ThreadPool.QueueUserWorkItem(Publish);    
        }

        /// <summary>
        /// Updates the value for a monitored item displayed in the list control.
        /// </summary>
        private void UpdateValue(object state)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new WaitCallback(UpdateValue), state);
                return;
            }

            MonitoredItemNotification notification = (MonitoredItemNotification)state;

            foreach (ListViewItem item in UpdatesLV.Items)
            {
                MonitoredItem monitoredItem = item.Tag as MonitoredItem;

                if (monitoredItem != null && monitoredItem.Parameters.ClientHandle == notification.ClientHandle)
                {
                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
                    item.SubItems[2].Text = String.Format("{0}", notification.Value.Value);

                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
                    item.SubItems[3].Text = String.Format("{0}", notification.Value.StatusCode);

                    item.SubItems.Add(new ListViewItem.ListViewSubItem());
                    item.SubItems[4].Text = String.Format("{0:HH:mm:ss}", notification.Value.ServerTimestamp);
                }
            }
        }
        #endregion

        #region Event Handlers
        private void BrowseTV_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                if (e.Node.Nodes.Count != 1 || e.Node.Nodes[0].Text != "")
                {
                    return;
                }

                Browse(e.Node);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void BrowseTV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                ReadAttributes(e.Node);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Subscription_CreateMI_Click(object sender, EventArgs e)
        {
            try
            {
                CreateSubscription();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void SubscriptionMI_MonitoreValueMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (BrowseTV.SelectedNode == null || m_subscriptionId == 0)
                {
                    return;
                }

                CreateMonitoredItem(BrowseTV.SelectedNode.Tag as ReferenceDescription);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }
        #endregion
    }
}
