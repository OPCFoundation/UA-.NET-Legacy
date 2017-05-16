/* Copyright (c) 1996-2016, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Opc.Ua.Configuration;
using Opc.Ua.Client.Controls;
using Opc.Ua.Gds;

namespace Opc.Ua.Gds
{
    public partial class QueryApplicationsDialog : Form
    {
        public QueryApplicationsDialog(GlobalDiscoveryServer gds)
        {
            InitializeComponent();
            Icon = ConfigUtils.GetAppIcon();
            ServersDataGridView.AutoGenerateColumns = false;

            m_gds = gds;

            m_dataset = new DataSet();
            m_dataset.Tables.Add("Servers");

            m_dataset.Tables[0].Columns.Add("RecordId", typeof(uint));
            m_dataset.Tables[0].Columns.Add("ApplicationName", typeof(string));
            m_dataset.Tables[0].Columns.Add("ApplicationUri", typeof(string));
            m_dataset.Tables[0].Columns.Add("DiscoveryUrls", typeof(string));
            m_dataset.Tables[0].Columns.Add("ApplicationDescription", typeof(ApplicationDescription));

            ServersDataGridView.DataSource = m_dataset.Tables[0];
        }

        private DataTable ApplicationsTable { get { return m_dataset.Tables[0]; } }
        private DataSet m_dataset;
        private GlobalDiscoveryServer m_gds;

        public List<ApplicationDescription> ShowDialog(IWin32Window owner, ref QueryServersFilter filters)
        {
            ApplicationsTable.Rows.Clear();

            if (filters == null)
            {
                filters = new QueryServersFilter();
            }

            ApplicationUriTextBox.Text = filters.ApplicationUri;
            ApplicationNameTextBox.Text = filters.ApplicationName;
            ProductUriTextBox.Text = filters.ProductUri;
            
            if (base.ShowDialog(owner) != DialogResult.OK)
            {
                return null;
            }

            List<ApplicationDescription> applications = new List<ApplicationDescription>();

            foreach (DataRow row in ApplicationsTable.Rows)
            {
                applications.Add((ApplicationDescription)row[4]);
            }

            return applications;
        }

        private void ApplicationRecordDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                SearchButton.Enabled = ServersDataGridView.SelectedRows.Count > 0;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationsTable.Rows.Clear();

                if (!m_gds.IsConnected)
                {
                    m_gds.SelectDefaultGds(null);
                }

                uint maxNoOfRecords = (uint)NumberOfRecordsUpDown.Value;

                var applications = m_gds.QueryApplications(
                    maxNoOfRecords,
                    ApplicationNameTextBox.Text.Trim(),
                    ApplicationUriTextBox.Text.Trim(),
                    ProductUriTextBox.Text.Trim(),
                    ServerCapabilitiesTextBox.Tag as IList<string>);

                bool found = false;
                int count = 0;

                foreach (var application in applications)
                {
                    found = true;

                    if (maxNoOfRecords == 0)
                    {
                        SearchButton.Visible = false;
                        NextButton.Visible = true;
                        StopButton.Visible = true;
                        StopButton.Tag = applications;
                        break;
                    }

                    maxNoOfRecords--;

                    DataRow row = ApplicationsTable.NewRow();

                    row[0] = count++;
                    row[1] = application.ApplicationName;
                    row[2] = application.ApplicationUri;

                    StringBuilder buffer = new StringBuilder();

                    if (application.DiscoveryUrls != null)
                    {
                        foreach (var discoveryUrl in application.DiscoveryUrls)
                        {
                            if (buffer.Length > 0)
                            {
                                buffer.Append(';');
                            }

                            buffer.Append(discoveryUrl);
                        }
                    }

                    row[3] = buffer.ToString();
                    row[4] = application;

                    ApplicationsTable.Rows.Add(row);
                }

                if (!found)
                {
                    SearchButton.Visible = true;
                    SearchButton.Enabled = true;
                    NextButton.Visible = false;
                    StopButton.Visible = false;
                }

                ApplicationsTable.AcceptChanges();

                if (ApplicationsTable.Rows.Count == 0)
                {
                    MessageBox.Show(ParentForm, "No servers available that meet the filter criteria.", Text, MessageBoxButtons.OK, MessageBoxIcon.Information);                        
                }
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void NextButton_Click(object sender, EventArgs e)
        {
            try
            {
                IEnumerable<ServerOnNetwork> servers = (IEnumerable<ServerOnNetwork>)StopButton.Tag;
                StopButton.Visible = false;
                StopButton.Tag = null;

                uint maxNoOfRecords = (uint)NumberOfRecordsUpDown.Value;

                bool found = false;

                foreach (var server in servers)
                {
                    found = true;

                    if (maxNoOfRecords == 0)
                    {
                        SearchButton.Visible = false;
                        NextButton.Visible = true;
                        StopButton.Visible = true;
                        StopButton.Tag = servers;
                        break;
                    }

                    maxNoOfRecords--;

                    DataRow row = ApplicationsTable.NewRow();

                    row[0] = server.RecordId;
                    row[1] = server.ServerName;
                    row[2] = server.DiscoveryUrl;

                    StringBuilder buffer = new StringBuilder();

                    if (server.ServerCapabilities != null)
                    {
                        foreach (var id in server.ServerCapabilities)
                        {
                            if (buffer.Length > 0)
                            {
                                buffer.Append(',');
                            }

                            buffer.Append(id);
                        }
                    }

                    row[3] = buffer.ToString();
                    row[4] = server;

                    ApplicationsTable.Rows.Add(row);
                }

                if (!found)
                {
                    SearchButton.Visible = true;
                    SearchButton.Enabled = true;
                    NextButton.Visible = false;
                    StopButton.Visible = false;
                }

                ApplicationsTable.AcceptChanges();
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            try
            {
                SearchButton.Visible = true;
                SearchButton.Enabled = true;
                StopButton.Visible = false;
                StopButton.Tag = null;
                NextButton.Visible = false;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void ServerCapabilitiesButton_Click(object sender, EventArgs e)
        {
            try
            {
                var capabilities = new ServerCapabilitiesDialog().ShowDialog(this, ServerCapabilitiesTextBox.Tag as IList<string>);

                if (capabilities == null)
                {
                    return;
                }

                StringBuilder buffer = new StringBuilder();

                foreach (var capability in capabilities)
                {
                    if (buffer.Length > 0)
                    {
                        buffer.Append(",");
                    }

                    buffer.Append(capability);
                }

                ServerCapabilitiesTextBox.Text = buffer.ToString();
                ServerCapabilitiesTextBox.Tag = capabilities;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }
    }
}
