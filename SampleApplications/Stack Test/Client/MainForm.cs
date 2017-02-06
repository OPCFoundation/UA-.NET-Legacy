/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
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
using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Description;

using Opc.Ua.Client;
using Opc.Ua.Client.Controls;
using Opc.Ua.Sample.Controls;

namespace Opc.Ua.StackTest
{
    public partial class MainForm : Form
    {
        #region Constructors
        public MainForm()
        {
            InitializeComponent();
            this.Icon = ClientUtils.GetAppIcon();

            CreateClient(false, 1024);

            TestCancelMI.Enabled = false;
            TestCasesCTRL.Initialize(m_client.SequenceToExecute);

            m_endpoints = new ConfiguredEndpointCollection(m_configuration);
            m_endpointsToTest = new Queue<ConfiguredEndpoint>();
            m_clientsToTest = new Queue<ClientOptions>();

            CreateCertificate(false, 1024);
            CreateCertificate(true, 1024);
            CreateCertificate(false, 2048);
            CreateCertificate(true, 2048);

            AddTcpEndpoint(12001, MessageSecurityMode.None, SecurityPolicies.None, 2048, true);
            AddTcpEndpoint(12001, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic128Rsa15, 2048, true);
            AddTcpEndpoint(12001, MessageSecurityMode.Sign, SecurityPolicies.Basic128Rsa15, 2048, true);
            AddTcpEndpoint(12001, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic256, 2048, true);
            AddTcpEndpoint(12001, MessageSecurityMode.Sign, SecurityPolicies.Basic256, 2048, true);

            AddHttpEndpoint(10000, MessageSecurityMode.None, SecurityPolicies.None, false, 1024);
            AddHttpEndpoint(10000, MessageSecurityMode.None, SecurityPolicies.None, true, 1024);
            AddHttpEndpoint(10000, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic128Rsa15, false, 1024);
            AddHttpEndpoint(10000, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic128Rsa15, true, 1024);
            AddHttpEndpoint(10000, MessageSecurityMode.Sign, SecurityPolicies.Basic128Rsa15, false, 1024);
            AddHttpEndpoint(10000, MessageSecurityMode.Sign, SecurityPolicies.Basic128Rsa15, true, 1024);
            AddHttpEndpoint(10000, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic256, false, 1024);
            AddHttpEndpoint(10000, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic256, true, 1024);
            AddHttpEndpoint(10000, MessageSecurityMode.Sign, SecurityPolicies.Basic256, false, 1024);
            AddHttpEndpoint(10000, MessageSecurityMode.Sign, SecurityPolicies.Basic256, true, 1024);

            AddTcpEndpoint(12000, MessageSecurityMode.None, SecurityPolicies.None, 1024, true);
            AddTcpEndpoint(12000, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic128Rsa15, 1024, true);
            AddTcpEndpoint(12000, MessageSecurityMode.Sign, SecurityPolicies.Basic128Rsa15, 1024, true);
            AddTcpEndpoint(12000, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic256, 1024, true);
            AddTcpEndpoint(12000, MessageSecurityMode.Sign, SecurityPolicies.Basic256, 1024, true);

            AddTcpEndpoint(11000, MessageSecurityMode.None, SecurityPolicies.None, 1024, false);
            AddTcpEndpoint(11000, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic128Rsa15, 1024, false);
            AddTcpEndpoint(11000, MessageSecurityMode.Sign, SecurityPolicies.Basic128Rsa15, 1024, false);
            AddTcpEndpoint(11000, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic256, 1024, false);
            AddTcpEndpoint(11000, MessageSecurityMode.Sign, SecurityPolicies.Basic256, 1024, false);

            AddTcpEndpoint(11001, MessageSecurityMode.None, SecurityPolicies.None, 2048, false);
            AddTcpEndpoint(11001, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic128Rsa15, 2048, false);
            AddTcpEndpoint(11001, MessageSecurityMode.Sign, SecurityPolicies.Basic128Rsa15, 2048, false);
            AddTcpEndpoint(11001, MessageSecurityMode.SignAndEncrypt, SecurityPolicies.Basic256, 2048, false);
            AddTcpEndpoint(11001, MessageSecurityMode.Sign, SecurityPolicies.Basic256, 2048, false);

            EndpointSelectorCTRL.Initialize(m_endpoints, m_configuration);
        }
        #endregion
                
        #region Private Fields
        private TestClient m_client;
        private ConfiguredEndpointCollection m_endpoints;
        private ApplicationConfiguration m_configuration;
        private ClientOptions m_currentOptions;
        private Queue<ConfiguredEndpoint> m_endpointsToTest;
        private Queue<ClientOptions> m_clientsToTest;
        #endregion

        #region Private Methods
        private class ClientOptions
        {
            public ClientOptions(bool useAnsiCStack, ushort keySize, bool serializersOnly)
            {
                UseAnsiCStack = useAnsiCStack;
                KeySize = keySize;
                SerializersOnly = serializersOnly;
            }

            public bool UseAnsiCStack;
            public ushort KeySize;
            public bool SerializersOnly;
        }

        private void CreateCertificate(bool useAnsiCStack, ushort keySize)
        {
            ApplicationConfiguration configuration = ApplicationConfiguration.Load("Opc.Ua.Client", ApplicationType.Client);

            configuration.ApplicationName = Utils.Format("UA StackTest Client ({0}-{1})", (useAnsiCStack) ? "AnsiC" : "C#", keySize);
            configuration.ApplicationUri = Utils.Format("http://{0}/{1}", System.Net.Dns.GetHostName(), configuration.ApplicationName);

            string subjectName = Utils.Format("CN={1}/DC={0}", System.Net.Dns.GetHostName(), configuration.ApplicationName);

            configuration.SecurityConfiguration.ApplicationCertificate.RawData = null;
            configuration.SecurityConfiguration.ApplicationCertificate.Thumbprint = null;
            configuration.SecurityConfiguration.ApplicationCertificate.SubjectName = subjectName;

            // check if UA TCP implementation explicitly specified.
            configuration.UseNativeStack = useAnsiCStack;

            // check for certificate.
            GuiUtils.CheckApplicationInstanceCertificate(configuration, keySize, false, false);
        }

        /// <summary>
        /// Determines whether configuration specifies that the native stack should be used.
        /// </summary>
        /// <returns>
        /// 	<c>true</c> if using the native stack; otherwise, <c>false</c>.
        /// </returns>
        private bool IsUsingNativeStack()
        {
            return m_configuration.UseNativeStack;
        }

        /// <summary>
        /// Creates the client that can connect to the server.
        /// </summary>
        private void CreateClient(bool useAnsiCStack, ushort keySize)
        {
            ApplicationConfiguration configuration = ApplicationConfiguration.Load("Opc.Ua.Client", ApplicationType.Client);

            configuration.ApplicationName = Utils.Format("UA StackTest Client ({0}-{1})", (useAnsiCStack) ? "AnsiC" : "C#", keySize);
            configuration.ApplicationUri = Utils.Format("http://{0}/{1}", System.Net.Dns.GetHostName(), configuration.ApplicationName);

            string subjectName = Utils.Format("CN={1}/DC={0}", System.Net.Dns.GetHostName(), configuration.ApplicationName);

            configuration.SecurityConfiguration.ApplicationCertificate.RawData = null;
            configuration.SecurityConfiguration.ApplicationCertificate.Thumbprint = null;
            configuration.SecurityConfiguration.ApplicationCertificate.SubjectName = subjectName;

            // check if UA TCP implementation explicitly specified.
            configuration.UseNativeStack = useAnsiCStack;

            // check for certificate.
            GuiUtils.CheckApplicationInstanceCertificate(configuration, keySize, false, false);
            
            m_configuration = configuration;

            m_client = new TestClient(m_configuration);
            m_client.TestSequenceEvent += new TestSequenceEventHandler(TestClient_TestSequenceEvent);
            m_client.TestLogEventHandler += new TestLogEventHandler(TestClient_TestLogEventHandler);

            if (TestCasesCTRL.SequenceToExecute != null)
            {
                m_client.SequenceToExecute = TestCasesCTRL.SequenceToExecute;
            }

            m_client.QuickTest = QuickTestMI.Checked;
        }

        private void AddHttpEndpoint(ushort port, MessageSecurityMode securityMode, string securityPolicyUri, bool useBinaryEncoding, ushort keySize)
        {
            ConfiguredEndpoint endpoint = m_endpoints.Create(Utils.Format("http://localhost:{0}/StackTestServer/{1}", port, keySize));

            endpoint.Description.SecurityMode = securityMode;
            endpoint.Description.SecurityPolicyUri = securityPolicyUri;
            endpoint.Configuration.UseBinaryEncoding = useBinaryEncoding;

            m_endpoints.Add(endpoint);
        }

        private void AddTcpEndpoint(ushort port, MessageSecurityMode securityMode, string securityPolicyUri, ushort keySize, bool useAnsiCStack)
        {
            ConfiguredEndpoint endpoint = m_endpoints.Create(Utils.Format("opc.tcp://localhost:{0}/StackTestServer/{1}/{2}", port, (useAnsiCStack)?"AnsiC":"DotNet", keySize));

            endpoint.Description.SecurityMode = securityMode;
            endpoint.Description.SecurityPolicyUri = securityPolicyUri;

            m_endpoints.Add(endpoint);
        }

        /// <summary>
        /// Connects to a endpoint.
        /// </summary>
        private void Connect(ConfiguredEndpoint endpoint, bool useAnsiCStack, ushort keySize)
        {    
            try
            {
                TestEvent e = new TestEvent();

                e.Timestamp = DateTime.Now;
                e.TestId = 0;
                e.Iteration = 0;
                e.EventType = TestEventType.Started;
                e.Details = endpoint.ToString();

                this.TestEventsCTRL.AddEvent(e);

                CreateClient(useAnsiCStack, keySize);

                m_client.BeginExecuteTestSequence(endpoint);
                TestCancelMI.Enabled = true; 
            }
            catch (Exception exception)
            {
                MessageBox.Show("Connect");
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
                TestCancelMI.Enabled = false;
            }       
        }
        
        /// <summary>
        /// Connects to all endpoints.
        /// </summary>
        private void StartTest(ClientOptions options)
        {
            TestEvent e = new TestEvent();

            e.Timestamp = DateTime.Now;
            e.TestId = 0;
            e.Iteration = 0;
            e.EventType = TestEventType.Started;
            e.Details = Utils.Format("Testing with Client: {0}/{1}", (options.UseAnsiCStack)?"AnsiC":"DotNet", options.KeySize);

            this.TestEventsCTRL.AddEvent(e);

            m_currentOptions = options;
            m_endpointsToTest.Clear();

            foreach (ConfiguredEndpoint endpoint in m_endpoints.Endpoints)
            {
                if (options.UseAnsiCStack && endpoint.EndpointUrl.Scheme != Utils.UriSchemeOpcTcp)
                {
                    continue;
                }

                if (options.SerializersOnly && (endpoint.Description.SecurityMode != MessageSecurityMode.None || !endpoint.Description.EndpointUrl.EndsWith("1024")))
                {
                    continue;
                }

                m_endpointsToTest.Enqueue(endpoint);
            }

            if (m_endpointsToTest.Count > 0)
            {
                Connect(m_endpointsToTest.Dequeue(), options.UseAnsiCStack, options.KeySize);
            }
        }

        /// <summary>
        /// Connects to all endpoints.
        /// </summary>
        private void ConnectAll()
        {
            try
            {
                m_clientsToTest.Clear();

                m_clientsToTest.Enqueue(new ClientOptions(false, 2048, false));
                m_clientsToTest.Enqueue(new ClientOptions(false, 1024, false));
                m_clientsToTest.Enqueue(new ClientOptions(true, 1024, false));
                m_clientsToTest.Enqueue(new ClientOptions(true, 2048, false));

                StartTest(m_clientsToTest.Dequeue());
            }
            catch (Exception exception)
            {
                MessageBox.Show("ConnectAll");
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
                TestCancelMI.Enabled = false;
            }
        }

        /// <summary>
        /// Tests the serializers
        /// </summary>
        private void TestSerializers()
        {
            try
            {
                m_clientsToTest.Clear();

                m_clientsToTest.Enqueue(new ClientOptions(false, 1024, true));
                m_clientsToTest.Enqueue(new ClientOptions(true, 1024, true));

                StartTest(m_clientsToTest.Dequeue());
            }
            catch (Exception exception)
            {
                MessageBox.Show("TestSerializers");
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
                TestCancelMI.Enabled = false;
            }
        }
        #endregion

        #region Event Handlers
        private void TestSerializerDirectMI_Click(object sender, EventArgs e)
        {
            try
            {
                m_client.BeginExecuteSerializerDirect();
            }
            catch (Exception exception)
            {
                MessageBox.Show("TestSerializerDirectMI_Click");
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void PerformanceTestMI_Click(object sender, EventArgs e)
        {  
            try
            {
                CreateClient(true, 1024);

                new PerformanceTestDlg().ShowDialog(
                    m_configuration,
                    m_endpoints, 
                    m_configuration.SecurityConfiguration.ApplicationCertificate.Find(true));
            }
            catch (Exception exception)
            {
                MessageBox.Show("PerformanceTestMI_Click");
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        void TestClient_TestLogEventHandler(Logger logger, TestEvent e)
        {
            if (InvokeRequired)
            {
                Invoke(new TestLogEventHandler(TestClient_TestLogEventHandler), logger, e);
                return;
            }

            try
            {
                // TBD
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }     
        }

        void TestClient_TestSequenceEvent(TestClient client, TestSequenceEventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new TestSequenceEventHandler(TestClient_TestSequenceEvent), client, e);
                return;
            }
            
            try
            {
                if (e.TestCaseName == "Done")
                {
                    TestCancelMI.Enabled = false;

                    if (!m_client.Cancel)
                    {
                        if (m_endpointsToTest.Count > 0)
                        {
                            Connect(m_endpointsToTest.Dequeue(), m_currentOptions.UseAnsiCStack, m_currentOptions.KeySize);
                            return;
                        }

                        if (m_clientsToTest.Count > 0)
                        {
                            StartTest(m_clientsToTest.Dequeue());
                            return;
                        }
                    }

                    m_endpointsToTest.Clear();
                    m_clientsToTest.Clear();

                    TestEvent e1 = new TestEvent();

                    e1.Timestamp = DateTime.Now;
                    e1.TestId = 0;
                    e1.Iteration = 0;
                    e1.EventType = TestEventType.Completed;
                    e1.Details = Utils.Format("Completed all tests.");

                    TestEventsCTRL.AddEvent(e1);
                }

                TestCaseTB.Text  = e.TestCaseName;
                TestIdTB.Text    = String.Format("{0}", e.TestId);
                IterationTB.Text = String.Format("{0}", e.Iteration);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }     
        }

        void EndpointSelectorCTRL_ConnectEndpoint(object sender, ConnectEndpointEventArgs e)
        {
            try
            {
                TestEventsCTRL.Clear();
                Connect(e.Endpoint, Test_UseNativeStackMI.Checked, 1024);
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
                e.UpdateControl = false;
            }
        }

        private void EndpointSelectorCTRL_OnChange(object sender, EventArgs e)
        {
            try
            {
                m_endpoints.Save();
            }
            catch (Exception exception)
            {
                MessageBox.Show("EndpointSelectorCTRL_OnChange");
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {            
            try
            {
                // TBD
            }
            catch (Exception exception)
            {
                MessageBox.Show("MainForm_FormClosing");
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void FileLoadMI_Click(object sender, EventArgs e)
        {
			try
			{
                FileInfo fileInfo = new FileInfo(m_client.TestFilePath);

				OpenFileDialog dialog = new OpenFileDialog();

				dialog.CheckFileExists  = true;
				dialog.CheckPathExists  = true;
				dialog.DefaultExt       = ".xml";
				dialog.Filter           = "Config Files (*.uatest)|*.uatest|All Files (*.*)|*.*";
				dialog.Multiselect      = false;
				dialog.ValidateNames    = true;
				dialog.Title            = "Open Test Configuration File";
				dialog.FileName         = m_client.TestFilePath;
                dialog.InitialDirectory = fileInfo.DirectoryName;

				if (dialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}

                m_client.LoadTestConfiguration(dialog.FileName);
			}
            catch (Exception exception)
            {
                MessageBox.Show("FileLoadMI_Click");
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void FileSaveAsMI_Click(object sender, EventArgs e)
        {
			try
			{
                FileInfo fileInfo = new FileInfo(m_client.TestFilePath);

				SaveFileDialog dialog = new SaveFileDialog();

				dialog.CheckFileExists  = true;
				dialog.CheckPathExists  = true;
				dialog.DefaultExt       = ".config";
				dialog.Filter           = "Config Files (*.uatest)|*.uatest|All Files (*.*)|*.*";
				dialog.ValidateNames    = true;
				dialog.Title            = "Save Test Configuration File";
				dialog.FileName         = m_client.TestFilePath;
                dialog.InitialDirectory = fileInfo.DirectoryName;

				if (dialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
			}
            catch (Exception exception)
            {
                MessageBox.Show("FileSaveAsMI_Click");
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void FileSaveMI_Click(object sender, EventArgs e)
        {
			try
			{
				OpenFileDialog dialog = new OpenFileDialog();

				dialog.CheckFileExists = true;
				dialog.CheckPathExists = true;
				dialog.DefaultExt      = ".config";
				dialog.Filter          = "Config Files (*.uaconfig)|*.uaconfig|All Files (*.*)|*.*";
				dialog.Multiselect     = false;
				dialog.ValidateNames   = true;
				dialog.Title           = "Open Test Configuration File";
				dialog.FileName        = m_client.TestFilePath;

				if (dialog.ShowDialog() != DialogResult.OK)
				{
					return;
				}
			}
            catch (Exception exception)
            {
				GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void FileExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TestCancelMI_Click(object sender, EventArgs e)
        {
            m_client.Cancel = true;
        }

        private void TestAllMI_Click(object sender, EventArgs e)
        {
            try
            {
                TestEventsCTRL.Clear();
                ConnectAll();
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void Test_TestSerializersMI_Click(object sender, EventArgs e)
        {
            try
            {
                TestEventsCTRL.Clear();
                TestSerializers();
            }
            catch (Exception exception)
            {
                GuiUtils.HandleException(this.Text, MethodBase.GetCurrentMethod(), exception);
            }
        }

        private void TestMI_DropDownOpening(object sender, EventArgs e)
        {
        }

        private void Test_UserNativeEncodersMI_CheckStateChanged(object sender, EventArgs e)
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
        #endregion
    }
}
