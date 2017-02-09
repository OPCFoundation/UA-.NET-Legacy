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
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Amqp;
using Amqp.Framing;
using Amqp.Types;

namespace Opc.Ua.Bindings
{
    /// <remarks />
    public interface IAmqpConnection
    {
        /// <remarks />
        event EventHandler<AmqpConnectionEventArgs> ConnectionClosed;

        /// <remarks />
        int AddRef();

        /// <remarks />
        int Release();

        /// <remarks />
        void Close();

        /// <remarks />
        Task SendAsync(AmqpServiceMessageSettings settings, ArraySegment<byte> body);

        /// <remarks />
        Task SendAsync(AmqpPubSubMessageSettings settings, ArraySegment<byte> body);

        /// <remarks />
        Task RenewTokenAsync(int expiryTime);

        /// <remarks />
        Task UpdateTokenAsync(string tokenUri, string accessToken);
    }

    /// <remarks />
    public class AmqpConnectionEventArgs
    {
        /// <remarks />
        public AmqpConnectionEventArgs(string amqpNodeName)
        {
            AmqpNodeName = amqpNodeName;
        }

        /// <remarks />
        public string AmqpNodeName { get; private set; }
    }

    /// <remarks />
    public class AmqpServiceMessageSettings
    {
        /// <remarks />
        public string MessageId;
        /// <remarks />
        public string CorrelationId;
        /// <remarks />
        public string TokenUri;
        /// <remarks />
        public string TokenData;
        /// <remarks />
        public string ChannelId;
        /// <remarks />
        public uint SequenceNumber;
    }

    /// <remarks />
    public class AmqpPubSubMessageSettings
    {
        /// <remarks />
        public string MessageId;
        /// <remarks />
        public string ContentType;
        /// <remarks />
        public string PublisherId;
        /// <remarks />
        public string Subject;
        /// <remarks />
        public string DataSetWriterId;
        /// <remarks />
        public uint SequenceNumber;
        /// <remarks />
        public string DataSetClassId;
        /// <remarks />
        public string MetadataNodeName;
    }
}
