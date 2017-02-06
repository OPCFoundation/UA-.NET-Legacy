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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Globalization;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Opc.Ua
{
    /// <summary>
    /// Adds constructors, comparison functions and format capabilities to the ExpandedNodeId class.
    /// </summary>
    public partial class ExpandedNodeId : IComparable, IFormattable
    {
        #region Constructors
        /// <summary>
        /// Initializes a null node id.
        /// </summary>
        private ExpandedNodeId()
        {
        }

        /// <summary>
        /// Initializes the node id with an identifier.
        /// </summary>
        public ExpandedNodeId(string identifier)
        {
            Identifier = identifier;
        }

        /// <summary>
        /// Initializes the node id with an identifier.
        /// </summary>
        public ExpandedNodeId(uint identifier)
        {
            Identifier = String.Format("i={0}", identifier);
        }

        /// <summary>
        /// Initializes the node id with an identifier.
        /// </summary>
        public ExpandedNodeId(NodeId nodeId)
        {
            if (nodeId != null)
            {
                Identifier = nodeId.Identifier;
            }
        }
        #endregion

        #region Static Members
        /// <summary>
        /// Returns an instance of a null NodeId.
        /// </summary>
        public static ExpandedNodeId Null 
        {
            get { return m_null; }
        }

        private static readonly ExpandedNodeId m_null = new ExpandedNodeId();
        #endregion
        
        #region Public Methods
        /// <summary>
        /// Formats a node id as a string.
        /// </summary>
        public string Format()
        {
            StringBuilder buffer = new StringBuilder();
            Format(buffer);
            return buffer.ToString();
        }
        
        /// <summary>
        /// Formats the NodeId as a string and appends it to the buffer.
        /// </summary>
        public void Format(StringBuilder buffer)
        {
            if (Identifier != null)
            {
                buffer.Append(Identifier);
            }
        }

        /// <summary>
        /// Returns the string representation of a NodeId.
        /// </summary>
        public override string ToString()
        {
            return ToString(null, null);
        }
        #endregion
        
		#region IComparable Members
        /// <summary>
        /// Compares the current instance to the object.
        /// </summary>
        public int CompareTo(object obj)
        {  
            // check for null.
            if (Object.ReferenceEquals(obj, null))
            {
				return -1;
            }

            // check for reference comparisons.
            if (Object.ReferenceEquals(this, obj))
            {
                return 0;
            }          

            string id = obj as string;

            if (id == null)
            {
                NodeId nodeId = obj as NodeId;

                if (nodeId != null)
                {
                    id = nodeId.Identifier;
                }
                else
                {
                    ExpandedNodeId expandedNodeId = obj as ExpandedNodeId;

                    if (expandedNodeId != null)
                    {
                        id = expandedNodeId.Identifier;
                    }
                }
            }

            if (id == null)
            {
                return (Identifier != null)?-1:0;
            }

            if (Identifier != null)
            {
                return Identifier.CompareTo(id);
            }

            return +1;
        }

        /// <summary>
        /// Returns true if a is greater than b.
        /// </summary>
        public static bool operator >(ExpandedNodeId a, ExpandedNodeId b)
        {
            if (!Object.ReferenceEquals(a, null))
            {
                return a.CompareTo(b) > 0;
            }

            return false;
        }
      
        /// <summary>
        /// Returns true if a is less than b.
        /// </summary>
        public static bool operator <(ExpandedNodeId a, ExpandedNodeId b)
        {
            if (!Object.ReferenceEquals(a, null))
            {
                return a.CompareTo(b) < 0;
            }

            return true;
        }
        #endregion

        #region IFormattable Members
        /// <summary>
        /// Returns the string representation of a NodeId.
        /// </summary>
        public string ToString(string format, IFormatProvider provider)
        {
            if (format == null)
            {
                return String.Format(provider, "{0}", Format());
            }

            throw new FormatException(String.Format("Invalid format string: '{0}'.", format));
        }
        #endregion

		#region Comparison Functions
        /// <summary>
        /// Determines if the specified object is equal to the NodeId.
        /// </summary>
        public override bool Equals(object obj)
        {
            return (CompareTo(obj) == 0);
        }

        /// <summary>
        /// Returns a unique hashcode for the NodeId
        /// </summary>
        public override int GetHashCode()
        {
            if (Identifier == null)
            {
                return 0;
            }

            return Identifier.GetHashCode();
        }

        /// <summary>
        /// Returns true if the objects are equal.
        /// </summary>
        public static bool operator==(ExpandedNodeId a, object b)
        {
            if (Object.ReferenceEquals(a, null))
            {
                return Object.ReferenceEquals(b, null);
            }

            return (a.CompareTo(b) == 0);
        }

        /// <summary>
        /// Returns true if the objects are not equal.
        /// </summary>
        public static bool operator!=(ExpandedNodeId a, object b)
        {
            if (Object.ReferenceEquals(a, null))
            {
                return !Object.ReferenceEquals(b, null);
            }

            return (a.CompareTo(b) != 0);
        }
		#endregion
    }
}
