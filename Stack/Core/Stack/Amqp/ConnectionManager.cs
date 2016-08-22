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
using System.Threading;

namespace Opc.Ua.Bindings
{
    public class ConnectionManager : IDisposable
    {
        private class CachedConnection
        {
            public string AmqpNodeName;
            public IAmqpConnection Connection;
            public long LastMessageTime;
        }

        private long m_connectionExpiryTime;
        private Dictionary<string, CachedConnection> m_connections;
        private Timer m_cleanupTimer;
        
        private void OnCleanupTimerExpired(object state)
        {
            try
            {
                List<CachedConnection> connectionsToDelete = new List<CachedConnection>();

                long cutoff = TimeUtils.GetTickCount() - m_connectionExpiryTime;

                lock (m_connections)
                {
                    foreach (var ii in m_connections)
                    {
                        if (cutoff > ii.Value.LastMessageTime)
                        {
                            connectionsToDelete.Add(ii.Value);
                        }
                    }
                }

                foreach (var ii in connectionsToDelete)
                {
                    ii.Connection.Close();
                    m_connections.Remove(ii.AmqpNodeName);
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.Write("Unexpected error deleting connections: " + e.Message);
            }
        }

        public ConnectionManager()
        {
            m_connections = new Dictionary<string, CachedConnection>();
            m_connectionExpiryTime = 60000 * 5;
            m_cleanupTimer = new Timer(OnCleanupTimerExpired, null, m_connectionExpiryTime, m_connectionExpiryTime / 2);
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

                lock (m_connections)
                {
                    foreach (var ii in m_connections)
                    {
                        ii.Value.Connection.Close();
                    }

                    m_connections.Clear();
                }
            }
        }

        public IAmqpConnection Find(string amqpNodeName)
        {
            lock (m_connections)
            {
                CachedConnection cache = null;

                if (!m_connections.TryGetValue(amqpNodeName, out cache))
                {
                    return null;
                }

                cache.LastMessageTime = TimeUtils.GetTickCount();
                cache.Connection.AddRef();
                return cache.Connection;
            }
        }

        public void Save(string amqpNodeName, IAmqpConnection connection)
        {
            lock (m_connections)
            {
                CachedConnection cache = null;

                if (!m_connections.TryGetValue(amqpNodeName, out cache))
                {
                    cache = new CachedConnection() { AmqpNodeName = amqpNodeName, Connection = connection, LastMessageTime = TimeUtils.GetTickCount() };
                    connection.ConnectionClosed += Connection_ConnectionClosed;
                    connection.AddRef();
                    m_connections.Add(amqpNodeName, cache);
                }

                cache.Connection = connection;
                cache.LastMessageTime = TimeUtils.GetTickCount();
            }
        }

        private void Connection_ConnectionClosed(object sender, AmqpConnectionEventArgs e)
        {
            lock (m_connections)
            {
                CachedConnection cache = null;

                if (m_connections.TryGetValue(e.AmqpNodeName, out cache))
                {
                    m_connections.Remove(e.AmqpNodeName);
                    cache.Connection.Release();
                }
            }
        }

        public void Remove(string amqpNodeName)
        {
            lock (m_connections)
            {
                m_connections.Remove(amqpNodeName);
            }
        }

        public void RenewTokens()
        {
            List<CachedConnection> connectionsToRenew = new List<CachedConnection>();

            lock (m_connections)
            {
                connectionsToRenew.AddRange(m_connections.Values);
            }

            foreach (var ii in connectionsToRenew)
            {
                ii.Connection.RenewTokenAsync((int)m_connectionExpiryTime).Wait(10000);
            }
        }
    }
}
