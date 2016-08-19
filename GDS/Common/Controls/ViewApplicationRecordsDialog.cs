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
    public partial class ViewApplicationRecordsDialog : Form
    {
        public ViewApplicationRecordsDialog(GlobalDiscoveryServer gds)
        {
            InitializeComponent();
            Icon = ConfigUtils.GetAppIcon();
            ApplicationRecordDataGridView.AutoGenerateColumns = false;

            m_gds = gds;

            m_dataset = new DataSet();
            m_dataset.Tables.Add("ApplicationRecords");

            m_dataset.Tables[0].Columns.Add("ApplicationId", typeof(NodeId));
            m_dataset.Tables[0].Columns.Add("ApplicationName", typeof(string));
            m_dataset.Tables[0].Columns.Add("ApplicationType", typeof(ApplicationType));
            m_dataset.Tables[0].Columns.Add("ProductUri", typeof(string));
            m_dataset.Tables[0].Columns.Add("DiscoveryUrls", typeof(string));
            m_dataset.Tables[0].Columns.Add("ServerCapabilities", typeof(string));
            m_dataset.Tables[0].Columns.Add("ApplicationRecord", typeof(ApplicationRecordDataType));

            ApplicationRecordDataGridView.DataSource = m_dataset.Tables[0];
        }

        private DataTable ApplicationsTable { get { return m_dataset.Tables[0]; } }
        private DataSet m_dataset;
        private GlobalDiscoveryServer m_gds;

        public ApplicationRecordDataType ShowDialog(IWin32Window owner, IList<ApplicationRecordDataType> records, NodeId defaultRecord)
        {
            ApplicationsTable.Rows.Clear();

            DataRow selectedRow = null;

            if (records != null)
            {
                foreach (var record in records)
                {
                    DataRow row = ApplicationsTable.NewRow();

                    if (selectedRow == null && defaultRecord != null)
                    {
                        if (defaultRecord == record.ApplicationId)
                        {
                            selectedRow = row;
                        }
                    }

                    row[0] = record.ApplicationId;
                    row[1] = (record.ApplicationNames != null && record.ApplicationNames.Count > 0 && !LocalizedText.IsNullOrEmpty(record.ApplicationNames[0]))?record.ApplicationNames[0].Text:String.Empty;
                    row[2] = record.ApplicationType;
                    row[3] = record.ProductUri;

                    StringBuilder buffer = new StringBuilder();

                    if (record.DiscoveryUrls != null)
                    {
                        foreach (var url in record.DiscoveryUrls)
                        {
                            if (buffer.Length > 0)
                            {
                                buffer.Append(',');
                            }

                            buffer.Append(url);
                        }
                    }

                    row[4] = buffer.ToString();

                    buffer = new StringBuilder();

                    if (record.ServerCapabilities != null)
                    {
                        foreach (var id in record.ServerCapabilities)
                        {
                            if (buffer.Length > 0)
                            {
                                buffer.Append(',');
                            }

                            buffer.Append(id);
                        }
                    }

                    row[5] = buffer.ToString();
                    row[6] = record;

                    ApplicationsTable.Rows.Add(row);
                }

                m_dataset.AcceptChanges();
            }

            if (selectedRow != null)
            {
                foreach (DataGridViewRow row in ApplicationRecordDataGridView.Rows)
                {
                    DataRowView source = row.DataBoundItem as DataRowView;

                    if (Object.ReferenceEquals(source.Row, selectedRow))
                    {
                        row.Selected = true;
                        break;
                    }
                }
            }

            if (base.ShowDialog(owner) != DialogResult.OK)
            {
                return null;
            }

            if (ApplicationRecordDataGridView.SelectedRows.Count > 0)
            {
                DataRowView source = ApplicationRecordDataGridView.SelectedRows[0].DataBoundItem as DataRowView;
                return (ApplicationRecordDataType)source.Row[6];
            }

            return null;
        }

        private void UnregisterButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationRecordDataGridView.SelectedRows.Count == 0)
                {
                    return;
                }

                List<DataRow> rowsToDelete = new List<DataRow>();

                foreach (DataGridViewRow row in ApplicationRecordDataGridView.SelectedRows)
                {
                    DataRowView source = row.DataBoundItem as DataRowView;
                    ApplicationRecordDataType argument = (ApplicationRecordDataType)source.Row[6];
                    m_gds.UnregisterApplication(argument.ApplicationId);
                    rowsToDelete.Add(source.Row);
                }

                foreach (var rowToDelete in rowsToDelete)
                {
                    rowToDelete.Delete();
                }

                m_dataset.AcceptChanges();
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void ApplicationRecordDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                UnregisterButton.Enabled = ApplicationRecordDataGridView.SelectedRows.Count > 0;
                OkButton.Enabled = ApplicationRecordDataGridView.SelectedRows.Count <= 1;
            }
            catch (Exception exception)
            {
                ExceptionDlg.Show(this.Text, exception);
            }
        }
    }
}
