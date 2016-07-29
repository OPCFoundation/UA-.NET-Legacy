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
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Create a new user.
    /// </summary>
    public partial class UserAddControl : UserControl
    {
        #region Constructors
        /// <summary>
        /// Creates an empty control.
        /// </summary>
        public UserAddControl()
            : this(null)
        { 
        }

        /// <summary>
        /// Creates a control with owner as input.
        /// </summary>
        public UserAddControl(Form owner)
        {
            InitializeComponent();

            Owner = owner;
            if (Owner != null)
            {
                Owner.DialogResult = DialogResult.Cancel;
            }
        }
        #endregion

        #region Public Properties

        /// <summary>
        /// Returns the owner Form.
        /// </summary>
        public Form Owner { get; set; }

        /// <summary>
        /// Returns the user name.
        /// </summary>
        public string UserName
        {
            get { return ((userNameControl1 == null) ? null : userNameControl1.UserName); }
        }

        /// <summary>
        /// Returns the password.
        /// </summary>
        public string Password
        {
            get { return ((userPasswordControl1 == null) ? null : userPasswordControl1.Password); }
        }

        #endregion

        #region Event Handlers
        private void CreateButton_Click(object sender, EventArgs e)
        {
            // check date.
            if (string.IsNullOrEmpty(UserName))
            {   
                MessageBox.Show(this
                                , "A user name is not input. Please input a user name again."
                                , "Exclamation"
                                , MessageBoxButtons.OK
                                , MessageBoxIcon.Exclamation);
                return;
            }

            if (string.IsNullOrEmpty(Password))
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

            // closer a From.
            if (Owner != null)
            {
                Owner.DialogResult = DialogResult.OK;
                Owner.Close();
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            if (Owner == null)
            {
                return;
            }

            Owner.DialogResult = DialogResult.Cancel;
            Owner.Close();

            return;
        }
        #endregion
    }
}
