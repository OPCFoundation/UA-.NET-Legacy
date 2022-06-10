/* ========================================================================
 * Copyright (c) 2005-2020 The OPC Foundation, Inc. All rights reserved.
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
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace Opc.Ua.Security.Certificates
{
    /// <summary>
    /// Supporting functions for X509 extensions.
    /// </summary>
    public static class X509Extensions
    {
        /// <summary>
        /// Find a typed extension in a certificate.
        /// </summary>
        /// <typeparam name="T">The type of the extension.</typeparam>
        /// <param name="certificate">The certificate with extensions.</param>
        public static T FindExtension<T>(this X509Certificate2 certificate) where T : X509Extension
        {
            return FindExtension<T>(certificate.Extensions);
        }

        /// <summary>
        /// Find a typed extension in a extension collection.
        /// </summary>
        /// <typeparam name="T">The type of the extension.</typeparam>
        /// <param name="extensions">The extensions to search.</param>
        public static T FindExtension<T>(this X509ExtensionCollection extensions) where T : X509Extension
        {
            if (extensions == null) throw new ArgumentNullException(nameof(extensions));
            lock (extensions.SyncRoot)
            {
                // search known custom extensions
                if (typeof(T) == typeof(X509AuthorityKeyIdentifierExtension))
                {
                    var extension = extensions.Cast<X509Extension>().FirstOrDefault(e => (
                        e.Oid.Value == X509AuthorityKeyIdentifierExtension.AuthorityKeyIdentifierOid ||
                        e.Oid.Value == X509AuthorityKeyIdentifierExtension.AuthorityKeyIdentifier2Oid)
                    );
                    if (extension != null)
                    {
                        return new X509AuthorityKeyIdentifierExtension(extension, extension.Critical) as T;
                    }
                }

                if (typeof(T) == typeof(X509SubjectAltNameExtension))
                {
                    var extension = extensions.Cast<X509Extension>().FirstOrDefault(e => (
                        e.Oid.Value == X509SubjectAltNameExtension.SubjectAltNameOid ||
                        e.Oid.Value == X509SubjectAltNameExtension.SubjectAltName2Oid)
                    );
                    if (extension != null)
                    {
                        return new X509SubjectAltNameExtension(extension, extension.Critical) as T;
                    }
                }

                // search builtin extension
                return extensions.OfType<T>().FirstOrDefault();
            }
        }
    }
}
