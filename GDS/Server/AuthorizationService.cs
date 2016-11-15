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
using System.Text;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Owin.Hosting;
using Owin;
using IdentityServer3.Core.Configuration;
using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using IdentityServer3.Core.Validation;
using IdentityServer3.Core.Services.Default;
using IdentityServer3.Core.Extensions;
using System.Security.Cryptography.X509Certificates;
using Opc.Ua.Configuration;
using IdentityModel.Client;
using Serilog;
using System.Security.Claims;
using System.IdentityModel.Tokens;
using System.IdentityModel.Selectors;
using Microsoft.IdentityModel.Protocols;
using Microsoft.Owin;
using System.IO;
using IdentityServer3.Core.Services.InMemory;
using Opc.Ua.GdsServer;

namespace Opc.Ua.AuthorizationService
{
    public class AuthorizationService
    {
        private IDisposable m_host;

        public void Start(ApplicationInstance application, GlobalDiscoveryServerServer server)
        {
            Startup.Server = server;
            Startup.ServiceCertificate = application.ApplicationConfiguration.SecurityConfiguration.ApplicationCertificate.Find();
            Startup.ServiceConfiguration = application.ApplicationConfiguration.ParseExtension<AuthorizationServiceConfiguration>();

            string hostname = System.Net.Dns.GetHostName();

            foreach (var baseAddress in application.ApplicationConfiguration.ServerConfiguration.BaseAddresses)
            {
                Uri url = new Uri(baseAddress);

                if (url.Scheme == "https" && url.DnsSafeHost != "localhost")
                {
                    hostname = url.DnsSafeHost;
                    break;
                }
            }

            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.LiterateConsole()
                .CreateLogger();

            m_host = WebApp.Start<Startup>(String.Format("https://{0}:54333", hostname));
        }
    }

    public class Startup
    {
        public static X509Certificate2 ServiceCertificate;
        public static AuthorizationServiceConfiguration ServiceConfiguration;
        public static GlobalDiscoveryServerServer Server;

        public void Configuration(IAppBuilder app)
        {
            var factory = new IdentityServerServiceFactory().UseInMemoryScopes(Scopes.Get()).UseInMemoryUsers(Users.Get());

            factory.TokenService = new Registration<ITokenService>(typeof(CustomTokenService));
            factory.CorsPolicyService = new Registration<ICorsPolicyService>(new DefaultCorsPolicyService { AllowAll = true });
            factory.SecretParsers = new Registration<ISecretParser>[] { new Registration<ISecretParser>(new ApplicationCertificateSecretParser(Server)) };
            factory.SecretValidators = new Registration<ISecretValidator>[] { new Registration<ISecretValidator>(new ApplicationCertificateSecretValidator()) };
            factory.ClientStore = new Registration<IClientStore>(new ApplicationClientStore(ServiceConfiguration, Server));
            factory.CustomGrantValidators.Add(new Registration<ICustomGrantValidator>(new CustomGrantValidator(ServiceConfiguration)));

            CustomTokenService.Server = Startup.Server;
            CustomTokenService.Configuration = Startup.ServiceConfiguration;

            var options = new IdentityServerOptions
            {
                SiteName = "GDS AuthorizationService",

                SigningCertificate = LoadCertificate(),
                Factory = factory,
                InputLengthRestrictions = new InputLengthRestrictions() { Password = 2048 },
   
                EventsOptions = new EventsOptions
                {
                    RaiseSuccessEvents = true,
                    RaiseErrorEvents = true,
                    RaiseFailureEvents = true,
                    RaiseInformationEvents = true
                },
            };

            app.UseIdentityServer(options);
        }

        X509Certificate2 LoadCertificate()
        {
            return Startup.ServiceCertificate;
        }
    }

    static class Users
    {
        public static List<InMemoryUser> Get()
        {
            return new List<InMemoryUser>();
        }
    }

    static class Scopes
    {
        public static List<Scope> Get()
        {
            return new List<Scope>
            {
                new Scope { Name = "gds:admin" },
                new Scope { Name = "gds:appadmin" },
                new Scope { Name = "gds" },
                new Scope { Name = "pubsub" },
                new Scope { Name = "pubsub:secret" },
                new Scope { Name = "observer" }
            };
        }
    }

    public class ApplicationClientStore : IClientStore
    {
        private AuthorizationServiceConfiguration m_configuration;
        private GlobalDiscoveryServerServer m_server;

        /// <summary>
        /// Initializes a new instance of the <see cref="CachingClientStore"/> class.
        /// </summary>
        /// <param name="inner">The inner <see cref="IClientStore"/>.</param>
        /// <param name="cache">The cache.</param>
        /// <exception cref="System.ArgumentNullException">
        /// inner
        /// or
        /// cache
        /// </exception>
        public ApplicationClientStore(
            AuthorizationServiceConfiguration configuration,
            GlobalDiscoveryServerServer server)
        {
            m_configuration = configuration;
            m_server = server;
        }

        /// <summary>
        /// Finds a client by id
        /// </summary>
        /// <param name="clientId">The client id</param>
        /// <returns>
        /// The client
        /// </returns>
        public Task<Client> FindClientByIdAsync(string clientId)
        {
            if (m_configuration.Clients != null)
            {
                foreach (var client in m_configuration.Clients)
                {
                    if (client.ClientId == clientId)
                    {
                        return Task.FromResult(new Client
                        {
                            ClientName = client.ClientName,
                            ClientId = client.ClientId,
                            Enabled = true,
                            AccessTokenType = AccessTokenType.Jwt,
                            Flow = Flows.ClientCredentials,
                            ClientSecrets = new List<Secret> { new Secret(client.ClientSecret.Sha256()) },
                            AllowClientCredentialsOnly = true,
                            AllowAccessToAllScopes = true
                        });
                    }
                }
            }

            try
            {
                var application = m_server.FindApplication(clientId);

                if (application != null)
                {
                    return Task.FromResult(new Client
                    {
                        ClientName = application.ApplicationNames[0].Text,
                        ClientId = application.ApplicationUri,
                        Enabled = true,
                        AccessTokenType = AccessTokenType.Jwt,
                        Flow = Flows.Custom,
                        ClientSecrets = new List<Secret>(),
                        AllowAccessToAllCustomGrantTypes = true,
                        AllowedCustomGrantTypes = new List<string> { "urn:opcfoundation.org:oauth2:site_token" },
                        AllowAccessToAllScopes = true
                    });
                }
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Error checking if the application has been registerd.");
            }

            return Task.FromResult<Client>(null);
        }
    }

    /// <summary>
    /// Parses the environment for an X509 client certificate
    /// </summary>
    public class ApplicationCertificateSecretParser : ISecretParser
    {
        private GlobalDiscoveryServerServer m_server;

        public ApplicationCertificateSecretParser(GlobalDiscoveryServerServer server)
        {
            m_server = server;
        }

        /// <summary>
        /// Tries to find a secret on the environment that can be used for authentication
        /// </summary>
        /// <param name="environment">The environment.</param>
        /// <returns>
        /// A parsed secret
        /// </returns>
        public async Task<ParsedSecret> ParseAsync(IDictionary<string, object> environment)
        {
            var context = new OwinContext(environment);

            if (!context.Request.Body.CanSeek)
            {
                var copy = new MemoryStream();
                await context.Request.Body.CopyToAsync(copy);
                copy.Seek(0L, SeekOrigin.Begin);
                context.Request.Body = copy;
            }

            context.Request.Body.Seek(0L, SeekOrigin.Begin);
            var body = await context.Request.ReadFormAsync();
            context.Request.Body.Seek(0L, SeekOrigin.Begin);

            var grantType = body.Get("grant_type");

            if (String.IsNullOrEmpty(grantType))
            {
                return null;
            }

            var clientId = body.Get("client_id");

            if (String.IsNullOrEmpty(clientId))
            {
                return null;
            }

            var clientSecret = body.Get("client_secret");

            if (String.IsNullOrEmpty(clientSecret))
            {
                return null;
            }

            if (grantType == "client_credentials")
            {
                return new ParsedSecret
                {
                    Id = clientId,
                    Credential = clientSecret.Sha256(),
                    Type = "SharedSecret"
                };
            }

            var certificate = Convert.FromBase64String(clientId);
            var signature = Convert.FromBase64String(clientSecret);

            var data = body.Get("access_token");

            if (String.IsNullOrEmpty(data))
            {
                return null;
            }

            var accessToken = data;

            data = body.Get("nonce");

            if (String.IsNullOrEmpty(data))
            {
                return null;
            }

            var nonce = Convert.FromBase64String(data);

            try
            {
                // validate the certificate.
                X509Certificate2 x509 = new X509Certificate2(certificate);
                m_server.CertificateValidator.Validate(x509);

                var applicationUri = Utils.GetApplicationUriFromCertficate(x509);

                // verify signature.
                var dataToVerify = Utils.Append(new UTF8Encoding(false).GetBytes(accessToken), nonce);

                if (!RsaUtils.RsaPkcs15Sha1_Verify(new ArraySegment<byte>(dataToVerify), signature, x509))
                {
                    return null;
                }

                return new ParsedSecret
                {
                    Id = applicationUri,
                    Credential = x509,
                    Type = "ApplicationSignature"
                };
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Validates a secret based on the thumbprint of an X509 Certificate
    /// </summary>
    public class ApplicationCertificateSecretValidator : ISecretValidator
    {
        /// <summary>
        /// Validates a secret
        /// </summary>
        /// <param name="secrets">The stored secrets.</param>
        /// <param name="parsedSecret">The received secret.</param>
        /// <returns>
        /// A validation result
        /// </returns>
        /// <exception cref="System.ArgumentException">ParsedSecret.Credential is not an X509 Certificate</exception>
        public Task<SecretValidationResult> ValidateAsync(IEnumerable<Secret> secrets, ParsedSecret parsedSecret)
        {
            var fail = Task.FromResult(new SecretValidationResult { Success = false });
            var success = Task.FromResult(new SecretValidationResult { Success = true });

            if (parsedSecret.Type == "SharedSecret")
            {
                foreach (var secret in secrets)
                {
                    if (secret.Value.Equals(parsedSecret.Credential))
                    {
                        return success;
                    }
                }

                return fail;
            }

            if (parsedSecret.Type != "ApplicationSignature")
            {
                return fail;
            }

            var certificate = parsedSecret.Credential as X509Certificate2;

            if (certificate == null)
            {
                throw new ArgumentException("ParsedSecret.Credential is not an X509 Certificate");
            }

            return success;
        }
    }

    class CustomGrantValidator : ICustomGrantValidator
    {
        private AuthorizationServiceConfiguration m_configuration;

        public CustomGrantValidator(AuthorizationServiceConfiguration configuration)
        {
            m_configuration = configuration;
        }

        public Task<CustomGrantValidationResult> ValidateAsync(ValidatedTokenRequest request)
        {
            var accessToken = request.Raw.Get("access_token");
            var identity = JwtUtils.ValidateToken(new Uri("https://login.microsoftonline.com/opcfoundationprototyping.onmicrosoft.com"), "https://localhost:62540/prototypeserver", accessToken);
            JwtSecurityToken azureToken = identity.GetSecurityToken() as JwtSecurityToken;

            var scope = request.Raw.Get("scope");
            var nonce = request.Raw.Get("nonce");

            DateTime now = DateTime.UtcNow;
            double maxClockSkewInMinutes = 10;

            if (azureToken.ValidFrom.AddMinutes(-maxClockSkewInMinutes) > now || azureToken.ValidTo.AddMinutes(maxClockSkewInMinutes) < now)
            {
                return Task.FromResult(new CustomGrantValidationResult(
                    "Access token provided with the request has expired (" + 
                    azureToken.ValidTo.ToLocalTime().ToString("yyy-MM-dd HH:mm:ss") + 
                    ") or is not yet valid (" + 
                    azureToken.ValidFrom.ToLocalTime().ToString("yyy-MM-dd HH:mm:ss") + ")."));
            }
            
            List<Claim> claims = new List<Claim>();
            string subject = request.Client.ClientId;

            foreach (var claim in azureToken.Claims)
            {
                switch (claim.Type)
                {
                    case "unique_name": { subject = claim.Value; claims.Add(claim); break; }
                    case "name": { claims.Add(claim); break; }
                }
            }

            // add nonce to protect against replay attacks.
            claims.Add(new Claim("nonce", nonce));

            // make sure new token does not last longer than the original token.
            request.Client.AccessTokenLifetime = (int)(azureToken.ValidTo - now).TotalSeconds;

            var result = new CustomGrantValidationResult(
                subject,
                "site_token",
                claims,
                "gds");

            return Task.FromResult(result);
        }

        public string GrantType
        {
            get { return "urn:opcfoundation.org:oauth2:site_token"; }
        }
    }

    class CustomTokenService : DefaultTokenService
    {
        public static GlobalDiscoveryServerServer Server;
        public static AuthorizationServiceConfiguration Configuration;

        public CustomTokenService(IdentityServerOptions options, IClaimsProvider claimsProvider, ITokenHandleStore tokenHandles, ITokenSigningService signingService, IEventService events) 
            : base(options, claimsProvider, tokenHandles, signingService, events)
        {
        }

        public async override Task<Token> CreateAccessTokenAsync(TokenCreationRequest request)
        {
            var token = await base.CreateAccessTokenAsync(request);

            token.Lifetime = token.Client.AccessTokenLifetime;

            // ensure a valid resource.
            var resource = request.ValidatedRequest.Raw["resource"];

            if (String.IsNullOrEmpty(resource) || resource == Namespaces.OAuth2SiteResourceUri)
            {
                token.Audience = Server.CurrentInstance.ServerUris.GetString(0);
            }
            else
            {
                token.Audience = resource;
            }

            UriBuilder uri = new UriBuilder(token.Issuer);
            uri.Host = uri.Host.ToLowerInvariant();
            token.Issuer = uri.ToString();

            // remove the non-standard "scope" claim.
            for (int ii = 0; ii < token.Claims.Count;)
            {
                if (token.Claims[ii].Type == "scope")
                {
                    token.Claims.RemoveAt(ii);
                    continue;
                }

                ii++;
            }

            // build list of allowed scopes.
            if (Configuration != null && Configuration.Scopes != null)
            {
                foreach (var mapping in Configuration.Scopes)
                {
                    if (mapping.Users != null)
                    {
                        foreach (var user in mapping.Users)
                        {
                            if (user == token.SubjectId)
                            {
                                token.Claims.Add(new Claim("scp", mapping.Scope));
                                break;
                            }
                        }
                    }

                    if (mapping.Clients != null)
                    {
                        foreach (var user in mapping.Clients)
                        {
                            if (user == token.ClientId)
                            {
                                token.Claims.Add(new Claim("scp", mapping.Scope));
                                break;
                            }
                        }
                    }
                }
            }

            return token;
        }
    }
}
