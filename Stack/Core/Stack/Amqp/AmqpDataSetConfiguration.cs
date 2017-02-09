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
using System.Runtime.Serialization;

namespace Opc.Ua.Bindings
{
    /// <remarks />
    [DataContract(Namespace = Namespaces.OpcUaConfig)]
    public class AmqpConnectionConfiguration
    {
        /// <remarks />
        [DataMember(Order = 1)]
        public string ConnectionName { get; set; }

        /// <remarks />
        [DataMember(Order = 2)]
        public string BrokerUrl { get; set; }

        /// <remarks />
        [DataMember(Order = 3)]
        public string GroupName { get; set; }

        /// <remarks />
        [DataMember(Order = 4)]
        public string TargetName { get; set; }
    }

    /// <remarks />
    [CollectionDataContract(Name = "ListOfAmqpConnectionConfiguration", Namespace = Namespaces.OpcUaConfig, ItemName = "AmqpConnectionConfiguration")]
    public partial class AmqpConnectionConfigurationCollection : List<AmqpConnectionConfiguration>
    {
    }

    /// <remarks />
    [DataContract(Namespace = Namespaces.OpcUaConfig)]
    public class AmqpDataSetConfiguration
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        public AmqpDataSetConfiguration()
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
        /// <remarks />
        [DataMember(Order = 1)]
        public string Name { get; set; }

        /// <remarks />
        [DataMember(Order = 2)]
        public NodeId NotifierId { get; set; }

        /// <remarks />
        [DataMember(Order = 3)]
        public NodeId EventTypeId { get; set; }

        /// <remarks />
        [DataMember(Order = 4)]
        public AmqpConnectionConfigurationCollection Connections { get; set; }
        #endregion
    }

    /// <remarks />
    [CollectionDataContract(Name = "ListOfAmqpDataSetConfiguration", Namespace = Namespaces.OpcUaConfig, ItemName = "AmqpDataSetConfiguration")]
    public partial class AmqpDataSetConfigurationCollection : List<AmqpDataSetConfiguration>
    {
        /// <remarks />
        public static AmqpDataSetConfigurationCollection Load(ApplicationConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException("configuration");
            }

            AmqpDataSetConfigurationCollection brokers = null;

            lock (configuration.PropertiesLock)
            {
                object value = null;

                if (configuration.Properties.TryGetValue("AmqpDataSets", out value))
                {
                    brokers = value as AmqpDataSetConfigurationCollection;
                }

                if (brokers == null)
                {
                    brokers = configuration.ParseExtension<AmqpDataSetConfigurationCollection>();

                    if (brokers == null)
                    {
                        brokers = new AmqpDataSetConfigurationCollection();
                    }

                    configuration.Properties["AmqpBrokers"] = brokers;
                }
            }

            return brokers;
        }
    }
}
