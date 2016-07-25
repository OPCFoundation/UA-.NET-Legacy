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
    /// Prompts the user to edit a ApplicationDescription.
    /// </summary>
    public partial class CreateSslBindingDlg : Form
    {
        public CreateSslBindingDlg()
        {
            InitializeComponent();
        }

        private CertificateIdentifier m_certificate;
        private CertificateStoreIdentifier m_store;
        private SslCertificateBinding m_binding;
        private readonly Guid s_DefaultApplicationId = new Guid("{5B14D979-4D62-496e-BCF0-2CBB02996D68}");

        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public SslCertificateBinding ShowDialog(ushort port, CertificateIdentifier certificate)
        {
            m_certificate = certificate;

            IPAddressTB.Text = "0.0.0.0";
            PortUD.Value = port;
            CertificateTB.Text = "";
            CertificateStoreTB.Text = "LocalMachine\\My";

            if (PortUD.Value == 0)
            {
                PortUD.Value = 443;
            }

            if (certificate != null)
            {
                CertificateTB.Text = certificate.Thumbprint;
            }

            if (base.ShowDialog() == DialogResult.Cancel)
            {
                return null;
            }

            return m_binding;
        }

        private bool Ask(string message)
        {
            DialogResult result = MessageBox.Show(
                message,
                this.Text,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            return result == DialogResult.Yes;
        }

        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                IPAddress address = IPAddress.Parse(IPAddressTB.Text);
                ushort port = (ushort)PortUD.Value;

                if (m_certificate == null)
                {
                    throw new ArgumentException("You must specify a certificate.");
                }

                X509Certificate2 certificate = m_certificate.Find(true);

                if (certificate == null)
                {
                    throw new ArgumentException("Certificate does not exist or has no private key.");
                }

                // setup policy chain
                X509ChainPolicy policy = new X509ChainPolicy();

                policy.RevocationFlag = X509RevocationFlag.EntireChain;
                policy.RevocationMode = X509RevocationMode.Offline;
                policy.VerificationFlags = X509VerificationFlags.NoFlag;

                policy.VerificationFlags |= X509VerificationFlags.IgnoreCertificateAuthorityRevocationUnknown;
                policy.VerificationFlags |= X509VerificationFlags.IgnoreCtlSignerRevocationUnknown;
                policy.VerificationFlags |= X509VerificationFlags.IgnoreEndRevocationUnknown;
                policy.VerificationFlags |= X509VerificationFlags.IgnoreRootRevocationUnknown;

                // build chain.
                X509Chain chain = new X509Chain();
                chain.ChainPolicy = policy;
                chain.Build(certificate);

                for (int ii = 0; ii < chain.ChainElements.Count; ii++)
                {
                    X509ChainElement element = chain.ChainElements[ii];

                    // check for chain status errors.
                    foreach (X509ChainStatus status in element.ChainElementStatus)
                    {
                        if (status.Status == X509ChainStatusFlags.UntrustedRoot)
                        {
                            if (!Ask("Cannot verify certificate up to a trusted root.\r\nAdd anyways?"))
                            {
                                return;
                            }

                            continue;
                        }

                        if (status.Status == X509ChainStatusFlags.RevocationStatusUnknown)
                        {
                            if (!Ask("The revocation status of this certificate cannot be verified.\r\nAdd anyways?"))
                            {
                                return;
                            }

                            continue;
                        }

                        // ignore informational messages.
                        if (status.Status == X509ChainStatusFlags.OfflineRevocation)
                        {
                            continue;
                        }

                        if (status.Status != X509ChainStatusFlags.NoError)
                        {
                            throw new ArgumentException("[" + status.Status + "] " + status.StatusInformation);
                        }
                    }
                }

                // get the target store.
                if (m_store == null)
                {
                    m_store = new CertificateStoreIdentifier();
                    m_store.StoreType = CertificateStoreType.Windows;
                    m_store.StorePath = CertificateStoreTB.Text;
                }

                if (m_store.StoreType != CertificateStoreType.Windows)
                {
                    throw new ArgumentException("You must choose a Windows store for SSL certificates.");
                }

                if (!m_store.StorePath.StartsWith("LocalMachine\\", StringComparison.OrdinalIgnoreCase))
                {
                    throw new ArgumentException("You must choose a machine store for SSL certificates.");
                }

                bool deleteExisting = false;

                using (ICertificateStore store = m_store.OpenStore())
                {
                    if (store.FindByThumbprint(certificate.Thumbprint) == null)
                    {
                        store.Add(certificate);
                        deleteExisting = true;
                    }
                }

                if (deleteExisting)
                {
                    if (Ask("Would you like to delete the certificate from its current location?"))
                    {
                        using (ICertificateStore store = m_certificate.OpenStore())
                        {
                            store.Delete(certificate.Thumbprint);
                        }
                    }
                }

                SslCertificateBinding binding = new SslCertificateBinding();

                binding.IPAddress = address;
                binding.Port = port;
                binding.Thumbprint = certificate.Thumbprint;
                binding.ApplicationId = s_DefaultApplicationId;
                binding.StoreName = null;

                if (!m_store.StorePath.EndsWith("\\My"))
                {
                    int index = m_store.StorePath.LastIndexOf("\\");
                    binding.StoreName = m_store.StorePath.Substring(index+1);
                }

                HttpAccessRule.SetSslCertificateBinding(binding);

                m_binding = binding;
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void CertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CertificateStoreIdentifier store = new CertificateStoreIdentifier();
                store.StoreType = m_certificate.StoreType;
                store.StorePath = m_certificate.StorePath;
               
                CertificateIdentifier certificate = new CertificateListDlg().ShowDialog(store, true);

                if (certificate != null)
                {
                    m_certificate = certificate;
                    CertificateTB.Text = m_certificate.Thumbprint;
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void CertificateStoreBTN_Click(object sender, EventArgs e)
        {
            try
            {
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
    }
}
