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

namespace Opc.Ua.Gds
{
    using System;
    using System.Collections.Generic;
    
    public partial class Application
    {
        public Application()
        {
            this.ApplicationNames = new HashSet<ApplicationName>();
            this.ServerEndpoints = new HashSet<ServerEndpoint>();
            this.CertificateRequests = new HashSet<CertificateRequest>();
        }
    
        public int ID { get; set; }
        public System.Guid ApplicationId { get; set; }
        public string ApplicationUri { get; set; }
        public string ApplicationName { get; set; }
        public int ApplicationType { get; set; }
        public string ProductUri { get; set; }
        public string ServerCapabilities { get; set; }
        public byte[] Certificate { get; set; }
        public byte[] HttpsCertificate { get; set; }
        public Nullable<int> TrustListId { get; set; }
        public Nullable<int> HttpsTrustListId { get; set; }
    
        public virtual ICollection<ApplicationName> ApplicationNames { get; set; }
        public virtual ICollection<ServerEndpoint> ServerEndpoints { get; set; }
        public virtual CertificateStore HttpsTrustList { get; set; }
        public virtual CertificateStore TrustList { get; set; }
        public virtual ICollection<CertificateRequest> CertificateRequests { get; set; }
    }
}
