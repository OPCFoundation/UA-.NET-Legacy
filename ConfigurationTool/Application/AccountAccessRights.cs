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
using System.Text;
using System.Security.Principal;
using System.Security.AccessControl;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// The objects associated with an application that must be secured.
    /// </summary>
    [Flags]
    public enum SecuredObject
    {
        /// <summary>
        /// The executable file.
        /// </summary>
        ExecutableFile = 0x1,

        /// <summary>
        /// The app.config file.
        /// </summary>
        DotNetAppConfigFile = 0x2,

        /// <summary>
        /// The configuration file.
        /// </summary>
        ConfigurationFile = 0x4,

        /// <summary>
        /// The private key.
        /// </summary>
        PrivateKey = 0x8,

        /// <summary>
        /// The trust list.
        /// </summary>
        TrustList = 0x10,

        /// <summary>
        /// The HTTP endpoint.
        /// </summary>
        HttpEndpoint = 0x20
    }

    /// <summary>
    /// The rights associated with an application that are granted to an account.
    /// </summary>
    public class SecuredObjectAccessRights
    {
        /// <summary>
        /// The account or group.
        /// </summary>
        public IdentityReference Identity;

        /// <summary>
        /// The secured objects that are granted access.
        /// </summary>
        public SecuredObject AllowedObjects;

        /// <summary>
        /// The secured objects that are denied access.
        /// </summary>
        public SecuredObject DeniedObjects;
    }
}
