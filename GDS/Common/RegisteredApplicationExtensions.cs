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
using System.Text;

namespace Opc.Ua.Gds
{
    public partial class RegisteredApplication
    {
        [System.Xml.Serialization.XmlIgnore()]
        public string ApplicationId { get; set; }

        /// <summary>
        /// Gets the name of the HTTPS domain for the application.
        /// </summary>
        /// <returns></returns>
        public string GetHttpsDomainName()
        {
            if (this.DiscoveryUrl != null)
            {
                foreach (string disoveryUrl in this.DiscoveryUrl)
                {
                    if (Uri.IsWellFormedUriString(disoveryUrl, UriKind.Absolute))
                    {
                        Uri url = new Uri(disoveryUrl);
                        return url.DnsSafeHost.Replace("localhost", System.Net.Dns.GetHostName());
                    }
                }
            }

            return null;
        }
    }
}
