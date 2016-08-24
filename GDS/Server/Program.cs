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
using System.Windows.Forms;
using System.Security.Cryptography.X509Certificates;
using Opc.Ua;
using Opc.Ua.Server;
using Opc.Ua.Configuration;
using Owin;
using System.Web.Http;
using System.Net.Http;
using Microsoft.Owin.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Opc.Ua.GdsServer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Initialize the user interface.
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationType = ApplicationType.Server;
            application.ConfigSectionName = "Opc.Ua.ServerConfiguration";

            try
            {
                // process and command line arguments.
                if (application.ProcessCommandLine())
                {
                    return;
                }

                // check if running as a service.
                if (!Environment.UserInteractive)
                {
                    application.StartAsService(new GlobalDiscoveryServerServer());
                    return;
                }

                // load the application configuration.
                application.LoadApplicationConfiguration(false);

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 2048);

                // set up HTTPS certificate validation.
                application.ApplicationConfiguration.CertificateValidator.CertificateValidation += CertificateValidator_CertificateValidation;
                ApplicationInstance.SetUaValidationForHttps(application.ApplicationConfiguration.CertificateValidator);

                // start authorization service.
                var aus = new Opc.Ua.AuthorizationService.AuthorizationService();
                aus.Start(application);

                // start the server.
                var server = new GlobalDiscoveryServerServer();
                application.Start(server);

                // run the application interactively.
                Application.Run(new Opc.Ua.Server.Controls.ServerForm(server, application.ApplicationConfiguration));
            }
            catch (Exception e)
            {
                ExceptionDlg.Show(application.ApplicationName, e);
                return;
            }
        }

        static void CertificateValidator_CertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            // automatically accept all untrusted certficates.
            if (e.Error.Code == StatusCodes.BadCertificateUntrusted)
            {
                e.Accept = true;
            }
        }
    }
}
