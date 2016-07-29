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
using Opc.Ua;

namespace Quickstarts.ComDataAccessServer
{
    /// <summary>
    /// Prompts the user to accept or reject an untrusted certificate.
    /// </summary>
    public partial class AcceptCertificateDlg : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AcceptCertificateDlg"/> class.
        /// </summary>
        public AcceptCertificateDlg()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Shows the dialog.
        /// </summary>
        /// <param name="e">The <see cref="Opc.Ua.CertificateValidationEventArgs"/> instance containing the event data.</param>
        /// <returns>True if the certificate was accepted.</returns>
        public AcceptCertificateOptions ShowDialog(CertificateValidationEventArgs e)
        {
            SubjectTB.Text = Utils.Format("{0}", e.Certificate.Subject);
            IssuerTB.Text = Utils.Format("{0}", (e.Certificate.Subject == e.Certificate.Issuer)?"Self-signed":e.Certificate.Issuer);
            ValidFromTB.Text = Utils.Format("{0:yyyy-MM-dd}", e.Certificate.NotBefore);
            ValidToTB.Text = Utils.Format("{0:yyyy-MM-dd}", e.Certificate.NotAfter);
            ThumbprintTB.Text = Utils.Format("{0}", e.Certificate.Thumbprint);

            AlwaysAcceptAllRB.Enabled = false;
            AlwaysAcceptSingleRB.Enabled = false;
            AlwaysRejectRB.Enabled = false;
            OneTimeAcceptRB.Checked = true;

            if (ShowDialog() != DialogResult.OK)
            {
                return AcceptCertificateOptions.RejectOnce;
            }

            if (OneTimeAcceptRB.Checked)
            {
                return AcceptCertificateOptions.AcceptOnceForCurrent;
            }

            return AcceptCertificateOptions.RejectOnce;
        }
    }

    /// <summary>
    /// The available choices when accepting a certificate.
    /// </summary>
    public enum AcceptCertificateOptions
    {
        /// <summary>
        /// The certificate should be rejected this time.
        /// </summary>
        RejectOnce,

        /// <summary>
        /// The certificate should be accepted once for the current server.
        /// </summary>
        AcceptOnceForCurrent,

        /// <summary>
        /// The certificate should be accepted always for the current server.
        /// </summary>
        AcceptAlwaysForCurrent,

        /// <summary>
        /// The certificate should be accepted always for all servers on the machine.
        /// </summary>
        AcceptAlwaysForAll,

        /// <summary>
        /// The certificate should be rejected always.
        /// </summary>
        RejectAlways
    }
}
