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
using System.Security.Principal;
using System.Reflection;

using Opc.Ua.Client.Controls;
using Opc.Ua.Configuration;
using Opc.Ua.Com.Server;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Prompts the user to specify a new access rule for a file.
    /// </summary>
    public partial class NewEndpointDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the dialog.
        /// </summary>
        public NewEndpointDlg()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        private ConfiguredEndpoint m_endpoint;
        private ApplicationConfiguration m_configuration;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public ConfiguredEndpoint ShowDialog(ApplicationConfiguration configuration, ConfiguredEndpoint endpoint)
        {
            m_configuration = configuration;
            m_endpoint = endpoint;

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return m_endpoint;
        }
        #endregion

        #region Event Handlers
        private void ConfigureEndpoint(ConfiguredEndpoint endpoint)
        {
            EndpointComIdentity comIdentity = endpoint.ComIdentity;

            if (comIdentity == null)
            {
                comIdentity = new EndpointComIdentity();
                comIdentity.Specification = ComSpecification.DA;
                endpoint.ComIdentity = comIdentity;
            }

            string oldProgId = PseudoComServer.CreateProgIdFromUrl(endpoint.ComIdentity.Specification, endpoint.EndpointUrl.ToString());

            endpoint = new ConfiguredServerDlg().ShowDialog(endpoint, m_configuration);

            if (endpoint == null)
            {
                return;
            }

            if (String.IsNullOrEmpty(comIdentity.ProgId) || oldProgId == comIdentity.ProgId)
            {
                comIdentity.ProgId = PseudoComServer.CreateProgIdFromUrl(endpoint.ComIdentity.Specification, endpoint.EndpointUrl.ToString());

                if (comIdentity.Clsid == Guid.Empty)
                {
                    comIdentity.Clsid = Guid.NewGuid();
                }
            }

            m_endpoint = endpoint;
            EndpointTB.Text = m_endpoint.EndpointUrl.ToString();
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            if (m_endpoint == null)
            {
                EditBTN_Click(sender, e);

                if (m_endpoint == null)
                {
                    return;
                }
            }

            try
            {
                EndpointComIdentity comIdentity = new PseudoComServerDlg().ShowDialog(m_endpoint);

                if (comIdentity == null)
                {
                    return;
                }

                m_endpoint.ComIdentity = comIdentity;

                // set a default configuration.
                if (comIdentity.Specification != ComSpecification.HDA)
                {
                    ComProxyConfiguration configuration = m_endpoint.ParseExtension<ComProxyConfiguration>(null);

                    if (configuration == null)
                    {
                        configuration = new ComProxyConfiguration();
                        configuration.BrowseBlockSize = 1000;
                    }

                    m_endpoint.UpdateExtension<ComProxyConfiguration>(null, configuration);
                }
                else
                {
                    ComHdaProxyConfiguration configuration = m_endpoint.ParseExtension<ComHdaProxyConfiguration>(null);

                    if (configuration == null)
                    {
                        configuration = new ComHdaProxyConfiguration();
                        configuration.BrowseBlockSize = 1000;
                        configuration.MaxReturnValues = 10000;
                    }

                    m_endpoint.UpdateExtension<ComHdaProxyConfiguration>(null, configuration);
                }

                PseudoComServer.Save(m_endpoint);

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void DiscoverBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ApplicationDescription server = new DiscoveredServerListDlg().ShowDialog(null, m_configuration);

                if (server == null)
                {
                    return;
                }

                ConfiguredEndpoint endpoint = m_endpoint;

                if (endpoint == null)
                {
                    endpoint = new ConfiguredEndpoint(server, null);
                }
                
                ConfigureEndpoint(endpoint);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void EditBTN_Click(object sender, EventArgs e)
        {
            try
            {
                Uri uri = null;
                ConfiguredEndpoint endpoint = null;
                
                if (m_endpoint == null)
                {
                    string url = EndpointTB.Text;

                    if (String.IsNullOrEmpty(url))
                    {
                        DiscoverBTN_Click(sender, e);
                        return;
                    }

                    uri = new Uri(url);
                    EndpointDescription description = new EndpointDescription(uri.ToString());
                    endpoint = new ConfiguredEndpoint(null, description, EndpointConfiguration.Create(m_configuration));
                }
                else
                {
                    uri = m_endpoint.EndpointUrl;
                    endpoint = m_endpoint;
                }

                ConfigureEndpoint(endpoint);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
