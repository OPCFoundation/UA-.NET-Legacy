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
    /// Active Directory name translation.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Translates names between Active Directory formats, e.g. from down-level NT4 
    /// style names ("ACME\alice") to User Principal Name ("alice@acme.com").
    /// </para>
    /// <para>
    /// This utility class encapsulates the ActiveDs.dll COM library.
    /// </para>
    /// </remarks>
    public static class NameTranslator
    {
        const int NameTypeUpn = (int)ActiveDs.ADS_NAME_TYPE_ENUM.ADS_NAME_TYPE_USER_PRINCIPAL_NAME;
        const int NameTypeNt4 = (int)ActiveDs.ADS_NAME_TYPE_ENUM.ADS_NAME_TYPE_NT4;
        const int NameTypeDn = (int)ActiveDs.ADS_NAME_TYPE_ENUM.ADS_NAME_TYPE_1779;

        /// <summary>
        /// Convert from a down-level NT4 style name to an Active Directory User Principal Name (UPN).
        /// </summary>
        public static string TranslateDownLevelToUpn(string downLevelNt4Name)
        {
            string userPrincipalName;
            ActiveDs.NameTranslate nt = new ActiveDs.NameTranslate();
            nt.Set(NameTypeNt4, downLevelNt4Name);
            userPrincipalName = nt.Get(NameTypeUpn);
            return userPrincipalName;
        }

        /// <summary>
        /// Convert from an Active Directory User Principal Name (UPN) to a down-level NT4 style name.
        /// </summary>
        public static string TranslateUpnToDownLevel(string userPrincipalName)
        {
            string downLevelName;
            ActiveDs.NameTranslate nt = new ActiveDs.NameTranslate();
            nt.Set(NameTypeUpn, userPrincipalName);
            downLevelName = nt.Get(NameTypeNt4);
            return downLevelName;
        }
    }
}
