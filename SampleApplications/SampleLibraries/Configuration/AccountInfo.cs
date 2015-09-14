/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
 *
 * OPC Foundation MIT License 1.00
 * 
 * Permission is hereby granted, free of charge, to any person
 * obtaining a copy of this software and associated documentation
 * files (the "Software"), to deal in the Software without
 * restriction, including without limitation the rights to use,
 * copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the
 * Software is furnished to do so, subject to the following
 * conditions:
 * 
 * The above copyright notice and this permission notice shall be
 * included in all copies or substantial portions of the Software.
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
 * EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 * OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
 * NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
 * HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
 * WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
 * FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
 * OTHER DEALINGS IN THE SOFTWARE.
 *
 * The complete license agreement can be found here:
 * http://opcfoundation.org/License/MIT/1.00/
 * ======================================================================*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Management;
using System.Security.AccessControl;
using System.Security.Principal;
using System.IO;
using System.Runtime.InteropServices;

using Opc.Ua.Configuration;

namespace Opc.Ua.Configuration
{
    /// <summary>
    /// Stores information about an account.
    /// </summary>
    public class AccountInfo : IComparable
    {
        #region Public Properties
        /// <summary>
        /// The name of the account.
        /// </summary>
        public string Name
        {
            get { return m_name;  } 
            set { m_name = value; }
        }

        /// <summary>
        /// The domain that the account belongs to.
        /// </summary>
        public string Domain
        {
            get { return m_domain;  } 
            set { m_domain = value; }
        }

        /// <summary>
        /// The SID for the account.
        /// </summary>
        public string Sid
        {
            get { return m_sid;  } 
            set { m_sid = value; }
        }

        /// <summary>
        /// The type of SID used by the account.
        /// </summary>
        public AccountSidType SidType
        {
            get { return m_sidType;  } 
            set { m_sidType = value; }
        }

        /// <summary>
        /// Thr description for the account.
        /// </summary>
        public string Description
        {
            get { return m_description;  } 
            set { m_description = value; }
        }

        /// <summary>
        /// Thr current status for the account.
        /// </summary>
        public string Status
        {
            get { return m_status;  } 
            set { m_status = value; }
        }
        #endregion 
        
        #region Overridden Methods
        /// <summary cref="Object.ToString()" />
        public override string ToString()
        {
            try
            {                
                IdentityReference identity = GetIdentityReference();
                            
                if (identity != null && m_sid != identity.Value)
                {
                    return identity.Value;
                }
            }
            catch
            {
                // don't care about invalid accounts when displaying a string.
            }

            if (String.IsNullOrEmpty(m_name))
            {
                return m_sid;
            }
            
            if (!String.IsNullOrEmpty(m_domain))
            {
                return Utils.Format(@"{0}\{1}", m_domain, m_name);
            }

            return m_name;
        }
        #endregion 

        #region IComparable Members
        /// <summary>
        /// Compares the obj.
        /// </summary>
        public int CompareTo(object obj)
        {
            AccountInfo target = obj as AccountInfo;

            if (Object.ReferenceEquals(target, null))
            {
                return -1;
            }

            if (Object.ReferenceEquals(target, this))
            {
                return 0;
            }
            
            if (m_domain == null)
            {
                return (target.m_domain == null)?0:-1;
            }

            int result = m_domain.CompareTo(target.m_domain);

            if (result != 0)
            {
                return result;
            }

            if (m_name == null)
            {
                return (target.m_name == null)?0:-1;
            }

            result = m_name.CompareTo(target.m_name);

            if (result != 0)
            {
                return result;
            }
            
            if (m_sid == null)
            {
                return (target.m_sid == null)?0:-1;
            }

            return m_sid.CompareTo(target.m_sid);
        }
        #endregion
 
        #region Public Methods
        /// <summary>
        /// Returns the identity reference for the account.
        /// </summary>
        public IdentityReference GetIdentityReference()
        {
            string domain = m_domain;

            if (String.Compare(domain, System.Net.Dns.GetHostName(), true) == 0)
            {
                domain = null;
            }

            if (!String.IsNullOrEmpty(m_name))
            {
                if (String.IsNullOrEmpty(domain))
                {
                    return new NTAccount(m_name);
                }

                return new NTAccount(domain, m_name);
            }

            if (!String.IsNullOrEmpty(m_sid))
            {
                return new SecurityIdentifier(m_sid);
            }

            return null;
        }

        /// <summary>
        /// Returns the application rights implied by the file system rights.
        /// </summary>
        public static ApplicationAccessRight GetApplicationRights(Opc.Ua.AccessControlType accessType, FileSystemRights accessRights)
        {
            if (accessType == Opc.Ua.AccessControlType.Allow)
            {
                if ((accessRights & ReadWrite) == ReadWrite)
                {
                    return ApplicationAccessRight.Configure;
                }

                if ((accessRights & ReadOnly) == ReadOnly)
                {
                    return ApplicationAccessRight.Run;
                }
            }                        
            else if (accessType == Opc.Ua.AccessControlType.Deny)
            {
                if ((accessRights & ReadOnly) != 0)
                {
                    return ApplicationAccessRight.Run;
                }

                if ((accessRights & WriteOnly) != 0)
                {
                    return ApplicationAccessRight.Configure;
                }
            }

            return ApplicationAccessRight.None;
        }

        /// <summary>
        /// Returns the directory that is the source for the specified access rule.
        /// </summary>
        public static DirectoryInfo GetAccessRuleSource(FileInfo file, FileSystemAccessRule inheritedRule)
        {
            DirectoryInfo parent = file.Directory;

            while (parent != null)
            {                    
                DirectorySecurity security = parent.GetAccessControl(AccessControlSections.Access);

                foreach (AuthorizationRule rule in security.GetAccessRules(true, true, typeof(NTAccount)))
                {
                    if (rule.IsInherited)
                    {
                        continue;
                    }

                    if (inheritedRule.IdentityReference.Value != rule.IdentityReference.Value)
                    {
                        continue;
                    }

                    FileSystemAccessRule accessRule = rule as FileSystemAccessRule;
                    
                    if (accessRule == null)
                    {
                        continue;
                    }

                    if (accessRule.AccessControlType != inheritedRule.AccessControlType)
                    {
                        continue;
                    }

                    return parent;
                }

                parent = parent.Parent;   
            }

            return null;
        }

        /// <summary>
        /// Queries the SID table for the specified account name.
        /// </summary>
        public static string LookupDomainSid(string domainName)
        {          
            StringBuilder builder = new StringBuilder();
            builder.AppendFormat("DomainName='{0}'", domainName);

            SelectQuery query = new SelectQuery("Win32_NTDomain", builder.ToString());  
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            
            try
            {
                foreach (ManagementObject target in searcher.Get())
                {
                    return target["SID"] as string;
                }
            }
            finally
            {
                searcher.Dispose();
            }

            return null;
        }

        /// <summary>
        /// Queries the SID table for the specified account name.
        /// </summary>
        public static string LookupAccountSid(string accountName)
        {   
            if (String.IsNullOrEmpty(accountName))
            {
                return null;
            }

            // check if already a SID.
            if (accountName.StartsWith("S-"))
            {
                if (Create(accountName) == null)
                {
                    return null;
                }

                return accountName;
            }

            string domain = null;

            int index = accountName.IndexOf('\\');

            if (index != -1)
            {
                domain = accountName.Substring(0, index).ToUpper();
                accountName = accountName.Substring(index+1);
            }

            StringBuilder builder = new StringBuilder();

            builder.AppendFormat("Name='{0}'", accountName);
            
            if (!String.IsNullOrEmpty(domain))
            {
                if (domain != "BUILTIN" && domain != "NT AUTHORITY")
                {
                    builder.AppendFormat(" AND Domain='{0}'", domain);
                }
            }

            SelectQuery query = new SelectQuery("Win32_Account", builder.ToString());  
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            
            try
            {
                foreach (ManagementObject target in searcher.Get())
                {
                    return target["SID"] as string;
                }
            }
            finally
            {
                searcher.Dispose();
            }

            return null;
        }
        
        /// <summary>
        /// Creates an account info object from an identity name.
        /// </summary>
        public static AccountInfo Create(string identityName)
        {
            Console.WriteLine("CONFIGURATION CONSOLE AccountInfo {0}", identityName);

            // check for null.
            if (String.IsNullOrEmpty(identityName))
            {
                return null;
            }

            StringBuilder builder = new StringBuilder();

            // check for SID based query.
            if (identityName.StartsWith("S-"))
            {
                builder.AppendFormat("SID='{0}'", identityName);
            }

            // search by account name.
            else
            {
                string domain = null;
                string name = identityName;

                int index = identityName.IndexOf('\\');

                if (index != -1)
                {
                    domain = identityName.Substring(0, index);
                    name = identityName.Substring(index+1);
                }
           
                builder.AppendFormat("Name='{0}'", name);

                if (!String.IsNullOrEmpty(domain))
                {
                    // check for non-existent domain.
                    if (String.Compare(domain, System.Net.Dns.GetHostName(), true) != 0)
                    {
                        if (String.IsNullOrEmpty(LookupDomainSid(domain)))
                        {
                            return null;
                        }
                    }
                    
                    builder.AppendFormat("AND Domain='{0}'", domain);
                }
            }
            
            SelectQuery query = new SelectQuery("Win32_Account", builder.ToString());
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            try
            {
                foreach (ManagementObject target in searcher.Get())
                {
                    // filter on SID type.
                    byte? sidType =  target["SIDType"] as byte?;

                    if (sidType == null || sidType.Value == 3 || sidType.Value > 5)
                    {
                        continue;
                    }

                    // create account info object.
                    AccountInfo account = new AccountInfo();

                    account.Name = target["Name"] as string;
                    account.SidType = (AccountSidType)sidType.Value;
                    account.Sid = target["SID"] as string;
                    account.Domain = target["Domain"] as string;
                    account.Description = target["Description"] as string;
                    account.Status = target["Status"] as string;
                                        
                    string caption = target["Caption"] as string;
                    object InstallDate = target["InstallDate"];
                    bool? LocalAccount = target["LocalAccount"] as bool?;

                    return account;
                }
            }
            finally
            {
                searcher.Dispose();
            }

            return null;
        }

        [DllImport("netapi32.dll")]
        private static extern int NetUserAdd(
            [MarshalAs(UnmanagedType.LPWStr)]
            string  servername,
            int     level,
            IntPtr  buf,
            out int parm_err);

        [DllImport("netapi32.dll")]
        private static extern int NetUserSetInfo (
            [MarshalAs(UnmanagedType.LPWStr)]
            string servername,
            [MarshalAs(UnmanagedType.LPWStr)]
            string username,
            int level,
            IntPtr  buf,
            out int parm_err);

        [StructLayout(LayoutKind.Sequential)]
        private struct USER_INFO_1 
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string usri1_name;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string usri1_password;
            public int usri1_password_age;
            public int usri1_priv;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string usri1_home_dir;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string usri1_comment;
            public int usri1_flags;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string usri1_script_path;
        }
            
        [StructLayout(LayoutKind.Sequential)]
        private struct USER_INFO_1003 
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string usri1003_password;
        }    
                    
        [StructLayout(LayoutKind.Sequential)]
        private struct USER_INFO_1008 
        {
            public int usri1008_flags;
        }
        
        private const int NERR_Success = 0;
        private const int USER_PRIV_USER = 1;
        
        private const int UF_SCRIPT = 0x0001;
        private const int UF_DONT_EXPIRE_PASSWD = 0x10000;
        private const int UF_PASSWD_CANT_CHANGE = 0x0040;
        
        /// <summary>
        /// Creates a new NT user account.
        /// </summary>
        public static AccountInfo CreateUser(string username, string password)
        {
            int dwLevel = 1;
            int dwError = 0;
            int nStatus;

            //
            // Set up the USER_INFO_1 structure.
            //  USER_PRIV_USER: name identifies a user, 
            //    rather than an administrator or a guest.
            //  UF_SCRIPT: required for LAN Manager 2.0 and
            //    Windows NT and later.
            //
            USER_INFO_1 ui = new USER_INFO_1();

            ui.usri1_name = username;
            ui.usri1_password = password;
            ui.usri1_priv = USER_PRIV_USER;
            ui.usri1_home_dir = null;
            ui.usri1_comment = username;
            ui.usri1_flags = UF_SCRIPT | UF_DONT_EXPIRE_PASSWD | UF_PASSWD_CANT_CHANGE;
            ui.usri1_script_path = null;

            IntPtr pInfo = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(USER_INFO_1)));
            Marshal.StructureToPtr(ui, pInfo, false);
            
            // try to add the user.
            try
            {
               nStatus = NetUserAdd(
                   null, 
                   dwLevel,
                   pInfo,
                   out dwError);
            }
            finally
            {
                Marshal.DestroyStructure(pInfo, typeof(USER_INFO_1));
                Marshal.FreeCoTaskMem(pInfo);
            }

            if (nStatus != NERR_Success)  // maybe account exists, so just set the password
            {
                // set the password.
                dwLevel = 1003;
                USER_INFO_1003 ui1003;
                ui1003.usri1003_password = password;

                pInfo = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(USER_INFO_1003)));
                Marshal.StructureToPtr(ui1003, pInfo, false);

                try
                {
                    nStatus = NetUserSetInfo(
                        null,
                        username,
                        dwLevel,
                        pInfo,
                        out dwError);
                }
                finally
                {
                    Marshal.DestroyStructure(pInfo, typeof(USER_INFO_1003));
                    Marshal.FreeCoTaskMem(pInfo);
                }

	            // set the account flags (e.g. enable the account if disabled)
	            dwLevel = 1008;
	            USER_INFO_1008 ui1008;
	            ui1008.usri1008_flags = UF_SCRIPT | UF_DONT_EXPIRE_PASSWD | UF_PASSWD_CANT_CHANGE;
        	
                pInfo = Marshal.AllocCoTaskMem(Marshal.SizeOf(typeof(USER_INFO_1003)));
                Marshal.StructureToPtr(ui1003, pInfo, false);

                try
                {
                    nStatus = NetUserSetInfo(
                        null,
                        username,
                        dwLevel,
                        pInfo,
                        out dwError);
                }
                finally
                {
                    Marshal.DestroyStructure(pInfo, typeof(USER_INFO_1008));
                    Marshal.FreeCoTaskMem(pInfo);
                }
            }

            if (nStatus != NERR_Success)
            {
                return null;
            }

            return Create(username);
        }

        /// <summary>
        /// Queries the account table for the specified accounts.
        /// </summary>
        public static IList<AccountInfo> Query(AccountFilters filters)
        {
            if (filters == null)
            {
                filters = new AccountFilters();
            }

            List<AccountInfo> accounts = new List<AccountInfo>();

            StringBuilder builder = new StringBuilder();
            
            if (!String.IsNullOrEmpty(filters.Domain))
            {
                // check for non-existent domain.
                if (String.Compare(filters.Domain, System.Net.Dns.GetHostName(), true) != 0)
                {
                    if (String.IsNullOrEmpty(LookupDomainSid(filters.Domain)))
                    {
                        return accounts;
                    }
                }
                
                builder.AppendFormat("Domain='{0}'", filters.Domain);
            }
            
            SelectQuery query = new SelectQuery("Win32_Account", builder.ToString());
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);

            try
            {
                foreach (ManagementObject target in searcher.Get())
                {
                    // filter on SID type.
                    byte? sidType =  target["SIDType"] as byte?;

                    if (sidType == null || sidType.Value == 3 || sidType.Value > 5)
                    {
                        continue;
                    }

                    // create account info object.
                    AccountInfo account = new AccountInfo();

                    account.Name = target["Name"] as string;
                    account.SidType = (AccountSidType)sidType.Value;
                    account.Sid = target["SID"] as string;
                    account.Domain = target["Domain"] as string;
                    account.Description = target["Description"] as string;
                    account.Status = target["Status"] as string;


                    if (account.ApplyFilters(filters))
                    {
                        accounts.Add(account);
                    }
                }
            }
            finally
            {
                searcher.Dispose();
            }

            return accounts;
        }

        /// <summary>
        /// Applies the filters to the accounts.
        /// </summary>
        public static IList<AccountInfo> ApplyFilters(AccountFilters filters, IList<AccountInfo> accounts)
        {
            if (filters == null || accounts == null)
            {
                return accounts;
            }

            List<AccountInfo> filteredAccounts = new  List<AccountInfo>();

            for (int ii = 0; ii < accounts.Count; ii++)
            {                
                if (accounts[ii].ApplyFilters(filters))
                {
                    filteredAccounts.Add(accounts[ii]);
                }
            }

            return filteredAccounts;
        }
        
        /// <summary>
        /// Applies the filters to the account
        /// </summary>
        public bool ApplyFilters(AccountFilters filters)
        {
            // filter on name.
            if (!String.IsNullOrEmpty(filters.Name))
            {
                if (!Utils.Match(this.Name, filters.Name, false))
                {
                    return false;
                }
            }

            // filter on domain.
            if (!String.IsNullOrEmpty(filters.Domain))
            {
                if (String.Compare(this.Domain, filters.Domain, true) != 0)
                {
                    return false;
                }
            }
                
            // exclude non-user related accounts.
            if (this.SidType == AccountSidType.Domain || this.SidType > AccountSidType.BuiltIn)
            {
                return false;
            }

            // apply account type filter.
            if (filters.AccountTypeMask != AccountTypeMask.None)
            {
                if ((1<<((int)this.SidType-1) & (int)filters.AccountTypeMask) == 0)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion 

        #region Private Fields
        /// <summary>
        /// The rights necessary for read access to a file.
        /// </summary>
        private const FileSystemRights ReadOnly  =
            FileSystemRights.ReadData | 
            FileSystemRights.ReadAttributes | 
            FileSystemRights.ReadExtendedAttributes | 
            FileSystemRights.ReadPermissions;
        
        /// <summary>
        /// The rights necessary for write access to a file.
        /// </summary>
        private const FileSystemRights WriteOnly = 
            FileSystemRights.WriteData | 
            FileSystemRights.AppendData | 
            FileSystemRights.WriteAttributes | 
            FileSystemRights.WriteExtendedAttributes | 
            FileSystemRights.ChangePermissions | 
            FileSystemRights.TakeOwnership;
        
        /// <summary>
        /// The rights necessary for read/write access to a file.
        /// </summary>
        private const FileSystemRights ReadWrite = ReadOnly | WriteOnly;

        private string m_name;
        private string m_domain;
        private string m_sid;
        private AccountSidType m_sidType;
        private string m_description;
        private string m_status;
        #endregion 
    }
    
    #region AccountSidType Enumeration
    /// <summary>
    /// The type of SID used by the account.
    /// </summary>
    public enum AccountSidType : byte
    {        
        /// <summary>
        /// An interactive user account.
        /// </summary>
        User = 0x1,

        /// <summary>
        /// An group of users.
        /// </summary>
        Group = 0x2,

        /// <summary>
        /// A domain.
        /// </summary>
        Domain = 0x3,

        /// <summary>
        /// An alias for a group or user.
        /// </summary>
        Alias = 0x4,

        /// <summary>
        /// Built-in identity principals.
        /// </summary>
        BuiltIn = 0x5
    }
    #endregion 
    
    #region AccountFilters Class
    /// <summary>
    /// Filters that can be used to restrict the set of accounts returned.
    /// </summary>
    public class AccountFilters
    {
        #region Public Properties
        /// <summary>
        /// The name of the account (supports the '*' wildcard).
        /// </summary>
        public string Name
        {
            get { return m_name;  } 
            set { m_name = value; }
        }

        /// <summary>
        /// The domain that the account belongs to.
        /// </summary>
        public string Domain
        {
            get { return m_domain;  } 
            set { m_domain = value; }
        }
        

        /// <summary>
        /// The types of accounts.
        /// </summary>
        public AccountTypeMask AccountTypeMask
        {
            get { return m_accountTypeMask;  } 
            set { m_accountTypeMask = value; }
        }
        #endregion 

        #region Private Fields
        private string m_name;
        private string m_domain;
        private AccountTypeMask m_accountTypeMask;
        #endregion 
    }
    #endregion 
    
    #region AccountTypeMask Enumeration
    /// <summary>
    /// The masks that can be use to filter a list of accounts.
    /// </summary>
    [Flags]
    public enum AccountTypeMask
    {        
        /// <summary>
        /// Mask not specified.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// An interactive user account.
        /// </summary>
        User = 0x1,

        /// <summary>
        /// An NT user group.
        /// </summary>
        Group = 0xA,

        /// <summary>
        /// Well-known groups.
        /// </summary>
        WellKnownGroup = 0x10
    }
    #endregion 
    
    #region WellKnownSids Class
    /// <summary>
    /// The well known NT security identifiers.
    /// </summary>
    public static class WellKnownSids
    {
        /// <summary>
        /// Interactive users.
        /// </summary>
        public const string Interactive = "S-1-5-4";

        /// <summary>
        /// Authenticated users.
        /// </summary>
        public const string AuthenticatedUser = "S-1-5-11";

        /// <summary>
        /// Anonymous Logons
        /// </summary>
        public const string AnonymousLogon = "S-1-5-7";

        /// <summary>
        /// The local system account.
        /// </summary>
        public const string LocalSystem = "S-1-5-18";

        /// <summary>
        /// The local service account.
        /// </summary>
        public const string LocalService = "S-1-5-19";

        /// <summary>
        /// The network service account.
        /// </summary>
        public const string NetworkService  = "S-1-5-20";   

        /// <summary>
        /// The administrators group.
        /// </summary>     
        public const string Administrators  = "S-1-5-32-544";

        /// <summary>
        /// The users group.
        /// </summary>   
        public const string Users = "S-1-5-32-545";

        /// <summary>
        /// The guests group.
        /// </summary>   
        public const string Guests = "S-1-5-32-546";
    }
    #endregion
}
