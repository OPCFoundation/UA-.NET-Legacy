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
using System.Security.Cryptography.X509Certificates;
using Microsoft.IdentityModel.Protocols;
using System.Net.Http;

namespace Opc.Ua
{
    /// <remark />
    public class JwtUtils
    {
        /// <remark />
        public static IUserIdentity ValidateToken(Uri authorityUrl, X509Certificate2 authorityCertificate, string issuerUri, string audiance, string jwt)
        {
            var task = ValidateTokenAsync(authorityUrl, authorityCertificate, issuerUri, audiance, jwt);
            task.Wait();
            return task.Result;
        }

        /// <remark />
        public static async Task<IUserIdentity> ValidateTokenAsync(Uri authorityUrl, X509Certificate2 authorityCertificate, string issuerUri, string audiance, string jwt)
        {
            JwtSecurityToken token = new JwtSecurityToken(jwt);

            SecurityToken validatedToken = new JwtSecurityToken();
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            TokenValidationParameters validationParameters = new TokenValidationParameters
            {
                ValidateAudience = true,
                ValidAudience = audiance,
                ValidateLifetime = true,
                ClockSkew = new TimeSpan(0, 5, 0),
                CertificateValidator = X509CertificateValidator.None
            };

            if (authorityCertificate != null)
            {
                validationParameters.ValidateIssuer = true;
                validationParameters.ValidIssuer = issuerUri;
                validationParameters.IssuerSigningKey = new X509AsymmetricSecurityKey(authorityCertificate);

                tokenHandler.ValidateToken(jwt, validationParameters, out validatedToken);
            }
            else
            {
                ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(authorityUrl.ToString() + "/.well-known/openid-configuration");
                OpenIdConnectConfiguration config = await configManager.GetConfigurationAsync();
                validationParameters.ValidIssuer = new Uri(config.Issuer).ToString();
                validationParameters.IssuerSigningTokens = new List<SecurityToken>(config.SigningTokens);

                tokenHandler.ValidateToken(jwt, validationParameters, out validatedToken);
            }

            return new UserIdentity(validatedToken);
        }

        /// <remark />
        public static OpenIdConnectConfiguration Discover(Uri authorityUrl)
        {
            var task = DiscoverAsync(authorityUrl);
            task.Wait();
            return task.Result;
        }

        /// <remark />
        public static async Task<OpenIdConnectConfiguration> DiscoverAsync(Uri authorityUrl)
        {
            ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(authorityUrl.ToString());
            return await configManager.GetConfigurationAsync();
        }

        /// <remark />
        public static string RequestTokenForApplication(UserTokenPolicy policy, string clientId, string clientSecret, string scope = null)
        {
            var task = RequestTokenForApplicationAsync(policy, clientId, clientSecret, scope);
            task.Wait();
            return task.Result;
        }

        /// <remark />
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

    /// <remark />
    public class JwtEndpointParameters
    {
        /// <remark />
        public string AuthorityUrl;
        /// <remark />
        public string AuthorityProfileUri;
        /// <remark />
        public string TokenEndpoint;
        /// <remark />
        public string AuthorizationEndpoint;
        /// <remark />
        public List<string> RequestTypes;
        /// <remark />
        public string ResourceId;
        /// <remark />
        public List<string> Scopes;

        /// <remark />
        public string ToJson()
        {
            var encoder = new JsonEncoder(ServiceMessageContext.GlobalContext, true);

            encoder.WriteString("ua:authorityUrl", AuthorityUrl);
            encoder.WriteString("ua:authorityProfileUri", AuthorityProfileUri);
            encoder.WriteString("ua:tokenEndpoint", TokenEndpoint);
            encoder.WriteString("ua:authorizationEndpoint", AuthorizationEndpoint);
            encoder.WriteStringArray("ua:requestTypes", RequestTypes);
            encoder.WriteString("ua:resource", ResourceId);
            encoder.WriteStringArray("ua:scopes", Scopes);

            return encoder.CloseAndReturnText();
        }

        /// <remark />
        public void FromJson(string json)
        {
            var decoder = new JsonDecoder(json, ServiceMessageContext.GlobalContext);

            AuthorityUrl = decoder.ReadString("ua:authorityUrl");
            AuthorityProfileUri = decoder.ReadString("ua:authorityProfileUri");
            TokenEndpoint = decoder.ReadString("ua:tokenEndpoint");
            AuthorizationEndpoint = decoder.ReadString("ua:authorizationEndpoint");
            RequestTypes = decoder.ReadStringArray("ua:requestTypes");
            ResourceId = decoder.ReadString("ua:resourceId");
            Scopes = decoder.ReadStringArray("ua:scopes");
        }
    }

    /// <remark />
    public static class JwtConstants
    {
        /// <remark />
        public const string JwtUserTokenPolicy = "http://opcfoundation.org/UA/UserToken#JWT";
        /// <remark />
        public const string OAuth2AuthorizationPolicy = "http://opcfoundation.org/UA/Authorization#OAuth2";
        /// <remark />
        public const string AzureIdentityProviderPolicy = "http://opcfoundation.org/UA/IdentityProvider#Azure";
        /// <remark />
        public const string OAuth2AuthorizationCode = "authorization_code";
        /// <remark />
        public const string OAuth2ClientCredentials = "client_credentials";
    }
}
