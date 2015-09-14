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

namespace TutorialClient
{
    /// <summary>
    /// The main form for a simple Client application.
    /// </summary>
    public partial class MainForm : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an Tutorial form.
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
            ConnectServerCTRL.ServerUrl = "opc.tcp://localhost:62541/TutorialServer";
            this.Text = m_configuration.ApplicationName;
        }
        #endregion

        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private Session m_session;
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

                // browse the instances in the server.
                BrowseCTRL.Initialize(m_session, ObjectIds.ObjectsFolder, ReferenceTypeIds.Organizes, ReferenceTypeIds.Aggregates);
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

                #region Task #B3 - Subscribe Data
                if (m_SubscribeDataDlg != null)
                {
                    m_SubscribeDataDlg.ReconnectComplete(m_session);
                }
                #endregion
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

        private void ShowReferencesMI_Click(object sender, EventArgs e)
        {
            try
            {
                #region Task #B1 - Browse References
                // do nothing if nothing selected or if a off server reference was returned.
                ReferenceDescription reference = BrowseCTRL.SelectedNode;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }

                // display the dialog.
                new ShowReferencesDlg().ShowDialog(m_session, ExpandedNodeId.ToNodeId(reference.NodeId, m_session.NamespaceUris));
                #endregion
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void WriteValueMI_Click(object sender, EventArgs e)
        {
            try
            {
                #region Task #B2 - Write Value
                // do nothing if nothing selected or if a off server reference was returned.
                ReferenceDescription reference = BrowseCTRL.SelectedNode;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }

                // display the dialog.
                new WriteValueDlg().ShowDialog(m_session, ExpandedNodeId.ToNodeId(reference.NodeId, m_session.NamespaceUris));
                #endregion
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void SubscribeMI_Click(object sender, EventArgs e)
        {
            try
            {
                #region Task #B3 - Subscribe Data
                // do nothing if nothing selected or if a off server reference was returned.
                ReferenceDescription reference = BrowseCTRL.SelectedNode;

                if (reference == null || reference.NodeId.IsAbsolute)
                {
                    return;
                }

                // display the dialog.
                m_SubscribeDataDlg = new SubscribeDataDlg();
                m_SubscribeDataDlg.FormClosed += new FormClosedEventHandler(SubscribeDataDlg_FormClosed);
                m_SubscribeDataDlg.Show(m_session, ExpandedNodeId.ToNodeId(reference.NodeId, m_session.NamespaceUris));
                #endregion
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        
        #region Task #B3 - Subscribe Data
        private SubscribeDataDlg m_SubscribeDataDlg;

        void SubscribeDataDlg_FormClosed(object sender, FormClosedEventArgs e)
        {
            m_SubscribeDataDlg = null;
        }
        #endregion

        private void CallMI_Click(object sender, EventArgs e)
        {
            try
            {
                #region Task #B4 - Call a Method
                if (m_session == null)
                {
                    return;
                }

                // do nothing if nothing selected or if a off server reference was returned.
                ReferenceDescription method = BrowseCTRL.SelectedNode;

                if (method == null || method.NodeId.IsAbsolute)
                {
                    return;
                }

                // do nothing if nothing selected or if a off server reference was returned.
                ReferenceDescription objectn = BrowseCTRL.SelectedParent;

                if (objectn == null || objectn.NodeId.IsAbsolute)
                {
                    return;
                }

                // display the dialog.
                new CallMethodDlg().Show(m_session, (NodeId)objectn.NodeId, (NodeId)method.NodeId);
                #endregion
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }

        private void Server_ChangeUserOrLocaleMI_Click(object sender, EventArgs e)
        {
            try
            {
                #region Task #D3 - Change Locale and User Identity
                if (m_session == null)
                {
                    return;
                }

                // display the dialog.
                if (new SetUserAndLocaleDlg().ShowDialog(m_session))
                {
                    ConnectServerCTRL.UserIdentity = m_session.Identity;
                    ConnectServerCTRL.PreferredLocales = m_session.PreferredLocales.ToArray();
                }
                #endregion
            }
            catch (Exception exception)
            {
                ClientUtils.HandleException(this.Text, exception);
            }
        }
        #endregion
    }
}
