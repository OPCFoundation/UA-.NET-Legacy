# OAuth2 Prototype Readme #
## Overview ##
The OAuth2 Prototype codebase includes 5 elements:

* Modified C# Stack that supports OAuth2 UserIdentityTokens;
* A GDS Server that supports OAuth2 UserIdentityTokens and the new Role-base Authorization model;
* A GDS Server that supports the PubSub GetSecurityKeys Method;
* A C# Client that requests OAuth2 token and uses it to make a Session-less Service via HTTPS;
* A basic ANSI C Client able to request OAuth2 tokens via HTTPS and call GetSecurityKeys as a Session-less service call; 
* A basic ANSI C Client able to request OAuth2 tokens via HTTPS and call GetSecurityKeys as a regular Method call via OPC UA TCP; 

## OAuth2 ##
### OAuth2 Authorization Services ###
OAuth2 is a widely used standard for user authenication based on HTTPS. The prototype makes use of 2 OAuth2 services:

1. An Azure AD instance installed at opcfoundation-prototyping.servicebus.windows.net;
2. The IdentityServer3 (https://github.com/IdentityServer/IdentityServer3) C# based framework which is incorporated into the GDS;

The Azure AD instance has 4 test accounts:

| Account | Groups | Password |
|---------|--------|----------|
|device1@opcfoundationprototyping.onmicrosoft.com|Producers|Joyo9630|
|hmi1@opcfoundationprototyping.onmicrosoft.com|Consumers||
|device2@opcfoundationprototyping.onmicrosoft.com|Consumers||
|hmi2@opcfoundationprototyping.onmicrosoft.com|Producers||

### OAuth2 Server Configuration ###
If a OPC UA Server supports OAuth2 then it will publish a UserTokenPolicy with IssuedTokenType=http://opcfoundation.org/UA/UserTokenPolicy#JWT 

The IssuerEndpointUrl is a JSON object that looks like this:

```json
{ 
	"authority": "https://localhost:54333", 
	"grantType" : "site_token", 
	"resource" : "urn:localhost:somecompany.com:GlobalDiscoveryServer",
	"tokenEndpoint" : "/connect/token", 
	"scopes": [ "gdsadmin", "appadmin", "observer" ], 
	"sources": [ "https://login.microsoftonline.com/opcfoundationprototyping.onmicrosoft.com" ]
}
```
where the authority specifies the URL of the Authorization Service which provides JWTs that that the Server accepts. The scopes are used to by the Server to determine what priviledges to grant to the Client that provided the JWT. The resource is the string that identifies the Server to the Authorization Service. If not specified the resource is the Server ApplicationUri.

The grantType 'site_token' indicates that the Server accepts JWTs issued by other Authorization Services. In these cases, the 'sources' must be specified which provide the base URL for the external Authorization Services which the Server accepts. 

### OAuth2 Client Configuration ###
Clients can call GetEndpoints to read to the UserTokenPolicies from the Server.

To request a token from an Authorization Service a Client must be registered with that Service. These credentials are specified in the Client configuration with an XML element that looks like this:

```xml
<OAuth2Credential>
  <AuthorityUrl>https://login.microsoftonline.com/opcfoundationprototyping.onmicrosoft.com</AuthorityUrl>
  <GrantType>authorization_code</GrantType>
  <ClientId>f8b31779-d9a3-43ff-b854-28f27a52e2f2</ClientId>
  <RedirectUrl>https://localhost:62540/prototypeclient</RedirectUrl>
  <TokenEndpoint>/oauth2/token</TokenEndpoint>
  <AuthorizationEndpoint>/oauth2/authorize</AuthorizationEndpoint>          
  <Servers>
    <OAuth2ServerSettings>
      <ApplicationUri>urn:localhost:somecompany.com:GlobalDiscoveryServer</ApplicationUri>
      <ResourceId>https://localhost:62540/prototypeserver</ResourceId>
    </OAuth2ServerSettings>
  </Servers>
</OAuth2Credential>
```

The OAuth2ServerSettings element allows the administrator to specify additional parameters needed to identify the Server to the Authorization Service. If this element is missing the Client should use the resource provided by the Server in the UserTokenPolicy.

If the Server accepts the site_token GrantType then the OPC UA Application Certificate is used to identify the Client to the Authorization Service.

## GDS OAuth2 Authorization Service ##
### Overview ###
The IdentityServer3 (https://github.com/IdentityServer/IdentityServer3) C# based framework which is incorporated into the GDS.

This implementation uses the database of registered applications to validate clients so applications do not have to be registered twice. It also accepts tokens issued by Azure AD in lieu of a username/password known to the GDS.

### Setup ###
Setting up the GDS OAuth2 Service on a new machine requires that a HTTPS certificate be created and then registered with windows. This can be done with the Windows Power Shell (must be launched with Administrator priviledges). The steps are:

Create a new certificate (replace <hostname> with the actual hostname):
```
New-SelfSignedCertificate -DnsName <hostname> -CertStoreLocation cert:Localmachine\My -HashAlgorithm SHA256
```

Register the ports (Authorization Service and GDS HTTPS Endpoint):
```
netsh
http
add sslcert ipport=0.0.0.0:54333 certhash=<thumprint> appid={00112233-4455-6677-8899-AABBCCDDEEFF}
add sslcert ipport=0.0.0.0:58811 certhash=<thumprint> appid={00112233-4455-6677-8899-AABBCCDDEEFF}
```
The appid can be any valid GUID. 
The certhash is the thumprint created in the first step.

## Session-less Service Calls ##
The GDS supports Session-less calls for the GetSecurityKeys Method defined in the PubSub specification. This allows Clients to request SecurityKeys associated with a PubSub group without creating a Session with the GDS if they first request an OAuth2 token from a Authorization Service. This can be done by either:

* Creating a OPC UA TCP SecureChannel and invoke the Call Service with the AuthenticationToken set to the JWT returned from OAuth2 Authorization Service;
* Use HTTPS post to invoke Call Service with the JWT passed in the HTTP Authorization Header; 

The SessionlessMethodCallClient project is simple C# application that uses the second option.

## Simple OAuth2 Client ##
The oauth2_client solution is a simple application written in ANSI C that calls the GetSecurityKeys Method on the GDS using Session-less Service calls. The application simple calls GetSecurityKeys twice using OPC UA TCP and HTTPS. 
