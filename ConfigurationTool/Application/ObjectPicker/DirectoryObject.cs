/* ========================================================================
 * Copyright (c) 2005-2016 The OPC Foundation, Inc. All rights reserved.
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

namespace CubicOrange.Windows.Forms.ActiveDirectory
{
	/// <summary>
	/// Details of a directory object selected in the DirectoryObjectPickerDialog.
	/// </summary>
	public class DirectoryObject
	{
        private string adsPath;
        private string className;
		private string name;
		private string upn;

        public DirectoryObject(string name, string path, string schemaClass, string upn)
        {
            this.name = name;
            this.adsPath = path;
            this.className = schemaClass;
            this.upn = upn;
        }

        /// <summary>
        /// Gets the Active Directory path for this directory object.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The format of this string depends on the options specified in the DirectoryObjectPickerDialog
        /// from which this object was selected.
        /// </para>
        /// </remarks>
        public string Path
        {
            get
            {
                return adsPath;
            }
        }

        /// <summary>
        /// Gets the name of the schema class for this directory object (objectClass attribute).
        /// </summary>
		public string SchemaClassName
		{
			get
			{
				return className;
			}
		}

        /// <summary>
        /// Gets the directory object's relative distinguished name (RDN).
        /// </summary>
		public string Name
		{
			get
			{
				return name;
			}
		}

        /// <summary>
        /// Gets the objects user principal name (userPrincipalName attribute).
        /// </summary>
        /// <remarks>
        /// <para>
        /// If the object does not have a userPrincipalName value, this property is an empty string. 
        /// </para>
        /// </remarks>
		public string Upn
		{
			get
			{
				return upn;
			}
		}
	}
}
