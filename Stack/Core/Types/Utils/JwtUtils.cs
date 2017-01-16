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
using System.Threading.Tasks;
using System.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Selectors;
using Microsoft.IdentityModel.Protocols;
using System.Net.Http;

namespace Opc.Ua
{
    public class JwtUtils
    {
        public static IUserIdentity ValidateToken(Uri authorityUrl, string audiance, string jwt)
        {
            var task = ValidateTokenAsync(authorityUrl, audiance, jwt);
            task.Wait();
            return task.Result;
        }

        public static async Task<IUserIdentity> ValidateTokenAsync(Uri authorityUrl, string audiance, string jwt)
        {
            JwtSecurityToken token = new JwtSecurityToken(jwt);

            SecurityToken validatedToken = new JwtSecurityToken();
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidAudience = audiance,
                CertificateValidator = X509CertificateValidator.None
            };

            ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(authorityUrl.ToString() + "/.well-known/openid-configuration");
            OpenIdConnectConfiguration config = await configManager.GetConfigurationAsync();
            validationParameters.ValidIssuer = new Uri(config.Issuer).ToString();
            validationParameters.IssuerSigningTokens = new List<SecurityToken>(config.SigningTokens);

            tokenHandler.ValidateToken(jwt, validationParameters, out validatedToken);

            return new UserIdentity(validatedToken);
        }

        public static OpenIdConnectConfiguration Discover(Uri authorityUrl)
        {
            var task = DiscoverAsync(authorityUrl);
            task.Wait();
            return task.Result;
        }

        public static async Task<OpenIdConnectConfiguration> DiscoverAsync(Uri authorityUrl)
        {
            ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(authorityUrl.ToString());
            return await configManager.GetConfigurationAsync();
        }

        public static string RequestTokenForApplication(UserTokenPolicy policy, string clientId, string clientSecret, string scope = null)
        {
            var task = RequestTokenForApplicationAsync(policy, clientId, clientSecret, scope);
            task.Wait();
            return task.Result;
        }

        public static async Task<string> RequestTokenForApplicationAsync(UserTokenPolicy policy, string clientId, string clientSecret, string scope = null)
        {
            if (policy == null)
            {
                throw new ArgumentNullException("policy");
            }

            JwtEndpointParameters parameters = new JwtEndpointParameters();
            parameters.FromJson(policy.IssuerEndpointUrl);

            var configuration = await DiscoverAsync(new Uri(parameters.AuthorityUrl + "/.well-known/openid-configuration"));

            if (String.IsNullOrEmpty(scope) && parameters.Scopes != null && parameters.Scopes.Count > 0)
            {
                scope = String.Empty;

                foreach (var entry in parameters.Scopes)
                {
                    if (scope.Length > 0)
                    {
                        scope += " ";
                    }

                    scope += entry;
                }
            }

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();

                Dictionary<string, string> fields = new Dictionary<string, string>();

                fields["grant_type"] = "client_credentials";
                fields["client_id"] = clientId;
                fields["client_secret"] = clientSecret;

                if (!String.IsNullOrEmpty(parameters.ResourceId))
                {
                    fields["resource"] = parameters.ResourceId;
                }

                if (!String.IsNullOrEmpty(scope))
                {
                    fields["scope"] = scope;
                }

                var content = new System.Net.Http.FormUrlEncodedContent(fields);
                HttpResponseMessage response = await client.PostAsync(configuration.TokenEndpoint, content);

                if (!response.IsSuccessStatusCode)
                {
                    throw new SecurityTokenException("The could not authorize client.");
                }

                var strm = await response.Content.ReadAsStreamAsync();
                var reader = new JsonTextReader(new System.IO.StreamReader(strm));

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName && (string)reader.Value == "access_token")
                    {
                        if (reader.Read() && reader.TokenType == JsonToken.String)
                        {
                            return (string)reader.Value;
                        }
                    }
                }
            }

            throw new SecurityTokenException("The authorization server did not return a valid JWT.");
        }
    }


    public class JwtIdentityProviderParameters : IEncodeable
    {
        public string IdentityProviderUrl;
        public string IdentityProfileUri;
        public string TokenEndpoint;
        public string AuthorizationEndpoint;
        public string ResourceId;

        #region IEncodeable Members
        public ExpandedNodeId TypeId { get { return ExpandedNodeId.Null; } }
        public ExpandedNodeId BinaryEncodingId { get { return ExpandedNodeId.Null; } }
        public ExpandedNodeId XmlEncodingId { get { return ExpandedNodeId.Null; } }

        public void Encode(IEncoder encoder)
        {
            encoder.WriteString("ua:identityProvider", IdentityProviderUrl);
            encoder.WriteString("ua:identityProfileUri", IdentityProfileUri);
            encoder.WriteString("ua:authorizationEndpoint", AuthorizationEndpoint);
            encoder.WriteString("ua:tokenEndpoint", TokenEndpoint);
            encoder.WriteString("ua:resource", ResourceId);
        }

        public void Decode(IDecoder decoder)
        {
            IdentityProviderUrl = decoder.ReadString("ua:identityProvider");
            IdentityProfileUri = decoder.ReadString("ua:identityProfileUri");
            AuthorizationEndpoint = decoder.ReadString("ua:authorizationEndpoint");
            TokenEndpoint = decoder.ReadString("ua:tokenEndpoint");
            ResourceId = decoder.ReadString("ua:resource");
        }

        public bool IsEqual(IEncodeable encodeable)
        {
            return base.Equals(encodeable);
        }

        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion
    }

    public class JwtEndpointParameters
    {
        public string AuthorityUrl;
        public string AuthorityProfileUri;
        public string TokenEndpoint;
        public List<string> RequestTypes;
        public string ResourceId;
        public List<string> Scopes;
        public List<JwtIdentityProviderParameters> IdentityProviders;

        public string ToJson()
        {
            var encoder = new JsonEncoder(ServiceMessageContext.GlobalContext, true);

            encoder.WriteString("ua:authority", AuthorityUrl);
            encoder.WriteString("ua:authorityProfileUri", AuthorityProfileUri);
            encoder.WriteString("ua:tokenEndpoint", TokenEndpoint);
            encoder.WriteStringArray("ua:requestTypes", RequestTypes);
            encoder.WriteString("ua:resource", ResourceId);
            encoder.WriteStringArray("ua:scopes", Scopes);

            if (IdentityProviders != null && IdentityProviders.Count > 0)
            {
                encoder.WriteEncodeableArray("ua:identityProviders", IdentityProviders.ToArray(), typeof(JwtIdentityProviderParameters));
            }

            return encoder.CloseAndReturnText();
        }

        public void FromJson(string json)
        {
            var decoder = new JsonDecoder(json, ServiceMessageContext.GlobalContext);

            AuthorityUrl = decoder.ReadString("ua:authority");
            AuthorityProfileUri = decoder.ReadString("ua:authorityProfileUri");
            TokenEndpoint = decoder.ReadString("ua:tokenEndpoint");
            RequestTypes = decoder.ReadStringArray("ua:requestTypes");
            ResourceId = decoder.ReadString("ua:resourceId");
            Scopes = decoder.ReadStringArray("ua:scopes");

            var providers = (IList<JwtIdentityProviderParameters>)decoder.ReadEncodeableArray("ua:identityProviders", typeof(JwtIdentityProviderParameters));

            if (providers != null && providers.Count > 0)
            {
                IdentityProviders = new List<JwtIdentityProviderParameters>(providers);
            }
            else
            {
                IdentityProviders = new List<JwtIdentityProviderParameters>();
            }
        }
    }

    public static class JwtConstants
    {
        public const string JwtUserTokenPolicy = "http://opcfoundation.org/UA/UserToken#JWT";
        public const string OAuth2AuthorizationPolicy = "http://opcfoundation.org/UA/Authorization#OAuth2";
        public const string AzureIdentityProviderPolicy = "http://opcfoundation.org/UA/IdentityProvider#Azure";
        public const string OAuth2AuthorizationCode = "authorization_code";
        public const string OAuth2SiteToken = "site_token";
        public const string OAuth2ClientCredentials = "client_credentials";
    }
}
