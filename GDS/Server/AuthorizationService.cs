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

            string hostname = application.ApplicationConfiguration.GetDefaultHostName();

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
            factory.ClientStore = new Registration<IClientStore>(new ApplicationClientStore(ServiceConfiguration, Server));

            CustomTokenService.Server = Startup.Server;
            CustomTokenService.Configuration = Startup.ServiceConfiguration;

            var options = new IdentityServerOptions
            {
                SiteName = "GDS AuthorizationService",

                SigningCertificate = LoadCertificate(),
                Factory = factory,
                InputLengthRestrictions = new InputLengthRestrictions() { Password = 2048, ClientId = 2048 },
   
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
                new Scope { Name = "UAPubSub" },
                new Scope { Name = "UAServer" }
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
                return Task.FromResult(new Client
                {
                    ClientName = clientId,
                    ClientId = clientId,
                    Enabled = true,
                    AccessTokenType = AccessTokenType.Jwt,
                    Flow = Flows.Custom,
                    ClientSecrets = new List<Secret>(),
                    AllowAccessToAllCustomGrantTypes = true,
                    AllowedCustomGrantTypes = new List<string> { "urn:opcfoundation.org:oauth2:site_token" },
                    AllowAccessToAllScopes = true
                });
            }
            catch (Exception e)
            {
                Utils.Trace(e, "Error checking if the application has been registerd.");
            }

            return Task.FromResult<Client>(null);
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

            List<string> scopes = new List<string>();
            List<string> roles = new List<string>();

            // build list of allowed scopes and roles for the client.
            if (Configuration != null && Configuration.Clients != null)
            {
                foreach (var mapping in Configuration.Clients)
                {
                    if (mapping.ClientId == token.ClientId)
                    {
                        if (mapping.AllowedScopes != null)
                        {
                            foreach (var scope in mapping.AllowedScopes)
                            {
                                if (!scopes.Contains(scope))
                                {
                                    scopes.Add(scope);
                                }
                            }
                        }

                        if (mapping.AllowedRoles != null)
                        {
                            foreach (var role in mapping.AllowedRoles)
                            {
                                if (!roles.Contains(role))
                                {
                                    roles.Add(role);
                                }
                            }
                        }
                    }
                }
            }

            // build list of allowed scopes and roles for the user.
            if (Configuration != null && Configuration.Users != null)
            {
                foreach (var mapping in Configuration.Users)
                {
                    if (mapping.ClientId == token.SubjectId)
                    {
                        if (mapping.AllowedScopes != null)
                        {
                            foreach (var scope in mapping.AllowedScopes)
                            {
                                if (!scopes.Contains(scope))
                                {
                                    scopes.Add(scope);
                                }
                            }
                        }

                        if (mapping.AllowedRoles != null)
                        {
                            foreach (var role in mapping.AllowedRoles)
                            {
                                if (!roles.Contains(role))
                                {
                                    roles.Add(role);
                                }
                            }
                        }
                    }
                }
            }

            // add name.
            bool nameFound = false;

            foreach (var claim in token.Claims)
            {
                if (claim.Type == "name" || claim.Type == "unique_name")
                {
                    nameFound = true;
                    break;
                }
            }

            if (!nameFound)
            {
                token.Claims.Add(new Claim("name", token.Client.ClientName));
            }

            // add scopes.
            if (scopes.Count > 0)
            {
                foreach (var scope in scopes)
                {
                    token.Claims.Add(new Claim("scp", scope));
                }
            }

            // add roles.
            if (roles.Count > 0)
            {
                foreach (var role in roles)
                {
                    token.Claims.Add(new Claim("roles", role));
                }
            }

            return token;
        }
    }
}
