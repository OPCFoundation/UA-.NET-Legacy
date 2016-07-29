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
using System.Collections.Generic;
using System.Text;

namespace CubicOrange.Windows.Forms.ActiveDirectory
{
    /// <summary>
    /// Indicates the type of objects the DirectoryObjectPickerDialog searches for.
    /// </summary>
    [Flags]
    public enum ObjectTypes
    {
        /// <summary>
        /// No object types.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// Includes user objects.
        /// </summary>
        Users = 0x0001, 

        /// <summary>
        /// Includes security groups with universal scope. 
        /// </summary>
        /// <remarks>
        /// <para>
        /// In an up-level scope, this includes distribution and security groups, with universal, global and domain local scope.
        /// </para>
        /// <para>
        /// In a down-level scope, this includes local and global groups.
        /// </para>
        /// </remarks>
        Groups = 0x0002, 
        
        /// <summary>
        /// Includes computer objects.
        /// </summary>
        Computers = 0x0004, 

        /// <summary>
        /// Includes contact objects.
        /// </summary>
        Contacts = 0x0008, 

        /// <summary>
        /// Includes built-in group objects.
        /// </summary>
        /// <summary>
        /// <para>
        /// In an up-level scope, this includes group objects with the built-in groupType flags.
        /// </para>
        /// <para>
        /// In a down-level scope, not setting this object type excludes local built-in groups.
        /// </para>
        /// </summary>
        BuiltInGroups = 0x0010, 

        /// <summary>
        /// Includes all well-known security principals. 
        /// </summary>
        /// <remarks>
        /// <para>
        /// In an up-level scope, this includes the contents of the Well Known Security Principals container.
        /// </para>
        /// <para>
        /// In a down-level scope, this includes all well-known SIDs.
        /// </para>
        /// </remarks>
        WellKnownPrincipals = 0x0020, 

        /// <summary>
        /// All object types.
        /// </summary>
        All = 0x003F
    }
}
