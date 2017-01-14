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
using System.ServiceModel.Channels;
using System.Xml;

namespace Opc.Ua
{
    /// <summary>
    /// Describes how to connect to an endpoint.
    /// </summary>
    public partial class EndpointDescription
    {
        #region Constructors
        /// <summary>
        /// Creates an endpoint configuration from a url.
        /// </summary>
        public EndpointDescription(string url)
        {
            Initialize();
            
            UriBuilder parsedUrl = new UriBuilder(url);

            if (parsedUrl.Scheme == Utils.UriSchemeHttp)
            {
                if (!parsedUrl.Path.EndsWith("/discovery"))
                {
                    parsedUrl.Path += "/discovery";
                }
            }

            Server.DiscoveryUrls.Add(parsedUrl.ToString());

            EndpointUrl            = url;
            Server.ApplicationUri  = url;
            Server.ApplicationName = url;
            SecurityMode           = MessageSecurityMode.None;
            SecurityPolicyUri      = SecurityPolicies.None;
        }
        #endregion
        
        #region Public Properties
        /// <summary>
        /// The encodings supported by the configuration.
        /// </summary>
        public BinaryEncodingSupport EncodingSupport
        {
            get
            {
                if (!String.IsNullOrEmpty(EndpointUrl) && (EndpointUrl.StartsWith(Utils.UriSchemeOpcTcp) || EndpointUrl.StartsWith(Utils.UriSchemeOpcWss)))
                {
                    return BinaryEncodingSupport.Required;
                }

                TransportProfileUri = Profiles.NormalizeUri(TransportProfileUri);

                switch (TransportProfileUri)
                {
                    case Profiles.WsHttpXmlOrBinaryTransport:
                    case Profiles.HttpsXmlOrBinaryTransport:
                    {
                        return BinaryEncodingSupport.Optional;
                    }

                    case Profiles.HttpsBinaryTransport:
                    {
                        return BinaryEncodingSupport.Required;
                    }

                    case Profiles.WsHttpXmlTransport:
                    case Profiles.HttpsXmlTransport:
                    {
                        return BinaryEncodingSupport.None;
                    }
                }
    
                return BinaryEncodingSupport.None;
            }
        }

        /// <summary>
        /// The proxy url to use when connecting to the endpoint.
        /// </summary>
        public Uri ProxyUrl
        {
            get { return m_proxyUrl;  }
            set { m_proxyUrl = value; }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Finds the user token policy with the specified id.
        /// </summary>
        public UserTokenPolicy FindUserTokenPolicy(string policyId)
        {
            foreach (UserTokenPolicy policy in m_userIdentityTokens)
            {
                if (policy.PolicyId == policyId)
                {
                    return policy;
                }
            }

            return null;
        }

        /// <summary>
        /// Finds a token policy that matches the user identity specified.
        /// </summary>
        public UserTokenPolicy FindUserTokenPolicy(UserTokenType tokenType, XmlQualifiedName issuedTokenType)
        {
            if (issuedTokenType == null)
            {
                return FindUserTokenPolicy(tokenType, (string)null);
            }

            return FindUserTokenPolicy(tokenType, issuedTokenType.Namespace);
        }

        /// <summary>
        /// Finds a token policy that matches the user identity specified.
        /// </summary>
        public UserTokenPolicy FindUserTokenPolicy(UserTokenType tokenType, string issuedTokenType = null)
        {            
            // find matching policy.
            foreach (UserTokenPolicy policy in m_userIdentityTokens)
            {
                // check token type.
                if (tokenType != policy.TokenType)
                {
                    continue;
                }

                // check issuer token type.
                if (issuedTokenType != null && issuedTokenType != policy.IssuedTokenType)
                {
                    continue;
                }

                return policy;
            }

            // no policy found
            return null;
        }

        public static readonly string[] s_SupportedProfiles = new string[]
        {
            SecurityPolicies.None,
            SecurityPolicies.Basic128Rsa15,
            SecurityPolicies.Basic256
        };

        /// <summary>
        /// Finds the endpoint that best matches the current settings.
        /// </summary>
        /// <param name="application">The application configuration.</param>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <param name="useSecurity">if set to <c>true</c> select an endpoint that uses security.</param>
        /// <returns>The best available endpoint.</returns>
        public static EndpointDescription SelectEndpoint(ApplicationConfiguration application, ITransportWaitingConnection connection, bool useSecurity)
        {
            // set a short timeout because this is happening in the drop down event.
            EndpointConfiguration configuration = EndpointConfiguration.Create();
            // configuration.OperationTimeout = 5000;
            configuration.OperationTimeout = 500000;

            using (DiscoveryClient client = DiscoveryClient.Create(application, connection, configuration))
            {
                return SelectEndpoint(application, client, useSecurity);
            }
        }

        /// <summary>
        /// Finds the endpoint that best matches the current settings.
        /// </summary>
        /// <param name="application">The application configuration.</param>
        /// <param name="discoveryUrl">The discovery URL.</param>
        /// <param name="useSecurity">if set to <c>true</c> select an endpoint that uses security.</param>
        /// <returns>The best available endpoint.</returns>
        public static EndpointDescription SelectEndpoint(ApplicationConfiguration application, string discoveryUrl, bool useSecurity)
        {
            // needs to add the '/discovery' back onto non-UA TCP URLs.
            if (discoveryUrl.StartsWith(Utils.UriSchemeHttp))
            {
                if (!discoveryUrl.EndsWith("/discovery"))
                {
                    discoveryUrl += "/discovery";
                }
            }

            // parse the selected URL.
            Uri uri = new Uri(discoveryUrl);

            // set a short timeout because this is happening in the drop down event.
            EndpointConfiguration configuration = EndpointConfiguration.Create();
            configuration.OperationTimeout = 5000;

            using (DiscoveryClient client = DiscoveryClient.Create(application, uri, configuration))
            {
                var selectedEndpoint = SelectEndpoint(application, client, useSecurity);

                // if a server is behind a firewall it may return URLs that are not accessible to the client.
                // This problem can be avoided by assuming that the domain in the URL used to call 
                // GetEndpoints can be used to access any of the endpoints. This code makes that conversion.
                // Note that the conversion only makes sense if discovery uses the same protocol as the endpoint.

                Uri endpointUrl = Utils.ParseUri(selectedEndpoint.EndpointUrl);

                if (endpointUrl != null && endpointUrl.Scheme == uri.Scheme)
                {
                    UriBuilder builder = new UriBuilder(endpointUrl);
                    builder.Host = uri.DnsSafeHost;
                    builder.Port = uri.Port;
                    selectedEndpoint.EndpointUrl = builder.ToString();
                }

                return selectedEndpoint;
            }
        }
              
        private static EndpointDescription SelectEndpoint(ApplicationConfiguration application, DiscoveryClient client, bool useSecurity)
        {
            Uri url = new Uri(client.Endpoint.EndpointUrl);
            EndpointDescription selectedEndpoint = null;

            // Connect to the server's discovery endpoint and find the available configuration.
            EndpointDescriptionCollection endpoints = client.GetEndpoints(null);

            // select the best endpoint to use based on the selected URL and the UseSecurity checkbox. 
            for (int ii = 0; ii < endpoints.Count; ii++)
            {
                EndpointDescription endpoint = endpoints[ii];

                // check for a match on the URL scheme.
                if (endpoint.EndpointUrl.StartsWith(url.Scheme))
                {
                    // check if security was requested.
                    if (useSecurity)
                    {
                        if (endpoint.SecurityMode == MessageSecurityMode.None)
                        {
                            continue;
                        }
                    }
                    else
                    {
                        if (endpoint.SecurityMode != MessageSecurityMode.None)
                        {
                            continue;
                        }
                    }

                    // ignore unsupported policies.
                    bool found = false;

                    for (int jj = 0; jj < s_SupportedProfiles.Length; jj++)
                    {
                        if (s_SupportedProfiles[jj] == endpoint.SecurityPolicyUri)
                        {
                            found = true;
                        }
                    }

                    if (!found)
                    {
                        continue;
                    }

                    // pick the first available endpoint by default.
                    if (selectedEndpoint == null)
                    {
                        selectedEndpoint = endpoint;
                    }

                    // The security level is a relative measure assigned by the server to the 
                    // endpoints that it returns. Clients should always pick the highest level
                    // unless they have a reason not too.
                    if (endpoint.SecurityLevel >= selectedEndpoint.SecurityLevel)
                    {
                        // only select the matching domain/port.
                        if (new Uri(endpoint.EndpointUrl).Port == url.Port)
                        {
                            selectedEndpoint = endpoint;
                        }
                    }
                }
            }

            // pick the first available endpoint by default.
            if (selectedEndpoint == null && endpoints.Count > 0)
            {
                selectedEndpoint = endpoints[0];
            }

            // return the selected endpoint.
            return selectedEndpoint;
        }
        #endregion

        #region Private Fields
        private Uri m_proxyUrl;
        #endregion
    }
}
