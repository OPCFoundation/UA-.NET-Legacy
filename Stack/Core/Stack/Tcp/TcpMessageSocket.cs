/* Copyright (c) 1996-2017, OPC Foundation. All rights reserved.

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
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// An interface to an object that received messages from the socket.
    /// </summary>
    public interface IMessageSink
    {
        /// <summary>
        /// Called when a new message arrives.
        /// </summary>
        void OnMessageReceived(TcpMessageSocket source, ArraySegment<byte> message);

        /// <summary>
        /// Called when an error occurs during a read.
        /// </summary>
        void OnReceiveError(TcpMessageSocket source, ServiceResult result);
    }

    /// <summary>
    /// Handles reading and writing of message chunks over a socket.
    /// </summary>
    public class TcpMessageSocket : IDisposable
    {
        #region Constructors
        /// <summary>
        /// Creates an unconnected socket.
        /// </summary>
        public TcpMessageSocket(
            IMessageSink  sink, 
            BufferManager bufferManager, 
            int           receiveBufferSize)
        {
            if (bufferManager == null) throw new ArgumentNullException("bufferManager");
            
            m_sink = sink;
            m_socket = null;
            m_bufferManager = bufferManager;
            m_receiveBufferSize = receiveBufferSize;
            m_incomingMessageSize = -1;
            m_ReadComplete = new AsyncCallback(OnReadComplete);
            m_writeQueue = new LinkedList<WriteOperation>();
            m_readQueue = new LinkedList<ArraySegment<byte>>();
        }

        /// <summary>
        /// Attaches the object to an existing socket.
        /// </summary>
        public TcpMessageSocket(
            IMessageSink  sink, 
            Socket        socket, 
            BufferManager bufferManager, 
            int           receiveBufferSize)
        {
            if (socket == null) throw new ArgumentNullException("socket");
            if (bufferManager == null) throw new ArgumentNullException("bufferManager");
            
            m_sink = sink;
            m_socket = socket;
            m_bufferManager = bufferManager;
            m_receiveBufferSize = receiveBufferSize;
            m_incomingMessageSize = -1;
            m_ReadComplete = new AsyncCallback(OnReadComplete);
            m_writeQueue = new LinkedList<WriteOperation>();
            m_readQueue = new LinkedList<ArraySegment<byte>>();
        }
        #endregion
        
        #region IDisposable Members
        /// <summary>
        /// Frees any unmanaged resources.
        /// </summary>
        public void Dispose()
        {   
            Dispose(true);
        }

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing) 
            {
                m_socket.Close();
            }
        }
        #endregion

        #region Connect/Disconnect Handling
        /// <summary>
        /// Gets the socket handle.
        /// </summary>
        /// <value>The socket handle.</value>
        public int Handle
        {
            get
            {
                if (m_socket != null)
                {
                    return m_socket.Handle.ToInt32();
                }

                return -1;
            }
        }

        /// <summary>
        /// Connects to an endpoint.
        /// </summary>
        public IAsyncResult BeginConnect(Uri endpointUrl, AsyncCallback callback, object state)
        {
            if (endpointUrl == null) throw new ArgumentNullException("endpointUrl");

            lock (m_socketLock)
            {
                if (m_socket != null)
                {
                    throw new InvalidOperationException("The socket is already connected.");
                }

                bool ipV6Required = false;

                // need to check if an IP address was provided.
                IPAddress address = null;

                if (IPAddress.TryParse(endpointUrl.DnsSafeHost, out address))
                {
                    ipV6Required = address.AddressFamily == AddressFamily.InterNetworkV6;
                }

                IPAddress[] addresses = null;

                // need to check if any IPv4 addresses are available for the server.
                if (address == null)
                {
                    addresses = Dns.GetHostAddresses(endpointUrl.DnsSafeHost);

                    if (!ipV6Required)
                    {
                        ipV6Required = true;

                        for (int ii = 0; ii < addresses.Length; ii++)
                        {
                            if (addresses[ii].AddressFamily == AddressFamily.InterNetwork)
                            {
                                ipV6Required = false;
                                break;
                            }
                        }
                    }
                }

                // need to check if IPv4 is enabled locally.
                if (!ipV6Required)
                {
                    IPAddress[] localAddresses = Dns.GetHostAddresses(Dns.GetHostName());
                    ipV6Required = false;

                    // look for an IPv6 address.
                    for (int ii = 0; ii < localAddresses.Length; ii++)
                    {
                        if (localAddresses[ii].AddressFamily == AddressFamily.InterNetworkV6)
                        {
                            ipV6Required = true;
                            break;
                        }
                    }

                    // check if an IPv4 address exists.
                    if (ipV6Required)
                    {
                        for (int ii = 0; ii < localAddresses.Length; ii++)
                        {
                            if (localAddresses[ii].AddressFamily == AddressFamily.InterNetwork && !IPAddress.IsLoopback(localAddresses[ii]))
                            {
                                ipV6Required = false;
                                break;
                            }
                        }
                    }
                }

                // create the correct type of socket.
                if (ipV6Required)
                {
                    m_socket = new Socket(AddressFamily.InterNetworkV6, SocketType.Stream, ProtocolType.IP);
                }
                else
                {
                    m_socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
                }

                // ensure a valid port.
                int port = endpointUrl.Port;

                if (port <= 0 || port > UInt16.MaxValue)
                {
                    port = Utils.UaTcpDefaultPort;
                }

                // connect to the server.
                if (address != null)
                {
                    return m_socket.BeginConnect(address, port, callback, state);
                }

                return m_socket.BeginConnect(addresses, port, callback, state);
            }
        }
        
        /// <summary>
        /// Called to complete an asynchronous connect operation.
        /// </summary>
        public void EndConnect(IAsyncResult result)
        {
            lock (m_socketLock)
            {
                if (m_socket == null)
                {
                    throw new InvalidOperationException("Socket has been closed.");
                }           
                
                m_socket.EndConnect(result);         
            }
        }

        /// <summary>
        /// Disconnects from an endpoint.
        /// </summary>
        public IAsyncResult BeginDisconnect(AsyncCallback callback, object state)
        {
            lock (m_socketLock)
            {
                if (m_socket == null)
                {
                    throw new InvalidOperationException("The socket is already disconnected.");
                }    

                m_socket.Shutdown(SocketShutdown.Both);  
                return m_socket.BeginDisconnect(false, callback, state);              
            }
        }
        
        /// <summary>
        /// Called to complete an asynchronous disconnect operation.
        /// </summary>
        public void EndDisconnect(IAsyncResult result)
        {
            Socket socket = null;

            lock (m_socketLock)
            {
                if (m_socket == null)
                {
                    throw new InvalidOperationException("Socket has been closed.");
                }  

                socket = m_socket;
            }
                
            socket.EndDisconnect(result);

            lock (m_socketLock)
            {
                // cancel the I/O operations.
                CancelOperations();
            }
        }

        /// <summary>
        /// Forcefully closes the socket.
        /// </summary>
        public void Close()
        {
            // get the socket.
            Socket socket = null;

            lock (m_socketLock)
            {   
                socket = m_socket;
                m_socket = null;
            }
            
            // shutdown the socket.
            if (socket != null)
            {
                try
                {
                    if (socket.Connected)
                    {
                        socket.Shutdown(SocketShutdown.Both);
                    }
                    
                    socket.Close();
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error closing socket.");
                }
            }

            // cancel the I/O operations.
            CancelOperations();
        }

        /// <summary>
        /// Cancels all outstanding I/O operations.
        /// </summary>
        private void CancelOperations()
        {            
            // cancel any outstanding write operations.
            WriteOperation operation = null;

            do
            {
                operation = null;

                lock (m_writeQueue)
                {
                    if (m_writeQueue.Count > 0)
                    {
                        operation = m_writeQueue.First.Value;
                        m_writeQueue.RemoveFirst();
                    }
                }

                if (operation != null)
                {
                    operation.Fault(StatusCodes.BadConnectionClosed);
                }
            }
            while (operation != null);
            
            // cancel any outstanding read operations.
            byte[] buffer = null;

            do
            {
                buffer = null;

                lock (m_readQueue)
                {
                    if (m_readQueue.Count > 0)
                    {
                        buffer = m_readQueue.First.Value.Array;
                        m_readQueue.RemoveFirst();
                        
                        // check for graceful shutdown.
                        if (buffer != null)
                        {
                            BufferManager.UnlockBuffer(buffer);
                        
                            #if TRACK_MEMORY
                            int cookie = BitConverter.ToInt32(buffer, 0);

                            if (cookie < 0)
                            {
                                Utils.Trace("BufferCookieError (CancelOperations): Cookie={0:X8}", cookie);
                            }
                            #endif
                        }
                    }
                }

                if (buffer != null)
                {
                    m_bufferManager.ReturnBuffer(buffer, "CancelOperations");
                }
            }
            while (buffer != null);
        }
        #endregion
        
        #region Read Handling
        /// <summary>
        /// Starts reading messages from the socket.
        /// </summary>
        public void ReadNextMessage()
        {
            lock (m_readLock)
            {              
                // allocate a buffer large enough to a message chunk.
                if (m_receiveBuffer == null)
                {
                    m_receiveBuffer = m_bufferManager.TakeBuffer(m_receiveBufferSize, "ReadNextMessage");
                }
                
                // read the first 8 bytes of the message which contains the message size.          
                m_bytesReceived = 0;
                m_bytesToReceive = TcpMessageLimits.MessageTypeAndSize;
                m_incomingMessageSize = -1;

                ReadNextBlock();
            }
        }

        /// <summary>
        /// Changes the sink used to report reads.
        /// </summary>
        public void ChangeSink(IMessageSink sink)
        {
            lock (m_readLock)
            {
                m_sink = sink;
            }
        }

        /// <summary>
        /// Handles a read complete event.
        /// </summary>
        private void OnReadComplete(IAsyncResult result)
        {
            lock (m_readLock)
            {
                ServiceResult error = null;

                try
                {
                    error = DoReadComplete(result);
                }
                catch (Exception e)
                {                    
                    Utils.Trace(e, "Unexpected error during OnReadComplete,");
                    error = ServiceResult.Create(e, StatusCodes.BadTcpInternalError, e.Message);
                }

                if (ServiceResult.IsBad(error))
                {                
                    if (m_receiveBuffer != null)
                    {
                        m_bufferManager.ReturnBuffer(m_receiveBuffer, "OnReadComplete");
                        m_receiveBuffer = null;
                    }

                    if (m_sink != null)
                    {
                        m_sink.OnReceiveError(this, error);
                    }
                }
            }
        }

        /// <summary>
        /// Handles a read complete event.
        /// </summary>
        private ServiceResult DoReadComplete(IAsyncResult result)
        {
            // complete operation.
            int bytesRead = 0; 
            
            lock (m_socketLock)
            {
                try
                {
                    if (m_socket != null)
                    {
                        bytesRead = m_socket.EndReceive(result);
                        // Utils.Trace("EndReceive {0} bytes", bytesRead);
                    }

                    #if TRACK_MEMORY
                    int cookie = BitConverter.ToInt32(m_receiveBuffer, 0);

                    if (cookie < 0)
                    {
                        Utils.Trace("BufferCookieError (EndReceive): Cookie={0:X8}", cookie);
                    }
                    #endif
                }
                finally
                {
                    BufferManager.UnlockBuffer(m_receiveBuffer);
                }
            }

            if (bytesRead == 0)
            {
                // free the empty receive buffer.
                if (m_receiveBuffer != null)
                {
                    m_bufferManager.ReturnBuffer(m_receiveBuffer, "DoReadComplete");
                    m_receiveBuffer = null;
                }

                // put a null buffer to ensure that all queued messages are processed before close.
                lock (m_readQueue)
                {   
                    m_readQueue.AddLast(new ArraySegment<byte>());

                    if (m_readQueue.Count == 1 && !m_readThreadActive)
                    {
                        ThreadPool.QueueUserWorkItem(ReadQueuedMessages, null);
                    }
                }
                    
                return ServiceResult.Good;
            }

            // Utils.Trace("Bytes read: {0}", bytesRead);

            m_bytesReceived += bytesRead;

            // check if more data left to read.
            if (m_bytesReceived < m_bytesToReceive)
            {
                ReadNextBlock();
                
                #if TRACK_MEMORY
                int cookie = BitConverter.ToInt32(m_receiveBuffer, 0);

                if (cookie < 0)
                {
                    Utils.Trace("BufferCookieError (ReadNextBlock): Cookie={0:X8}", cookie);
                }
                #endif

                return ServiceResult.Good;
            }

            // start reading the message body.
            if (m_incomingMessageSize < 0)
            {
                m_incomingMessageSize = BitConverter.ToInt32(m_receiveBuffer, 4);

                if (m_incomingMessageSize <= 0 || m_incomingMessageSize > m_receiveBufferSize)
                {
                    Utils.Trace(
                        "BadTcpMessageTooLarge: BufferSize={0}; MessageSize={1}", 
                        m_receiveBufferSize, 
                        m_incomingMessageSize);

                    return ServiceResult.Create(
                        StatusCodes.BadTcpMessageTooLarge, 
                        "Messages size {1} bytes is too large for buffer of size {0}.", 
                        m_receiveBufferSize,
                        m_incomingMessageSize);
                }

                // set up buffer for reading the message body.
                m_bytesToReceive = m_incomingMessageSize;
                
                ReadNextBlock();
                return ServiceResult.Good;
            }                    
            
            // add message to queue.
            ArraySegment<byte> messageChunk = new ArraySegment<byte>(m_receiveBuffer, 0, m_incomingMessageSize);
            
            // must allocate a new buffer for the next message.
            m_receiveBuffer = null;

            lock (m_readQueue)
            {   
                #if TRACK_MEMORY
                int cookie = BitConverter.ToInt32(messageChunk.Array, 0);

                if (cookie < 0)
                {
                    Utils.Trace("BufferCookieError (DoReadComplete): Cookie={0:X8}", cookie);
                }
                #endif

                BufferManager.LockBuffer(messageChunk.Array);
                m_readQueue.AddLast(messageChunk);

                if (m_readQueue.Count == 1 && !m_readThreadActive)
                {
                    ThreadPool.QueueUserWorkItem(ReadQueuedMessages, null);
                }
            }
                        
            // start receiving next message.
            ReadNextMessage();
            return ServiceResult.Good;
        }

        /// <summary>
        /// Reads the next block of data from the socket.
        /// </summary>
        private void ReadNextBlock()
        {      
            Socket socket = null;

            // check if already closed.
            lock (m_socketLock)
            {
                if (m_socket == null)
                {
                    if (m_receiveBuffer != null)
                    {
                        m_bufferManager.ReturnBuffer(m_receiveBuffer, "ReadNextBlock");
                        m_receiveBuffer = null;
                    }

                    return;
                }

                socket = m_socket;
            }

            BufferManager.LockBuffer(m_receiveBuffer);

            try
            {
                socket.BeginReceive(
                    m_receiveBuffer,
                    m_bytesReceived,
                    m_bytesToReceive - m_bytesReceived,
                    SocketFlags.None,
                    m_ReadComplete,
                    null);
            }
            catch (Exception e)
            {
                BufferManager.UnlockBuffer(m_receiveBuffer);
                throw ServiceResultException.Create(StatusCodes.BadTcpInternalError, e, "BeginReceive failed.");
            }
        }

        /// <summary>
        /// Removes the next message from the queue.
        /// </summary>
        private bool GetNextMessage(out ArraySegment<byte> messageChunk)
        {      
            lock (m_readQueue)
            {   
                // check if queue has been cleared.
                if (m_readQueue.Count == 0)
                {
                    messageChunk = new ArraySegment<byte>();
                    m_readThreadActive = false;
                    return false;
                }

                messageChunk = m_readQueue.First.Value;
                m_readQueue.RemoveFirst();             
   
                // return message.
                if (messageChunk.Array != null)
                {
                    BufferManager.UnlockBuffer(messageChunk.Array);
                    m_readThreadActive = true;
                    
                    #if TRACK_MEMORY
                    int cookie = BitConverter.ToInt32(messageChunk.Array, 0);

                    if (cookie < 0)
                    {
                        Utils.Trace("BufferCookieError (ReadQueuedMessages1): Cookie={0:X8}", cookie);
                    }
                    #endif

                    return true;
                }

                m_readThreadActive = false;
            }

            // handle graceful shutdown.
            if (m_sink != null)
            {
                try
                {
                    m_sink.OnReceiveError(this, StatusCodes.BadSecureChannelClosed);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error invoking OnReceiveError callback.");
                }
            }          
       
            return false;
        }

        /// <summary>
        /// Reads the messages in the queue.
        /// </summary>
        private void ReadQueuedMessages(object state)
        {
            // get first message in the queue.
            ArraySegment<byte> messageChunk;

            if (!GetNextMessage(out messageChunk))
            {
                return;
            }

            // keep processing messages until the queue is empty.
            while (messageChunk.Array != null)
            {
                // get the read sink.
                IMessageSink sink = null;

                lock (m_readLock)
                {
                    sink = m_sink;
                }

                // notify the sink.
                if (sink != null)
                {                
                    try
                    {
                        // send notification (implementor responsible for freeing buffer) on success.
                        m_sink.OnMessageReceived(this, messageChunk);
                        messageChunk = new ArraySegment<byte>();
                    }
                    catch (Exception e)
                    {
                        Utils.Trace(e, "Unexpected error invoking OnMessageReceived callback.");
                    }
                }
                
                // free the buffer if not already freed.
                if (messageChunk.Array != null)
                {                        
                    m_bufferManager.ReturnBuffer(messageChunk.Array, "ReadQueuedMessages");
                }
                
                // get next chunk.
                if (!GetNextMessage(out messageChunk))
                {
                    break;
                }
            }
        }
        #endregion
        
        #region Write Handling
        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary>
        public IAsyncResult BeginWriteMessage(ArraySegment<byte> buffer, int timeout, AsyncCallback callback, object state)
        {
            BufferCollection chunksToSend = new BufferCollection();
            chunksToSend.Add(buffer);
            return BeginWriteMessage(chunksToSend, timeout, callback, state);
        }
        
        /// <summary>
        /// Begins an asynchronous write operation.
        /// </summary>
        public IAsyncResult BeginWriteMessage(BufferCollection buffers, int timeout, AsyncCallback callback, object state)
        {
            lock (m_socketLock)
            {
                if (m_socket == null)
                {
                    throw new ServiceResultException(StatusCodes.BadConnectionClosed);
                }      
            }

            WriteOperation operation = new WriteOperation(timeout, callback, state);

            operation.ChunksToSend  = buffers;
            operation.BufferManager = m_bufferManager;

            lock (m_writeQueue)
            {   
                for (int ii = 0; ii < buffers.Count; ii++)
                {
                    m_bufferManager.TransferBuffer(buffers[ii].Array, "BeginWriteMessage");
                }
                
                m_writeQueue.AddLast(operation);

                if (m_writeQueue.Count == 1 && !m_writeThreadActive)
                {
                    ThreadPool.QueueUserWorkItem(WriteQueuedMessages, null);
                }

                return operation;
            }
        }
        
        /// <summary>
        /// Completes an asynchronous write operation.
        /// </summary>
        public int EndWriteMessage(IAsyncResult result, int timeout)
        {         
            // ensure the caller passed in a valid object.
            WriteOperation operation = result as WriteOperation;

            if (result == null)
            {
                throw new ArgumentException("Not a valid IAsyncResult object.", "result");
            }

            // block until the operation completes.
            try
            {
                return operation.End(timeout);
            }
            catch (Exception e)
            {
                // make sure operation is removed from queue if there was a timeout.
                lock (m_writeQueue)
                {
                    for (LinkedListNode<WriteOperation> ii = m_writeQueue.First; ii != null; ii = ii.Next)
                    {
                        if (Object.ReferenceEquals(ii.Value, operation))
                        {
                            m_writeQueue.Remove(ii);
                            break;
                        }
                    }
                }

                throw new ServiceResultException(e, StatusCodes.BadUnexpectedError);
            }
        }

        /// <summary>
        /// Writes the messages in the queue.
        /// </summary>
        private void WriteQueuedMessages(object state)
        {
            // get first operation on the queue.
            WriteOperation operation = null;
            
            lock (m_writeQueue)
            {   
                if (m_writeQueue.Count == 0)
                {
                    return;
                }

                operation = m_writeQueue.First.Value;
                m_writeQueue.RemoveFirst();
                m_writeThreadActive = true;
            }

            // keep processing messages until the queue is empty.
            while (operation != null)
            {
                // write message.
                try
                {
                    WriteMessage(operation);
                }
                catch (Exception e)
                {
                    Utils.Trace(e, "Unexpected error during write.");
                }

                // check if more operations are queued.
                lock (m_writeQueue)
                {   
                    if (m_writeQueue.Count == 0)
                    {
                        m_writeThreadActive = false;
                        break;
                    }

                    operation = m_writeQueue.First.Value;
                    m_writeQueue.RemoveFirst();
                }
            }
        }   
        
        /// <summary>
        /// Write a single message.
        /// </summary>
        private void WriteMessage(WriteOperation operation)
        {
            // get the buffers to write.
            BufferCollection buffers = operation.ChunksToSend;
                            
            // get the socket.
            Socket socket = null;

            lock (m_socketLock)
            {   
                socket = m_socket;
            }
            
            // check if the socket has been closed.
            if (socket == null)
            {
                operation.Fault(ServiceResult.Create(StatusCodes.BadConnectionClosed, "Socket is no longer available."));
                return;
            }
            
            // begin the write operation (blocks until data is copied into the transport buffer).
            try
            {
                int bytesSent = socket.Send(buffers, SocketFlags.None);

                // check that all the data was sent.
                if (bytesSent < buffers.TotalSize)
                {
                    operation.Fault(ServiceResult.Create(StatusCodes.BadConnectionClosed, "Write operation could not complete."));
                    return;
                }

                // everything ok - yeah!.
                operation.Complete(bytesSent);
            }
            catch (Exception e)
            {
                operation.Fault(ServiceResult.Create(e, StatusCodes.BadConnectionClosed, "Write to socket failed."));
            }
        }
        #endregion

        #region Private Fields
        /// <summary>
        /// Stores the state of an asynchronous write operation.
        /// </summary>
        private class WriteOperation : TcpAsyncOperation<int>
        {
            public WriteOperation(int timeout, AsyncCallback callback, object state)
            :
                base(timeout, callback, state)
            {
            }
            
            /// <summary>
            /// Called when an asynchronous operation completes.
            /// </summary>
            protected override bool InternalComplete(bool donotBlock, object result)
            {
                if (ChunksToSend != null)
                {
                    ChunksToSend.Release(BufferManager, "WriteOperation");
                    ChunksToSend = null;
                }

                return base.InternalComplete(donotBlock, result);
            }

            public BufferCollection ChunksToSend;
            public BufferManager BufferManager;
        }

        private IMessageSink m_sink; 
        private BufferManager m_bufferManager;
        private int m_receiveBufferSize;
        private AsyncCallback m_ReadComplete;
        
        private object m_socketLock = new object();
        private Socket m_socket;
        
        private object m_readLock = new object();
        private byte[] m_receiveBuffer;
        private int m_bytesReceived;
        private int m_bytesToReceive;
        private int m_incomingMessageSize;        

        private LinkedList<WriteOperation> m_writeQueue;
        private LinkedList<ArraySegment<byte>> m_readQueue;
        private bool m_writeThreadActive;
        private bool m_readThreadActive;
        #endregion
     }

    /// <summary>
    /// Used to receive messages read from the socket.
    /// </summary>
    public delegate void TcpMessageReceivedEventHandler(TcpMessageSocket socket, ArraySegment<byte> messageChunk);

    /// <summary>
    /// Used to receive errors reported by the socket.
    /// </summary>
    public delegate void TcpMessageErrorEventHandler(TcpMessageSocket socket, ServiceResult error);
}
