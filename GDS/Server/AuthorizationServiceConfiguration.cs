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
using Opc.Ua.Server;

namespace Opc.Ua.GdsServer
{
    /// <summary>
    /// Stores the configuration the data access node manager.
    /// </summary>
    [DataContract(Namespace = Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd")]
    public class AuthorizationServiceConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public AuthorizationServiceConfiguration()
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
        public ClientRegistrationCollection Clients { get; set; }

        [DataMember(Order = 2)]
        public ScopeMappingCollection Scopes { get; set; }

        [DataMember(Order = 3)]
        public string DefaultScope { get; set; }
        #endregion

        #region Private Members
        #endregion
    }

    [DataContract(Namespace = Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd")]
    public class ClientRegistration
    {
        [DataMember(Order = 1)]
        public string ClientId;

        [DataMember(Order = 2)]
        public string ClientSecret;

        [DataMember(Order = 3)]
        public string ClientName;
    }

    [CollectionDataContract(Name = "ListOfClientRegistration", Namespace = Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd", ItemName = "ClientRegistration")]
    public partial class ClientRegistrationCollection : List<ClientRegistration>
    {
        /// <summary>
        /// Initializes an empty collection.
        /// </summary>
        public ClientRegistrationCollection() { }

        /// <summary>
        /// Initializes the collection from another collection.
        /// </summary>
        /// <param name="collection">A collection of values to add to this new collection</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="collection"/> is null.
        /// </exception>
        public ClientRegistrationCollection(IEnumerable<ClientRegistration> collection) : base(collection) { }

        /// <summary>
        /// Initializes the collection with the specified capacity.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public ClientRegistrationCollection(int capacity) : base(capacity) { }
    }

    [DataContract(Namespace = Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd")]
    public class ScopeMapping
    {
        [DataMember(Order = 1)]
        public string Scope;

        [DataMember(Order = 2)]
        public StringCollection Clients;

        [DataMember(Order = 3)]
        public StringCollection Users;
    }

    [CollectionDataContract(Name = "ListOfScopeMapping", Namespace = Opc.Ua.Gds.Namespaces.OpcUaGds + "Configuration.xsd", ItemName = "ScopeMapping")]
    public partial class ScopeMappingCollection : List<ScopeMapping>
    {
        /// <summary>
        /// Initializes an empty collection.
        /// </summary>
        public ScopeMappingCollection() { }

        /// <summary>
        /// Initializes the collection from another collection.
        /// </summary>
        /// <param name="collection">A collection of values to add to this new collection</param>
        /// <exception cref="T:System.ArgumentNullException">
        /// 	<paramref name="collection"/> is null.
        /// </exception>
        public ScopeMappingCollection(IEnumerable<ScopeMapping> collection) : base(collection) { }

        /// <summary>
        /// Initializes the collection with the specified capacity.
        /// </summary>
        /// <param name="capacity">The capacity.</param>
        public ScopeMappingCollection(int capacity) : base(capacity) { }
    }
}
