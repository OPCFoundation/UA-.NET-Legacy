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
using System.IO;
using System.Threading;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Amqp;
using Amqp.Framing;
using Amqp.Types;

namespace Opc.Ua.Bindings
{
    public class MessageChunkCache
    {
        private long m_messageExpiryTime;
        private Dictionary<string, MessageBody> m_messages;
        private Timer m_cleanupTimer;
        
        private void OnCleanupTimerExpired(object state)
        {
            try
            {
                List<string> messagesToDelete = new List<string>();

                long cutoff = TimeUtils.GetTickCount() + m_messageExpiryTime;

                lock (m_messages)
                {
                    foreach (var ii in m_messages)
                    {
                        if (cutoff > ii.Value.CreationTime)
                        {
                            messagesToDelete.Add(ii.Key);
                        }
                    }
                }

                foreach (var ii in messagesToDelete)
                {
                    m_messages.Remove(ii);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("Unexpected error deleting messages: " + e.Message);
            }
        }

        public MessageChunkCache()
        {
            m_messages = new Dictionary<string, MessageBody>();
            m_messageExpiryTime = 60000 * 5;
            m_cleanupTimer = new Timer(OnCleanupTimerExpired, null, m_messageExpiryTime, m_messageExpiryTime / 2);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (m_cleanupTimer != null)
                {
                    m_cleanupTimer.Dispose();
                    m_cleanupTimer = null;
                }

                lock (m_messages)
                {
                    m_messages.Clear();
                }
            }
        }

        public MemoryStream Process(string sourceName, Stream input)
        {
            MessageChunk chunk = new MessageChunk();
            chunk.Decode(input);

            if (chunk.ChunkId == 0)
            {
                return new MemoryStream(chunk.Buffer.Array, chunk.Buffer.Offset, chunk.Buffer.Count, false);
            }

            MessageBody body = null;

            lock (m_messages)
            {
                var key = sourceName + chunk.MessageId.ToString();

                if (!m_messages.TryGetValue(key, out body))
                {
                    body = new MessageBody()
                    {
                        MessageId = chunk.MessageId,
                        CreationTime = System.Environment.TickCount
                    };

                    m_messages.Add(key, body);
                }

                body.Append(chunk);

                for (int ii = 1; ii <= body.Chunks.Count; ii++)
                {
                    if (ii != body.Chunks[ii-1].ChunkId)
                    {
                        return null;
                    }
                }

                if (!body.Chunks[body.Chunks.Count - 1].IsFinalChunk)
                {
                    return null;
                }

                MemoryStream output = new MemoryStream();

                for (int ii = 0; ii < body.Chunks.Count; ii++)
                {
                    var buffer = body.Chunks[ii].Buffer;
                    output.Write(buffer.Array, buffer.Offset, buffer.Count);
                }
            
                output.Position = 0;

                m_messages.Remove(key);

                return output;
            }
        }
    }

    public class MessageBody
    {
        public uint MessageId;
        public long CreationTime;
        public List<MessageChunk> Chunks;

        public void Encode(ArraySegment<byte> message, uint messageId, int maxChunkSize)
        {
            MessageId = messageId;
            CreationTime = System.Environment.TickCount;
            Chunks = new List<MessageChunk>();

            if (message == null || message.Count < maxChunkSize)
            {
                Chunks.Add(new MessageChunk() { MessageId = MessageId, ChunkId = 0, IsFinalChunk = true, Buffer = message });
                return;
            }

            for (int ii = 0; ii < message.Count; ii += maxChunkSize)
            {
                if (message.Count < ii + maxChunkSize)
                {
                    Chunks.Add(new MessageChunk() { MessageId = MessageId, ChunkId = Chunks.Count + 1, IsFinalChunk = true, Buffer = message });
                    return;
                }

                Chunks.Add(new MessageChunk() { MessageId = MessageId, ChunkId = Chunks.Count + 1, Buffer = message });
            }

            Chunks[Chunks.Count - 1].IsFinalChunk = true;
        }

        public void Encode(Stream istrm, uint messageId, int maxChunkSize)
        {
            MessageId = messageId;
            CreationTime = System.Environment.TickCount;
            Chunks = new List<MessageChunk>();

            byte[] buffer = new byte[maxChunkSize];

            int result = istrm.Read(buffer, 0, maxChunkSize);

            if (result < maxChunkSize)
            {
                Chunks.Add(new MessageChunk() { MessageId = MessageId, ChunkId = 0, IsFinalChunk = true, Buffer = new ArraySegment<byte>(buffer, 0, result) });
                return;
            }

            while (result > 0)
            {
                Chunks.Add(new MessageChunk() { MessageId = MessageId, ChunkId = Chunks.Count + 1, Buffer = new ArraySegment<byte>(buffer, 0, result) });

                if (result < maxChunkSize)
                {
                    break;
                }

                buffer = new byte[maxChunkSize];
                result = istrm.Read(buffer, 0, maxChunkSize);
            }

            Chunks[Chunks.Count - 1].IsFinalChunk = true;
        }

        public void Append(MessageChunk chunk)
        {
            if (Chunks == null)
            {
                Chunks = new List<MessageChunk>();
            }

            for (int ii = 0; ii < Chunks.Count; ii++)
            {
                if (Chunks[ii].ChunkId > chunk.ChunkId)
                {
                    Chunks.Insert(ii, chunk);
                    return;
                }
            }

            Chunks.Add(chunk);
        }
    }

    public class MessageChunk
    {
        public uint MessageId;
        public int ChunkId;
        public bool IsFinalChunk;
        public ArraySegment<byte> Buffer;
        
        public MessageChunk()
        {
        }

        public void Encode(MemoryStream ostrm)
        {
            var bits = BitConverter.GetBytes(MessageId);
            ostrm.Write(bits, 0, bits.Length);

            int chunkId = ChunkId;

            if (IsFinalChunk)
            {
                chunkId = -chunkId;
            }

            bits = BitConverter.GetBytes(chunkId);
            ostrm.Write(bits, 0, bits.Length);

            ostrm.Write(Buffer.Array, Buffer.Offset, Buffer.Count);
        }

        public byte[] Encode()
        {
            int length = 8 + Buffer.Count;

            byte[] buffer = new byte[length];

            var bits = BitConverter.GetBytes(MessageId);
            Array.Copy(bits, 0, buffer, 0, bits.Length);

            int chunkId = ChunkId;

            if (IsFinalChunk)
            {
                chunkId = -chunkId;
            }

            bits = BitConverter.GetBytes(chunkId);
            Array.Copy(bits, 0, buffer, 4, bits.Length);
            Array.Copy(Buffer.Array, Buffer.Offset, buffer, 20, Buffer.Count);

            return buffer;
        }

        public void Decode(Stream istrm)
        {
            MessageId = 0;
            ChunkId = 0;
            IsFinalChunk = false;

            byte[] buffer = new byte[4096];

            if (istrm.Read(buffer, 0, 4) == 0)
            {
                return;
            }

            MessageId = BitConverter.ToUInt32(buffer, 0);

            if (istrm.Read(buffer, 0, 4) == 0)
            {
                return;
            }

            ChunkId = BitConverter.ToInt32(buffer, 0);

            if (ChunkId <= 0)
            {
                ChunkId = -ChunkId;
                IsFinalChunk = true;
            }

            MemoryStream ostrm = new MemoryStream();

            for (int ii = 0; ii >= 0; ii += 4096)
            {
                int result = istrm.Read(buffer, 0, 4096);

                if (result == 0)
                {
                    break;
                }

                ostrm.Write(buffer, 0, result);
            }

            ostrm.Close();

            Buffer = new ArraySegment<byte>(ostrm.ToArray());
        }

        public void Decode(byte[] buffer)
        {
            MessageId = 0;
            ChunkId = 0;
            IsFinalChunk = false;

            if (buffer.Length < 8)
            {
                return;
            }

            MessageId = BitConverter.ToUInt32(buffer, 0);
            ChunkId = BitConverter.ToInt32(buffer, 4);

            if (ChunkId < 0)
            {
                ChunkId = -ChunkId;
                IsFinalChunk = true;
            }

            Buffer = new ArraySegment<byte>(buffer, 8, buffer.Length - 8);
        }
    }
}
