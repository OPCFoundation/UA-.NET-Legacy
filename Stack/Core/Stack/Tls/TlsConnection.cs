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
using System.Net.Sockets;
using System.Net.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Opc.Ua.Bindings
{
    public sealed class TlsConnection : IDisposable
    {
        private bool m_disposed;
        private TcpClient m_client;
        private Stream m_stream;
        private BufferManager m_bufferManager;
        private bool m_writeQueueTaskActive;
        private Queue<ArraySegment<byte>> m_writeQueue = new Queue<ArraySegment<byte>>();

        public TlsConnection(TcpClient client, Stream stream, BufferManager bufferManager)
        {
            if (client == null)
            {
                throw new ArgumentNullException("client");
            }

            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            if (bufferManager == null)
            {
                throw new ArgumentNullException("bufferManager");
            }

            m_client = client;
            m_stream = stream;
            m_bufferManager = bufferManager;
        }

        #region IDisposable Support
        void Dispose(bool disposing)
        {
            if (!m_disposed)
            {
                if (disposing)
                {
                    if (m_stream != null)
                    {
                        m_stream.Close();
                        m_stream = null;
                    }

                    if (m_client != null)
                    {
                        m_client.Close();
                        m_client = null;
                    }
                }

                m_disposed = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
        }
        #endregion

        public object Handle { get; set; }

        public bool FirstMessageReceived
        {
            get; internal set;
        }

        public TcpClient TcpClient
        {
            get { return m_client; }
        }

        public Stream Stream
        {
            get { return m_stream; }
        }

        public void Upgrade(Stream stream)
        {
            m_stream = stream;
        }

        public async Task<ArraySegment<byte>> Receive()
        {
            if (m_disposed)
            {
                throw new ObjectDisposedException("TlsConnection");
            }

            var chunk = m_bufferManager.TakeBuffer(0, "TlsConnection.Receive");

            try
            {
                int bytesRead = await Receive(m_stream, new ArraySegment<byte>(chunk, 0, 8));

                if (bytesRead == 0)
                {
                    throw new EndOfStreamException("Peer closed socket gracefully.");
                }

                if (bytesRead < 8)
                {
                    throw new EndOfStreamException("Message header incomplete.");
                }

                var messageType = BitConverter.ToUInt32(chunk, 0);
                var messageSize = BitConverter.ToInt32(chunk, 4);

                if (messageSize > chunk.Length)
                {
                    throw new EndOfStreamException(String.Format("Message size of {0} bytes too large.", messageSize));
                }

                int bodySize = messageSize - 8;

                if (bodySize > 0)
                {
                    bytesRead = await Receive(m_stream, new ArraySegment<byte>(chunk, 8, bodySize));

                    if (bytesRead == 0)
                    {
                        throw new EndOfStreamException("Peer closed socket gracefully.");
                    }

                    if (bytesRead < bodySize)
                    {
                        throw new EndOfStreamException("Message body incomplete.");
                    }
                }

                return new ArraySegment<byte>(chunk, 0, messageSize);
            }
            catch (Exception)
            {
                m_bufferManager.ReturnBuffer(chunk, "TlsConnection.Receive");
                throw;
            }
        }

        private async Task<int> Receive(Stream istrm, ArraySegment<byte> buffer)
        {
            int bytesRead = 0;
            int start = buffer.Offset;

            do
            {
                int nextBlock = await istrm.ReadAsync(buffer.Array, start, buffer.Count - bytesRead);

                if (nextBlock == 0)
                {
                    break;
                }

                bytesRead += nextBlock;
                start += nextBlock;
            }
            while (bytesRead < buffer.Count);

            return bytesRead;
        }

        public void Enqueue(IList<ArraySegment<byte>> buffers)
        {
            if (m_disposed)
            {
                throw new ObjectDisposedException("TlsConnection");
            }

            lock (m_writeQueue)
            {
                foreach (var buffer in buffers)
                {
                    m_writeQueue.Enqueue(buffer);

                    if (!m_writeQueueTaskActive)
                    {
                        m_writeQueueTaskActive = true;
                        Task.Run(() => Dequeue());
                    }
                }
            }

            Task.Run(() => Dequeue());
        }
    
        public void Enqueue(ArraySegment<byte> buffer)
        {
            if (m_disposed)
            {
                throw new ObjectDisposedException("TlsConnection");
            }

            lock (m_writeQueue)
            {
                m_writeQueue.Enqueue(buffer);

                if (!m_writeQueueTaskActive)
                {
                    m_writeQueueTaskActive = true;
                    Task.Run(() => Dequeue());
                }
            }
        }

        private async void Dequeue()
        {
            var stream = m_stream;

            do
            {
                ArraySegment <byte> message;

                lock (m_writeQueue)
                {
                    if (m_writeQueue.Count == 0)
                    {
                        m_writeQueueTaskActive = false;
                        break;
                    }

                    message = m_writeQueue.Dequeue();
                }

                try
                {
                    await stream.WriteAsync(message.Array, message.Offset, message.Count);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "TlsConnection.Dequeue: WriteAsync failed.");
                }
                finally
                {
                    m_bufferManager.ReturnBuffer(message.Array, "TlsConnection.Dequeue");
                }
            }
            while (true);

            try
            {
                await stream.FlushAsync();
            }
            catch (Exception e)
            {
                Utils.Trace(e, "TlsConnection.Dequeue: FlushAsync failed.");
            }
        }
    }
}
