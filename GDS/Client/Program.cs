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
using System.Linq;
using System.Windows.Forms;
using Opc.Ua;
using Opc.Ua.Configuration;
using Cannoli.Services;

namespace Opc.Ua.GdsClient
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
            application.ApplicationType = ApplicationType.Client;
            application.ConfigSectionName = "Opc.Ua.ClientConfiguration";

            try
            {
                // process and command line arguments.
                if (application.ProcessCommandLine())
                {
                    return;
                }

                // load the application configuration.
                application.LoadApplicationConfiguration(false);

                // check the application certificate.
                application.CheckApplicationInstanceCertificate(false, 0);

                var httpsCertificateValidator = new CertificateValidator();
                httpsCertificateValidator.CertificateValidation += CertificateValidator_HttpsCertificateValidation;
                ApplicationInstance.SetUaValidationForHttps(httpsCertificateValidator);

                // run the application interactively.
                Application.Run(new MainForm(application));
            }
            catch (Exception e)
            {
                ExceptionDlg.Show(application.ApplicationName, e);
                return;
            }
        }

        static void CertificateValidator_HttpsCertificateValidation(CertificateValidator sender, CertificateValidationEventArgs e)
        {
            // automatically accept all untrusted certficates.
            if (e.Error.Code == StatusCodes.BadCertificateUntrusted)
            {
                e.Accept = true;
            }
        }
    }
}
