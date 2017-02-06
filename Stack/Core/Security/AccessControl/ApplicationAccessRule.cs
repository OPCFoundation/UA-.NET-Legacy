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
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Opc.Ua
{
    /// <summary>
    /// An access rule for an application.
    /// </summary>
    public partial class ApplicationAccessRule
    {
        #region Public Properties
        /// <summary>
        /// The name of the NT account principal which the access rule applies to.
        /// </summary>
        public IdentityReference IdentityReference
        {
            get { return m_identityReference; }
            set { m_identityReference = value; }
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Converts a System.Security.AccessControl.AccessControlType to a Opc.Ua.Configuration.AccessControlType
        /// </summary>
        public static AccessControlType Convert(System.Security.AccessControl.AccessControlType input)
        {
            if (input == System.Security.AccessControl.AccessControlType.Deny)
            {
                return AccessControlType.Deny;
            }

            return AccessControlType.Allow;
        }

        /// <summary>
        /// Converts a System.Security.AccessControl.AccessControlType to a Opc.Ua.Configuration.AccessControlType
        /// </summary>
        public static System.Security.AccessControl.AccessControlType Convert(AccessControlType input)
        {
            if (input == AccessControlType.Deny)
            {
                return System.Security.AccessControl.AccessControlType.Deny;
            }

            return System.Security.AccessControl.AccessControlType.Allow;
        }

        /// <summary>
        /// Gets the application access rules implied by the access rights to the file.
        /// </summary>
        public static IList<ApplicationAccessRule> GetAccessRules(String filePath)
        {
            // get the current permissions from the file or directory.
            FileSystemSecurity security = null;

            FileInfo fileInfo = new FileInfo(filePath);
            DirectoryInfo directoryInfo = null;

            if (!fileInfo.Exists)
            {
                directoryInfo = new DirectoryInfo(filePath);

                if (!directoryInfo.Exists)
                {
                    throw new FileNotFoundException("File or directory does not exist.", filePath);
                }

                security = directoryInfo.GetAccessControl(AccessControlSections.Access);
            }
            else
            {
                security = fileInfo.GetAccessControl(AccessControlSections.Access);
            }

            // combine the access rules into a set of abstract application rules.
            List<ApplicationAccessRule> accessRules = new List<ApplicationAccessRule>();

            AuthorizationRuleCollection authorizationRules = security.GetAccessRules(true, true, typeof(NTAccount));

            for (int ii = 0; ii < authorizationRules.Count; ii++)
            {
                FileSystemAccessRule accessRule = authorizationRules[ii] as FileSystemAccessRule;

                // only care about file system rules.
                if (accessRule == null)
                {
                    continue;
                }

                ApplicationAccessRule rule = new ApplicationAccessRule();

                rule.RuleType = ApplicationAccessRule.Convert(accessRule.AccessControlType);
                rule.IdentityName = accessRule.IdentityReference.Value;
                rule.Right = ApplicationAccessRight.None;

                // create an allow rule.
                if (rule.RuleType == AccessControlType.Allow)
                {
                    // check if all rights required for configuration access exist.
                    if (((int)accessRule.FileSystemRights & (int)Configure) == (int)Configure)
                    {
                        rule.Right = ApplicationAccessRight.Configure;
                    }

                    // check if all rights required for update access exist.
                    else if (((int)accessRule.FileSystemRights & (int)Update) == (int)Update)
                    {
                        rule.Right = ApplicationAccessRight.Update;
                    }

                    // check if all rights required for read access exist.   
                    else if (((int)accessRule.FileSystemRights & (int)Read) == (int)Read)
                    {
                        rule.Right = ApplicationAccessRight.Run;
                    }
                }

                // create a deny rule.
                else if (rule.RuleType == AccessControlType.Deny)
                {
                    // check if any rights required for read access are denied.
                    if (((int)accessRule.FileSystemRights & (int)Read) != 0)
                    {
                        rule.Right = ApplicationAccessRight.Run;
                    }

                    // check if any rights required for update access are denied.
                    else if (((int)accessRule.FileSystemRights & (int)Update) != 0)
                    {
                        rule.Right = ApplicationAccessRight.Update;
                    }

                    // check if any rights required for configure access are denied.
                    else if (((int)accessRule.FileSystemRights & (int)Configure) != 0)
                    {
                        rule.Right = ApplicationAccessRight.Configure;
                    }
                }

                // add rule if not trivial.
                if (rule.Right != ApplicationAccessRight.None)
                {
                    accessRules.Add(rule);
                }
            }

            return accessRules;
        }

        /// <summary>
        /// Gets the application access rules implied by the access rights to the file.
        /// </summary>
        public static void SetAccessRules(String filePath, IList<ApplicationAccessRule> accessRules, bool replaceExisting)
        {
            // get the current permissions from the file or directory.
            FileSystemSecurity security = null;

            FileInfo fileInfo = new FileInfo(filePath);
            DirectoryInfo directoryInfo = null;

            if (!fileInfo.Exists)
            {
                directoryInfo = new DirectoryInfo(filePath);

                if (!directoryInfo.Exists)
                {
                    throw new FileNotFoundException("File or directory does not exist.", filePath);
                }

                security = directoryInfo.GetAccessControl(AccessControlSections.Access);
            }
            else
            {
                security = fileInfo.GetAccessControl(AccessControlSections.Access);
            }

            if (replaceExisting)
            {
                // can't use inhieritance when setting permissions 
                security.SetAccessRuleProtection(true, false);

                // remove all existing access rules.
                AuthorizationRuleCollection authorizationRules = security.GetAccessRules(true, true, typeof(NTAccount));

                for (int ii = 0; ii < authorizationRules.Count; ii++)
                {
                    FileSystemAccessRule accessRule = authorizationRules[ii] as FileSystemAccessRule;

                    // only care about file system rules.
                    if (accessRule == null)
                    {
                        continue;
                    }

                    security.RemoveAccessRule(accessRule);
                }
            }

            // allow children to inherit rules for directories.
            InheritanceFlags flags = InheritanceFlags.None;

            if (directoryInfo != null)
            {
                flags = InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit;
            }

            // add the new rules.
            for (int ii = 0; ii < accessRules.Count; ii++)
            {
                ApplicationAccessRule applicationRule = accessRules[ii];

                IdentityReference identityReference = applicationRule.IdentityReference;

                if (identityReference == null)
                {
                    if (applicationRule.IdentityName.StartsWith("S-"))
                    {
                        SecurityIdentifier sid = new SecurityIdentifier(applicationRule.IdentityName);

                        if (!sid.IsValidTargetType(typeof(NTAccount)))
                        {
                            continue;
                        }

                        identityReference = sid.Translate(typeof(NTAccount));
                    }
                    else
                    {
                        identityReference = new NTAccount(applicationRule.IdentityName);
                    }
                }
                
                FileSystemAccessRule fileRule = null;

                switch (applicationRule.Right)
                {
                    case ApplicationAccessRight.Run:
                    {
                        fileRule = new FileSystemAccessRule(
                            identityReference,
                            (applicationRule.RuleType == AccessControlType.Allow) ? Read : Configure,
                            flags,
                            PropagationFlags.None,
                            ApplicationAccessRule.Convert(applicationRule.RuleType));

                        break;
                    }

                    case ApplicationAccessRight.Update:
                    {
                        fileRule = new FileSystemAccessRule(
                            identityReference,
                            (applicationRule.RuleType == AccessControlType.Allow) ? Update : ConfigureOnly | UpdateOnly,
                            flags,
                            PropagationFlags.None,
                            ApplicationAccessRule.Convert(applicationRule.RuleType));

                        security.SetAccessRule(fileRule);
                        break;
                    }

                    case ApplicationAccessRight.Configure:
                    {
                        fileRule = new FileSystemAccessRule(
                            identityReference,
                            (applicationRule.RuleType == AccessControlType.Allow) ? Configure : ConfigureOnly,
                            flags,
                            PropagationFlags.None,
                            ApplicationAccessRule.Convert(applicationRule.RuleType));

                        break;
                    }
                }

                try
                {
                    security.SetAccessRule(fileRule);
                }
                catch (Exception e)
                {
                    Utils.Trace(
                        "Could not set access rule for account '{0}' on file '{1}'. Error={2}", 
                        applicationRule.IdentityName,
                        filePath,
                        e.Message);
                }
            }

            if (directoryInfo != null)
            {
                directoryInfo.SetAccessControl((DirectorySecurity)security);
                return;
            }

            fileInfo.SetAccessControl((FileSecurity)security);
        }

        /// <summary>
        /// Converts a SID to a user account name.
        /// </summary>
        public static string SidToAccountName(string sid)
        {
            SecurityIdentifier identifier = new SecurityIdentifier(sid);
            
            if (!identifier.IsValidTargetType(typeof(NTAccount)))
            {
                return null;
            }

            return identifier.Translate(typeof(NTAccount)).ToString();
        }

        /// <summary>
        /// Converts a user account name to a SID.
        /// </summary>
        public static string AccountNameToSid(string accountName)
        {
            NTAccount account = new NTAccount(accountName);
            return account.Translate(typeof(SecurityIdentifier)).ToString();
        }
        #endregion

        #region Private Constants
        /// <summary>
        /// The rights necessary for read a certificate or certificate store. 
        /// </summary>
        private const FileSystemRights ReadOnly =
            FileSystemRights.ExecuteFile |
            FileSystemRights.ReadData |
            FileSystemRights.ReadAttributes |
            FileSystemRights.ReadExtendedAttributes |
            FileSystemRights.ReadPermissions;

        /// <summary>
        /// The rights necessary for update a certificate or certificate store. 
        /// </summary>
        private const FileSystemRights UpdateOnly =
            FileSystemRights.WriteData |
            FileSystemRights.AppendData |
            FileSystemRights.WriteAttributes |
            FileSystemRights.WriteExtendedAttributes;

        /// <summary>
        /// The rights necessary for change access to a certificate or certificate store. 
        /// </summary>
        private const FileSystemRights ConfigureOnly =
            FileSystemRights.ChangePermissions |
            FileSystemRights.TakeOwnership |
            FileSystemRights.Delete;

        /// <summary>
        /// The rights granted to entities with read access to a certificate or certificate store. 
        /// </summary>
        private const FileSystemRights Read = ReadOnly;

        /// <summary>
        /// The rights granted to entities with read/update access to a certificate or certificate store. 
        /// </summary>
        private const FileSystemRights Update = ReadOnly | UpdateOnly;

        /// <summary>
        /// The rights granted to entities with read/update/configure access to a certificate or certificate store. 
        /// </summary>
        private const FileSystemRights Configure = ReadOnly | UpdateOnly | ConfigureOnly;
        #endregion

        #region Private Fields
        private IdentityReference m_identityReference;
        #endregion
    }
}
