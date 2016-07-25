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
    /// Indicates the scope the DirectoryObjectPickerDialog searches for objects.
    /// </summary>
    [Flags]
    public enum Locations
    {
        /// <summary>
        /// No locations.
        /// </summary>
        None = 0x0,

        /// <summary>
        /// The target computer (down-level).
        /// </summary>
        LocalComputer = 0x0001,

        /// <summary>
        /// A domain to which the target computer is joined (down-level and up-level).
        /// </summary>
        JoinedDomain = 0x0002,

        /// <summary>
        /// All Windows 2000 domains in the enterprise to which the target computer belongs (up-level).
        /// </summary>
        EnterpriseDomain = 0x0004,

        /// <summary>
        /// A scope containing objects from all domains in the enterprise (up-level). 
        /// </summary>
        GlobalCatalog = 0x0008,

        /// <summary>
        /// All domains external to the enterprise, but trusted by the domain to which the target computer 
        /// is joined (down-level and up-level).
        /// </summary>
        ExternalDomain = 0x0010,

        /// <summary>
        /// The workgroup to which the target computer is joined (down-level). 
        /// </summary>
        /// <remarks>
        /// <para>
        /// Applies only if the target computer is not 
        /// joined to a domain. The only type of object that can be selected from a workgroup is a computer.
        /// </para>
        /// </remarks>
        Workgroup = 0x0020,

        /// <summary>
        /// Enables the user to enter a scope (down-level and up-level). 
        /// </summary>
        /// <remarks>
        /// <para>
        /// If not specified, the dialog box restricts the user to the scopes in the locations drop-down list.
        /// </para>
        /// </remarks>
        UserEntered = 0x0040,

        /// <summary>
        /// All locations.
        /// </summary>
        All = 0x007F
    }
}
