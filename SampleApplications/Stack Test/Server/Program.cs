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
using System.Windows.Forms;
using System.ComponentModel;

using Opc.Ua.Server;
using Opc.Ua.Client.Controls;
using Opc.Ua.Sample.Controls;

namespace Opc.Ua.StackTest
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

            List<TestServer> servers = new List<TestServer>();

            try
            {
                servers.Add(CreateHttpServer(10000, 1024, false));
                servers.Add(CreateTcpServer(11000, 1024, false));
                servers.Add(CreateTcpServer(11001, 2048, false));
                servers.Add(CreateTcpServer(12000, 1024, true));
                servers.Add(CreateTcpServer(12001, 2048, true));

                Application.Run(new MainForm(servers[0]));
            }
            catch (Exception e)
            {
                GuiUtils.HandleException("UA Test Server", null, e);
            }
            finally
            {
                for (int ii = 0; ii < servers.Count; ii++)
                {
                    servers[ii].Stop();
                }
            }
        }

        /// <summary>
        /// Creates and starts a HTTP server.
        /// </summary>
        private static TestServer CreateHttpServer(ushort port, ushort keySize, bool useAnsiCStack)
        {
            TestServer server = new TestServer(port);

            ApplicationConfiguration configuration = ApplicationConfiguration.Load("Opc.Ua.Server", ApplicationType.Server);

            configuration.ApplicationName = Utils.Format("UA StackTest Server (Http-{0})", keySize);
            configuration.ApplicationUri = Utils.Format("http://{0}/{1}", System.Net.Dns.GetHostName(), configuration.ApplicationName);

            string subjectName = Utils.Format("CN={1}/DC={0}", System.Net.Dns.GetHostName(), configuration.ApplicationName);

            configuration.SecurityConfiguration.ApplicationCertificate.RawData = null;
            configuration.SecurityConfiguration.ApplicationCertificate.Thumbprint = null;
            configuration.SecurityConfiguration.ApplicationCertificate.SubjectName = subjectName;

            // set base addresses.
            string url = Utils.Format("http://{0}:{1}/StackTestServer/{2}", System.Net.Dns.GetHostName(), port, keySize);

            configuration.ServerConfiguration.BaseAddresses.Clear();
            configuration.ServerConfiguration.BaseAddresses.Add(url);

            GuiUtils.CheckApplicationInstanceCertificate(configuration, keySize, false, false);

            // start server.
            server.Start(configuration);
            TestUtils.InitializeContexts(server.MessageContext);

            return server;
        }

        /// <summary>
        /// Creates and starts a TCP server.
        /// </summary>
        private static TestServer CreateTcpServer(ushort port, ushort keySize, bool useAnsiCStack)
        {
            TestServer server = new TestServer(port);

            ApplicationConfiguration configuration = ApplicationConfiguration.Load("Opc.Ua.Server", ApplicationType.Server);

            configuration.ApplicationName = Utils.Format("UA StackTest Server ({0}-{1})", (useAnsiCStack)?"AnsiC":"C#", keySize);
            configuration.ApplicationUri = Utils.Format("http://{0}/{1}", System.Net.Dns.GetHostName(), configuration.ApplicationName);

            string subjectName = Utils.Format("CN={1}/DC={0}", System.Net.Dns.GetHostName(), configuration.ApplicationName);

            configuration.SecurityConfiguration.ApplicationCertificate.RawData = null;
            configuration.SecurityConfiguration.ApplicationCertificate.Thumbprint = null;
            configuration.SecurityConfiguration.ApplicationCertificate.SubjectName = subjectName;

            // check if UA TCP configuration included.
            configuration.UseNativeStack = useAnsiCStack;

            // set base addresses.
            string url = Utils.Format("opc.tcp://{0}:{1}/StackTestServer/{2}/{3}", System.Net.Dns.GetHostName(), port, (useAnsiCStack) ? "AnsiC" : "DotNet", keySize);
            
            configuration.ServerConfiguration.BaseAddresses.Clear();
            configuration.ServerConfiguration.BaseAddresses.Add(url);

            GuiUtils.CheckApplicationInstanceCertificate(configuration, keySize, false, false);

            // start server.
            server.Start(configuration);
            TestUtils.InitializeContexts(server.MessageContext);

            return server;
        }
    }
}
