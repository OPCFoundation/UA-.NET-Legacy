/* ========================================================================
 * Copyright (c) 2005-2017 The OPC Foundation, Inc. All rights reserved.
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
using System.ServiceModel;
using System.Runtime.Serialization;
using System.Xml;

namespace Opc.Ua
{
    /// <summary>
    /// Adds constructors, comparison functions and format capabilities to the QualifiedName class.
	/// </summary>
	public partial class QualifiedName : IFormattable, IComparable
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with default values.
        /// </summary>
        /// <remarks>
        /// Initializes the object with default values.
        /// </remarks>
        internal QualifiedName()
        {
            NamespaceIndex = 0;
            Name           = null;
        }
                
        /// <summary>
        /// Creates a deep copy of the value.
        /// </summary>
        /// <remarks>
        /// Creates a deep copy of the value.
        /// </remarks>
        /// <param name="value">The qualified name to copy</param>
        /// <exception cref="ArgumentNullException">Thrown if the provided value is null</exception>
        public QualifiedName(QualifiedName value)
        {            
            if (value == null) throw new ArgumentNullException("value");

            Name = value.Name;
            NamespaceIndex = value.NamespaceIndex;
        }

        /// <summary>
        /// Initializes the object with a name.
        /// </summary>
        /// <remarks>
        /// Initializes the object with a name.
        /// </remarks>
        /// <param name="name">The name-portion to store as part of the fully qualified name</param>
        public QualifiedName(string name)
        {
            NamespaceIndex = 0;
            Name           = name;
        }
        
        /// <summary>
        /// Initializes the object with a name and a namespace index.
        /// </summary>
        /// <remarks>
        /// Initializes the object with a name and a namespace index.
        /// </remarks>
        /// <param name="name">The name-portion of the fully qualified name</param>
        /// <param name="namespaceIndex">The index of the namespace within the namespace-table</param>
        public QualifiedName(string name, ushort namespaceIndex)
        {
            NamespaceIndex = namespaceIndex;
            Name           = name;
        }
        #endregion
        
        #region IComparable Members
        /// <summary>
        /// Compares two QualifiedNames.
        /// </summary>
        /// <param name="obj">The object to compare to.</param>
        /// <returns>
        /// Less than zero if the instance is less than the object.
        /// Zero if the instance is equal to the object.
        /// Greater than zero if the instance is greater than the object.
        /// </returns>
        public int CompareTo(object obj)
        {            
            if (Object.ReferenceEquals(obj, null))
            {
                return -1;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return 0;
            }

            QualifiedName qname = obj as QualifiedName;

            if (qname == null)
            {
                return typeof(QualifiedName).GUID.CompareTo(obj.GetType().GUID);
            }

            if (qname.NamespaceIndex != NamespaceIndex)
            {
                return NamespaceIndex.CompareTo(qname.NamespaceIndex);
            }
            
            if (Name != null)
            {
                return Name.CompareTo(qname.Name);
            }
            
            return -1;
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Returns a suitable hash value for the instance.
        /// </summary>
        public override int GetHashCode()
        {
            if (Name != null)
            {
                return Name.GetHashCode();
            }

            return 0;
        }

        /// <summary>
        /// Returns true if the objects are equal.
        /// </summary>
        /// <remarks>
        /// Returns true if the objects are equal.
        /// </remarks>
        /// <param name="obj">The object to compare to this/me</param>
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(obj, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            QualifiedName qname = obj as QualifiedName;

            if (qname == null)
            {
                return false;
            }

            if (qname.NamespaceIndex != NamespaceIndex)
            {
                return false;
            }

            return qname.Name == Name;
        }
        
        /// <summary>
        /// Returns true if the objects are equal.
        /// </summary>
        /// <remarks>
        /// Returns true if the objects are equal.
        /// </remarks>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        public static bool operator==(QualifiedName value1, QualifiedName value2)
        {
            if (!Object.ReferenceEquals(value1, null))
            {
                return value1.Equals(value2);
            }

            return Object.ReferenceEquals(value2, null);
        }

        /// <summary>
        /// Returns true if the objects are not equal.
        /// </summary>
        /// <remarks>
        /// Returns true if the objects are equal.
        /// </remarks>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        public static bool operator!=(QualifiedName value1, QualifiedName value2)
        {
            if (!Object.ReferenceEquals(value1, null))
            {
                return !value1.Equals(value2);
            }

            return !Object.ReferenceEquals(value2, null);
        }

        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <remarks>
        /// Returns the string representation of the object.
        /// </remarks>
        public override string ToString()
        {
            return ToString(null, null);
        }
        #endregion

        #region IFormattable Members
        /// <summary>
        /// Returns the string representation of the object.
        /// </summary>
        /// <remarks>
        /// Returns the string representation of the object.
        /// </remarks>
        /// <param name="format">(Unused) Always pass null</param>
        /// <param name="provider">(Unused) Always pass null</param>
        /// <exception cref="FormatException">Thrown if non-null parameters are passed</exception>
        public string ToString(string format, IFormatProvider provider)
        {
            if (format == null)
            {
                if (this.NamespaceIndex > 0)
                {
                    return String.Format(provider, "{1}:{0}", this.Name, this.NamespaceIndex);
                }

                return String.Format(provider, "{0}", this.Name);
            }
        
            throw new FormatException(String.Format("Invalid format string: '{0}'.", format));
        }
        #endregion

        #region ICloneable Members
        /// <summary>
        /// Makes a deep copy of the object.
        /// </summary>
        /// <remarks>
        /// Makes a deep copy of the object.
        /// </remarks>
        public object Clone()
        {
            // this object cannot be altered after it is created so no new allocation is necessary.
            return this;
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Converts an expanded node id to a node id using a namespace table.
        /// </summary>
        public static QualifiedName Create(string name, string namespaceUri, NamespaceTable namespaceTable)
        {
            // check for null.
            if (String.IsNullOrEmpty(name))
            {
                return QualifiedName.Null;
            }

            // return a name using the default namespace.
            if (String.IsNullOrEmpty(namespaceUri))
            {
                return new QualifiedName(name);
            }

            // find the namespace index.
            int namespaceIndex = -1;

            if (namespaceTable != null)
            {
                namespaceIndex = namespaceTable.GetIndex(namespaceUri);
            }

            // oops - not found.
            if (namespaceIndex < 0)
            {
                throw new ApplicationException(String.Format("NamespaceUri ({0}) is not in the NamespaceTable.", namespaceUri));
            }
            
            // return the name.
            return new QualifiedName(name, (ushort)namespaceIndex);
        }

        /// <summary>
        /// Returns true if the QualifiedName is valid.
        /// </summary>
        public static bool IsValid(QualifiedName value, NamespaceTable namespaceUris)
        {
            if (value == null || String.IsNullOrEmpty(value.Name))
            {
                return false;
            }

            if (namespaceUris != null)
            {
                if (namespaceUris.GetString((ushort)value.NamespaceIndex) == null)
                {
                    return false;
                }
            }
                
            return true;
        }

        /// <summary>
        /// Parses a string containing a QualifiedName with the syntax n:qname
        /// </summary>
        /// <param name="text">The QualifiedName value as a string.</param>
        /// <exception cref="ServiceResultException">Thrown under a variety of circumstances, each time with a specific message.</exception>
        public static QualifiedName Parse(string text)
        {
            // check for null.
            if (String.IsNullOrEmpty(text))
            {
                return QualifiedName.Null;
            }
            
            int index = text.IndexOf(':');

            if (index == -1)
            {
                return new QualifiedName(text);
            }

            try
            {
                ushort namespaceIndex = Convert.ToUInt16(text.Substring(0, index));
                return new QualifiedName(text.Substring(index+1), namespaceIndex);
            }
            catch (FormatException)
            {
                // assume the QualifiedName contains an embedded ':'.
                return new QualifiedName(text);
            }
        }
        
        /// <summary>
        /// Returns true if the value is null.
        /// </summary>
        /// <param name="value">The qualified name to check</param>
        public static bool IsNull(QualifiedName value)
        {
            if (value != null)
            {
                if (value.NamespaceIndex != 0 || !String.IsNullOrEmpty(value.Name))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Converts a string to a qualified name.
        /// </summary>
        /// <remarks>
        /// Converts a string to a qualified name.
        /// </remarks>
        /// <param name="value">The string to turn into a fully qualified name</param>
        public static QualifiedName ToQualifiedName(string value)
        {
            return new QualifiedName(value);
        }
        
        /// <summary>
        /// Converts a string to a qualified name.
        /// </summary>
        /// <remarks>
        /// Converts a string to a qualified name.
        /// </remarks>
        /// <param name="value">The string to turn into a fully qualified name</param>
        public static implicit operator QualifiedName(string value)
        {
            return new QualifiedName(value);
        }

        /// <summary>
        /// Returns an instance of a null QualifiedName.
        /// </summary>
        public static QualifiedName Null 
        {
            get { return m_null; }
        }

        private static readonly QualifiedName m_null = new QualifiedName();
        #endregion
    }
}
