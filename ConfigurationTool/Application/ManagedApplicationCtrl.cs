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
using System.Security.Cryptography.X509Certificates;
using System.Reflection;
using System.Xml;
using System.IO;
using System.Runtime.Serialization;

using Opc.Ua.Client.Controls;
using Opc.Ua.Configuration;

namespace Opc.Ua.Configuration
{
    public partial class ManagedApplicationCtrl : UserControl
    {
        #region Constructors
        public ManagedApplicationCtrl()
        {
            InitializeComponent();
            m_groupName = "Configuration Tool";
        }
        #endregion
       
        #region Private Fields
        private string m_groupName;
        private event EventHandler m_ApplicationChanged;

        private string[] s_StandardApplications = new string[]
        {
            "Opc.Ua.DiscoveryServer.exe",
            "Opc.Ua.ComProxyServer.exe",
            "Opc.Ua.ComServerWrapper.exe",
            "Opc.Ua.ConfigurationTool.exe"
        };
        #endregion

        [DefaultValue("Configuration Tool")]
        public string GroupName
        {
            get { return m_groupName; }
            set { m_groupName = value; }
        }

        public event EventHandler ApplicationChanged
        {
            add { m_ApplicationChanged += value; }
            remove { m_ApplicationChanged -= value; }
        }

        /// <summary>
        /// Loads the applications from disk.
        /// </summary>
        public void LoadApplications()
        {
            ApplicationToManageCB.Items.Clear();

            // add the recent files.
            foreach (string filePath in Utils.GetRecentFileList(m_groupName))
            {
                AddApplicationToManage(new FileInfo(filePath));
            }

            // load the config files for any OPC applications.
            string configDir = Utils.GetAbsoluteDirectoryPath("%LocalApplicationData%\\OPC Foundation\\Applications", false, false, true);

            if (configDir != null)
            {
                foreach (FileInfo fileInfo in new DirectoryInfo(configDir).GetFiles("*.xml"))
                {
                    AddApplicationToManage(fileInfo);
                }
            }

            // add the standard applications.
            foreach (string fileName in s_StandardApplications)
            {
                string filePath = Utils.FindInstalledFile(fileName);

                if (!String.IsNullOrEmpty(filePath))
                {
                    ManagedApplication application = new ManagedApplication();
                    application.SetExecutableFile(filePath);

                    bool found = false;

                    foreach (ManagedApplication item in ApplicationToManageCB.Items)
                    {
                        if (item.ExecutablePath != null)
                        {
                            if (String.Compare(item.ExecutablePath, application.ExecutablePath, StringComparison.OrdinalIgnoreCase) == 0)
                            {
                                found = true;
                                break;
                            }
                        }
                    }

                    if (!found)
                    {
                        application.Save(configDir + "\\" + application.DisplayName + ".xml");
                        AddApplicationToManage(application);
                    }
                }
            }

            // select the first item.
            if (ApplicationToManageCB.Items.Count > 0)
            {
                ApplicationToManageCB.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Gets the selected application.
        /// </summary>
        /// <returns>The selected application.</returns>
        public ManagedApplication GetSelectedApplication()
        {
            if (ApplicationToManageCB.SelectedIndex < 0)
            {
                return null;
            }

            return (ManagedApplication)ApplicationToManageCB.SelectedItem;
        }

        /// <summary>
        /// Sets the selected application.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        public void SetSelectedApplication(string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                return;
            }

            int ii = 0;
            
            foreach (ManagedApplication application in ApplicationToManageCB.Items)
            {
                if (application.ExecutablePath != null)
                {
                    if (String.Compare(filePath, application.ExecutablePath, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        ApplicationToManageCB.SelectedIndex = ii;
                        break;
                    }
                }

                if (application.ConfigurationPath != null)
                {
                    if (String.Compare(filePath, application.ConfigurationPath, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        ApplicationToManageCB.SelectedIndex = ii;
                        break;
                    }
                }

                if (application.SourceFile != null)
                {
                    if (String.Compare(filePath, application.SourceFile.FullName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        ApplicationToManageCB.SelectedIndex = ii;
                        break;
                    }
                }

                ii++;
            }
        }

        #region Private Methods
        /// <summary>
        /// Adds an application to manage to the drop down menu.
        /// </summary>
        private int AddApplicationToManage(FileInfo fileInfo)
        {
            // ignore files that don't exist.
            if (fileInfo == null || !fileInfo.Exists)
            {
                return ApplicationToManageCB.SelectedIndex;
            }

            try
            {
                ManagedApplication application = ManagedApplication.Load(fileInfo.FullName);

                if (application == null)
                {
                    return ApplicationToManageCB.SelectedIndex;
                }

                // add to list.
                return AddApplicationToManage(application);
            }

            // ignore errors.
            catch (Exception)
            {
                return ApplicationToManageCB.SelectedIndex;
            }
        }

        /// <summary>
        /// Adds an application to manage to the drop down menu.
        /// </summary>
        private int AddApplicationToManage(ManagedApplication application)
        {
            // ignore files that don't exist.
            if (application == null)
            {
                return ApplicationToManageCB.SelectedIndex;
            }

            try
            {
                // ignore duplicates.
                foreach (ManagedApplication applicationToManage in ApplicationToManageCB.Items)
                {
                    if (String.Compare(applicationToManage.SourceFile.FullName, application.SourceFile.FullName, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return ApplicationToManageCB.SelectedIndex;
                    }
                }

                // add to list.
                return ApplicationToManageCB.Items.Add(application);
            }

            // ignore errors.
            catch (Exception)
            {
                return ApplicationToManageCB.SelectedIndex;
            }
        }
        #endregion

        #region Event Handlers
        private void ApplicationToManageCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                EditApplicationBTN.Enabled = false;

                // check if nothing is selected.
                if (ApplicationToManageCB.SelectedIndex == -1)
                {
                    if (ApplicationToManageCB.Items.Count > 0)
                    {
                        ApplicationToManageCB.SelectedIndex = 0;
                    }

                    return;
                }

                // get the application.
                ManagedApplication application = ApplicationToManageCB.SelectedItem as ManagedApplication;

                if (application == null)
                {
                    return;
                }

                EditApplicationBTN.Enabled = true;
                Utils.UpdateRecentFileList(m_groupName, application.SourceFile.FullName, 16);

                // raise notification.
                if (m_ApplicationChanged != null)
                {
                    m_ApplicationChanged(this, null);
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void NewApplicationBTN_Click(object sender, EventArgs e)
        {
            try
            {
                ManagedApplication application = new ManagedApplicationDlg().ShowDialog(null);

                if (application == null)
                {
                    return;
                }

                ApplicationToManageCB.SelectedIndex = ApplicationToManageCB.Items.Add(application);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void EditApplicationBTN_Click(object sender, EventArgs e)
        {
            try
            {
                // get application.
                ManagedApplication application = ApplicationToManageCB.SelectedItem as ManagedApplication;

                if (application == null)
                {
                    return;
                }

                // edit application.
                application = new ManagedApplicationDlg().ShowDialog(application);

                if (application == null)
                {
                    return;
                }

                // update list.
                ApplicationToManageCB.Items.RemoveAt(ApplicationToManageCB.SelectedIndex);
                ApplicationToManageCB.SelectedIndex = ApplicationToManageCB.Items.Add(application);
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion
    }
}
