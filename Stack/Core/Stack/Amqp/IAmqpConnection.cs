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
    public interface IAmqpConnection
    {
        event EventHandler<AmqpConnectionEventArgs> ConnectionClosed;

        int AddRef();

        int Release();

        void Close();

        Task SendAsync(AmqpServiceMessageSettings settings, ArraySegment<byte> body);

        Task SendAsync(AmqpPubSubMessageSettings settings, ArraySegment<byte> body);

        Task RenewTokenAsync(int expiryTime);

        Task UpdateTokenAsync(string tokenUri, string accessToken);
    }

    public class AmqpConnectionEventArgs
    {
        public AmqpConnectionEventArgs(string amqpNodeName)
        {
            AmqpNodeName = amqpNodeName;
        }

        public string AmqpNodeName { get; private set; }
    }

    public class AmqpServiceMessageSettings
    {
        public string MessageId;
        public string CorrelationId;
        public string TokenUri;
        public string TokenData;
        public string ChannelId;
        public uint SequenceNumber;
    }

    public class AmqpPubSubMessageSettings
    {
        public string MessageId;
        public string ContentType;
        public string PublisherId;
        public string Subject;
        public string DataSetWriterId;
        public uint SequenceNumber;
        public string DataSetClassId;
        public string MetadataNodeName;
    }
}
