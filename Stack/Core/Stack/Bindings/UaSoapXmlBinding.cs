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
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Security;
using System.Text;

namespace Opc.Ua.Bindings
{
    /// <summary>
    /// The binding for the UA TCP protocol
    /// </summary>
    public class UaSoapXmlBinding : BaseBinding
    {
        #region Constructors
        /// <summary>
        /// Initializes the binding.
        /// </summary>
        /// <param name="namespaceUris">The namespace uris.</param>
        /// <param name="factory">The factory.</param>
        /// <param name="configuration">The configuration.</param>
        /// <param name="description">The description.</param>
        public UaSoapXmlBinding(
            NamespaceTable        namespaceUris,
            EncodeableFactory     factory,
            EndpointConfiguration configuration,
            EndpointDescription   description)
        :
            base(namespaceUris, factory, configuration)
        {                       
            if (description != null && description.SecurityMode != MessageSecurityMode.None)
            {
                SymmetricSecurityBindingElement bootstrap = (SymmetricSecurityBindingElement)SecurityBindingElement.CreateMutualCertificateBindingElement();
                
                bootstrap.MessageProtectionOrder       = MessageProtectionOrder.SignBeforeEncryptAndEncryptSignature;
                bootstrap.DefaultAlgorithmSuite        = SecurityPolicies.ToSecurityAlgorithmSuite(description.SecurityPolicyUri);
                bootstrap.IncludeTimestamp             = true;
                bootstrap.MessageSecurityVersion       = MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
                bootstrap.RequireSignatureConfirmation = false;
                bootstrap.SecurityHeaderLayout         = SecurityHeaderLayout.Strict;

                bootstrap.SetKeyDerivation(true);
                
                m_security = (SymmetricSecurityBindingElement)SecurityBindingElement.CreateSecureConversationBindingElement(bootstrap, true);
                
                m_security.MessageProtectionOrder       = MessageProtectionOrder.EncryptBeforeSign;
                m_security.DefaultAlgorithmSuite        = SecurityPolicies.ToSecurityAlgorithmSuite(description.SecurityPolicyUri);
                m_security.IncludeTimestamp             = true;
                m_security.KeyEntropyMode               = SecurityKeyEntropyMode.CombinedEntropy;
                m_security.MessageSecurityVersion       = MessageSecurityVersion.WSSecurity11WSTrust13WSSecureConversation13WSSecurityPolicy12BasicSecurityProfile10;
                m_security.RequireSignatureConfirmation = false;
                m_security.SecurityHeaderLayout         = SecurityHeaderLayout.Strict;

                m_security.SetKeyDerivation(true);
            }
            
            m_encoding  = new TextMessageEncodingBindingElement(MessageVersion.Soap12WSAddressing10, Encoding.UTF8);
           
            // WCF does not distinguish between arrays and byte string.
            int maxArrayLength = configuration.MaxArrayLength;

            if (configuration.MaxArrayLength < configuration.MaxByteStringLength)
            {
                maxArrayLength = configuration.MaxByteStringLength;
            }

            m_encoding.ReaderQuotas.MaxArrayLength         = maxArrayLength;
            m_encoding.ReaderQuotas.MaxStringContentLength = configuration.MaxStringLength;
            m_encoding.ReaderQuotas.MaxBytesPerRead        = Int32.MaxValue;
            m_encoding.ReaderQuotas.MaxDepth               = Int32.MaxValue;
            m_encoding.ReaderQuotas.MaxNameTableCharCount  = Int32.MaxValue;

            m_transport = new HttpTransportBindingElement();

            m_transport.AllowCookies           = false;
            m_transport.AuthenticationScheme   = System.Net.AuthenticationSchemes.Anonymous;
            m_transport.BypassProxyOnLocal     = true;
            m_transport.HostNameComparisonMode = HostNameComparisonMode.StrongWildcard;
            m_transport.KeepAliveEnabled       = true;
            m_transport.ManualAddressing       = false;
            m_transport.MaxBufferPoolSize      = Int32.MaxValue;
            m_transport.MaxBufferSize          = configuration.MaxMessageSize;
            m_transport.MaxReceivedMessageSize = configuration.MaxMessageSize;
            m_transport.TransferMode           = TransferMode.Buffered;
            m_transport.UseDefaultWebProxy     = false;
        }
        #endregion
        
        #region Overridden Methods
        /// <summary>
        /// The URL scheme for the UA TCP protocol.
        /// </summary>
        /// <value></value>
        /// <returns>The URI scheme that is used by the channels or listeners that are created by the factories built by the current binding.</returns>
        public override string Scheme 
        {
            get { return Utils.UriSchemeHttp; } 
        }

        /// <summary>
        /// Create the set of binding elements that make up this binding.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.ICollection`1"/> object of type <see cref="T:System.ServiceModel.Channels.BindingElement"/> that contains the binding elements from the current binding object in the correct order.
        /// </returns>
        public override BindingElementCollection CreateBindingElements()
        {   
            BindingElementCollection elements = new BindingElementCollection();

            if (m_security != null)
            {
                elements.Add(m_security);
            }

            elements.Add(m_encoding);
            elements.Add(m_transport);

            return elements.Clone();
        }
        #endregion

        #region Private Fields
        private SymmetricSecurityBindingElement m_security;
        private TextMessageEncodingBindingElement m_encoding;
        private HttpTransportBindingElement m_transport;
        #endregion
    }
}
