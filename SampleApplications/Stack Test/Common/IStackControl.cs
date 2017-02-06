/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.StackTest
{
    #region Interface IStackControl
    /// <summary>
    /// A interface that is used recieve events from the stack.
    /// </summary>
    public interface IStackEventSink
    {
        /// <summary>
        /// A certificate provided in an open secure channel message was rejected.
        /// </summary>
        void CertificateRejected(uint channelId, X509Certificate2 certificate);

        /// <summary>
        /// Reports an error during message processing.
        /// </summary>
        void MessageError(uint channelId, ServiceResult result);
    }
    #endregion

    #region Interface IStackControl
    /// <summary>
    /// A interface that is used to control the stack during testing.
    /// </summary>
    public interface IStackControl
    {
        /// <summary>
        /// Sets the event sink for the stack.
        /// </summary>
        void SetEventSink(IStackEventSink sink);

        /// <summary>
        /// Queues an action.
        /// </summary>
        void QueueAction(StackAction action);
    }
    #endregion

    #region Class StackAction
    /// <summary>
    /// An action which the stack should take.
    /// </summary>
    /// <remarks>
    /// Actions with a RepeatCount >= 1 are placed in the action queue. Each time a request arrives an action
    /// is removed from the queue, applied and the repeat count is decremented. When the repeat count reaches 0
    /// it is removed from the head of the action queue.
    /// 
    /// Actions with a RepeatCount = 0 are applied immediately.    
    /// </remarks>
    public class StackAction
    {
        #region Public Properties
        /// <summary>
        /// The action to take.
        /// </summary>
        public StackActionType ActionType
        {
            get { return m_actionType;  } 
            set { m_actionType = value; }
        }

        /// <summary>
        /// How long the action should last in milliseconds.
        /// </summary>
        public int Duration
        {
            get { return m_duration;  } 
            set { m_duration = value; }
        }
        #endregion

        #region Private Fields
        private StackActionType m_actionType;
        private int m_duration;
        #endregion
    }
    #endregion

    #region Enums StackActionType
    /// <summary>
    /// The types of stack actions.
    /// </summary>
    public enum StackActionType
    {
        /// <summary>
        /// The socket for the connection should be forcably closed.
        /// </summary>
        CloseConnectionSocket,

        /// <summary>
        /// The listening socket for the server should be forceably closed.
        /// </summary>
        CloseListeningSocket,

        /// <summary>
        /// The listening socket for the server should be re-opened.
        /// </summary>
        ReOpenListeningSocket,

        /// <summary>
        /// Corrupt message chunk
        /// </summary>
        CorruptMessageChunk,

        /// <summary>
        /// Re-use a sequence number
        /// </summary>
        ReuseSequenceNumber
    }
    #endregion
}
