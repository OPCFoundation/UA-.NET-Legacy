/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Reciprocal Community Binary License ("RCBL") Version 1.00
 * 
 * Unless explicitly acquired and licensed from Licensor under another 
 * license, the contents of this file are subject to the Reciprocal 
 * Community Binary License ("RCBL") Version 1.00, or subsequent versions 
 * as allowed by the RCBL, and You may not copy or use this file in either 
 * source code or executable form, except in compliance with the terms and 
 * conditions of the RCBL.
 * 
 * All software distributed under the RCBL is provided strictly on an 
 * "AS IS" basis, WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESS OR IMPLIED, 
 * AND LICENSOR HEREBY DISCLAIMS ALL SUCH WARRANTIES, INCLUDING WITHOUT 
 * LIMITATION, ANY WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
 * PURPOSE, QUIET ENJOYMENT, OR NON-INFRINGEMENT. See the RCBL for specific 
 * language governing rights and limitations under the RCBL.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/RCBL/1.00/
 * ======================================================================*/

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
