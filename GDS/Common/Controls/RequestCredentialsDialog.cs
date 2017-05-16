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
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace Opc.Ua.Gds
{
    public partial class RequestCredentialsDialog : Form
    {
        public RequestCredentialsDialog()
        {
            InitializeComponent();
            Icon = ImageListControl.AppIcon;
        }

        private GlobalDiscoveryServer m_gds;

        public string ShowDialog(IWin32Window owner, GlobalDiscoveryServer gds, IList<string> serverUrls)
        {
            m_gds = gds;

            CredentialServicesListBox.Items.Clear();
             
            foreach (var serverUrl in serverUrls)
            {
                CredentialServicesListBox.Items.Add(serverUrl);
            }

            CredentialServiceTextBox.Text = gds.EndpointUrl;
            OkButton.Enabled = Uri.IsWellFormedUriString(CredentialServiceTextBox.Text.Trim(), UriKind.Absolute);

            if (base.ShowDialog(owner) != DialogResult.OK)
            {
                return null;
            }

            return CredentialServiceTextBox.Text.Trim();
        }

        private void ServersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            CredentialServiceTextBox.Text = CredentialServicesListBox.SelectedItem as string;
        }

        private void ServerUrlTextBox_TextChanged(object sender, EventArgs e)
        {
            OkButton.Enabled = Uri.IsWellFormedUriString(CredentialServiceTextBox.Text.Trim(), UriKind.Absolute);
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                string url = CredentialServiceTextBox.Text.Trim();

                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    throw new ArgumentException("The URL is not valid: " + url, "ServerUrl");
                }

                try
                {
                    Cursor = Cursors.WaitCursor;

                    var endpoint = EndpointDescription.SelectEndpoint(m_gds.Application.ApplicationConfiguration, url, true);

                    var identity = new Opc.Ua.Client.Controls.UserNamePasswordDlg().ShowDialog(m_gds.AdminCredentials, "Provide GDS Administartor Credentials");

                    if (identity != null)
                    {
                        m_gds.AdminCredentials = identity;
                    }

                    m_gds.Connect(url);
                }
                finally
                {
                    Cursor = Cursors.Default;
                }

                DialogResult = System.Windows.Forms.DialogResult.OK;
            }
            catch (Exception exception)
            {
                Opc.Ua.Configuration.ExceptionDlg.Show(Text, exception);
            }
        }
    }
}
