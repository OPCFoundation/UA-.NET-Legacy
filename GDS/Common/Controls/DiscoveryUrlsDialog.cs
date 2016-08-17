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
using Opc.Ua.Gds;

namespace Opc.Ua.Gds
{
    public partial class DiscoveryUrlsDialog : Form
    {
        public DiscoveryUrlsDialog()
        {
            InitializeComponent();
            Icon = ImageListControl.AppIcon;
        }

        private List<string> m_discoveryUrls;

        public List<string> ShowDialog(IWin32Window owner, IList<string> discoveryUrls)
        {
            StringBuilder builder = new StringBuilder();

            if (discoveryUrls != null)
            {
                foreach (var discoveryUrl in discoveryUrls)
                {
                    if (discoveryUrl != null && !String.IsNullOrEmpty(discoveryUrl.Trim()))
                    {
                        if (builder.Length > 0)
                        {
                            builder.Append("\r\n");
                        }

                        builder.Append(discoveryUrl.Trim());
                    }
                }
            }

            DiscoveryUrlsTextBox.Text = builder.ToString();

            if (base.ShowDialog(owner) != DialogResult.OK)
            {
                return null;
            }

            return m_discoveryUrls;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> validatedUrls = new List<string>();

                string[] discoveryUrls = DiscoveryUrlsTextBox.Text.Split('\n');

                foreach (var discoveryUrl in discoveryUrls)
                {
                    if (discoveryUrl != null && !String.IsNullOrEmpty(discoveryUrl.Trim()))
                    {
                        string url = discoveryUrl.Trim();

                        if (!Uri.IsWellFormedUriString(url, UriKind.Absolute))
                        {
                            throw new ArgumentException("'" + discoveryUrl + "' is not a valid URL.", "discoveryUrls");
                        }

                        validatedUrls.Add(url);
                    }
                }

                m_discoveryUrls = validatedUrls;
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                Opc.Ua.Configuration.ExceptionDlg.Show(this.Text, exception);
            }
        }

        private void DiscoveryUrlsDialog_VisibleChanged(object sender, EventArgs e)
        {
            DiscoveryUrlsTextBox.SelectedText = "";
        }
    }
}
