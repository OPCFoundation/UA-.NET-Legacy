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
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Data;
using System.Net;

using Opc.Ua.Client.Controls;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Allows the use to manage the SSL certificate bindings.
    /// </summary>
    public partial class ManageSslBindingsDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Constructs the object.
        /// </summary>
        public ManageSslBindingsDlg()
        {
            InitializeComponent();
            BindingsDV.AutoGenerateColumns = false;
            BindingsDV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            m_dataset = new DataSet();

            DataTable table = new DataTable();

            table.Columns.Add("IPAddress", typeof(IPAddress));
            table.Columns.Add("Port", typeof(ushort));
            table.Columns.Add("SubjectName", typeof(string));
            table.Columns.Add("Thumbprint", typeof(string));
            table.Columns.Add("Binding", typeof(SslCertificateBinding));

            m_dataset.Tables.Add(table);
        }
        #endregion

        #region Private Fields
        private DataSet m_dataset;
        private CertificateStoreIdentifier m_defaultStore;
        #endregion

        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public bool ShowDialog(CertificateStoreIdentifier defaultStore)
        {
            // save the default store (used when creating new bindings).
            m_defaultStore = defaultStore;

            if (m_defaultStore == null)
            {
                m_defaultStore = new CertificateStoreIdentifier();
                m_defaultStore.StoreType = Utils.DefaultStoreType;
                m_defaultStore.StorePath = Utils.DefaultStorePath;
            }

            // populate the grid.
            foreach (SslCertificateBinding binding in HttpAccessRule.GetSslCertificateBindings())
            {
                AddRow(binding);
            }

            m_dataset.AcceptChanges();
            BindingsDV.DataSource = m_dataset.Tables[0].DefaultView;

            if (base.ShowDialog() == DialogResult.Cancel)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Adds a certificate binding to to list.
        /// </summary>
        private void AddRow(SslCertificateBinding binding)
        {
            DataRow row = m_dataset.Tables[0].NewRow();

            row[0] = binding.IPAddress;
            row[1] = binding.Port;
            row[3] = binding.Thumbprint;
            row[4] = binding;

            CertificateStoreIdentifier id = new CertificateStoreIdentifier();
            id.StoreType = CertificateStoreType.Windows;
            id.StorePath = "LocalMachine\\" + ((String.IsNullOrEmpty(binding.StoreName)) ? "My" : binding.StoreName);

            using (ICertificateStore store = id.OpenStore())
            {
                X509Certificate2 certificate = store.FindByThumbprint(binding.Thumbprint);

                if (certificate != null)
                {
                    row[2] = certificate.Subject;
                }
                else
                {
                    row[2] = "<not found>";
                }
            }

            m_dataset.Tables[0].Rows.Add(row);
        }

        /// <summary>
        /// Asks a question.
        /// </summary>
        private bool Ask(string message)
        {
            DialogResult result = MessageBox.Show(
                message,
                this.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }
        #endregion

        #region Event Handlers
        private void NewBindingMI_Click(object sender, EventArgs e)
        {
            try
            {
                CertificateIdentifier certificate = new CertificateIdentifier();
                certificate.StoreType = m_defaultStore.StoreType;
                certificate.StorePath = m_defaultStore.StorePath;

                SslCertificateBinding binding = new CreateSslBindingDlg().ShowDialog(0, certificate);

                if (binding != null)
                {
                    AddRow(binding);
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void DeleteBindingMI_Click(object sender, EventArgs e)
        {
            try
            {
                if (BindingsDV.SelectedRows.Count == 0)
                {
                    return;
                }

                if (Ask("Are you sure you want to delete these bindings?"))
                {
                    foreach (DataGridViewRow row in BindingsDV.SelectedRows)
                    {
                       DataRowView source = row.DataBoundItem as DataRowView;
                       SslCertificateBinding binding = (SslCertificateBinding)source.Row[4];
                       HttpAccessRule.DeleteSslCertificateBinding(binding.IPAddress, binding.Port);
                    }

                    m_dataset.Tables[0].Clear();

                    // repopulate the grid.
                    foreach (SslCertificateBinding binding in HttpAccessRule.GetSslCertificateBindings())
                    {
                        AddRow(binding);
                    }

                    m_dataset.AcceptChanges();
                    BindingsDV.DataSource = m_dataset.Tables[0].DefaultView;
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
