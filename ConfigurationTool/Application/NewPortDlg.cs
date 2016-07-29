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
using System.Security.Principal;
using System.Reflection;

using Opc.Ua.Client.Controls;
using Opc.Ua.Configuration;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Prompts the user to specify a new access rule for a file.
    /// </summary>
    public partial class NewPortDlg : Form
    {
        #region Constructors
        /// <summary>
        /// Initializes the dialog.
        /// </summary>
        public NewPortDlg()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        #endregion
        
        #region Public Interface
        /// <summary>
        /// Displays the dialog.
        /// </summary>
        public int ShowDialog(int port)
        {
            if (port <= 0)
            {
                PortCTRL.Value = 4048;
            }
            else if (port > PortCTRL.Minimum)
            {
                PortCTRL.Value = PortCTRL.Maximum;
            }
            else if (port < PortCTRL.Minimum)
            {
                PortCTRL.Value = PortCTRL.Minimum;
            }
            else if (port < PortCTRL.Minimum)
            {
                PortCTRL.Value = port;
            }

            if (ShowDialog() != DialogResult.OK)
            {
                return -1;
            }

            return (int)PortCTRL.Value;
        }
        #endregion
    }
}
