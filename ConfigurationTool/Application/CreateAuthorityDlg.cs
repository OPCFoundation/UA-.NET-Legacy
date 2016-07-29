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
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Opc.Ua.Client.Controls;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Prompts the user to specify a new access rule for a file.
    /// </summary>
    public partial class CreateAuthorityDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the dialog.
        /// </summary>
        public CreateAuthorityDlg()
        {
            InitializeComponent();

            KeySizeCB.Items.Add("1024");
            KeySizeCB.Items.Add("2048");
            KeySizeCB.SelectedIndex = 0;
        }
        #endregion

        #region Private Fields
        private CertificateIdentifier m_certificate;
        private string m_currentDirectory;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public CertificateIdentifier ShowDialog(CertificateStoreIdentifier store)
        {
            CertificateStoreCTRL.StoreType = null;
            CertificateStoreCTRL.StorePath = null;
            ApplicationNameTB.Text = null;
            SubjectNameTB.Text = null;
            KeySizeCB.SelectedIndex = 0;
            LifeTimeInMonthsUD.Value = 60;

            if (store != null)
            {
                CertificateStoreCTRL.StoreType = store.StoreType;
                CertificateStoreCTRL.StorePath = store.StorePath;
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return m_certificate;
        }
        #endregion

        #region Event Handlers
        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                string storeType = null;
                string storePath = null;
                string applicationName = ApplicationNameTB.Text.Trim();
                string subjectName = SubjectNameTB.Text.Trim();
                string issuerKeyFilePath = IssuerKeyFilePathTB.Text.Trim();
                string issuerKeyFilePassword = IssuerPasswordTB.Text.Trim();

                if (!String.IsNullOrEmpty(issuerKeyFilePath))
                {
                    // verify certificate.
                    X509Certificate2 issuer = new X509Certificate2(
                        issuerKeyFilePath,
                        issuerKeyFilePassword,
                        X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);
                    
                    if (!issuer.HasPrivateKey)
                    {
                        throw new ApplicationException("Issuer certificate does not have a private key.");
                    }

                    // determine certificate type.
                    foreach (X509Extension extension in issuer.Extensions)
                    {
                        X509BasicConstraintsExtension basicContraints = extension as X509BasicConstraintsExtension;

                        if (basicContraints != null)
                        {
                            if (!basicContraints.CertificateAuthority)
                            {
                                throw new ApplicationException("Certificate cannot be used to issue new certificates.");
                            }
                        }
                    }
                }

                string password1 = PasswordTB.Text;
                string password2 = VerifyPasswordTB.Text;

                if (password1 != password2)
                {
                    throw new ApplicationException("Passwords do not match.");
                }

                if (!String.IsNullOrEmpty(CertificateStoreCTRL.StorePath))
                {
                    storeType = CertificateStoreCTRL.StoreType;
                    storePath = CertificateStoreCTRL.StorePath;
                }

                if (String.IsNullOrEmpty(storePath))
                {
                    throw new ApplicationException("Please specify a store path.");
                }

                if (String.IsNullOrEmpty(applicationName))
                {
                    throw new ApplicationException("Please specify an application name.");
                }

                X509Certificate2 certificate = Opc.Ua.CertificateFactory.CreateCertificate(
                    storeType,
                    storePath,
                    password1,
                    null,
                    applicationName,
                    subjectName,
                    null,
                    Convert.ToUInt16(KeySizeCB.SelectedItem.ToString()),
                    DateTime.MinValue,
                    (ushort)LifeTimeInMonthsUD.Value,
                    0,
                    true,
                    false,
                    issuerKeyFilePath,
                    issuerKeyFilePassword);

                m_certificate = new CertificateIdentifier();
                m_certificate.StoreType = storeType;
                m_certificate.StorePath = storePath;
                m_certificate.Certificate = certificate;
                
                // close the dialog.
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void DomainsCK_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                SubjectNameTB.Enabled = SubjectNameCK.Checked;
                ApplicationNameTB_TextChanged(sender, e);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ApplicationNameTB_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // update subject name.
                if (!SubjectNameCK.Checked)
                {
                    StringBuilder buffer = new StringBuilder();
                    buffer.Append("CN=");
                    buffer.Append(ApplicationNameTB.Text);

                    if (!String.IsNullOrEmpty(OrganizationTB.Text))
                    {
                        buffer.Append("/O=");
                        buffer.Append(OrganizationTB.Text);
                    }

                    SubjectNameTB.Text = buffer.ToString();
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BrowseBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // set current directory.
                if (m_currentDirectory == null)
                {
                    m_currentDirectory = Utils.GetAbsoluteDirectoryPath("%CommonApplicationData%\\OPC Foundation\\CertificateStores\\UA Certificate Authorities\\private", false, false);
                }

                // open file dialog.
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".pfx";
                dialog.Filter = "PKCS#12 Files (*.pfx)|*.pfx|All Files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.ValidateNames = true;
                dialog.Title = "Open Issuer (CA) Private Key File";
                dialog.FileName = null;
                dialog.InitialDirectory = m_currentDirectory;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileInfo fileInfo = new FileInfo(dialog.FileName);
                m_currentDirectory = fileInfo.Directory.FullName;
                IssuerKeyFilePathTB.Text = fileInfo.FullName;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
