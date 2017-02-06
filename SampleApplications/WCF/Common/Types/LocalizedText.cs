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
    /// Adds constructors, comparison functions and format capabilities to the LocalizedText class.
	/// </summary>
    public partial class LocalizedText : IFormattable
    {
        #region Constructors
        /// <summary>
        /// Initializes the object with the default values.
        /// </summary>
        /// <remarks>
        /// Initializes the object with the default values.
        /// </remarks>
        internal LocalizedText()
        {
        }

        /// <summary>
        /// Creates a deep copy of the value.
        /// </summary>
        /// <remarks>
        /// Creates a deep copy of the value.
        /// </remarks>
        /// <param name="value">The text to create an instance from</param>
        /// <exception cref="ArgumentNullException">Thrown when the value is null</exception>
        public LocalizedText(LocalizedText value)
        {
            if (value == null) throw new ArgumentNullException("value");

            Locale = value.Locale;
            Text = value.Text;
        }

        /// <summary>
        /// Initializes the object with a text and the default locale.
        /// </summary>
        /// <remarks>
        /// Initializes the object with a text and the default locale.
        /// </remarks>
        /// <param name="text">The plain text stored within this object</param>
        public LocalizedText(string text)
        {
            Locale = null;
            Text = text;
        }

        /// <summary>
        /// Initializes the object with a locale and text.
        /// </summary>
        /// <remarks>
        /// Initializes the object with a locale and text.
        /// </remarks>
        /// <param name="locale">The locale code applicable for the specified text</param>
        /// <param name="text">The text to store</param>
        public LocalizedText(string locale, string text)
        {
            Locale = locale;
            Text = text;
        }
        #endregion

        #region Overridden Methods
        /// <summary>
        /// Returns true if the objects are equal.
        /// </summary>
        /// <remarks>
        /// Returns true if the objects are equal.
        /// </remarks>
        /// <param name="obj">The object to compare to this</param>
        public override bool Equals(object obj)
        {
            if (Object.ReferenceEquals(this, obj))
            {
                return true;
            }

            LocalizedText ltext = obj as LocalizedText;

            if (ltext == null)
            {
                return false;
            }

            if (ltext.Locale != Locale)
            {
                return false;
            }

            return ltext.Text == Text;
        }

        /// <summary>
        /// Returns true if the objects are equal.
        /// </summary>
        /// <remarks>
        /// Returns true if the two objects are equal.
        /// </remarks>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        public static bool operator ==(LocalizedText value1, LocalizedText value2)
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
        /// Returns true if the two objects are not equal.
        /// </remarks>
        /// <param name="value1">The first value to compare</param>
        /// <param name="value2">The second value to compare</param>
        public static bool operator !=(LocalizedText value1, LocalizedText value2)
        {
            if (!Object.ReferenceEquals(value1, null))
            {
                return !value1.Equals(value2);
            }

            return !Object.ReferenceEquals(value2, null);
        }

        /// <summary>
        /// Returns a suitable hash code for the object.
        /// </summary>
        /// <remarks>
        /// Returns a suitable hash code for the object.
        /// </remarks>
        public override int GetHashCode()
        {
            if (Text != null)
            {
                return Text.GetHashCode();
            }

            return 0;
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
        /// <param name="format">(Unused). Always pass NULL/NOTHING</param>
        /// <param name="provider">(Unused). Always pass NULL/NOTHING</param>
        /// <exception cref="FormatException">Thrown if non-null parameters are used</exception>
        public string ToString(string format, IFormatProvider provider)
        {
            if (format == null)
            {
                return String.Format(provider, "{0}", this.Text);
            }

            throw new FormatException(String.Format("Invalid format string: '{0}'.", format));
        }
        #endregion

        #region Static Methods
        /// <summary>
        /// Converts a string to a localized text.
        /// </summary>
        /// <remarks>
        /// Converts a string to a localized text.
        /// </remarks>
        /// <param name="value">The string to store as localized text</param>
        public static LocalizedText ToLocalizedText(string value)
        {
            return new LocalizedText(value);
        }

        /// <summary>
        /// Converts a string to a localized text.
        /// </summary>
        /// <remarks>
        /// Converts a string to a localized text.
        /// </remarks>
        /// <param name="value">The string to store as localized text</param>
        public static implicit operator LocalizedText(string value)
        {
            return new LocalizedText(value);
        }

        /// <summary>
        /// Returns an instance of a null LocalizedText.
        /// </summary>
        public static LocalizedText Null
        {
            get { return m_null; }
        }

        private static readonly LocalizedText m_null = new LocalizedText();

        /// <summary>
        /// Returns true if the text is a null or empty string.
        /// </summary>
        public static bool IsNullOrEmpty(LocalizedText value)
        {
            if (value == null)
            {
                return true;
            }

            return String.IsNullOrEmpty(value.Text);
        }
        #endregion
    }
}
