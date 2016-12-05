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
    public partial class SelectGdsDialog : Form
    {
        public SelectGdsDialog()
        {
            InitializeComponent();
            Icon = ImageListControl.AppIcon;
        }

        private GlobalDiscoveryServer m_gds;

        public string ShowDialog(IWin32Window owner, GlobalDiscoveryServer gds, IList<string> serverUrls)
        {
            m_gds = gds;

            ServersListBox.Items.Clear();
            ServersListBox.Items.Add("opc.tcp://opcfoundation-prototyping.org:58810/GlobalDiscoveryServer");
            ServersListBox.Items.Add("opc.tcp://gds.opc.org:58810/GlobalDiscoveryServer");
             
            foreach (var serverUrl in serverUrls)
            {
                ServersListBox.Items.Add(serverUrl);
            }

            ServerUrlTextBox.Text = gds.EndpointUrl;
            UserNameCredentialsRB.Checked = true;
            OkButton.Enabled = Uri.IsWellFormedUriString(ServerUrlTextBox.Text.Trim(), UriKind.Absolute);

            if (base.ShowDialog(owner) != DialogResult.OK)
            {
                return null;
            }

            return ServerUrlTextBox.Text.Trim();
        }

        private void ServersListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ServerUrlTextBox.Text = ServersListBox.SelectedItem as string;
        }

        private void ServerUrlTextBox_TextChanged(object sender, EventArgs e)
        {
            OkButton.Enabled = Uri.IsWellFormedUriString(ServerUrlTextBox.Text.Trim(), UriKind.Absolute);
        }

        private async void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                string url = ServerUrlTextBox.Text.Trim();

                if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                {
                    throw new ArgumentException("The URL is not valid: " + url, "ServerUrl");
                }

                try
                {
                    Cursor = Cursors.WaitCursor;

                    if (UserNameCredentialsRB.Checked)
                    {
                        var identity = new Opc.Ua.Client.Controls.UserNamePasswordDlg().ShowDialog(m_gds.AdminCredentials, "Provide GDS Administartor Credentials");

                        if (identity != null)
                        {
                            m_gds.AdminCredentials = identity;
                        }
                    }
                    else
                    {
                        m_gds.AdminCredentials = await OAuth2Client.GetIdentityToken(m_gds.Application.ApplicationConfiguration, url);
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
