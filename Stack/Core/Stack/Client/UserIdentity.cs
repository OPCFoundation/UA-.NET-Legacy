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
using System.IdentityModel.Selectors;
using System.IdentityModel.Tokens;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;
using System.ServiceModel.Security;
using System.Text;
using System.Xml;

namespace Opc.Ua
{    
    /// <summary>
    /// A generic user identity class.
    /// </summary>
    public class UserIdentity : IUserIdentity
    {
        #region Constructors
        /// <summary>
        /// Initializes the object as an anonymous user.
        /// </summary>
        public UserIdentity()
        {
            m_tokenType = UserTokenType.Anonymous;
            m_displayName = "Anonymous";
            m_token = null;
        }

        /// <summary>
        /// Initializes the object with a username and password.
        /// </summary>
        /// <param name="username">The user name.</param>
        /// <param name="password">The password.</param>
        public UserIdentity(string username, string password)
        {
            Initialize(username, password);
        }

        /// <summary>
        /// Initializes the object with an X509 certificate identifier
        /// </summary>
        /// <param name="certificateId">The certificate identifier.</param>
        public UserIdentity(CertificateIdentifier certificateId)
        {
            Initialize(certificateId);
        }

        /// <summary>
        /// Initializes the object with an X509 certificate
        /// </summary>
        /// <param name="certificate">The X509 certificate.</param>
        public UserIdentity(X509Certificate2 certificate)
        {
            Initialize(certificate);
        }

        /// <summary>
        /// Initializes the object with a .NET security token
        /// </summary>
        /// <param name="token">The security token.</param>
        public UserIdentity(SecurityToken token)
        {
            Initialize(token);
        }

        /// <summary>
        /// Initializes the object with a UA identity token.
        /// </summary>
        /// <param name="token">The user identity token.</param>
        public UserIdentity(UserIdentityToken token)
        {
            Initialize(token);
        }

        /// <summary>
        /// Initializes the object with a UA identity token.
        /// </summary>
        /// <param name="token">The token.</param>
        /// <param name="serializer">The token serializer.</param>
        /// <param name="resolver">The token resolver.</param>
        public UserIdentity(IssuedIdentityToken token, SecurityTokenSerializer serializer, SecurityTokenResolver resolver)
        {
            Initialize(token, serializer, resolver);
        }        
        #endregion

        #region IUserIdentity Methods
        /// <summary>
        /// Gets or sets the UserIdentityToken PolicyId associated with the UserIdentity.
        /// </summary>
        /// <remarks>
        /// This value is used to initialize the UserIdentityToken object when GetIdentityToken() is called.
        /// </remarks>
        public string PolicyId
        {
            get { return m_policyId; }
            set { m_policyId = value; }
        }
        #endregion

        #region IUserIdentity Methods
        /// <summary cref="IUserIdentity.DisplayName" />
        public string DisplayName
        {
            get { return m_displayName; }
        }

        /// <summary cref="IUserIdentity.TokenType" />
        public UserTokenType TokenType
        {
            get { return m_tokenType; }
        }
        
        /// <summary cref="IUserIdentity.IssuedTokenType" />
        public XmlQualifiedName IssuedTokenType
        {
            get { return m_issuedTokenType; }
        }        

        /// <summary cref="IUserIdentity.SupportsSignatures" />
        public bool SupportsSignatures
        {
            get  
            {
                if (m_token is X509SecurityToken)
                {
                    return true;
                }

                return false; 
            }
        }

        /// <summary cref="IUserIdentity.GetSecurityToken" />
        public SecurityToken GetSecurityToken()
        {
            return m_token;
        }

        /// <summary cref="IUserIdentity.GetIdentityToken" />
        public UserIdentityToken GetIdentityToken()
        {
            // check for anonymous.
            if (m_token == null)
            {
                AnonymousIdentityToken token = new AnonymousIdentityToken();
                token.PolicyId = m_policyId;
                return token;
            }

            // return a user name token.
            UserNameSecurityToken usernameToken = m_token as UserNameSecurityToken;

            if (usernameToken != null)
            {
                UserNameIdentityToken token = new UserNameIdentityToken();
                token.PolicyId = m_policyId;
                token.UserName = usernameToken.UserName;
                token.DecryptedPassword = usernameToken.Password;
                return token;
            }

            // return an X509 token.
            X509SecurityToken x509Token = m_token as X509SecurityToken;

            if (x509Token != null)
            {
                X509IdentityToken token = new X509IdentityToken();
                token.PolicyId = m_policyId;
                token.CertificateData = x509Token.Certificate.GetRawCertData();
                token.Certificate = x509Token.Certificate;
                return token;
            }
            
            // handle SAML token.
            SamlSecurityToken samlToken = m_token as SamlSecurityToken;

            if (samlToken != null)
            {
                MemoryStream ostrm = new MemoryStream();      
                XmlTextWriter writer = new XmlTextWriter(ostrm, new UTF8Encoding());   
 
                try
                {
                    SamlSerializer serializer = new SamlSerializer();
                    serializer.WriteToken(samlToken, writer, WSSecurityTokenSerializer.DefaultInstance);
                }
                finally
                {
                    writer.Close();
                }

                IssuedIdentityToken wssToken = new IssuedIdentityToken();
                wssToken.PolicyId = m_policyId;
                wssToken.DecryptedTokenData = ostrm.ToArray();

                return wssToken;
            }

            // return a WSS token by default.
            if (m_token != null)
            {
                MemoryStream ostrm = new MemoryStream();
                XmlWriter writer = new XmlTextWriter(ostrm, new UTF8Encoding());

                try
                {
                    WSSecurityTokenSerializer serializer = new WSSecurityTokenSerializer();
                    serializer.WriteToken(writer, m_token);
                }
                finally
                {
                    writer.Close();
                }

                IssuedIdentityToken wssToken = new IssuedIdentityToken();
                wssToken.PolicyId = m_policyId;
                wssToken.DecryptedTokenData = ostrm.ToArray();

                return wssToken;
            }

            return null;
        }
        #endregion
        
        #region Private Methods
        /// <summary>
        /// Initializes the object with a username and password.
        /// </summary>
        private void Initialize(string username, string password)
        {
            if (username == null) throw new ArgumentNullException("username");   
            Initialize(new UserNameSecurityToken(username, password));
        }

        /// <summary>
        /// Initializes the object with an X509 certificate identifier
        /// </summary>
        private void Initialize(CertificateIdentifier certificateId)
        {
            if (certificateId == null) throw new ArgumentNullException("certificateId");

            X509Certificate2 certificate = certificateId.Find(true);

            if (certificate != null)
            {
                Initialize(new X509SecurityToken(certificate));
            }
        }

        /// <summary>
        /// Initializes the object with an X509 certificate
        /// </summary>
        private void Initialize(X509Certificate2 certificate)
        {
            if (certificate == null) throw new ArgumentNullException("certificate");
            Initialize(new X509SecurityToken(certificate));
        }

        /// <summary>
        /// Initializes the object with a .NET security token
        /// </summary>
        private void Initialize(SecurityToken token)
        {                        
            if (token == null) throw new ArgumentNullException("token");

            m_token = token;

            UserNameSecurityToken usernameToken = token as UserNameSecurityToken;

            if (usernameToken != null)
            {
                m_displayName     = usernameToken.UserName;
                m_tokenType       = UserTokenType.UserName;
                m_issuedTokenType = null; 
                return;
            }
            
            X509SecurityToken x509Token = token as X509SecurityToken;

            if (x509Token != null)
            {
                m_displayName     = x509Token.Certificate.Subject;
                m_tokenType       = UserTokenType.Certificate;
                m_issuedTokenType = null; 
                return;
            }
            
            KerberosReceiverSecurityToken kerberosToken1 = token as KerberosReceiverSecurityToken;

            if (kerberosToken1 != null)
            {
                m_displayName     = kerberosToken1.WindowsIdentity.Name;
                m_tokenType       = UserTokenType.IssuedToken;
                m_issuedTokenType = new XmlQualifiedName("", "http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1"); 
                return;
            }
            
            KerberosRequestorSecurityToken kerberosToken2 = token as KerberosRequestorSecurityToken;

            if (kerberosToken2 != null)
            {
                m_displayName     = kerberosToken2.ServicePrincipalName;
                m_tokenType       = UserTokenType.IssuedToken;
                m_issuedTokenType = new XmlQualifiedName("", "http://docs.oasis-open.org/wss/oasis-wss-kerberos-token-profile-1.1"); 
                return;
            }

            SamlSecurityToken samlToken = token as SamlSecurityToken;

            if (samlToken != null)
            {
                m_displayName = "SAML";

                // find the subject of the SAML assertion.
                foreach (SamlStatement statement in samlToken.Assertion.Statements)
                {
                    SamlAttributeStatement attribute = statement as SamlAttributeStatement;

                    if (attribute != null)
                    {
                        m_displayName = attribute.SamlSubject.Name;
                        break;
                    }
                }

                m_tokenType = UserTokenType.IssuedToken;
                m_issuedTokenType = new XmlQualifiedName("", "urn:oasis:names:tc:SAML:1.0:assertion"); 
                return;
            }
            
            m_displayName = UserTokenType.IssuedToken.ToString();
            m_tokenType   = UserTokenType.IssuedToken;
        }

        /// <summary>
        /// Initializes the object with a UA identity token
        /// </summary>
        private void Initialize(UserIdentityToken token)
        {
            if (token == null) throw new ArgumentNullException("token");

            m_policyId = token.PolicyId;
  
            UserNameIdentityToken usernameToken = token as UserNameIdentityToken;

            if (usernameToken != null)
            {
                Initialize(new UserNameSecurityToken(usernameToken.UserName, usernameToken.DecryptedPassword));
                return;
            }        
  
            X509IdentityToken x509Token = token as X509IdentityToken;

            if (x509Token != null)
            {
                X509Certificate2 certificate = CertificateFactory.Create(x509Token.CertificateData, true);  
                Initialize(new X509SecurityToken(certificate));
                return;
            }
   
            IssuedIdentityToken wssToken = token as IssuedIdentityToken;
            
            if (wssToken != null)
            {
                Initialize(wssToken, WSSecurityTokenSerializer.DefaultInstance, null);                
                return;
            }
            
            AnonymousIdentityToken anonymousToken = token as AnonymousIdentityToken;

            if (anonymousToken != null)
            {
                m_tokenType = UserTokenType.Anonymous;
                m_issuedTokenType = null;
                m_displayName = "Anonymous";
                m_token = null;
                return;
            }        
  
            throw new ArgumentException("Unrecognized UA user identity token type.", "token");
        }
        
        /// <summary>
        /// Initializes the object with a UA identity token
        /// </summary>
        private void Initialize(IssuedIdentityToken token, SecurityTokenSerializer serializer, SecurityTokenResolver resolver)
        {
            if (token == null) throw new ArgumentNullException("token");          
     
            string text = new UTF8Encoding().GetString(token.DecryptedTokenData);

            XmlDocument document = new XmlDocument();
            document.InnerXml = text.Trim();
            XmlNodeReader reader = new XmlNodeReader(document.DocumentElement);
                          
            try
            {      
                if (document.DocumentElement.NamespaceURI == "urn:oasis:names:tc:SAML:1.0:assertion")
                {
                    SecurityToken samlToken = new SamlSerializer().ReadToken(reader, serializer, resolver);
                    Initialize(samlToken);
                }
                else
                {
                    SecurityToken securityToken = serializer.ReadToken(reader, resolver);
                    Initialize(securityToken);
                }
            }
            finally
            {
                reader.Close();
            }
        }
        #endregion
        
        #region WIN32 Function Declarations
        private static class Win32
        {
            public const int LOGON32_PROVIDER_DEFAULT = 0;
            public const int LOGON32_LOGON_INTERACTIVE = 2;
            public const int LOGON32_LOGON_NETWORK = 3;

            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern int LogonUserW(
                [MarshalAs(UnmanagedType.LPWStr)]
                string lpszUsername,
                [MarshalAs(UnmanagedType.LPWStr)]
                string lpszDomain,
                [MarshalAs(UnmanagedType.LPWStr)]
                string lpszPassword,
                int dwLogonType,
                int dwLogonProvider,
                ref IntPtr phToken);

            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public extern static int CloseHandle(IntPtr handle);
        }
        #endregion
        
        #region Static Methods
        /// <summary>
        /// Verifies that the security token is a valid windows user.
        /// </summary>
        /// <param name="identityToken">The security token.</param>
        public static void VerifyPassword(UserNameSecurityToken identityToken)
        {
            if (identityToken == null)
            {
                throw ServiceResultException.Create(StatusCodes.BadIdentityTokenRejected, "Secuirty token is not a valid username token.");
            }

            // extract the username and domain from the security token.
            string username = identityToken.UserName;
            string domain = null;

            int index = username.IndexOf('\\');

            if (index != -1)
            {
                domain = username.Substring(0, index);
                username = username.Substring(index + 1);
            }

            IntPtr handle = IntPtr.Zero;

            int result = Win32.LogonUserW(
                username,
                domain,
                identityToken.Password, 
                Win32.LOGON32_LOGON_NETWORK,
                Win32.LOGON32_PROVIDER_DEFAULT,
                ref handle);

            if (result == 0)
            {
                throw ServiceResultException.Create(StatusCodes.BadIdentityTokenRejected, "Login failed for user: {0}", username);
            }

            Win32.CloseHandle(handle);
        }

        /// <summary>
        /// Returns the windows principal associated with a user name security token.
        /// </summary>
        /// <param name="identityToken">The identity token.</param>
        /// <param name="interactive">Whether to logon interactively (slow).</param>
        /// <returns>The impersonation context (must be disposed to reverse impersonation).</returns>
        public static ImpersonationContext LogonUser(UserNameSecurityToken identityToken, bool interactive)
        {
            if (identityToken == null)
            {
                throw ServiceResultException.Create(StatusCodes.BadIdentityTokenRejected, "Secuirty token is not a valid username token.");
            }

            // extract the username and domain from the security token.
            string username = identityToken.UserName;
            string domain   = null;

            int index = username.IndexOf('\\');

            if (index != -1)
            {
                domain   = username.Substring(0, index);
                username = username.Substring(index+1);
            }

            // validate the credentials.
            IntPtr handle = IntPtr.Zero;

            int result = Win32.LogonUserW(
			    username,
                domain,
                identityToken.Password,
                (interactive) ? Win32.LOGON32_LOGON_INTERACTIVE : Win32.LOGON32_LOGON_NETWORK,
                Win32.LOGON32_PROVIDER_DEFAULT,
                ref handle);

            if (result == 0)
            {
                result = Marshal.GetLastWin32Error();

                throw ServiceResultException.Create(
                    StatusCodes.BadIdentityTokenRejected, 
                    "Could not logon as user '{0}'. Reason: {1}.",
                    identityToken.UserName,
                    result);
		    }
            
            try
            {
                WindowsIdentity identity = new WindowsIdentity(handle);

                ImpersonationContext context = new ImpersonationContext();
                
                context.Principal = new WindowsPrincipal(identity);
                context.Context = identity.Impersonate();
                context.Handle = handle;

                return context;
            }
            catch (Exception e)
            {
                Win32.CloseHandle(handle);
                throw e;
            }
        }        
        #endregion

        #region Private Fields
        private SecurityToken m_token;
        private string m_displayName;
        private UserTokenType m_tokenType;
        private XmlQualifiedName m_issuedTokenType;
        private string m_policyId;
        #endregion
    }

    #region ImpersonationContext Class
    /// <summary>
    /// Stores information about the user that is currently being impersonated.
    /// </summary>
    public class ImpersonationContext : IDisposable
    {
        #region Public Members
        /// <summary>
        /// The security principal being impersonated.
        /// </summary>
        public IPrincipal Principal { get; set; }
        #endregion

        #region Internal Members
        internal WindowsImpersonationContext Context { get; set; }
        internal IntPtr Handle { get; set; }
        #endregion

        #region IDisposable Members
        /// <summary>
        /// The finializer implementation.
        /// </summary>
        ~ImpersonationContext()
        {
            Dispose(false);
        }

        /// <summary>
        /// Frees any unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #region PInvoke Declarations
        private static class Win32
        {
            [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
            public extern static bool CloseHandle(IntPtr handle);
        }
        #endregion

        /// <summary>
        /// An overrideable version of the Dispose.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (Context != null)
                {
                    Context.Dispose();
                    Context = null;
                }
            }

            if (Handle != IntPtr.Zero)
            {
                Win32.CloseHandle(Handle);
                Handle = IntPtr.Zero;
            }
        }
        #endregion
    }
    #endregion
}
