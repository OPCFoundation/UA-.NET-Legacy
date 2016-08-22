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
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Opc.Ua
{
    [DataContract(Namespace = Opc.Ua.Namespaces.OpcUaConfig)]
    public class OAuth2AuthorityConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public OAuth2AuthorityConfiguration()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
        }
        #endregion

        #region Public Properties
        [DataMember(Order = 1)]
        public OAuth2AuthorityCollection KnownAuthorities { get; set; }
        #endregion
    }

    [CollectionDataContract(Name = "ListOfOAuth2Authority", Namespace = Namespaces.OpcUaConfig, ItemName = "OAuth2Authority")]
    public class OAuth2AuthorityCollection : List<OAuth2Authority>
    {
        public OAuth2AuthorityCollection()
        {
        }
    }

    [DataContract(Namespace = Opc.Ua.Namespaces.OpcUaConfig)]
    public enum OAuth2AuthorityType
    {
        [EnumMember()]
        ClientCredentials,

        [EnumMember()]
        AzureAD
    }

    [DataContract(Namespace = Opc.Ua.Namespaces.OpcUaConfig)]
    public class OAuth2Authority
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public OAuth2Authority()
        {
            Initialize();
        }

        /// <summary>
        /// Initializes the object during deserialization.
        /// </summary>
        [OnDeserializing()]
        private void Initialize(StreamingContext context)
        {
            Initialize();
        }

        /// <summary>
        /// Sets private members to default values.
        /// </summary>
        private void Initialize()
        {
        }
        #endregion

        #region Public Properties
        [DataMember(Order = 1)]
        public string AuthorityUrl { get; set; }

        [DataMember(Order = 2)]
        public OAuth2AuthorityType AuthorityType { get; set; }

        [DataMember(Order = 3)]
        public string ClientId { get; set; }

        [DataMember(Order = 4)]
        public string ClientSecret { get; set; }

        [DataMember(Order = 5)]
        public string RedirectUrl { get; set; }
        #endregion
    }
}
