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
using System.Linq;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.ServiceModel;
using System.Xml;
using System.Runtime.Serialization;

namespace Opc.Ua.Sample
{
    /// <summary>
    /// Manages the state of the server.
    /// </summary>
    class ServerObject
    {
        #region Initialization
        /// <summary>
        /// Constructs the server.
        /// </summary>
        public ServerObject(string applicationUri, NodeManager nodeManager)
        {
            // the namespace table is used for the namepace indexes in NodeIds and QualifiedNames
            // The first index (added by default) is the UA namespace. The second is the application uri.
            m_namespaceUris = new NamespaceTable();
            m_namespaceUris.Append(applicationUri);

            // the server table is used for the server index in remote NodeIds (a.k.a. ExpandedNodeIds)
            // The first index is always the current server.
            m_serverUris = new StringTable();
            m_serverUris.Append(applicationUri);

            m_serviceLevel = 100;

            m_serverStatus = new ServerStatusDataType();
            m_serverStatus.StartTime = DateTime.UtcNow;
            m_serverStatus.CurrentTime = DateTime.UtcNow;
            m_serverStatus.State = ServerState.Running_0;
            m_serverStatus.SecondsTillShutdown = 0;
            m_serverStatus.ShutdownReason = null;

            m_serverStatus.BuildInfo = new BuildInfo();
            m_serverStatus.BuildInfo.BuildDate = new DateTime(2008, 7, 1);
            m_serverStatus.BuildInfo.SoftwareVersion = "1.00";
            m_serverStatus.BuildInfo.BuildNumber = "218.0";
            m_serverStatus.BuildInfo.ManufacturerName = "My Company";
            m_serverStatus.BuildInfo.ProductName = "My Sample Server";
            m_serverStatus.BuildInfo.ProductUri = "http://mycompany.com/MySampleServer/v1.0";

            // tell the node manager to call this object whenever the value of these attributes are read.
            nodeManager.SetReadValueCallback(new NodeId(Variables.Server_NamespaceArray), GetNamespaceArray);
            nodeManager.SetReadValueCallback(new NodeId(Variables.Server_ServerArray), GetServerArray);
            nodeManager.SetReadValueCallback(new NodeId(Variables.Server_ServiceLevel), GetServiceLevel);
            nodeManager.SetReadValueCallback(new NodeId(Variables.Server_ServerStatus), GetServerStatus);
            nodeManager.SetReadValueCallback(new NodeId(Variables.Server_ServerStatus_StartTime), GetServerStatus_StartTime);
            nodeManager.SetReadValueCallback(new NodeId(Variables.Server_ServerStatus_CurrentTime), GetServerStatus_CurrentTime);
            nodeManager.SetReadValueCallback(new NodeId(Variables.Server_ServerStatus_State), GetServerStatus_State);
        }
        #endregion
        
        #region Read Callback Functions
        /// <summary>
        /// Returns the namespace array.
        /// </summary>
        public object GetNamespaceArray()
        {
            lock (m_lock)
            {
                return m_namespaceUris.ToArray();
            }
        }

        /// <summary>
        /// Returns the server array.
        /// </summary>
        public object GetServerArray()
        {
            lock (m_lock)
            {
                return m_serverUris.ToArray();
            }
        }

        /// <summary>
        /// Returns the service level.
        /// </summary>
        public object GetServiceLevel()
        {
            lock (m_lock)
            {
                // this dynamic behavoir has no meaning but it does provide a changing value for testing.
                if (m_serviceLevel == 255)
                {
                    m_serviceLevel = 0;
                }

                return m_serviceLevel++;
            }
        }

        /// <summary>
        /// Returns the server status as a structure.
        /// </summary>
        public object GetServerStatus()
        {
            lock (m_lock)
            {
                // update the current time.
                m_serverStatus.CurrentTime = DateTime.UtcNow;

                // The server status is a structure type that must be wrapped with an ExtensionObject
                // The TypeId tells the receiver what is contained in the Body of the ExtensionObject
                // In this case the body contains the ServerStatus serialized as an XML document.
                // The schema for the ServerStatusDataType is defined in Opc.Ua.Types.cs but any 
                // schema can be used. The identifier is a Node in the address space.

                ExtensionObject extension = new ExtensionObject(
                    new ExpandedNodeId(Objects.ServerStatusDataType_Encoding_DefaultXml),
                    m_serverStatus);

                // return the extension.
                return extension;
            }
        }

        /// <summary>
        /// Return the start time.
        /// </summary>
        public object GetServerStatus_StartTime()
        {
            lock (m_lock)
            {
                return m_serverStatus.StartTime;
            }
        }

        /// <summary>
        /// Return the current time.
        /// </summary>
        public object GetServerStatus_CurrentTime()
        {
            lock (m_lock)
            {
                return DateTime.UtcNow;
            }
        }
        
        /// <summary>
        /// Return the server state.
        /// </summary>
        public object GetServerStatus_State()
        {
            lock (m_lock)
            {
                // The server state is an enumeration, however, enumerated values are always converted as Int32 values
                // when they are exchanged between client and servers. The receiver will be able to convert the Int32 
                // value back to strings by using its knowledge of the information or by looking at the EnumStrings 
                // property associated with the Variable being read/written.

                return (int)m_serverStatus.State;
            }
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private NamespaceTable m_namespaceUris;
        private StringTable m_serverUris;
        private byte m_serviceLevel;
        private ServerStatusDataType m_serverStatus;
        #endregion
    }

}
