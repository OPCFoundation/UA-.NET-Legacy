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
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using Opc.Ua.Gds;

namespace Opc.Ua.Gds
{
    public partial class OAuth2CredentialsDialog : Form
    {
        private OAuth2Credential m_credential;
        private OAuth2AccessToken m_token;
        private AuthorizationClient m_client;

        public OAuth2CredentialsDialog()
        {
            InitializeComponent();
        }

        public OAuth2AccessToken ShowDialog(OAuth2Credential credential)
        {
            if (credential == null)
            {
                throw new ArgumentNullException("settings");
            }

            m_credential = credential;
            m_client = new AuthorizationClient();

            var url = new UriBuilder(m_credential.AuthorityUrl);
            url.Path += m_credential.AuthorizationEndpoint;
            url.Query = String.Format("response_type=code&client_id={0}&redirect_uri={1}", Uri.EscapeUriString(m_credential.ClientId), Uri.EscapeUriString(m_credential.RedirectUrl));

            Browser.Navigate(url.ToString());

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return m_token;
        }

        private void ShowError(Exception e)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(() => ShowError(e)));
                return;
            }

            Opc.Ua.Configuration.ExceptionDlg.Show(e.GetType().Name, e);
        }

        private async void Browser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            try
            {
                int index = e.Url.PathAndQuery.IndexOf("code=");

                if (index >= 0)
                {
                    var token = e.Url.PathAndQuery.Substring(index + "code=".Length);

                    index = token.IndexOf("&");

                    if (index >= 0)
                    {
                        token = token.Substring(0, index);
                    }

                    var resourceId = (m_credential.ServerResourceId != null) ? m_credential.ServerResourceId : null;

                    Browser.Visible = false;
                    m_token = await m_client.RequestTokenWithAuthenticationCodeAsync(m_credential, resourceId, token);
                    DialogResult = DialogResult.OK;
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void Browser_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
        }
    }
}
