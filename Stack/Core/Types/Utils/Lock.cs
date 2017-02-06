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
using System.Threading;

namespace Opc.Ua
{
    /// <summary>
    /// A class that allows threads to determine who, if anyone, has the lock on an object.
    /// </summary>
    public class SafeLock 
    {
        /// <summary>
        /// Acquires the lock.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the lock state is inconsistent.</exception>
        public void Enter()
        {
            System.Threading.Monitor.Enter(this);

            if (m_refs == 0)
            {
                int result = Interlocked.CompareExchange(ref m_owner, Thread.CurrentThread.ManagedThreadId, -1);

                if (result != -1)
                {
                    throw new InvalidOperationException("Operation failed because Lock object is in an invalid state.");
                }
            }

            m_refs++;
        }

        /// <summary>
        /// Attempts to acquire the lock.
        /// </summary>
        /// <param name="timeout">The number of milliseconds to wait.</param>
        /// <returns>True if the lock was acquired.</returns>
        /// <exception cref="InvalidOperationException">Thrown if the lock state is inconsistent.</exception>
        public bool TryEnter(int timeout)
        {
            if (!System.Threading.Monitor.TryEnter(this, timeout))
            {
                return false;
            }

            if (m_refs == 0)
            {
                int result = Interlocked.CompareExchange(ref m_owner, Thread.CurrentThread.ManagedThreadId, -1);

                if (result != -1)
                {
                    throw new InvalidOperationException("Operation failed because Lock object is in an invalid state.");
                }
            }

            m_refs++;

            return true;
        }
        
        /// <summary>
        /// Releases the lock.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown if the lock state is inconsistent.</exception>
        public void Exit()
        {
            m_refs--;

            if (m_refs == 0)
            {
                int threadId = Thread.CurrentThread.ManagedThreadId;

                int result = Interlocked.CompareExchange(ref m_owner, -1, threadId);

                if (result != threadId)
                {
                    throw new InvalidOperationException("Operation failed because Lock object is in an invalid state.");
                }
            }

            System.Threading.Monitor.Exit(this);
        }

        /// <summary>
        /// Checks if the current thread has acquired the lock.
        /// </summary>
        /// <returns>True if the current thread owns the lock.</returns>
        public bool HasLock()
        {
            int threadId = Thread.CurrentThread.ManagedThreadId;

            int result = Interlocked.CompareExchange(ref m_owner, threadId, threadId);

            if (result != threadId)
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// The ManagedThreadId for the Thread that owns the lock. -1 if no thread owns the lock.
        /// </summary>
        private int m_owner = -1;
        
        /// <summary>
        /// The number of times Enter has been called.
        /// </summary>
        private int m_refs = 0;
    }

    /// <summary>
    /// A helper object that can be used in a using() clause to acquire/release a SafeLock.
    /// </summary>
    public sealed class Lock : IDisposable
    {
        /// <summary>
        /// Acquires the lock on the SafeLock object.
        /// </summary>
        public Lock(SafeLock safeLock)
        {
            m_safeLock = safeLock;
            m_safeLock.Enter();
        }
        
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
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!m_disposed)
                {
                    m_safeLock.Exit();
                    m_disposed = true;
                }
            }
        }
        #endregion
        
        #region Private Fields
        private SafeLock m_safeLock;
        private bool m_disposed;
        #endregion
    }
}
