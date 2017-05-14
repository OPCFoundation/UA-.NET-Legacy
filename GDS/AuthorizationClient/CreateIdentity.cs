using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
using System.IdentityModel.Tokens;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Opc.Ua.Gds;

namespace AuthorizationClient
{
    partial class Program
    {
        static async Task<IUserIdentity> CreateIdentity(ApplicationInstance application, EndpointDescription target, UserTokenPolicy policy)
        {
            if (policy.TokenType == UserTokenType.Anonymous)
            {
                return new UserIdentity() { PolicyId = policy.PolicyId };
            }

            if (policy.TokenType == UserTokenType.UserName)
            {
                return CreateUserNameIdentity(application, target, policy);
            }

            if (policy.TokenType == UserTokenType.IssuedToken)
            {
                if (policy.IssuedTokenType == "http://opcfoundation.org/UA/UserToken#JWT")
                {
                    JwtEndpointParameters parameters = new JwtEndpointParameters();
                    parameters.FromJson(policy.IssuerEndpointUrl);

                    // choose a default resource id for the target server.
                    if (parameters.ResourceId == null)
                    {
                        parameters.ResourceId = target.Server.ApplicationUri;
                    }

                    // check if target server expects clients to use an OAuth2 service. 
                    if (parameters.AuthorityProfileUri == Profiles.OAuth2Authorization)
                    {
                        return await GetJwtWithOAuth2(application, policy, parameters);
                    }

                    // check if target server expects clients to use an OPCUA authorization service. 
                    if (parameters.AuthorityProfileUri == Profiles.OpcUaAuthorization)
                    {
                        return await GetJwtWithOpcUa(application, policy, parameters);
                    }
                }
            }

            throw new NotSupportedException();
        }

        static IUserIdentity CreateUserNameIdentity(ApplicationInstance application, EndpointDescription target, UserTokenPolicy policy)
        {
            return new UserIdentity("appadmin", "demo") { PolicyId = policy.PolicyId };
        }

        static async Task<IUserIdentity> GetJwtWithOpcUa(ApplicationInstance application, UserTokenPolicy policy, JwtEndpointParameters parameters)
        {
            // find the client's information needed to connection to the Azure identity provider.
            var credentials = OAuth2CredentialCollection.FindByAuthorityUrl(application.ApplicationConfiguration, parameters.AuthorityUrl);

            if (credentials == null)
            {
                throw new ServiceResultException(StatusCodes.BadConfigurationError, "No configuration specified for the selected Authority.");
            }

            // this identity is used to determine the client can access the authorization service.
            var requestorIdentity = new UserIdentity(credentials.ClientId, credentials.ClientSecret);

            var endpoint = EndpointDescription.SelectEndpoint(application.ApplicationConfiguration, parameters.AuthorityUrl, true);
            EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(application.ApplicationConfiguration);
            ConfiguredEndpoint ce = new ConfiguredEndpoint(null, endpoint, endpointConfiguration);

            Session session = null;

            try
            {
                session = Session.Create(
                    application.ApplicationConfiguration,
                    ce,
                    false,
                    false,
                    "Authorization Client",
                    60000,
                    requestorIdentity,
                    null);

                var eid = ExpandedNodeId.Parse(parameters.TokenEndpoint);
                var nid = ExpandedNodeId.ToNodeId(eid, session.NamespaceUris);

                byte[] continuationPoint = null;
                ReferenceDescriptionCollection references = null;

                session.Browse(
                    null,
                    null,
                    nid,
                    0,
                    BrowseDirection.Forward,
                    ReferenceTypeIds.HasProperty,
                    false,
                    0,
                    out continuationPoint,
                    out references);

                NodeId policiesNodeId = null;

                if (references != null || references.Count > 0)
                {
                    foreach (var reference in references)
                    {
                        if (reference.BrowseName.Name == Opc.Ua.Gds.BrowseNames.UserTokenPolicies)
                        {
                            policiesNodeId = ExpandedNodeId.ToNodeId(reference.NodeId, session.NamespaceUris);
                            break;
                        }
                    }
                }

                var dv = session.ReadValue(policiesNodeId);
                var policies = (UserTokenPolicy[])ExtensionObject.ToArray(dv.Value, typeof(UserTokenPolicy));
                var selectedPolicy = SelectUserTokenPolicy(policies);

                // get the user credentials used to request an access token.
                // unlike the requestor identity these credentials are passed onto the authorization service if the GDS is wrapping one.
                var identity = await CreateIdentityForAuthorizationService(application, parameters.ResourceId, selectedPolicy);

                if (identity == null)
                {
                    return null;
                }

                // encrypt or sign the credentials.
                var token = identity.GetIdentityToken();

                // hack until part 4 is finialized.
                token.Encrypt(
                    new X509Certificate2(endpoint.ServerCertificate),
                    endpoint.ServerCertificate,
                    selectedPolicy.SecurityPolicyUri);

                var outputArguments = session.Call(
                    nid,
                    ExpandedNodeId.ToNodeId(Opc.Ua.Gds.MethodIds.AuthorizationServiceType_RequestAccessToken, session.NamespaceUris),
                    token,
                    parameters.ResourceId);

                // return the new access token.
                var accessToken = outputArguments[0] as string;
                JwtSecurityToken securityToken = new JwtSecurityToken(accessToken);
                return new UserIdentity(securityToken) { PolicyId = policy.PolicyId };
            }
            finally
            {
                if (session != null)
                {
                    session.Close();
                    session.Dispose();
                    session = null;
                }
            }
        }

        static async Task<IUserIdentity> GetJwtWithOAuth2(ApplicationInstance application, UserTokenPolicy policy, JwtEndpointParameters parameters)
        {
            if (parameters.RequestTypes.Contains(Opc.Ua.JwtConstants.OAuth2ClientCredentials))
            {
                // find the client's information needed to connection to the Azure identity provider.
                var credentials = OAuth2CredentialCollection.FindByAuthorityUrl(application.ApplicationConfiguration, parameters.AuthorityUrl);

                if (credentials == null)
                {
                    throw new ServiceResultException(StatusCodes.BadConfigurationError, "No configuration specified for the selected Authority.");
                }

                credentials.TokenEndpoint = parameters.TokenEndpoint;

                // get token from OAuth2 server.
                var client = new Opc.Ua.Gds.AuthorizationClient() { Configuration = application.ApplicationConfiguration };
                var accessToken = await client.RequestTokenWithClientCredentialsAsync(credentials, parameters.ResourceId, "UAServer");

                // return user identity.
                JwtSecurityToken securityToken = new JwtSecurityToken(accessToken.AccessToken);
                return new UserIdentity(securityToken) { PolicyId = policy.PolicyId };
            }

            throw new NotSupportedException();
        }
    }
}
