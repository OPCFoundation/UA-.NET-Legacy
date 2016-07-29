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
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Change the password for form.
    /// </summary>
    public partial class UserPasswordChangeForm : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        public UserPasswordChangeForm()
        {
            InitializeComponent();

            DialogResult = DialogResult.Cancel;
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Returns the user name.
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Returns the old password.
        /// </summary>
        public string OldPassword { get; set; }

        /// <summary>
        /// Returns the new password.
        /// </summary>
        public string NewPassword
        {
            get { return ((userPasswordControl1 == null) ? null : userPasswordControl1.Password); }
        }

        #endregion

        #region Event Handlers
        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
            return;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            //  check data.
            if (string.IsNullOrEmpty(NewPassword))
            {   
                MessageBox.Show(this
                                , "A password is not input. Please input a password again."
                                , "Exclamation"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Exclamation);

                userPasswordControl1.PasswordConfirm = string.Empty;
                return;
            }

            if (!userPasswordControl1.PasswordAgrees)
            {   
                MessageBox.Show(this
                                , "A password does not accord. Please input a password for confirmation again."
                                , "Exclamation"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Exclamation);

                userPasswordControl1.PasswordConfirm = string.Empty;
                return;
            }

            DialogResult = DialogResult.OK;
            return;
        }

        private void UserPasswordChangeForm_Shown(object sender, EventArgs e)
        {
            Text += "(" + UserName + ")";
        }
        #endregion

    }
}
