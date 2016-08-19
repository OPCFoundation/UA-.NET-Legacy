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
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Security;
using System.Text;

namespace Opc.Ua.Bindings
{    
    /// <summary>
    /// A class that publishes the secuirty capabilities for a binding element.
    /// </summary>
    public class SecurityCapabilities : ISecurityCapabilities
    {
        #region ISecurityCapabilities Members
        /// <summary cref="ISecurityCapabilities.SupportedRequestProtectionLevel" />
        public System.Net.Security.ProtectionLevel SupportedRequestProtectionLevel
        {
            get { return System.Net.Security.ProtectionLevel.EncryptAndSign; }
        }

        /// <summary cref="ISecurityCapabilities.SupportedResponseProtectionLevel" />
        public System.Net.Security.ProtectionLevel SupportedResponseProtectionLevel
        {
            get { return System.Net.Security.ProtectionLevel.EncryptAndSign; }
        }

        /// <summary cref="ISecurityCapabilities.SupportsClientAuthentication" />
        public bool SupportsClientAuthentication
        {
            get { return false; }
        }

        /// <summary cref="ISecurityCapabilities.SupportsClientWindowsIdentity" />
        public bool SupportsClientWindowsIdentity
        {
            get { return false; }
        }

        /// <summary cref="ISecurityCapabilities.SupportsServerAuthentication" />
        public bool SupportsServerAuthentication
        {
            get { return false; }
        }
        #endregion
    }
}
