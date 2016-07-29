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
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.IO;

using Opc.Ua.Client;
using Opc.Ua.Configuration;
using Opc.Ua.Client.Controls;

namespace Opc.Ua.ServerTest
{
    public partial class MainForm : Form
    {
        #region Constructors
        /// <summary>
        /// Loads the configuration and initializes the form.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();

            m_configuration = GuiUtils.DoStartupChecks("Opc.Ua.ServerTestTool", ApplicationType.Client, null, true);

            if (m_configuration != null)
            {
                GuiUtils.OverrideUaTcpImplementation(m_configuration);
                GuiUtils.DisplayUaTcpImplementation(this, m_configuration);
            }

            m_configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
            m_testConfiguration = ServerTestConfiguration.Load(m_configuration.Extensions);

            // allow UA servers to use the same certificate for HTTPS validation.
            ApplicationInstance.SetUaValidationForHttps(m_configuration.CertificateValidator);

            TestCasesCTRL.Initialize(m_testConfiguration);

            // get list of cached endpoints.
            m_endpoints = m_configuration.LoadCachedEndpoints(true);
            EndpointsCTRL.Initialize(m_endpoints, m_configuration);

            // create the test client.
            m_testClient = new ServerTestClient(m_configuration);

            m_testClient.ReportResult += new EventHandler<ServerTestClient.ReportResultEventArgs>(TestClient_ReportTestResult);
            m_testClient.ReportProgress += new EventHandler<ServerTestClient.ReportProgressEventArgs>(TestClient_ReportTestProgress);
        }

        /// <summary>
        /// Accepts server certificates.
        /// </summary>
        void CertificateValidator_CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            // always safe to trust servers when connecting as a test application.
            e.Accept = true;
        }
        #endregion
        
        #region Private Fields
        private ApplicationConfiguration m_configuration;
        private ServerTestConfiguration m_testConfiguration;
        private ConfiguredEndpointCollection m_endpoints;
        private ServerTestClient m_testClient;
        private bool m_running;
        private string m_logFilePath;
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Runs the tests.
        /// </summary>
        private void Run(object state)
        {
            if (state == null)
            {
                return;
            }
            
            try
            {
                m_testClient.Run((ConfiguredEndpoint)state, m_testConfiguration);
                RunCompleted(null);
            }
            catch (Exception e)
            {
                RunCompleted(e);
            }
        }

        /// <summary>
        /// Called when the test run completes.
        /// </summary>
        private void RunCompleted(object exception)
        {
            if (InvokeRequired)
            {
                this.BeginInvoke(new WaitCallback(RunCompleted), exception);
                return;
            }

            if (IsDisposed)
            {
                return;
            }

            SetRunning(false);

            EndpointTB.Text = "---";
            IterationTB.Text = "---";
            TestCaseTB.Text = "---";
            TestCaseProgressCTRL.Value = TestCaseProgressCTRL.Maximum;

            if (exception != null)
            {
			    GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), (Exception)exception);
            }           
        }
        #endregion

        #region Event Handlers
        void EndpointsCTRL_ConnectEndpoint(object sender, ConnectEndpointEventArgs e)
        {
            try
            {
                if (m_running)
                {
                    throw new InvalidOperationException("Test is already running.");
                }

                if (m_testConfiguration.Coverage == 0)
                {
                    m_testConfiguration.Coverage = 100;
                }

                SetRunning(true);
                                
                EndpointTB.Text = e.Endpoint.EndpointUrl.ToString();
                TestsCompletedTB.Text = "---";
                IterationTB.Text = "---";
                TestCaseTB.Text = "---";
                TestCaseProgressCTRL.Value = 0;
                ResultsTB.Clear();

                ThreadPool.QueueUserWorkItem(Run, e.Endpoint);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
                e.UpdateControl = false;
            }
        }

        /// <summary>
        /// Toggles the test state between running and stopped.
        /// </summary>
        private void SetRunning(bool running)
        {
            if (running)
            {                
                StopBTN.Enabled = m_running = true;

                m_logFilePath = null;
                
                if (m_configuration.TraceConfiguration != null)
                {
                    m_logFilePath = Utils.GetAbsoluteFilePath(m_configuration.TraceConfiguration.OutputFilePath, true, false, true);
                    FileInfo file = new FileInfo(m_logFilePath);
                    m_logFilePath = file.DirectoryName;
                    m_logFilePath += "\\Opc.Ua.ServerTestTool";
                }

                if (String.IsNullOrEmpty(m_logFilePath))
                {
                    m_logFilePath = m_configuration.SourceFilePath;
                }

                if (!String.IsNullOrEmpty(m_logFilePath))
                {
                    try
                    {
                        m_logFilePath += ".";     
                        m_logFilePath += Utils.GetAssemblyBuildNumber();                        
                        m_logFilePath += ".log.txt";

                        using (StreamWriter logWriter = new StreamWriter(File.Open(m_logFilePath, FileMode.Create)))
                        {
                            logWriter.WriteLine(Utils.Format("Logging Started at {0:hh:mm:ss}", DateTime.Now));
                        }
                    }
                    catch (Exception exception)
                    {
			            GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
                    }
                }
            }
            else
            {
                StopBTN.Enabled = m_running = false;
            }
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        private void LogMessage(string message)
        {
            if (!this.Test_NoDisplayUpdateMI.Checked)
            {
                if (ResultsTB.Text.Length > 0)
                {
                    ResultsTB.AppendText("\r\n");
                }
                
                ResultsTB.AppendText(message);
            }

            try
            {
                if (!String.IsNullOrEmpty(m_logFilePath))
                {
                    using (StreamWriter logWriter = new StreamWriter(File.Open(m_logFilePath, FileMode.Append)))
                    {
                        logWriter.WriteLine(message);
                    }
                }
            }
            catch (Exception exception)
            {
                ResultsTB.AppendText(Utils.Format("ERROR WRITING TO LOGFILE: {0}\r\n", exception.Message.ToUpperInvariant()));
            }
        }

        private void EndpointsCTRL_OnChange(object sender, EventArgs e)
        {
            try
            {
                m_endpoints.Save();
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        void TestClient_ReportTestProgress(object sender, ServerTestClient.ReportProgressEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler<ServerTestClient.ReportProgressEventArgs>(TestClient_ReportTestProgress), sender, e);
                return;
            }

            try
            {
                if (this.Test_NoDisplayUpdateMI.Checked)
                {
                    return;
                }

                e.Stop = !m_running;

                if (!m_running)
                {
                    return;
                }
                
                TestsCompletedTB.Text = Utils.Format(
                    "{0} ({1} Failed)", 
                    e.TestCount,
                    e.FailedTestCount);

                EndpointTB.Text = Utils.Format(
                    "{0} of {1} [{2}:{3}:{4}:{5}]", 
                    e.EndpointCount,
                    e.TotalEndpointCount,
                    e.Endpoint.EndpointUrl.Scheme,
                    e.Endpoint.Description.SecurityMode, 
                    SecurityPolicies.GetDisplayName(e.Endpoint.Description.SecurityPolicyUri),
                    (e.Endpoint.Configuration.UseBinaryEncoding)?"Binary":"XML");

                IterationTB.Text = Utils.Format(
                    "{0} of {1}", 
                    e.IterationCount,
                    e.TotalIterationCount);

                TestCaseTB.Text = Utils.Format("{0}/{1}", e.Testcase.Parent, e.Testcase.Name);

                if (e.Breakpoint)
                {
                    DialogResult result = MessageBox.Show(
                        "Stopped at breakpoint. Continue?", 
                        e.Testcase.Name, 
                        MessageBoxButtons.OKCancel, 
                        MessageBoxIcon.Question, 
                        MessageBoxDefaultButton.Button1);

                    e.Stop = result != DialogResult.OK;
                    return;
                }

                double progress = (e.CurrentProgress/e.FinalProgress)*(TestCaseProgressCTRL.Maximum - TestCaseProgressCTRL.Minimum);

                if (progress < TestCaseProgressCTRL.Minimum)
                {
                    progress = TestCaseProgressCTRL.Minimum;
                }

                if (progress > TestCaseProgressCTRL.Maximum)
                {
                    progress = TestCaseProgressCTRL.Maximum;
                }

                TestCaseProgressCTRL.Value = (int)progress;
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void TestClient_ReportTestResult(
            object sender, 
            ServerTestClient.ReportResultEventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke(new EventHandler<ServerTestClient.ReportResultEventArgs>(TestClient_ReportTestResult), sender, e);
                return;
            }

            try
            {
                if (e.Args == null || e.Args.Length == 0)
                {
                    LogMessage(e.Format);
                }
                else
                {
                    LogMessage(Utils.Format(e.Format, e.Args));
                }

                e.Stop = !m_running;

                if (!this.Test_NoDisplayUpdateMI.Checked)
                {
                    ResultsTB.ScrollToCaret();
                }
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

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

        private void Test_RunMI_Click(object sender, EventArgs e)
        {
            try
            {
                m_testClient.Run(EndpointsCTRL.SelectedEndpoint, m_testConfiguration); 
                StopBTN.Enabled = true;               
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        #endregion

        /// <summary>
        /// Loads the test configuration from a file.
        /// </summary>
        private void LoadConfiguration(string filePath)
        {
            // load the new configuration.
            m_testConfiguration = ServerTestConfiguration.Load(filePath, m_testConfiguration);

            // update the file list.
            Utils.UpdateRecentFileList("Server Test Client", filePath, 4);

            // update the control.
            TestCasesCTRL.Initialize(m_testConfiguration);
        }

        private void File_LoadMI_Click(object sender, EventArgs e)
        {
			try
			{
                // select the directory.
                DirectoryInfo dirInfo = new DirectoryInfo(Environment.CurrentDirectory);

                if (m_testConfiguration.FilePath != null)
                {
                    FileInfo fileInfo = new FileInfo(m_testConfiguration.FilePath);

                    if (fileInfo.Directory.Exists)
                    {
                        dirInfo = fileInfo.Directory;
                    }
                }

				OpenFileDialog dialog = new OpenFileDialog();

				dialog.CheckFileExists  = true;
				dialog.CheckPathExists  = true;
				dialog.DefaultExt       = ".xml";
				dialog.Filter           = "Test Files (*.xml)|*.xml|All Files (*.*)|*.*";
				dialog.Multiselect      = false;
				dialog.ValidateNames    = true;
				dialog.Title            = "Open Test Configuration File";
				dialog.FileName         = m_testConfiguration.FilePath;
                dialog.InitialDirectory = dirInfo.FullName;

				if (dialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}

                // load the configuration file.
                LoadConfiguration(dialog.FileName);
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void File_SaveMI_Click(object sender, EventArgs e)
        {
			try
			{
                // select the directory.
                string filePath = null;
                DirectoryInfo dirInfo = new DirectoryInfo(Environment.CurrentDirectory);

                if (m_testConfiguration.FilePath != null)
                {
                    FileInfo fileInfo = new FileInfo(m_testConfiguration.FilePath);

                    if (fileInfo.Directory.Exists)
                    {
                        dirInfo = fileInfo.Directory;
                    }

                    filePath = m_testConfiguration.FilePath;
                }
                else
                {
                    filePath = dirInfo.FullName + "\\TestConfiguration";
                }

				SaveFileDialog dialog = new SaveFileDialog();

				dialog.CheckFileExists  = false;
				dialog.CheckPathExists  = true;
				dialog.DefaultExt       = ".xml";
				dialog.Filter           = "Config Files (*.xml)|*.xml|All Files (*.*)|*.*";
				dialog.ValidateNames    = true;
				dialog.Title            = "Save Test Configuration File";
                dialog.FileName         = filePath;
                dialog.InitialDirectory = dirInfo.FullName;

				if (dialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}

                m_testConfiguration.Save(dialog.FileName);

                // update the file list.
                Utils.UpdateRecentFileList("Server Test Client", dialog.FileName, 4);
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void File_RecentFilesMI_Click(object sender, EventArgs e)
        {
			try
			{
                ToolStripItem item = sender as ToolStripItem;

                if (item != null)
                {
                    // load the configuration file.
                    LoadConfiguration((string)item.Tag);
                }
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void File_RecentFilesMI_MouseEnter(object sender, EventArgs e)
        {
			try
			{
                File_RecentFilesMI.DropDown.Items.Clear();

                foreach (string filePath in Utils.GetRecentFileList("Server Test Client"))
                {
                    string displayName = Utils.GetFilePathDisplayName(filePath, 60);
                    ToolStripItem item = File_RecentFilesMI.DropDown.Items.Add(displayName);
                    item.Click += new EventHandler(File_RecentFilesMI_Click);
                    item.Tag = filePath;
                }
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }
        
        /// <summary>
        /// Creates a new session.
        /// </summary>
        private Session CreateSession()
        {
            try
            {
                Cursor = Cursors.WaitCursor;

                ServiceMessageContext messageContext = m_configuration.CreateMessageContext();
                BindingFactory bindingFactory = BindingFactory.Create(m_configuration, messageContext);

                ConfiguredEndpoint endpoint = this.EndpointsCTRL.SelectedEndpoint;
                
                endpoint.UpdateFromServer(bindingFactory);
                                
                // Initialize the channel which will be created with the server.
                ITransportChannel channel = SessionChannel.Create(
                    m_configuration,
                    endpoint.Description,
                    endpoint.Configuration,
                    m_configuration.SecurityConfiguration.ApplicationCertificate.Find(true),
                    messageContext);

                // Wrap the channel with the session object.
                Session session = new Session(channel, m_configuration, endpoint, null);

                // Create the session. This actually connects to the server.
                session.Open(Guid.NewGuid().ToString(), null);

                return session;
            }
            finally
            {
                Cursor = Cursors.Default;
            }
        }

        private void Test_BrowseRootsMI_Click(object sender, EventArgs e)
        {
            
			try
			{
                using (Session session = CreateSession())
                {
                    List<NodeId> nodeIds = m_testConfiguration.GetNodeList(m_testConfiguration.BrowseRoots, session.NamespaceUris);

                    IList<ILocalNode> nodes = new SelectNodesDlg().ShowDialog(session, null, nodeIds);

                    if (nodes  != null)
                    {
                        if (m_testConfiguration.BrowseRoots == null)
                        {
                            m_testConfiguration.BrowseRoots = new ListOfTestNode();
                        }

                        m_testConfiguration.ReplaceNodeList(m_testConfiguration.BrowseRoots, nodes, session.NamespaceUris);
                    }
                }
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void Test_BrowseWriteableMI_Click(object sender, EventArgs e)
        {
			try
			{
                using (Session session = CreateSession())
                {
                    List<NodeId> nodeIds = m_testConfiguration.GetNodeList(m_testConfiguration.WriteableVariables, session.NamespaceUris);

                    IList<ILocalNode> nodes = new SelectNodesDlg().ShowDialog(session, null, nodeIds);

                    if (nodes  != null)
                    {                        
                        if (m_testConfiguration.WriteableVariables == null)
                        {
                            m_testConfiguration.WriteableVariables = new ListOfTestNode();
                        }

                        m_testConfiguration.ReplaceNodeList(m_testConfiguration.WriteableVariables, nodes, session.NamespaceUris);
                    }
                }
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void Stop_Click(object sender, EventArgs e)
        {            
			try
			{
                SetRunning(false);
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void Stop_MouseDown(object sender, MouseEventArgs e)
        {
			try
			{
                StopBTN.BorderStyle = Border3DStyle.SunkenOuter;
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void StopBTN_MouseUp(object sender, MouseEventArgs e)
        {
			try
			{
                StopBTN.BorderStyle = Border3DStyle.RaisedInner;
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void Test_ContinuousMI_CheckStateChanged(object sender, EventArgs e)
        {
			try
			{
                m_testConfiguration.Continuous = Test_ContinuousMI.Checked;
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private bool IsUsingNativeStack()
        {
            return m_configuration.UseNativeStack;
        }

        private void TestMI_DropDownOpening(object sender, EventArgs e)
        {
            try
            {
                Test_UseNativeStackMI.Checked = IsUsingNativeStack();
                Test_UseNativeEncodersMI.Enabled = Test_UseNativeStackMI.Checked;
                //Test_UseNativeEncodersMI.Checked = Opc.Ua.NativeStack.NativeStackChannel.UseNativeEncoders;
                //Test_AlwaysCheckSizesMI.Checked = Opc.Ua.NativeStack.NativeStackChannel.AlwaysCheckSizes;
                Test_AlwaysCheckSizesMI.Enabled = Test_UseNativeEncodersMI.Checked;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void Test_UseNativeStackMI_Click(object sender, EventArgs e)
        {
            try
            {
                m_configuration.UseNativeStack = Test_UseNativeStackMI.Checked;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
            finally
            {
                GuiUtils.DisplayUaTcpImplementation(this, m_configuration);
            }
        }

        private void Test_UseNativeEncodersMI_CheckStateChanged(object sender, EventArgs e)
        {
            try
            {
                //Opc.Ua.NativeStack.NativeStackChannel.UseNativeEncoders = Test_UseNativeEncodersMI.Checked;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void Test_AlwaysCheckSizesMI_Click(object sender, EventArgs e)
        {
            try
            {
                //Opc.Ua.NativeStack.NativeStackChannel.AlwaysCheckSizes = Test_AlwaysCheckSizesMI.Checked;
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void CheckNodeIdMI_Click(object sender, EventArgs e)
        {
            try
            {
                string nodeId = new Opc.Ua.Client.Controls.StringValueEditDlg().ShowDialog("");

                if (nodeId == null)
                {
                    return;
                }

                string[] parts = nodeId.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);

                ushort ns = Convert.ToUInt16(parts[0].Substring(2));
                uint id = Convert.ToUInt32(parts[2]);

                using (Session session = CreateSession())
                {
                    new SelectNodesDlg().ShowDialog(session, new NodeId(id, ns), null);
                }
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }

        }
    }
}
