# OAuth2 Prototype Readme #
## Overview ##
The OAuth2 Prototype codebase includes these elements:

* Modified C# Stack that supports OAuth2 UserIdentityTokens;
* A GDS Server that supports OAuth2 UserIdentityTokens and the new Role-base Authorization model;
* A GDS Server that supports the PubSub GetSecurityKeys Method;
* A C# Client that requests OAuth2 token and uses it to make a Session-less Service via HTTPS;
* A basic ANSI C Client able to request OAuth2 tokens via HTTPS and call GetSecurityKeys as a Session-less service call; 
* A basic ANSI C Client able to request OAuth2 tokens via HTTPS and call GetSecurityKeys as a regular Method call via OPC UA TCP; 
* A C# Server that accepts different types of UserIdentityTokens;
* A C# Client allows users to interactively choose different ways to provide and UserIdentityToken for the Server.

## OAuth2 ##
### OAuth2 Authorization Services ###
OAuth2 is a widely used standard for user authenication based on HTTPS. The prototype makes use of 2 OAuth2 services:

1. An Azure AD instance installed at opcfoundation-prototyping.servicebus.windows.net;
2. The IdentityServer3 (https://github.com/IdentityServer/IdentityServer3) C# based framework which is incorporated into the GDS;

The Azure AD instance has 4 test accounts:

| Account | Groups | Password |
|---------|--------|----------|
|device1@opcfoundationprototyping.onmicrosoft.com|Producers|AGu59HU8|
|hmi1@opcfoundationprototyping.onmicrosoft.com|Consumers|AGu59HU8|
|device2@opcfoundationprototyping.onmicrosoft.com|Consumers|AGu59HU8|
|hmi2@opcfoundationprototyping.onmicrosoft.com|Producers|AGu59HU8|

### OAuth2 Server Configuration ###
If a OPC UA Server supports OAuth2 then it will publish a UserTokenPolicy with IssuedTokenType=http://opcfoundation.org/UA/UserTokenPolicy#JWT 

The IssuerEndpointUrl for a basic OAuth2 service is a JSON object that looks like this:

```json
{ 
	"ua:authorityUrl": "https://localhost:54333", 
	"ua:authorityProfileUri" : "http://opcfoundation.org/UA/Authorization#OAuth2", 
	"ua:tokenEndpoint" : "/connect/token", 
	"ua:requestTypes": [ "client_credentials" ],
	"ua:scopes": [ "UAPubSub", "UAServer" ]
}
```
where the authorityUrl specifies the URL of the Authorization Service which provides JWTs that that the Server accepts. The scopes are used to by the Server to determine what type of access to grant to the Client that provided the JWT. The resource is the string that identifies the Server to the Authorization Service. If not specified the resource is the Server ApplicationUri.

The IssuerEndpointUrl for an Azure OAuth2 service looks like this:

```json                  
{
	"ua:authorityUrl": "https://login.microsoftonline.com/opcfoundationprototyping.onmicrosoft.com",
	"ua:authorityProfileUri" : "http://opcfoundation.org/UA/Authorization#Azure",
	"ua:authorizationEndpoint" : "/oauth2/authorize",
	"ua:tokenEndpoint" : "/oauth2/token",
	"ua:requestTypes": [ "authorization_code" ],
	"ua:resourceId" : "https://mycompany.com/gds-prototype"
}
```
where authorizationEndpoint is the endpoint which supports an Azure API used to request an authorization code. Accessing this API requires that a web browser window be displayed which allows a human user to provide credentials to Azure AD which teh application cannot see (or absuse). This API returns and authorization code which is passed to the tokenEndpoint using standard OAuth2 calls. 

Lastly, this JSON object specifies a OPC-UA Authorization Service Object that can provide JWTs:

```json    
{
	"ua:authorityUrl": "opc.tcp://localhost:58810",
	"ua:authorityProfileUri" : "http://opcfoundation.org/UA/Authorization#OPCUA",
	"ua:tokenEndpoint" : "nsu=http://opcfoundation.org/UA/GDS/applications/;s=Local"
}
```
where the tokenEndpoint is a UA JSON encoded NodeId (see Part 6). Authorization Service Object is configured in the GDS with the AuthorizationServices XML element. Each AuthorizationService may specify 1 or more UserIdentityTokens which can be used to request a new JWT. These UserIdentityTokens may refer another OAuth2 service such as Azure AD which allows AuthorizationServices to be chained together. This would allow a service like Azure to manage the users while the GDS managed the Roles assigned to the users.

A number of sequence diagrams that illustrate the different scenarios can be found [here](AuthorizationClient/AuthorizationClient.pdf).

### OAuth2 Client Configuration ###
Clients can call GetEndpoints to read to the UserTokenPolicies from the Server.

To request a token from an OAuth2 service a Client must be registered with that Service. These credentials are specified in the Client configuration with an XML element that looks like this:

```xml
<OAuth2Credential>
  <AuthorityUrl>https://login.microsoftonline.com/opcfoundationprototyping.onmicrosoft.com</AuthorityUrl>
  <GrantType>authorization_code</GrantType>
  <ClientId>f8b31779-XXXX-XXXX-XXXX-28f27a52e2f2</ClientId>
  <RedirectUrl>https://localhost:62540/prototypeclient</RedirectUrl>
  <TokenEndpoint>/oauth2/token</TokenEndpoint>
  <AuthorizationEndpoint>/oauth2/authorize</AuthorizationEndpoint>
</OAuth2Credential>
<OAuth2Credential>
  <AuthorityUrl>https://localhost:54333</AuthorityUrl>
  <GrantType>client_credentials</GrantType>
  <ClientId>urn:localhost:OAuth2TestClient2</ClientId>
  <ClientSecret>---</ClientSecret>
</OAuth2Credential>
```
The information required depends on the GrantType. 

## GDS OAuth2 Authorization Service ##
The IdentityServer3 (https://github.com/IdentityServer/IdentityServer3) C# based framework which is incorporated into the GDS.

This implementation uses the database of registered applications to validate clients so applications do not have to be registered twice. 
It also accepts tokens issued by Azure AD in lieu of a username/password known to the GDS.

The setup of the GDS DB can be found [here](gdsdb_setup.md).

## GDS OPC-UA Authorization Service ##
The GDS provides one AuthorizationService Object (Local) which allows Clients that do not support OAuth2 to request JWTs.

The Authorization Server provides an example of a Server with a UserTokenPolcy that references the GDS OPC-UA AuthorizationService.
The Authorization Client provides an example of Client that requests a JWT from this AuthorizationService.

## Session-less Service Calls ##
The GDS supports Session-less calls for the GetSecurityKeys Method defined in the PubSub specification. This allows Clients to request SecurityKeys associated with a PubSub group without creating a Session with the GDS if they first request an OAuth2 token from a Authorization Service. This can be done by either:

* Creating a OPC UA TCP SecureChannel and invoke the Call Service with the AuthenticationToken set to the JWT returned from OAuth2 Authorization Service;
* Use HTTPS post to invoke Call Service with the JWT passed in the HTTP Authorization Header; 

The SessionlessMethodCallClient project is simple C# application that uses the second option.

## Authorization Server ##
The AuthorizationServer project is a simple Server that accepts JWTs as UserIdentityTokens. It is used with the AuthorizationClient project to illustrate the process of discovering and requesting JWTs.

## Authorization Client ##
The AuthorizationClient project is a console Server that queries a Server for its supported UserIdentityToken and allows the user to pick one. If the UserIdentityToken requires a JWT issued by an Authorization Service it connects to the Authorization Service and requests the JWT.

  
