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
using System.Xml;
using System.IdentityModel.Tokens;

namespace Opc.Ua
{
    public class RoleBasedIdentity : IUserIdentity
    {
        private IUserIdentity m_identity;
        private IList<NodeId> m_roles;

        public RoleBasedIdentity(IUserIdentity identity, IList<NodeId> roles)
        {
            m_identity = identity;
            m_roles = roles;
        }

        public IList<NodeId> Roles
        { 
            get { return m_roles; }
        }

        public string DisplayName
        {
            get { return m_identity.DisplayName; }
        }

        /// <summary>
        /// The user token policy.
        /// </summary>
        /// <value>The user token policy.</value>
        public string PolicyId
        {
            get { return m_identity.PolicyId; }
        }

        public UserTokenType TokenType
        {
            get { return m_identity.TokenType; }
        }

        public XmlQualifiedName IssuedTokenType
        {
            get { return m_identity.IssuedTokenType; }
        }

        public bool SupportsSignatures
        {
            get { return m_identity.SupportsSignatures; }
        }

        public SecurityToken GetSecurityToken()
        {
            return m_identity.GetSecurityToken();
        }

        public UserIdentityToken GetIdentityToken()
        {
            return m_identity.GetIdentityToken();
        }
    }
}
