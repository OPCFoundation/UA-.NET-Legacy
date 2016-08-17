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
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.IdentityModel.Tokens;
using Opc.Ua;

namespace Opc.Ua.Gds
{
    /// <summary>
    /// Prompts the user to select an area to use as an event filter.
    /// </summary>
    public partial class UserIdentityDialog : Form
    {
        #region Constructors
        /// <summary>
        /// Creates an empty form.
        /// </summary>
        public UserIdentityDialog()
        {
            InitializeComponent();
        }
        #endregion

        #region Private Fields
        #endregion

        #region Public Interface
        public UserIdentity ShowDialog(IWin32Window owner, string caption, UserIdentity identity)
        {
            if (!String.IsNullOrEmpty(caption))
            {
                InstructuctionsLabel.Text = caption;
                InstructuctionsLabel.Visible = true;
            }

            UserNameTextBox.Text = null;
            PasswordTextBox.Text = null;

            if (identity != null)
            {
                UserNameIdentityToken token = identity.GetIdentityToken() as UserNameIdentityToken;

                if (token != null)
                {
                    UserNameTextBox.Text = token.UserName;
                    PasswordTextBox.Text = token.DecryptedPassword;
                }
            }

            if (base.ShowDialog(owner) != DialogResult.OK)
            {
                return null;
            }

            return new UserIdentity(UserNameTextBox.Text.Trim(), PasswordTextBox.Text.Trim());
        }
        #endregion

        #region Private Methods
        #endregion

        #region Event Handlers
        private void OkButton_Click(object sender, EventArgs e)
        {
            try
            {
                string username = UserNameTextBox.Text.Trim();

                if (String.IsNullOrEmpty(username))
                {
                    throw new ArgumentException("UserName must not be empty.", "UserName");
                }

                DialogResult = DialogResult.OK;
            }
            catch (Exception exception)
            {
                Opc.Ua.Configuration.ExceptionDlg.Show(this.Text, exception);
            }
        }
        #endregion
    }
}
