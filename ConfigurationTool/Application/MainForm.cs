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
using System.IO;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;

using Opc.Ua.Client.Controls;

namespace Opc.Ua.Configuration
{
    public partial class MainForm : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the with the application configuration.
        /// </summary>
        public MainForm(ApplicationConfiguration configuration)
        {
            InitializeComponent();

            m_configuration = configuration;
            
            ComServersCTRL.Initialize(m_configuration);
            HttpAccessRuleCTRL.Initialize();

            ManagedStoreCTRL.StoreType = CertificateStoreType.Directory;
            ManagedStoreCTRL.StorePath = "%CommonApplicationData%\\OPC Foundation\\CertificateStores\\UA Certificate Authorities";

            ManageApplicationSecurityCTRL.LoadApplications();
            ApplicationToManageCTRL.LoadApplications();
        }
        #endregion
        
        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private string m_currentDirectory;
        private CertificateStoreIdentifier m_currentStore;
        #endregion
        
        #region Private Methods
        #endregion

        #region Manage Application
        /// <summary>
        /// Displays the application certificate.
        /// </summary>
        private void ViewApplicationCertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "View Application Certificate";

                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }

                application.Reload();
                
                if (application.Certificate == null)
                {
                    MessageBox.Show(application.ToString() + " does not have a certificate assigned.", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                X509Certificate2 certificate = application.Certificate.Find();
                
                if (certificate == null)
                {
                    MessageBox.Show(application.ToString() + " cannot find the assigned certificate.", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                new ViewCertificateDlg().ShowDialog(application.Certificate);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Gets the default store.
        /// </summary>
        private CertificateStoreIdentifier GetDefaultStore(ManagedApplication application, bool useApplicationCertificate)
        {
            CertificateStoreIdentifier store = m_currentStore;

            if (m_currentStore != null)
            {
                return m_currentStore;
            }
                
            store = new CertificateStoreIdentifier();

            if (application != null)
            {
                if (useApplicationCertificate && application.Certificate != null && !String.IsNullOrEmpty(application.Certificate.StorePath))
                {
                    store.StoreType = application.Certificate.StoreType;
                    store.StorePath = application.Certificate.StorePath;
                    return store;
                }

                if (application.TrustList != null && !String.IsNullOrEmpty(application.TrustList.StorePath))
                {
                    store.StoreType = application.TrustList.StoreType;
                    store.StorePath = application.TrustList.StorePath;
                    return store;
                }
            }

            store.StoreType = Utils.DefaultStoreType;
            store.StorePath = Utils.DefaultStorePath;
            return store;
        }

        /// <summary>
        /// Browses for a certificate to import.
        /// </summary>
        private void ImportApplicationCertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }

                // load the configuration.
                application.Reload();

                // can't set application certificate for non-sdk apps.
                if (!application.IsSdkCompatible)
                {
                    return;
                }

                // set current directory.
                if (m_currentDirectory == null)
                {
                    m_currentDirectory = Utils.GetAbsoluteDirectoryPath("%CommonApplicationData%\\OPC Foundation\\CertificateStores\\MachineDefault", false, false);
                }

                if (m_currentDirectory == null)
                {
                    m_currentDirectory = new FileInfo(Application.ExecutablePath).DirectoryName;
                }

                // open file dialog.
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".pfx";
                dialog.Filter = "PKCS#12 Files (*.pfx)|*.pfx|All Files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.ValidateNames = true;
                dialog.Title = "Open Application Certificate File";
                dialog.FileName = null;
                dialog.InitialDirectory = m_currentDirectory;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileInfo fileInfo = new FileInfo(dialog.FileName);
                m_currentDirectory = fileInfo.Directory.FullName;

                CertificateStoreIdentifier store = GetDefaultStore(application, true);

                // prompt for the store to import into.
                store = new CertificateStoreDlg().ShowDialog(store);

                if (store == null)
                {
                    return;
                }

                m_currentStore = store;
                string password = String.Empty;
                X509Certificate2 certificate = null;

                do
                {
                    try
                    {
                        // load the certificate.
                        certificate = new X509Certificate2(
                            fileInfo.FullName,
                            password,
                            X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);

                        if (!certificate.HasPrivateKey)
                        {
                            MessageBox.Show("Certificate does not have a private key.", "Import Certificate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // import certificate.
                        ICertificateStore physicalStore = store.OpenStore();
                        physicalStore.Add(certificate);
                        physicalStore.Close();
                        break;
                    }
                    catch (System.Security.Cryptography.CryptographicException exception)
                    {
                        // prompt for password.
                        password = new PasswordDlg().ShowDialog(password, exception.Message);

                        if (password == null)
                        {
                            return;
                        }
                    }
                }
                while (true);

                UpdateApplicationCertificate(application.Application, store, certificate);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Assigns a certificate to the application.
        /// </summary>
        private void AssignApplicationCertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }

                // load the configuration.
                application.Reload();

                // can't set application certificate for non-sdk apps.
                if (!application.IsSdkCompatible)
                {
                    return;
                }

                CertificateStoreIdentifier store = GetDefaultStore(application, true);

                // select the certificate.
                CertificateIdentifier certificate = new CertificateListDlg().ShowDialog(store, true);

                if (certificate == null)
                {
                    return;
                }

                store = new CertificateStoreIdentifier();
                store.StoreType = certificate.StoreType;
                store.StorePath = certificate.StorePath;
                m_currentStore = store;

                // update the certificate.
                UpdateApplicationCertificate(application.Application, store, certificate.Certificate);
                application.Certificate = certificate;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Assigns a certificate to the application.
        /// </summary>
        private void AssignTrustListBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }
                
                // load the configuration.
                application.Reload();

                // can't set application certificate for non-sdk apps.
                if (!application.IsSdkCompatible)
                {
                    return;
                }

                CertificateStoreIdentifier store = application.TrustList;

                if (store == null)
                {
                    store = GetDefaultStore(application, false);
                }

                // prompt for the store to open.
                store = new CertificateStoreDlg().ShowDialog(store);

                if (store == null)
                {
                    return;
                }

                // update the trust list.
                application.Application.TrustedCertificateStore = new Opc.Ua.Security.CertificateStoreIdentifier();
                application.Application.TrustedCertificateStore.StorePath = store.StorePath;
                application.Application.TrustedCertificateStore.StoreType = store.StoreType;
                application.Application.TrustedCertificates = new Opc.Ua.Security.CertificateList();

                m_currentStore = store;

                // save the configuration.
                new Opc.Ua.Security.SecurityConfigurationManager().WriteConfiguration(application.Application.ConfigurationFile, application.Application);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Deletes the application certificate.
        /// </summary>
        private void DeleteApplicationCertificate(Opc.Ua.Security.SecuredApplication application, X509Certificate2 certificate)
        {
            ICertificateStore physicalStore = application.ApplicationCertificate.OpenStore();

            try
            {
                physicalStore.Delete(certificate.Thumbprint);
            }
            catch (Exception)
            {
                MessageBox.Show("Delete application certificate failed.", "Delete Certificate", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                physicalStore.Close();
            }

            if (application.TrustedCertificateStore != null)
            {
                physicalStore = application.TrustedCertificateStore.OpenStore();

                try
                {
                    physicalStore.Delete(certificate.Thumbprint);
                }
                catch (Exception)
                {
                    // ignore errors.
                }
                finally
                {
                    physicalStore.Close();
                }
            }
        }

        private void UpdateApplicationCertificate(Opc.Ua.Security.SecuredApplication application, CertificateStoreIdentifier store, X509Certificate2 certificate)
        {
            if (!certificate.HasPrivateKey)
            {
                MessageBox.Show("Cannot use a certificate without an accessible private key.", "Import Certificate", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // check if the old certificate should be deleted.
            Opc.Ua.Security.CertificateIdentifier oldId = application.ApplicationCertificate;

            if (oldId != null)
            {
                X509Certificate2 oldCertificate = oldId.Find();

                if (oldCertificate != null && oldCertificate.Thumbprint != certificate.Thumbprint)
                {
                    if (new YesNoDlg().ShowDialog("Would you like to delete the old certificate?", "Delete Certificate") == DialogResult.Yes)
                    {
                        DeleteApplicationCertificate(application, oldCertificate);
                    }
                }
            }

            // set the application name.
            List<string> subjectName = Utils.ParseDistinguishedName(certificate.Subject);

            foreach (string subjectField in subjectName)
            {
                if (subjectField.StartsWith("CN="))
                {
                    application.ApplicationName = subjectField.Substring(3);
                    break;
                }
            }

            // set the application uri.
            string applicationUri = Utils.GetApplicationUriFromCertficate(certificate);

            if (applicationUri != null)
            {
                application.ApplicationUri = applicationUri;
            }

            // update the certificate.
            application.ApplicationCertificate = new Opc.Ua.Security.CertificateIdentifier();
            application.ApplicationCertificate.StorePath = store.StorePath;
            application.ApplicationCertificate.StoreType = store.StoreType;
            application.ApplicationCertificate.SubjectName = certificate.Subject;
            application.ApplicationCertificate.Thumbprint = certificate.Thumbprint;

            // save the configuration.
            new Opc.Ua.Security.SecurityConfigurationManager().WriteConfiguration(application.ConfigurationFile, application);
        }

        /// <summary>
        /// Creates a new self signed for a certificate.
        /// </summary>
        private void CreateApplicationCertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }

                // load the configuration.
                application.Reload();

                // can't set application certificate for non-sdk apps.
                if (!application.IsSdkCompatible)
                {
                    return;
                }

                // create the certificate.
                CertificateIdentifier certificate = new CreateCertificateDlg().ShowDialog(application.Application);

                if (certificate == null)
                {
                    return;
                }

                // save the configuration.
                CertificateStoreIdentifier store = new CertificateStoreIdentifier();
                store.StorePath = certificate.StorePath;
                store.StoreType = certificate.StoreType;
                m_currentStore = store;

                UpdateApplicationCertificate(application.Application, store, certificate.Certificate);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Edits the trust list for the application.
        /// </summary>
        private void EditTrustListBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }

                // load the configuration.
                application.Reload();

                // show the trust list.
                new CertificateListDlg().ShowDialog(application.TrustList, false);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Manages the permissions for the application.
        /// </summary>
        private void ManageApplicationPermissionsBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }

                // load the configuration.
                application.Reload();

                // show the dialog.
                new ManageAccessRulesDlg().ShowDialog(application);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void AddCertificateToTrustListBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }
                
                // load the configuration.
                application.Reload();

                CertificateStoreIdentifier store = GetDefaultStore(application, false);

                // show the list of rejected certificates.
                CertificateIdentifier id = new CertificateListDlg().ShowDialog(store, true);

                if (id == null)
                {
                    return;
                }

                store = new CertificateStoreIdentifier();
                store.StoreType = id.StoreType;
                store.StorePath = id.StorePath;
                m_currentStore = store;

                X509Certificate2 certificate = id.Find();
                ValidateAndImport(application.TrustList, certificate);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ImportCertificateToTrustListBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }

                // load the configuration.
                application.Reload();

                // set current directory.
                if (m_currentDirectory == null)
                {
                    m_currentDirectory = Utils.GetAbsoluteDirectoryPath("%CommonApplicationData%\\OPC Foundation\\CertificateStores\\UA Applications", false, false);
                }

                if (m_currentDirectory == null)
                {
                    m_currentDirectory = new FileInfo(Application.ExecutablePath).DirectoryName;
                }

                // open file dialog.
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".der";
                dialog.Filter = "DER Files (*.der)|*.der|PKCS #12 Files (*.pfx)|*.pfx|All Files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.ValidateNames = true;
                dialog.Title = "Open Certificate File";
                dialog.FileName = null;
                dialog.InitialDirectory = m_currentDirectory;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileInfo fileInfo = new FileInfo(dialog.FileName);
                m_currentDirectory = fileInfo.Directory.FullName;

                if (!fileInfo.Exists)
                {
                    return;
                }

                X509Certificate2 certificate = new X509Certificate2(fileInfo.FullName, (string)null, X509KeyStorageFlags.Exportable);
                ValidateAndImport(application.TrustList, certificate);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ReplaceTrustListBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }

                // load the configuration.
                application.Reload();

                CertificateStoreIdentifier store = GetDefaultStore(application, false);

                // chose trust list to import.
                CertificateStoreDlg dialog = new CertificateStoreDlg();
                dialog.Text = "Select Certificate Trust List to use as Source";
                CertificateStoreIdentifier id = dialog.ShowDialog(store);

                if (id == null)
                {
                    return;
                }

                if (String.Compare(application.TrustList.StorePath, id.StorePath, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    MessageBox.Show("Selected Certificate Store is already the same as the Application Trust List", "Replace Trust List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // check for private keys.
                ICertificateStore targetStore = application.TrustList.OpenStore();
                X509Certificate2Collection certificates = targetStore.Enumerate();

                bool hasPrivateKeys = true;
                StringBuilder buffer = null;
                DialogResult result = DialogResult.None;

                while (hasPrivateKeys)
                {
                    hasPrivateKeys = false;

                    foreach (X509Certificate2 certificate in certificates)
                    {
                        if (certificate.HasPrivateKey)
                        {
                            hasPrivateKeys = true;

                            buffer = new StringBuilder();

                            buffer.Append("The application's current trust list contains certificates with private keys.\r\n");
                            buffer.Append("Automatically deleting these certificates could break other applications. ");
                            buffer.Append("\r\n");
                            buffer.Append("\r\n");
                            buffer.Append("Would you like to remove these certificates manually?\r\n");
                            buffer.Append("\r\n");
                            buffer.Append("Current Application Trust List = ");
                            buffer.Append(application.TrustList.ToString());
                            buffer.Append("\r\n");
                            buffer.Append("Certificate with Private Key = ");
                            buffer.Append(certificate.Subject);

                            result = new YesNoDlg().ShowDialog(buffer.ToString(), "Warning Private Keys Found");

                            if (result != DialogResult.Yes)
                            {
                                return;
                            }

                            new CertificateListDlg().ShowDialog(application.TrustList, false);
                            certificates = targetStore.Enumerate();
                            break;
                        }
                    }
                }

                buffer = new StringBuilder();

                buffer.Append("This operation will delete all of the certificates in the current application trust list and ");
                buffer.Append("replace them with the certificates in the selected trust list.");
                buffer.Append("\r\n");
                buffer.Append("\r\n");
                buffer.Append("Do you wish to proceed?\r\n");
                buffer.Append("\r\n");
                buffer.Append("Current Application Trust List = ");
                buffer.Append(application.TrustList.ToString());
                buffer.Append("\r\n");
                buffer.Append("Selected Trust List = ");
                buffer.Append(id.ToString());
               
                result = new YesNoDlg().ShowDialog(buffer.ToString(), "Replace Trust List");

                if (result != DialogResult.Yes)
                {
                    return;
                }

                // delete existing certificates.
                certificates = targetStore.Enumerate();

                foreach (X509Certificate2 certificate in certificates)
                {
                    if (!certificate.HasPrivateKey)
                    {
                        targetStore.Delete(certificate.Thumbprint);
                    }
                }

                // copy the certificates.
                ICertificateStore sourceStore = id.OpenStore();

                foreach (X509Certificate2 certificate in sourceStore.Enumerate())
                {
                    targetStore.Add(new X509Certificate2(certificate.RawData));
                }

                EditTrustListBTN_Click(sender, e);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void MergeTrustListBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();;

                if (application == null)
                {
                    return;
                }

                // load the configuration.
                application.Reload();

                CertificateStoreIdentifier store = GetDefaultStore(application, false);

                // chose trust list to import.
                CertificateStoreDlg dialog = new CertificateStoreDlg();
                dialog.Text = "Select Certificate Trust List to use as Source";
                CertificateStoreIdentifier id = dialog.ShowDialog(store);

                if (id == null)
                {
                    return;
                }

                if (String.Compare(application.TrustList.StorePath, id.StorePath, StringComparison.OrdinalIgnoreCase) == 0)
                {
                    MessageBox.Show("Selected Certificate Store is already the same as the Application Trust List", "Merge Trust List", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
                // check for private keys.
                StringBuilder buffer = new StringBuilder();

                buffer.Append("This operation will add all of the certificates in the selected trust list to ");
                buffer.Append("the application trust list.");
                buffer.Append("\r\n");
                buffer.Append("\r\n");
                buffer.Append("Do you wish to proceed?\r\n");
                buffer.Append("\r\n");
                buffer.Append("Current Application Trust List = ");
                buffer.Append(application.TrustList.ToString());
                buffer.Append("\r\n");
                buffer.Append("Selected Trust List = ");
                buffer.Append(id.ToString());

                DialogResult result = new YesNoDlg().ShowDialog(buffer.ToString(), "Merge Trust List");

                if (result != DialogResult.Yes)
                {
                    return;
                }

                // delete existing certificates.
                ICertificateStore targetStore = application.TrustList.OpenStore();

                // add the certificates.
                ICertificateStore sourceStore = id.OpenStore();

                foreach (X509Certificate2 certificate in sourceStore.Enumerate())
                {
                    if (targetStore.FindByThumbprint(certificate.Thumbprint) == null)
                    {
                        targetStore.Add(new X509Certificate2(certificate.RawData));
                    }
                }

                EditTrustListBTN_Click(sender, e);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Validates a certificate and adds it to the trust list.
        /// </summary>
        private void ValidateAndImport(CertificateStoreIdentifier store, X509Certificate2 certificate)
        {
            if (store == null || certificate == null)
            {
                return;
            }

            // validate the certificate using the trust lists for the certificate tool.                                
            try
            {
                CertificateValidator validator = new CertificateValidator();
                validator.Update(m_configuration);
                validator.Validate(certificate);
            }
            catch (ServiceResultException exception)
            {
                if (!HandleValidationError(certificate, exception))
                {
                    return;
                }
            }

            // confirm import.
            StringBuilder buffer = new StringBuilder();

            buffer.Append("You are adding this certificate to a trust list that may be shared with other applications.");
            buffer.Append("\r\n");
            buffer.Append("\r\n");
            buffer.Append("Would you still like to accept the certificate?\r\n");
            buffer.Append("\r\n");
            buffer.Append("Target Trust List = ");
            buffer.Append(store.ToString());
            buffer.Append("\r\n");
            buffer.Append("Certificate to Add = ");
            buffer.Append(certificate.Subject);

            DialogResult result = new YesNoDlg().ShowDialog(buffer.ToString(), "Import Certificate to Trust List");

            if (result != DialogResult.Yes)
            {
                return;
            }

            // update store.
            ICertificateStore physicalStore = store.OpenStore();

            if (physicalStore.FindByThumbprint(certificate.Thumbprint) == null)
            {
                physicalStore.Add(new X509Certificate2(certificate.RawData));
            }
        }

        /// <summary>
        /// Handles a certificate validation error.
        /// </summary>
        private bool HandleValidationError(X509Certificate2 certificate, ServiceResultException e)
        {
            StringBuilder buffer = new StringBuilder();

            switch (e.StatusCode)
            {
                case StatusCodes.BadCertificateIssuerRevocationUnknown:
                {
                    buffer.AppendFormat("Could not determine whether the issuing certificate was revoked.");
                    buffer.Append("\r\n");
                    buffer.Append("Would you still like to accept the certificate?\r\n");
                    break;
                }

                case StatusCodes.BadCertificateIssuerTimeInvalid:
                {
                    buffer.AppendFormat("The issuing certificate has expired or is not yet valid.");
                    buffer.Append("\r\n");
                    buffer.Append("Would you still like to accept the certificate?\r\n");
                    break;
                }

                case StatusCodes.BadCertificateRevocationUnknown:
                {
                    buffer.AppendFormat("Could not determine whether the certificate was revoked by the Certificate Authority.");
                    buffer.Append("\r\n");
                    buffer.Append("Would you still like to accept the certificate?\r\n");
                    break;
                }

                case StatusCodes.BadCertificateTimeInvalid:
                {
                    buffer.AppendFormat("The certificate has expired or is not yet valid.");
                    buffer.Append("\r\n");
                    buffer.Append("Would you still like to accept the certificate?\r\n");
                    buffer.Append("\r\n");
                    buffer.Append("Certificate = ");
                    buffer.Append(certificate.Subject);
                    buffer.Append("\r\n");
                    buffer.Append("Valid From = ");
                    buffer.Append(certificate.NotBefore.ToLocalTime());
                    buffer.Append("\r\n");
                    buffer.Append("Valid To = ");
                    buffer.Append(certificate.NotBefore.ToLocalTime());
                    break;
                }

                case StatusCodes.BadCertificateUntrusted:
                {
                    if (Utils.CompareDistinguishedName(certificate.Issuer, certificate.Subject))
                    {
                        return true;
                    }

                    buffer.Append("This certificates was issued by an unknown Certificate Authority.");
                    buffer.Append("This means it could have been altered and there is no way to detect changes.");
                    buffer.Append("You should only accept it if you are absolutely certain the certificate has come via a secure channel from a legimate source.");
                    buffer.Append("\r\n");
                    buffer.Append("\r\n");
                    buffer.Append("Would you still like to accept the certificate?\r\n");
                    buffer.Append("\r\n");
                    buffer.Append("Certificate = ");
                    buffer.Append(certificate.Subject);
                    buffer.Append("\r\n");
                    buffer.Append("Certificate Authority = ");
                    buffer.Append(certificate.Issuer);
                    break;
                }

                default:
                {
                    buffer.Append("An error that cannot be ignored occurred during validation.\r\n");
                    buffer.Append("\r\n");
                    buffer.Append("Certificate = ");
                    buffer.Append(certificate.Subject);
                    buffer.Append("\r\n");
                    buffer.Append("ErrorCode = ");
                    buffer.Append(StatusCodes.GetBrowseName(e.StatusCode));
                    buffer.Append("\r\n");
                    buffer.Append("Message = ");
                    buffer.Append(e.Message);

                    new YesNoDlg().ShowDialog(buffer.ToString(), "Certificate Validation Error");
                    return false;
                }
            }

            DialogResult result = new YesNoDlg().ShowDialog(buffer.ToString(), "Certificate Validation Error");

            if (result != DialogResult.Yes)
            {
                return false;
            }

            return true;
        }
        #endregion

        #region Event Handlers
        private void File_ExitMI_Click(object sender, EventArgs e)
        {   
            try
			{
                Close();
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
			{
                // nothing to do.
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void Servers_ComServersMI_Click(object sender, EventArgs e)
        {
            try
            {
                new PseudoComServerListDlg().Show(m_configuration);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }       

        private void TabsPN_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (TabsPN.SelectedTab == this.ManageSecurityTAB)
                {
                    ManageApplicationSecurityCTRL.LoadApplications();
                }

                if (TabsPN.SelectedTab == this.ApplicationTAB)
                {
                    ApplicationToManageCTRL.LoadApplications();
                }

                if (TabsPN.SelectedTab == this.CertificatesTAB)
                {
                    foreach (string filePath in Utils.GetRecentFileList("CA Key File"))
                    {
                        IssuerKeyFilePathTB.Text = filePath;
                        break;
                    }
                }

                if (TabsPN.SelectedTab == HttpAccessRulesTAB)
                {
                    HttpAccessRuleCTRL.Initialize();
                }

                if (TabsPN.SelectedTab == ComServersTAB)
                {
                    ComServersCTRL.Initialize(m_configuration);
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void NewComServerBTN_Click(object sender, EventArgs e)
        {
            try
            {
                new NewEndpointDlg().ShowDialog(m_configuration, null);
                ComServersCTRL.Initialize(m_configuration);
                MessageBox.Show("Restart the 'UA COM Server Wrapper' (Administrative Tools -> Services) for any changes to take effect");
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void WrapComServerBTN_Click(object sender, EventArgs e)
        {
            try
            {
                new ManageWrappedComServersDlg().ShowDialog();
                MessageBox.Show("Restart the 'UA COM Server Wrapper' (Administrative Tools -> Services) for any changes to take effect");
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ClearRecentFileListsMI_Click(object sender, EventArgs e)
        {
            try
            {
                Utils.UpdateRecentFileList("Configuration Tool", null, 0);
                Utils.UpdateRecentFileList("COM Wrappers", null, 0);
                Utils.UpdateRecentFileList("CA Key File", null, 0);
                Utils.UpdateRecentFileList("CertificateStores:" + CertificateStoreType.Directory, null, 0);
                Utils.UpdateRecentFileList("CertificateStores:" + CertificateStoreType.Windows, null, 0);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void IssuerBrowseBTN_Click(object sender, EventArgs e)
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
                Utils.UpdateRecentFileList("CA Key File", IssuerKeyFilePathTB.Text, 1);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void CreateCertificateAuthorityBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CertificateStoreIdentifier store = new CertificateStoreIdentifier();
                store.StoreType = ManagedStoreCTRL.StoreType;
                store.StorePath = ManagedStoreCTRL.StorePath;
 
                CertificateIdentifier certificate = new CreateAuthorityDlg().ShowDialog(store);

                if (certificate != null)
                {
                    IssuerKeyFilePathTB.Text = certificate.GetPrivateKeyFilePath();
                    Utils.UpdateRecentFileList("CA Key File", IssuerKeyFilePathTB.Text, 1);
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void SelectAndIssueCertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Select Certificate to Issue";

                if (m_currentStore == null)
                {
                    m_currentStore = new CertificateStoreIdentifier();
                    m_currentStore.StoreType = Utils.DefaultStoreType;
                    m_currentStore.StorePath = Utils.DefaultStorePath;
                }

                CertificateIdentifier id = new CertificateListDlg().ShowDialog(m_currentStore, true);

                if (id == null)
                {
                    return;
                }

                m_currentStore.StoreType = id.StoreType;
                m_currentStore.StorePath = id.StorePath;

                X509Certificate2 certificate = id.Find();

                if (certificate == null)
                {
                    return;
                }

                CertificateIdentifier newId = new CreateCertificateDlg().ShowDialog(m_currentStore, IssuerKeyFilePathTB.Text, certificate);

                if (newId == null)
                {
                    return;
                }

                X509Certificate2 newCertificate = id.Find();

                MessageBox.Show(
                    this,
                    newCertificate.Subject + " issued.",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                // check if original certificate should be deleted.
                if (new YesNoDlg().ShowDialog("Delete orginal certificate?", caption) == DialogResult.Yes)
                {
                    ICertificateStore physicalStore = id.OpenStore();

                    try
                    {
                        physicalStore.Delete(certificate.Thumbprint);
                    }
                    finally
                    {
                        physicalStore.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ImportAndIssueCertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Select Certificate to Import";

                // set current directory.
                if (m_currentDirectory == null)
                {
                    m_currentDirectory = Utils.GetAbsoluteDirectoryPath("%LocalApplicationData%", false, false, false);
                }

                // open file dialog.
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".pfx";
                dialog.Filter = "Certificate Files (*.der)|*.der|All Files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.ValidateNames = true;
                dialog.Title = "Open Certificate File";
                dialog.FileName = null;
                dialog.InitialDirectory = m_currentDirectory;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileInfo fileInfo = new FileInfo(dialog.FileName);
                m_currentDirectory = fileInfo.Directory.FullName;
                
                X509Certificate2 certificate = new X509Certificate2(fileInfo.FullName);

                if (certificate == null)
                {
                    return;
                }

                CertificateStoreIdentifier store = new CertificateStoreIdentifier();
                store.StoreType = ManagedStoreCTRL.StoreType;
                store.StorePath = ManagedStoreCTRL.StorePath;

                CertificateIdentifier id = new CreateCertificateDlg().ShowDialog(store, IssuerKeyFilePathTB.Text, certificate);

                if (id == null)
                {
                    return;
                }

                certificate = id.Find(true);

                MessageBox.Show(
                    this,
                    certificate.Subject + " issued.",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ExportPrivateKeyBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Select Certificate to Export";

                CertificateStoreIdentifier store = new CertificateStoreIdentifier();
                store.StoreType = ManagedStoreCTRL.StoreType;
                store.StorePath = ManagedStoreCTRL.StorePath;

                CertificateIdentifier id = new CertificateListDlg().ShowDialog(store, true);

                if (id == null)
                {
                    return;
                }

                X509Certificate2 certificate = id.Find(false);

                if (certificate == null)
                {
                    MessageBox.Show(
                        this,
                        "Certificate does not exist or its private key cannot be accessed.",
                        caption,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                string displayName = null;

                foreach (string element in Utils.ParseDistinguishedName(certificate.Subject))
                {
                    if (element.StartsWith("CN="))
                    {
                        displayName = element.Substring(3);
                        break;
                    }
                }

                StringBuilder filePath = new StringBuilder();

                if (!String.IsNullOrEmpty(displayName))
                {
                    filePath.Append(displayName);
                    filePath.Append(" ");
                }

                filePath.Append("[");
                filePath.Append(certificate.Thumbprint);
                filePath.Append("].pfx");

                SaveFileDialog dialog = new SaveFileDialog();

                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".pfx";
                dialog.Filter = "PKCS#12 Files (*.pfx)|*.pfx|All Files (*.*)|*.*";
                dialog.ValidateNames = true;
                dialog.Title = "Save Private File";
                dialog.FileName = filePath.ToString();
                dialog.InitialDirectory = m_currentDirectory;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                string password = new PasswordDlg().ShowDialog(null, "Password recommended");

                FileInfo fileInfo = new FileInfo(dialog.FileName);
                m_currentDirectory = fileInfo.DirectoryName;

                // save the file.
                using (Stream ostrm = fileInfo.Open(FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                {
                    byte[] data = certificate.Export(X509ContentType.Pkcs12, password);
                    ostrm.Write(data, 0, data.Length);
                }

                // save the public key.
                string fileRoot = fileInfo.FullName.Substring(0, fileInfo.FullName.Length - fileInfo.Extension.Length);
                fileRoot += ".der";

                using (Stream ostrm = File.Open(fileRoot, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                {
                    byte[] data = certificate.RawData;
                    ostrm.Write(data, 0, data.Length);
                }

                // check if original certificate should be deleted.
                if (new YesNoDlg().ShowDialog("Delete original certificate?", caption) == DialogResult.Yes)
                {                    
                    ICertificateStore physicalStore = id.OpenStore();

                    try
                    {
                        physicalStore.Delete(certificate.Thumbprint);
                    }
                    finally
                    {
                        physicalStore.Close();
                    }
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ViewCertificatesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CertificateStoreIdentifier store = new CertificateStoreIdentifier();
                store.StoreType = ManagedStoreCTRL.StoreType;
                store.StorePath = ManagedStoreCTRL.StorePath;
                new CertificateListDlg().ShowDialog(store, false);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ApplicationToManageCTRL_ApplicationChanged(object sender, EventArgs e)
        {
            try
            {
                AssignApplicationCertificateBTN.Enabled = false;
                ManageApplicationPermissionsBTN.Enabled = false;
                AssignTrustListBTN.Enabled = false;
                CreateApplicationCertificateBTN.Enabled = false;
                ImportApplicationCertificateBTN.Enabled = false;
                ViewApplicationCertificateBTN.Enabled = false;

                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                ManageApplicationPermissionsBTN.Enabled = true;
                ViewApplicationCertificateBTN.Enabled = true;
                RegisterWithDiscoveryServerBTN.Enabled = true;
                ViewApplicationCertificateBTN.Enabled = true;

                if (application.IsSdkCompatible)
                {
                    AssignApplicationCertificateBTN.Enabled = true;
                    AssignTrustListBTN.Enabled = true;
                    CreateApplicationCertificateBTN.Enabled = true;
                    ImportApplicationCertificateBTN.Enabled = true;
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ManageApplicationSecurityCTRL_ApplicationChanged(object sender, EventArgs e)
        {
            try
            {
                TrustAnotherApplicationBTN.Enabled = false;
                ViewTrustedCertificatesBTN.Enabled = false;
                SelectCertificateToTrustBTN.Enabled = false;
                ImportCertificateToTrustBTN.Enabled = false;
                ImportCertificateListToTrustBTN.Enabled = false;
                DeleteAllTrustedCertificatesBTN.Enabled = false;
                RegisterWithDiscoveryServerBTN.Enabled = false;

                ManagedApplication application = ManageApplicationSecurityCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                TrustAnotherApplicationBTN.Enabled = true;
                ViewTrustedCertificatesBTN.Enabled = true;
                SelectCertificateToTrustBTN.Enabled = true;
                ImportCertificateToTrustBTN.Enabled = true;
                ImportCertificateListToTrustBTN.Enabled = true;
                DeleteAllTrustedCertificatesBTN.Enabled = true;
                RegisterWithDiscoveryServerBTN.Enabled = true;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void TrustAnotherApplicationBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ManagedApplication application1 = ApplicationToManageCTRL.GetSelectedApplication(); ;

                if (application1 == null)
                {
                    return;
                }

                application1.Reload();

                ManagedApplication application2 = new SelectApplicationDlg().ShowDialog();

                if (application2 == null)
                {
                    return;
                }

                SetupTrustRelationship(application1, application2);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ViewTrustedCertificatesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "View Trusted Certificates";

                ManagedApplication application = ManageApplicationSecurityCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                if (application.TrustList == null)
                {
                    MessageBox.Show(application.ToString() + " does not have a trust list defined.", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                new CertificateListDlg().ShowDialog(application.TrustList, false);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void SelectCertificateToTrustBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Select Certificate to Trust";

                ManagedApplication application = ManageApplicationSecurityCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                if (application.TrustList == null)
                {
                    MessageBox.Show(application.ToString() + " does not have a trust list defined.", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (m_currentStore == null)
                {
                    m_currentStore = new CertificateStoreIdentifier();
                    m_currentStore.StoreType = Utils.DefaultStoreType;
                    m_currentStore.StorePath = Utils.DefaultStorePath;
                }

                CertificateIdentifier id = new CertificateListDlg().ShowDialog(m_currentStore, true);

                if (id == null)
                {
                    return;
                }

                m_currentStore.StoreType = id.StoreType;
                m_currentStore.StorePath = id.StorePath;

                X509Certificate2 certificate = id.Find();

                if (certificate == null)
                {
                    return;
                }

                ICertificateStore store = application.TrustList.OpenStore();

                try
                {
                    if (store.FindByThumbprint(certificate.Thumbprint) == null)
                    {
                        store.Add(new X509Certificate2(certificate.RawData));
                    }
                }
                finally
                {
                    store.Close();
                }

                MessageBox.Show(
                    this,
                    certificate.Subject + " now trusted.",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ImportCertificateToTrustBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Import Certificate";

                ManagedApplication application = ManageApplicationSecurityCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                // load the configuration.
                application.Reload();

                if (application.TrustList == null)
                {
                    MessageBox.Show(application.ToString() + " does not have a trust list defined.", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // set current directory.
                if (m_currentDirectory == null)
                {
                    m_currentDirectory = Utils.GetAbsoluteDirectoryPath("%CommonApplicationData%\\OPC Foundation\\CertificateStores\\UA Applications", false, false);
                }

                if (m_currentDirectory == null)
                {
                    m_currentDirectory = new FileInfo(Application.ExecutablePath).DirectoryName;
                }

                // open file dialog.
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".der";
                dialog.Filter = "DER Files (*.der)|*.der|PKCS #12 Files (*.pfx)|*.pfx|All Files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.ValidateNames = true;
                dialog.Title = caption;
                dialog.FileName = null;
                dialog.InitialDirectory = m_currentDirectory;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileInfo fileInfo = new FileInfo(dialog.FileName);
                m_currentDirectory = fileInfo.Directory.FullName;

                if (!fileInfo.Exists)
                {
                    return;
                }

                X509Certificate2 certificate = new X509Certificate2(fileInfo.FullName, (string)null, X509KeyStorageFlags.Exportable);
                ValidateAndImport(application.TrustList, certificate);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ImportCertificateToStoreBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Import Certificate";

                CertificateStoreIdentifier list1 = new CertificateStoreIdentifier();
                list1.StoreType = ManagedStoreCTRL.StoreType;
                list1.StorePath = ManagedStoreCTRL.StorePath;

                // set current directory.
                if (m_currentDirectory == null)
                {
                    m_currentDirectory = Utils.GetAbsoluteDirectoryPath("%CommonApplicationData%\\OPC Foundation\\CertificateStores\\UA Applications", false, false);
                }

                if (m_currentDirectory == null)
                {
                    m_currentDirectory = new FileInfo(Application.ExecutablePath).DirectoryName;
                }

                // open file dialog.
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".der";
                dialog.Filter = "DER Files (*.der)|*.der|PKCS #12 Files (*.pfx)|*.pfx|All Files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.ValidateNames = true;
                dialog.Title = caption;
                dialog.FileName = null;
                dialog.InitialDirectory = m_currentDirectory;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileInfo fileInfo = new FileInfo(dialog.FileName);
                m_currentDirectory = fileInfo.Directory.FullName;

                if (!fileInfo.Exists)
                {
                    return;
                }

                X509Certificate2 certificate = new X509Certificate2(fileInfo.FullName, (string)null, X509KeyStorageFlags.Exportable);
                ValidateAndImport(list1, certificate);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ImportCertificateListToTrustBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Import Certificate List";

                ManagedApplication application = ManageApplicationSecurityCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                if (application.TrustList == null)
                {
                    MessageBox.Show(application.ToString() + " does not have a trust list defined.", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (m_currentStore == null)
                {
                    m_currentStore = new CertificateStoreIdentifier();
                    m_currentStore.StoreType = Utils.DefaultStoreType;
                    m_currentStore.StorePath = Utils.DefaultStorePath;
                }

                CertificateStoreIdentifier store = new CertificateStoreDlg().ShowDialog(m_currentStore);

                if (store == null)
                {
                    return;
                }

                m_currentStore = store;

                int count = 0;
                ICertificateStore store1 = application.TrustList.OpenStore();
                ICertificateStore store2 = store.OpenStore();

                try
                {
                    foreach (X509Certificate2 certificate in store2.Enumerate())
                    {
                        if (store1.FindByThumbprint(certificate.Thumbprint) == null)
                        {
                            store1.Add(certificate);
                            count++;
                        }
                    }
                }
                finally
                {
                    store1.Close();
                    store2.Close();
                }

                MessageBox.Show(
                    this,
                    count.ToString() + " certificates added.",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ImportCertificateListToStoreBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Import Certificate List";
                
                CertificateStoreIdentifier list1 = new CertificateStoreIdentifier();
                list1.StoreType = ManagedStoreCTRL.StoreType;
                list1.StorePath = ManagedStoreCTRL.StorePath;

                if (m_currentStore == null)
                {
                    m_currentStore = new CertificateStoreIdentifier();
                    m_currentStore.StoreType = Utils.DefaultStoreType;
                    m_currentStore.StorePath = Utils.DefaultStorePath;
                }

                CertificateStoreIdentifier list2 = new CertificateStoreDlg().ShowDialog(m_currentStore);

                if (list2 == null)
                {
                    return;
                }

                m_currentStore = list2;

                int count = 0;
                ICertificateStore store1 = list1.OpenStore();
                ICertificateStore store2 = list2.OpenStore();

                try
                {
                    foreach (X509Certificate2 certificate in store2.Enumerate())
                    {
                        if (store1.FindByThumbprint(certificate.Thumbprint) == null)
                        {
                            store1.Add(certificate);
                            count++;
                        }
                    }
                }
                finally
                {
                    store1.Close();
                    store2.Close();
                }

                MessageBox.Show(
                    this,
                    count.ToString() + " certificates added.",
                    caption,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void DeleteAllTrustedCertificatesBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Delete All Trusted Certificates";

                ManagedApplication application = ManageApplicationSecurityCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                if (application.TrustList == null)
                {
                    MessageBox.Show(application.ToString() + " does not have a trust list defined.", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                StringBuilder buffer = new StringBuilder();

                buffer.Append("Deleting all certificates from a trust list will affect other applications if you are using shared trust lists.");
                buffer.Append("\r\n\r\n");
                buffer.Append("Are you sure you would like to delete all certificates from '");
                buffer.Append(application.TrustList.ToString());
                buffer.Append("'?");

                if (new YesNoDlg().ShowDialog(buffer.ToString(), caption) != DialogResult.Yes)
                {
                    return;
                }

                bool privateKeys = false;
                int count = 0;
                ICertificateStore store = application.TrustList.OpenStore();

                try
                {
                    foreach (X509Certificate2 certificate in store.Enumerate())
                    {
                        if (certificate.HasPrivateKey)
                        {
                            privateKeys = true;
                            continue;
                        }

                        store.Delete(certificate.Thumbprint);
                        count++;
                    }
                }
                finally
                {
                    store.Close();
                }

                MessageBox.Show(
                    this,
                    count.ToString() + " certificates deleted.",
                    caption,  
                    MessageBoxButtons.OK, 
                    MessageBoxIcon.Information);

                if (privateKeys)
                {
                    buffer = new StringBuilder();

                    buffer.Append("Some certificates were not deleted because they have private keys.");
                    buffer.Append("\r\n\r\n");
                    buffer.Append("Would you like to view them?");

                    if (new YesNoDlg().ShowDialog(buffer.ToString(), caption) != DialogResult.Yes)
                    {
                        return;
                    }

                    new CertificateListDlg().ShowDialog(application.TrustList, false);
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Setups the trust relationship between two applications.
        /// </summary>
        /// <param name="application1">The application1.</param>
        /// <param name="application2">The application2.</param>
        private bool SetupTrustRelationship(ManagedApplication application1, ManagedApplication application2)
        {
            X509Certificate2 certificate1 = application1.Certificate.Find();

            if (certificate1 == null)
            {
                MessageBox.Show(application1.ToString() + " does not have a certificate defined.", "Setup Trust Relationship", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            X509Certificate2 certificate2 = application2.Certificate.Find();

            if (certificate2 == null)
            {
                MessageBox.Show(application2.ToString() + " does not have a certificate defined.", "Setup Trust Relationship", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (application1.TrustList != null)
            {
                ICertificateStore store = application1.TrustList.OpenStore();

                try
                {
                    if (store.FindByThumbprint(certificate2.Thumbprint) == null)
                    {
                        store.Add(new X509Certificate2(certificate2.RawData));
                    }
                }
                finally
                {
                    store.Close();
                }
            }

            if (application2.TrustList != null)
            {
                ICertificateStore store = application2.TrustList.OpenStore();

                try
                {
                    if (store.FindByThumbprint(certificate1.Thumbprint) == null)
                    {
                        store.Add(new X509Certificate2(certificate1.RawData));
                    }
                }
                finally
                {
                    store.Close();
                }
            }

            return true;
        }

        private void RegisterWithDiscoveryServerBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Register with Discovery Server";

                ManagedApplication application = ManageApplicationSecurityCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                application.Reload();

                if (application.Certificate == null)
                {
                    MessageBox.Show(this, "Certificate is not specified.", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // find discovery server.
                string path = Utils.FindInstalledFile("Opc.Ua.DiscoveryServer.exe");

                if (path == null)
                {
                    MessageBox.Show("Could not find the discovery server. Please confirm that it is installed.", caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                ManagedApplication lds = new ManagedApplication();
                lds.SetExecutableFile(path);

                if (!SetupTrustRelationship(application, lds))
                {
                    return;
                }

                MessageBox.Show("The Local Discovery Server now trusts the application.", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ExportApplicationCertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                const string caption = "Export Application Certificate";

                ManagedApplication application = ManageApplicationSecurityCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                application.Reload();

                if (application.Certificate == null)
                {
                    MessageBox.Show(this, "Certificate is not specified.", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                X509Certificate2 certificate = application.Certificate.Find(false);

                if (certificate == null)
                {
                    MessageBox.Show(this, "Certificate does not exist.", caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                string displayName = null;

                foreach (string element in Utils.ParseDistinguishedName(certificate.Subject))
                {
                    if (element.StartsWith("CN="))
                    {
                        displayName = element.Substring(3);
                        break;
                    }
                }

                StringBuilder filePath = new StringBuilder();

                if (!String.IsNullOrEmpty(displayName))
                {
                    filePath.Append(displayName);
                    filePath.Append(" ");
                }

                filePath.Append("[");
                filePath.Append(certificate.Thumbprint);
                filePath.Append("].der");

                SaveFileDialog dialog = new SaveFileDialog();

                dialog.CheckFileExists = false;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".pfx";
                dialog.Filter = "Certificate Files (*.der)|*.der|All Files (*.*)|*.*";
                dialog.ValidateNames = true;
                dialog.Title = "Save Certificate File";
                dialog.FileName = filePath.ToString();
                dialog.InitialDirectory = m_currentDirectory;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileInfo fileInfo = new FileInfo(dialog.FileName);
                m_currentDirectory = fileInfo.DirectoryName;

                using (Stream ostrm = File.Open(fileInfo.FullName, FileMode.Create, FileAccess.ReadWrite, FileShare.None))
                {
                    byte[] data = certificate.RawData;
                    ostrm.Write(data, 0, data.Length);
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ManageFirewallAccessBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ManagedApplication application = ApplicationToManageCTRL.GetSelectedApplication();

                if (application == null)
                {
                    return;
                }

                application.Reload();

                new FirewallAccessDlg().ShowDialog(application);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void IssueSslCertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CertificateStoreIdentifier store = new CertificateStoreIdentifier();
                store.StoreType = ManagedStoreCTRL.StoreType;
                store.StorePath = ManagedStoreCTRL.StorePath;

                CertificateIdentifier id = new CreateSslCertificateDlg().ShowDialog(store, IssuerKeyFilePathTB.Text, null);

                if (id == null)
                {
                    return;
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void BindSslCertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                CertificateStoreIdentifier store = new CertificateStoreIdentifier();
                store.StoreType = ManagedStoreCTRL.StoreType;
                store.StorePath = ManagedStoreCTRL.StorePath;

                new ManageSslBindingsDlg().ShowDialog(store);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion

        private void contentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start( Path.GetDirectoryName(Application.ExecutablePath) + "\\WebHelp\\ua_configuration_tool.htm");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to launch help documentation. Error: " + ex.Message);
            }
        }
    }
}
