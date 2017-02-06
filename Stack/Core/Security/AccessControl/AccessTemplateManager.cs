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
using System.Linq;
using System.Text;
using System.IO;
using System.Security.AccessControl;
using System.Security.Principal;
using Opc.Ua.Configuration;

namespace Opc.Ua
{
    /// <summary>
    /// Manages a set of user access permission templates.
    /// </summary>
    public class AccessTemplateManager
    {
        /// <summary>
        /// Initializes the manager to use the specified directory.
        /// </summary>
        public AccessTemplateManager(string directory)
        {
            if (directory == null)
            {
                throw new ArgumentNullException("directory");
            }

            directory = Utils.GetAbsoluteDirectoryPath(directory, false, false, false);

            if (directory == null)
            {
                throw new ArgumentException("Specified user template directory does not exist.", "directory");
            }

            m_directory = new DirectoryInfo(directory);
        }

        /// <summary>
        /// Enumerates the available templates.
        /// </summary>
        public string[] EnumerateTemplates()
        {
            List<string> templates = new List<string>();

            foreach (FileInfo file in m_directory.GetFiles("*" + m_FileExtension))
            {
                templates.Add(file.Name.Substring(0, file.Name.Length - file.Extension.Length));
            }

            return templates.ToArray();
        }

        /// <summary>
        /// Sets the permissions to match the template on the specified file.
        /// </summary>
        public void SetPermissions(string template, FileInfo target)
        {
            if (target == null || !target.Exists)
            {
                throw new ArgumentException("Target file does not exist.", "target");
            }

            string filePath = Utils.GetAbsoluteFilePath(m_directory.FullName + "\\" + template + m_FileExtension, false, false, false);

            // nothing more to do if no file.
            if (filePath == null)
            {
                return;
            }

            FileInfo templateFile = new FileInfo(filePath);

            FileSecurity security1 = templateFile.GetAccessControl(AccessControlSections.Access);
            FileSecurity security2 = target.GetAccessControl(AccessControlSections.Access);

            foreach (AuthorizationRule rule in security2.GetAccessRules(true, true, typeof(NTAccount)))
            {
                FileSystemAccessRule fsr = rule as FileSystemAccessRule;

                if (fsr != null)
                {
                    security2.RemoveAccessRule(fsr);
                }
            }

            foreach (AuthorizationRule rule in security1.GetAccessRules(true, true, typeof(NTAccount)))
            {
                FileSystemAccessRule fsr = rule as FileSystemAccessRule;

                if (fsr != null)
                {
                    security2.AddAccessRule(fsr);
                }
            }

            security2.SetAccessRuleProtection(true, false);
            target.SetAccessControl(security2);
        }

        /// <summary>
        /// Sets the permissions to match the template on the specified directory.
        /// </summary>
        public void SetPermissions(string template, DirectoryInfo target, bool recursive)
        {
            if (target == null || !target.Exists)
            {
                throw new ArgumentException("Target directory does not exist.", "target");
            }

            string filePath = Utils.GetAbsoluteFilePath(m_directory.FullName + "\\" + template + m_FileExtension, false, false, false);

            // nothing more to do if no file.
            if (filePath == null)
            {
                return;
            }

            FileInfo templateFile = new FileInfo(filePath);

            FileSecurity security1 = templateFile.GetAccessControl(AccessControlSections.Access);
            DirectorySecurity security2 = target.GetAccessControl(AccessControlSections.Access);

            foreach (AuthorizationRule rule in security2.GetAccessRules(true, true, typeof(NTAccount)))
            {
                FileSystemAccessRule fsr = rule as FileSystemAccessRule;

                if (fsr != null)
                {
                    security2.RemoveAccessRule(fsr);
                }
            }

            foreach (AuthorizationRule rule in security1.GetAccessRules(true, true, typeof(NTAccount)))
            {
                FileSystemAccessRule fsr = rule as FileSystemAccessRule;

                if (fsr != null)
                {
                    FileSystemAccessRule copy = new FileSystemAccessRule(
                        fsr.IdentityReference,
                        fsr.FileSystemRights,
                        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                        PropagationFlags.None,
                        fsr.AccessControlType);

                    security2.AddAccessRule(copy);
                }
            }

            security2.SetAccessRuleProtection(true, false);
            target.SetAccessControl(security2);

            if (recursive)
            {
                foreach (DirectoryInfo directory in target.GetDirectories())
                {
                    InheritPermissions(directory);
                }

                foreach (FileInfo file in target.GetFiles())
                {
                    InheritPermissions(file);
                }
            }
        }

        /// <summary>
        /// Sets the permissions to match the template on the specified directory.
        /// </summary>
        public void SetPermissions(string template, Uri url, bool exactMatch)
        {
            if (url == null)
            {
                throw new ArgumentException("Target URI is not valid.", "target");
            }

            string filePath = Utils.GetAbsoluteFilePath(m_directory.FullName + "\\" + template + m_FileExtension, false, false, false);

            // nothing more to do if no file.
            if (filePath == null)
            {
                return;
            }

            string urlMask = null;

            if (!exactMatch)
            {
                urlMask = url.Scheme;
                urlMask += "://+:";
                urlMask += url.Port;
                urlMask += url.PathAndQuery;

                if (!urlMask.EndsWith("/"))
                {
                    urlMask += "/";
                }
            }
            else
            {
                urlMask = url.ToString();
            }

            FileInfo templateFile = new FileInfo(filePath);
            FileSecurity security1 = templateFile.GetAccessControl(AccessControlSections.Access);
            List<HttpAccessRule> httpRules = new List<HttpAccessRule>();

            foreach (AuthorizationRule rule in security1.GetAccessRules(true, true, typeof(NTAccount)))
            {
                FileSystemAccessRule fsr = rule as FileSystemAccessRule;

                if (fsr != null)
                {
                    HttpAccessRule httpRule = new HttpAccessRule();
                    httpRule.UrlPrefix = urlMask;
                    httpRule.IdentityName = fsr.IdentityReference.Translate(typeof(NTAccount)).ToString();
                    httpRules.Add(httpRule);

                    if ((fsr.FileSystemRights & FileSystemRights.ChangePermissions) != 0)
                    {
                        httpRule.Right = ApplicationAccessRight.Configure;
                    }
                    else if ((fsr.FileSystemRights & FileSystemRights.WriteData) != 0)
                    {
                        httpRule.Right = ApplicationAccessRight.Update;
                    }
                    else if ((fsr.FileSystemRights & FileSystemRights.ReadData) != 0)
                    {
                        httpRule.Right = ApplicationAccessRight.Run;
                    }
                }
            }

            HttpAccessRule.SetAccessRules(urlMask, httpRules, true);
        }

        /// <summary>
        /// Sets the permissions the specified directory.
        /// </summary>
        public static void SetPermissions(DirectoryInfo directory, FileSystemRights rights, bool recursive, params WellKnownSidType[] sids)
        {
            DirectorySecurity security = directory.GetAccessControl(AccessControlSections.Access);

            foreach (FileSystemAccessRule target in security.GetAccessRules(true, true, typeof(NTAccount)))
            {
                security.RemoveAccessRule(target);
            }

            security.SetAccessRuleProtection(true, false);

            FileSystemAccessRule rule = new FileSystemAccessRule(
                new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null).Translate(typeof(NTAccount)),
                FileSystemRights.FullControl,
                InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                PropagationFlags.None,
                System.Security.AccessControl.AccessControlType.Allow);

            security.AddAccessRule(rule);

            if (sids != null)
            {
                foreach (WellKnownSidType sid in sids)
                {
                    rule = new FileSystemAccessRule(
                        new SecurityIdentifier(sid, null).Translate(typeof(NTAccount)),
                        rights,
                        InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit,
                        PropagationFlags.None,
                        System.Security.AccessControl.AccessControlType.Allow);

                    security.AddAccessRule(rule);
                }
            }

            directory.SetAccessControl(security);

            if (recursive)
            {
                foreach (DirectoryInfo subdir in directory.GetDirectories())
                {
                    InheritPermissions(subdir);
                }

                foreach (FileInfo file in directory.GetFiles())
                {
                    InheritPermissions(file);
                }
            }
        }

        /// <summary>
        /// Recursively clears the permissions on the directory and enables permission inheritance.
        /// </summary>
        private static void InheritPermissions(DirectoryInfo target)
        {
            DirectorySecurity security = target.GetAccessControl(AccessControlSections.Access);
            security.SetAccessRuleProtection(false, false);

            foreach (AuthorizationRule rule in security.GetAccessRules(true, false, typeof(NTAccount)))
            {
                FileSystemAccessRule fsr = rule as FileSystemAccessRule;

                if (fsr != null)
                {
                    security.RemoveAccessRule(fsr);
                }
            }

            target.SetAccessControl(security);

            foreach (DirectoryInfo directory in target.GetDirectories())
            {
                InheritPermissions(directory);
            }

            foreach (FileInfo file in target.GetFiles())
            {
                InheritPermissions(file);
            }
        }

        /// <summary>
        /// Clears the permissions on the file and enables permission inheritance.
        /// </summary>
        private static void InheritPermissions(FileInfo target)
        {
            FileSecurity security = target.GetAccessControl(AccessControlSections.Access);
            security.SetAccessRuleProtection(false, false);

            foreach (AuthorizationRule rule in security.GetAccessRules(true, false, typeof(NTAccount)))
            {
                FileSystemAccessRule fsr = rule as FileSystemAccessRule;

                if (fsr != null)
                {
                    security.RemoveAccessRule(fsr);
                }
            }

            target.SetAccessControl(security);
        }

        /// <summary>
        /// Creates an access template file.
        /// </summary>
        public static void CreateTemplate(string directory, string templateName, params WellKnownSidType[] sids)
        {
            string filePath = directory + " \\" + templateName + ".access";
            AccessTemplateManager.CreateFile(filePath, sids);
        }

        /// <summary>
        /// Deletes an access template file.
        /// </summary>
        public static void DeleteTemplate(string directory, string templateName)
        {
            string filePath = directory + " \\" + templateName + m_FileExtension;
            AccessTemplateManager.DeleteFile(filePath);
        }

        /// <summary>
        /// Creates an access template file.
        /// </summary>
        internal static void CreateFile(string filePath, params WellKnownSidType[] sids)
        {
            File.WriteAllText(filePath, String.Empty);

            FileInfo info = new FileInfo(filePath);
            FileSecurity security = info.GetAccessControl(System.Security.AccessControl.AccessControlSections.Access);

            foreach (FileSystemAccessRule target in security.GetAccessRules(true, true, typeof(NTAccount)))
            {
                security.RemoveAccessRule(target);
            }

            security.SetAccessRuleProtection(true, false);

            FileSystemAccessRule rule = new FileSystemAccessRule(
                new SecurityIdentifier(WellKnownSidType.BuiltinAdministratorsSid, null).Translate(typeof(NTAccount)),
                FileSystemRights.FullControl,
                InheritanceFlags.None,
                PropagationFlags.None,
                System.Security.AccessControl.AccessControlType.Allow);

            security.AddAccessRule(rule);

            if (sids != null)
            {
                foreach (WellKnownSidType sid in sids)
                {
                    try
                    {
                        rule = new FileSystemAccessRule(
                            new SecurityIdentifier(sid, null).Translate(typeof(NTAccount)),
                            FileSystemRights.ReadAndExecute,
                            InheritanceFlags.None,
                            PropagationFlags.None,
                            System.Security.AccessControl.AccessControlType.Allow);

                        security.AddAccessRule(rule);
                    }
                    catch (Exception e)
                    {
                        Utils.Trace((int)Utils.TraceMasks.Error, "Could not translate SID '{0}': {1}", sid, e.Message);
                    }
                }
            }

            info.SetAccessControl(security);
        }

        /// <summary>
        /// Deletes an access template file.
        /// </summary>
        internal static void DeleteFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    File.Delete(filePath);
                }
            }
            catch
            {
                // ignore errors.
            }
        }

        private const string m_FileExtension = ".access";
        private DirectoryInfo m_directory;
    }
}
