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
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using System.Security.Cryptography;
using System.ComponentModel;
using System.IO;

using Opc.Ua.Configuration;
using Opc.Ua.Client.Controls;

namespace Opc.Ua.ServerTest
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationName   = "UA Server Test Tool";
            application.ApplicationType   = ApplicationType.Client;
            application.ConfigSectionName = "Opc.Ua.ServerTestTool";

            try
            {
                // process and command line arguments.
                if (application.ProcessCommandLine())
                {
                    return;
                }

                // run the application interactively.
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                ExceptionDlg.Show(application.ApplicationName, e);
                return;
            }
        }

        /// <summary>
        /// Runs the test in a console.
        /// </summary>
        private static void RunInConsole(string endpointUrl)
        {
            ApplicationConfiguration m_configuration = GuiUtils.DoStartupChecks("Opc.Ua.ServerTestTool", ApplicationType.Client, null, true);

            if (m_configuration == null)
            {
                return;
            }

            GuiUtils.OverrideUaTcpImplementation(m_configuration);

            m_configuration.CertificateValidator.CertificateValidation += new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
            ServerTestConfiguration m_testConfiguration = ServerTestConfiguration.Load(m_configuration.Extensions);

            m_testConfiguration.Coverage = 30;
            m_testConfiguration.EndpointSelection = EndpointSelection.All;
            m_testConfiguration.ConnectToAllEndpoints = true;

            // initialize the log file.
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
                    Console.WriteLine(exception.Message);
                }
            }

            // create the test client.
            ServerTestClient testClient = new ServerTestClient(m_configuration);

            ConfiguredEndpointCollection collection = new ConfiguredEndpointCollection();
            ConfiguredEndpoint endpoint = collection.Create(endpointUrl);

            testClient.ReportResult += new EventHandler<ServerTestClient.ReportResultEventArgs>(TestClient_ReportTestResult);
            testClient.Run(endpoint, m_testConfiguration);
        }

        /// <summary>
        /// Handles the ReportTestResult event of the TestClient control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="Opc.Ua.ServerTest.ServerTestClient.ReportResultEventArgs"/> instance containing the event data.</param>
        private static void TestClient_ReportTestResult(
            object sender,
            ServerTestClient.ReportResultEventArgs e)
        {
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
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }

        /// <summary>
        /// Logs a message.
        /// </summary>
        private static void LogMessage(string message)
        {
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
                Console.WriteLine(Utils.Format("ERROR WRITING TO LOGFILE: {0}\r\n", exception.Message.ToUpperInvariant()));
            }
        }

        /// <summary>
        /// Accepts server certificates.
        /// </summary>
        static void CertificateValidator_CertificateValidation(CertificateValidator validator, CertificateValidationEventArgs e)
        {
            // always safe to trust servers when connecting as a test application.
            e.Accept = true;
        }

        static string m_logFilePath;
    }
}
