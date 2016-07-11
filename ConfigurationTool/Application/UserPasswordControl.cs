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
    /// Manage a password.
    /// </summary>
    public partial class UserPasswordControl : UserControl
    {
        #region Constructors
        /// <summary>
        /// Creates an empty control.
        /// </summary>
        public UserPasswordControl()
        {
            InitializeComponent();
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Returns the password.
        /// </summary>
        public string Password
        {
            get { return ((PasswordTextBox == null) ? string.Empty : PasswordTextBox.Text); }
            set
            {
                if (PasswordTextBox == null)
                {
                    return;
                }
                PasswordTextBox.Text = value;
            }
        }

        /// <summary>
        /// Returns the confirm password
        /// </summary>
        public string PasswordConfirm
        {
            get { return ((PasswordConfirmTextBox == null) ? string.Empty : PasswordConfirmTextBox.Text); }
            set
            {
                if (PasswordConfirmTextBox == null)
                {
                    return;
                }
                PasswordConfirmTextBox.Text = value;
            }
        }

        public bool PasswordAgrees { get; private set; }

        #endregion

        #region Event Handlers
        private void PassworConfirm_TextChanged(object sender, EventArgs e)
        {
            #region パラメータチェック

            if (sender == null)
            {
                return;
            }

            if (PasswordTextBox == null
                || PasswordConfirmTextBox == null)
            {
                return;
            }

            if(string.IsNullOrEmpty(PasswordTextBox.Text))
            {   // check a null.
                PasswordConfirmTextBox.BackColor = System.Drawing.Color.LightPink;
                PasswordAgrees = false;
                return;
            }

            if (string.IsNullOrEmpty(PasswordConfirmTextBox.Text))
            {   // check a null.
                PasswordConfirmTextBox.BackColor = System.Drawing.Color.LightPink;
                PasswordAgrees = false;
                return;
            }

            #endregion パラメータチェック

            if (PasswordTextBox.Text == PasswordConfirmTextBox.Text)
            {   // password matches confirm password.
                PasswordConfirmTextBox.BackColor = System.Drawing.Color.Lime;
                PasswordAgrees = true;
            }
            else
            {   //  password unmatched confirm password.
                PasswordConfirmTextBox.BackColor = System.Drawing.Color.LightPink;
                PasswordAgrees = false;
            }
        }
        #endregion メソッド定義
    }
}
