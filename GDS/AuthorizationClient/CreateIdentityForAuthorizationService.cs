using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Client;
using System.IdentityModel.Tokens;
using System.Windows.Forms;
using Opc.Ua.Gds;

namespace AuthorizationClient
{
    partial class Program
    { 
        static async Task<UserIdentity> CreateIdentityForAuthorizationService(ApplicationInstance application, string resourceId, UserTokenPolicy policy)
        {
            if (policy.TokenType == UserTokenType.Anonymous)
            {
                return new UserIdentity() { PolicyId = policy.PolicyId };
            }

            if (policy.TokenType == UserTokenType.UserName)
            {
                return new UserIdentity("appadmin", "demo") { PolicyId = policy.PolicyId };
            }

            if (policy.TokenType == UserTokenType.Certificate)
            {
                // TBD - Load User Certificate
                throw new NotSupportedException();
            }

            if (policy.TokenType == UserTokenType.IssuedToken)
            {
                if (policy.IssuedTokenType == "http://opcfoundation.org/UA/UserToken#JWT")
                {
                    JwtEndpointParameters parameters = new JwtEndpointParameters();
                    parameters.FromJson(policy.IssuerEndpointUrl);

                    if (parameters.AuthorityProfileUri == Profiles.AzureAuthorization)
                    {
                        return await GetTokenFromAzure(application, resourceId, policy, parameters);
                    }
                }
            }

            throw new NotSupportedException();
        }


        static async Task<UserIdentity> GetTokenFromAzure(ApplicationInstance application, string resourceId, UserTokenPolicy policy, JwtEndpointParameters parameters)
        {
            // find the client's information needed to connection to the Azure identity provider.
            var credentials = OAuth2CredentialCollection.FindByAuthorityUrl(application.ApplicationConfiguration, parameters.AuthorityUrl);

            if (credentials == null)
            {
                throw new ServiceResultException(StatusCodes.BadConfigurationError, "No OAuth2 configuration specified for the selected GDS.");
            }

            credentials.AuthorizationEndpoint = parameters.AuthorizationEndpoint;
            credentials.TokenEndpoint = parameters.TokenEndpoint;
            credentials.ServerResourceId = parameters.ResourceId;

            if (parameters.RequestTypes.Contains(Opc.Ua.JwtConstants.OAuth2AuthorizationCode))
            {
                var accessToken = new OAuth2CredentialsDialog().ShowDialog(credentials);

                if (accessToken == null)
                {
                    return null;
                }

                var jwt = new JwtSecurityToken(accessToken.AccessToken);
                return new UserIdentity(jwt) { PolicyId = policy.PolicyId };
            }

            if (parameters.RequestTypes.Contains(Opc.Ua.JwtConstants.OAuth2ClientCredentials))
            {
                var accessToken = await new Opc.Ua.Gds.AuthorizationClient().RequestTokenWithClientCredentialsAsync(credentials, resourceId, null);

                if (accessToken == null)
                {
                    return null;
                }

                var jwt = new JwtSecurityToken(accessToken.AccessToken);
                return new UserIdentity(jwt) { PolicyId = policy.PolicyId }; 
            }

            throw new NotSupportedException();
        }
    }
}
