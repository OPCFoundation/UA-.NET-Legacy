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
using System.Xml;
using System.Runtime.Serialization;
using Opc.Ua.Client.Controls;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Prompts the user to specify a new access rule for a file.
    /// </summary>
    public partial class ManagedApplicationDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the dialog.
        /// </summary>
        public ManagedApplicationDlg()
        {
            InitializeComponent();

            InstructionsTB.Text =
            "This dialog specifies the location of the information needed to configure security for a UA application. " +
            "The configuration file is the file used by the application to store its security settings. " +
            "This configuration file can be read by this tool if it conforms to the ApplicationConfiguration schema used by the OPC UA .NET SDK. " +
            "If it is not known or it uses an unknown schema then the application certificate and trust list must be specified manually. " +
            "Once this is done the tool can be used to manage the contents of trust list.";
        }
        #endregion

        #region Private Fields
        private string m_currentDirectory;
        private ManagedApplication m_application;
        private CertificateIdentifier m_certificate;
        private CertificateStoreIdentifier m_trustList;
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public ManagedApplication ShowDialog(ManagedApplication application)
        {
            Update(application);

            if (application == null)
            {
                m_application = new ManagedApplication();
                ExecutableBTN_Click(this, null);
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return null;
            }

            return m_application;
        }
        #endregion

        #region Event Handlers
        private void OkBTN_Click(object sender, EventArgs e)
        {
            try
            {
                if (String.IsNullOrEmpty(ApplicationNameTB.Text))
                {
                    MessageBox.Show("Application Name must be specified.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // set source file.
                string filePath = null;

                if (m_application.SourceFile != null)
                {
                    filePath = m_application.SourceFile.FullName;
                }
                else
                {
                    filePath = Utils.GetAbsoluteDirectoryPath("%LocalApplicationData%\\OPC Foundation\\Applications\\", false, false, true);
                    filePath += ApplicationNameTB.Text;
                    filePath += ".xml";
                }

                // check if exists.
                if (File.Exists(filePath))
                {
                    if (MessageBox.Show("File exists. Overwrite?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                    {
                        return;
                    }
                }

                // save the file.
                m_application.DisplayName = ApplicationNameTB.Text;
                m_application.ExecutablePath = ExecutableFileTB.Text;
                m_application.ConfigurationPath = ConfigurationFileTB.Text;
                m_application.Certificate = m_certificate;
                m_application.TrustList = m_trustList;

                m_application.Save(filePath);
                
                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        /// <summary>
        /// Updates the dialog with the configuration.
        /// </summary>
        private void Update(ManagedApplication application)
        {
            if (application == null)
            {
                application = new ManagedApplication();
            }

            m_application = application;
            SetIsSdkApplication(application.IsSdkCompatible);

            ApplicationNameTB.Text = application.DisplayName;
            ExecutableFileTB.Text = application.ExecutablePath;
            ConfigurationFileTB.Text = application.ConfigurationPath;
            CertificateTB.Text = null;
            TrustListTB.Text = null;

            m_certificate = application.Certificate;
            m_trustList = application.TrustList;

            if (m_certificate != null)
            {
                X509Certificate2 certificate = m_certificate.Find();

                if (certificate != null)
                {
                    CertificateTB.Text = certificate.Subject;
                }
                else
                {
                    CertificateTB.Text = m_certificate.ToString();
                }
            }

            if (m_trustList != null)
            {
                TrustListTB.Text = m_trustList.ToString();
            }
        }

        /// <summary>
        /// Sets the state based on whether the current application is compatible with the .NET SDK configuration file.
        /// </summary>
        private void SetIsSdkApplication(bool state)
        {
            CertificateBTN.Enabled = !state;
            TrustListBTN.Enabled = !state;
        }
        
        private void ExecutableBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get current executable file.
                if (!String.IsNullOrEmpty(ExecutableFileTB.Text))
                {
                    FileInfo filePath = new FileInfo(ExecutableFileTB.Text);

                    if (filePath.Exists)
                    {
                        m_currentDirectory = filePath.Directory.FullName;
                    }
                }

                // set current directory.
                if (m_currentDirectory == null)
                {
                    m_currentDirectory = Utils.GetAbsoluteDirectoryPath("%ProgramFiles%", false, false);
                }

                // open file dialog.
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".exe";
                dialog.Filter = "Executable Files (*.exe)|*.exe|All Files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.ValidateNames = true;
                dialog.Title = "Select Application Executable File";
                dialog.FileName = null;
                dialog.InitialDirectory = m_currentDirectory;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileInfo executableFile = new FileInfo(dialog.FileName);
                m_currentDirectory = executableFile.Directory.FullName;
                ExecutableFileTB.Text = executableFile.FullName;

                m_application.SetExecutableFile(executableFile.FullName);

                // update the control.
                Update(m_application);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void ConfigurationBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get current executable file.
                if (!String.IsNullOrEmpty(ConfigurationFileTB.Text))
                {
                    FileInfo filePath = new FileInfo(ConfigurationFileTB.Text);

                    if (filePath.Exists)
                    {
                        m_currentDirectory = filePath.Directory.FullName;
                    }
                }

                // set current directory.
                if (m_currentDirectory == null)
                {
                    m_currentDirectory = Utils.GetAbsoluteDirectoryPath("%CommonApplicationData%", false, false);
                }

                // open file dialog.
                OpenFileDialog dialog = new OpenFileDialog();

                dialog.CheckFileExists = true;
                dialog.CheckPathExists = true;
                dialog.DefaultExt = ".exe";
                dialog.Filter = "Configuration Files (*.xml)|*.xml|All Files (*.*)|*.*";
                dialog.Multiselect = false;
                dialog.ValidateNames = true;
                dialog.Title = "Select Application Configuration File";
                dialog.FileName = null;
                dialog.InitialDirectory = m_currentDirectory;
                dialog.RestoreDirectory = true;

                if (dialog.ShowDialog() != DialogResult.OK)
                {
                    return;
                }

                FileInfo configurationFile = new FileInfo(dialog.FileName);
                m_currentDirectory = configurationFile.Directory.FullName;
                ConfigurationFileTB.Text = configurationFile.FullName;

                m_application.SetConfigurationFile(configurationFile.FullName);

                // update the control.
                Update(m_application);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void CertificateBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // determine default store.
                CertificateStoreIdentifier store = new CertificateStoreIdentifier();

                if (m_certificate != null)
                {
                    store.StoreType = m_certificate.StoreType;
                    store.StorePath = m_certificate.StorePath;
                }
                else
                {
                    store.StoreType = Utils.DefaultStoreType;
                    store.StorePath = Utils.DefaultStorePath;
                }

                // select the certificate.
                CertificateIdentifier certificate = new CertificateListDlg().ShowDialog(store, true);

                if (certificate != null)
                {
                    m_certificate = certificate;
                    X509Certificate2 certificate2 = m_certificate.Find();

                    if (certificate2 != null)
                    {
                        CertificateTB.Text = certificate2.Subject;
                    }
                    else
                    {
                        CertificateTB.Text = m_certificate.ToString();
                    }
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void TrustListBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // determine default store.
                CertificateStoreIdentifier store = new CertificateStoreIdentifier();

                if (m_trustList != null)
                {
                    store.StoreType = m_trustList.StoreType;
                    store.StorePath = m_trustList.StorePath;
                }
                else
                {
                    store.StoreType = Utils.DefaultStoreType;
                    store.StorePath = Utils.DefaultStorePath;
                }

                // select store.
                CertificateStoreIdentifier trustList = new CertificateStoreDlg().ShowDialog(store);

                if (trustList != null)
                {
                    m_trustList = trustList;
                    TrustListTB.Text = m_trustList.ToString();
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, System.Reflection.MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
