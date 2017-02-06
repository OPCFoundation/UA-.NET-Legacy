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
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Sample
{
    /// <summary>
    /// Manages a session with a client application.
    /// </summary>
    class Session
    {
        #region Public Methods
        /// <summary>
        /// Creates the session.
        /// </summary>
        public void Create(
            EndpointDescription endpoint,
            ApplicationDescription client,
            byte[] clientCertificate,
            string sessionName,
            double sessionTimeout,
            out NodeId sessionId,
            out NodeId authenticationToken,
            out byte[] serverNonce,
            out double revisedSessionTimeout)
        {
            lock (m_lock)
            {
                // save the secure channel id.
                m_secureChannelId = null;

                if (OperationContext.Current != null)
                {
                    m_secureChannelId = OperationContext.Current.Channel.SessionId;
                }

                m_endpoint = endpoint;
                m_client = client;
                m_sessionName = sessionName;

                if (clientCertificate != null)
                {
                    m_clientCertificate = new X509Certificate2(clientCertificate);
                }

                // Create a public and a private identifier for the session. The public identifier is visible in the
                // address space and audit logs. The private identifier is only used by the client to identify itself 
                // when it sends a request. Clients and servers that do not keep the authentication token will be vulnerable
                // to session hijacking when using transports such as SSL to implement the secure channel. It is not an
                // issue for applications that use WS-Secure Conversation.

                // create a guid for a session id. use it for an authentication token as well.
                m_sessionId = new NodeId(System.Guid.NewGuid(), 1);
                m_authenticationToken = authenticationToken = sessionId = m_sessionId;

                // set a reasonable session timeout.
                m_sessionTimeout = sessionTimeout;

                if (m_sessionTimeout < 30000)
                {
                    m_sessionTimeout = 30000;
                }

                revisedSessionTimeout = m_sessionTimeout;

                // create a server nonce.
                m_serverNonce = serverNonce = new byte[32];
                RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
                random.GetBytes(m_serverNonce);
            }
        }

        /// <summary>
        /// Verify the secure channel.
        /// </summary>
        public void VerifySecureChannel(bool activating)
        {
            lock (m_lock)
            {
                // Each session is bound to a WCF channel instance. If that channel is lost the client can recover
                // by calling activate session again (the logic here would need to change to support that).

                if (OperationContext.Current == null || m_secureChannelId != OperationContext.Current.Channel.SessionId)
                {
                    throw new StatusCodeException(StatusCodes.BadSecureChannelIdInvalid, "Secure channel is not valid for session.");
                }

                // activate session must be called at least once before a session can be used.
                if (!activating && !m_activated)
                {
                    throw new StatusCodeException(StatusCodes.BadSessionNotActivated, "Session has not been activated.");
                }
            }
        }

        /// <summary>
        /// Activates the session.
        /// </summary>
        public byte[] Activate(
            SignatureData signature, 
            ListOfString localeIds,
            ExtensionObject userIdentityToken,
            SignatureData userTokenSignature)
        {
            lock (m_lock)
            {
                if (m_clientCertificate != null)
                {
                    // validate the client's signature.
                    byte[] dataToSign = SecurityUtils.Append(m_endpoint.ServerCertificate, m_serverNonce);

                    bool valid = SecurityUtils.Verify(
                        m_clientCertificate,
                        m_endpoint.SecurityPolicyUri,
                        dataToSign,
                        signature);

                    if (!valid)
                    {
                        throw new StatusCodeException(
                            StatusCodes.BadSecurityChecksFailed,
                            "Client did not provide a correct signature for the nonce data provided by the server.");
                    }
                }

                m_activated = true;
                m_localeIds = localeIds;

                // TBD - validate the user identity token.

                // return a new nonce.
                RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
                random.GetBytes(m_serverNonce);
                return m_serverNonce;
            }
        }
        #endregion

        #region Private Fields
        private object m_lock = new object();
        private string m_secureChannelId;
        private EndpointDescription m_endpoint;
        private ApplicationDescription m_client;
        private X509Certificate2 m_clientCertificate;
        private string m_sessionName;
        private double m_sessionTimeout;
        private NodeId m_sessionId;
        private NodeId m_authenticationToken;
        private byte[] m_serverNonce;
        private bool m_activated;
        private IList<string> m_localeIds;
        #endregion
    }
}
