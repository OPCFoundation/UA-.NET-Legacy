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
using System.Xml;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Opc.Ua
{
    /// <summary>
    /// Adds constructs and format capabilities to the Variant class.
    /// </summary>
    /// <remarks>
    /// Any valid XML element can be stored in a Variant. However, this means that the schema for the
    /// Variant contents cannot explicitly defined in the XSD. As as result, this class includes logic
    /// that serializes standard types using the XML schema defined in Part 6.
    /// </remarks>
    partial class Variant : IFormattable
    {
        #region Constructors
        /// <summary>
        /// Should use the Variant.Null instead of creating empty objects. 
        /// </summary>
        private Variant()
        {
        }

        /// <summary>
        /// Stores the object in the variant (makes a copy).
        /// </summary>
        public Variant(object value)
        {
            if (value == null)
            {
                return;
            }

            XmlDocument document = new XmlDocument();

            Array array = value as Array;

            if (array != null)
            {
                this.Value = CreateArray(document, array);
            }
            else
            {
                this.Value = CreateScalar(document, value);
            }
        }
        #endregion

        #region Public Methods
        /// <summary>
        /// Returns the object stored in the Variant (makes a copy).
        /// </summary>
        public static object ToObject(Variant value)
        {
            if (value == null)
            {
                return null;
            }

            return value.ToObject();
        }

        /// <summary>
        /// Returns the object stored in the Variant (makes a copy).
        /// </summary>
        public object ToObject()
        {
            if (Value == null || Value.Nodes == null || Value.Nodes.Length == 0)
            {
                return null;
            }

            XmlElement parent = Value.Nodes[0] as XmlElement;
            
            if (parent == null)
            {
                return null;
            }

            if (parent.Name.StartsWith("ListOf"))
            {
                System.Collections.ArrayList elements = new System.Collections.ArrayList();

                for (XmlNode child = parent.FirstChild; child != null; child = child.NextSibling)
                {
                    XmlElement element = child as XmlElement;

                    if (element != null)
                    {
                        object value = ToObject(element);
                        elements.Add(value);
                    }
                }

                Type elementType = GetTypeFromXmlName(parent.Name.Substring("ListOf".Length));
                return elements.ToArray(elementType);
            }

            return ToObject(parent);
        }
        #endregion
        
        #region Static Members
        /// <summary>
        /// Returns an instance of a null NodeId.
        /// </summary>
        public static Variant Null 
        {
            get { return m_null; }
        }

        private static readonly Variant m_null = new Variant();
        #endregion
        
        #region IFormattable Members
        /// <summary>
        /// Returns the string representation of a NodeId.
        /// </summary>
        public string ToString(string format, IFormatProvider provider)
        {
            if (format == null)
            {
                return String.Format(provider, "{0}", ToObject(this));
            }

            throw new FormatException(String.Format("Invalid format string: '{0}'.", format));
        }
        #endregion

        #region Helper Functions
        /// <summary>
        /// Parses an XML element and returns the value contained in it. 
        /// </summary>
        private object ToObject(XmlElement element)
        {
            switch (element.Name)
            {
                case "Byte":
                {
                    return XmlConvert.ToByte(element.InnerText);
                }

                case "SByte":
                {
                    return XmlConvert.ToSByte(element.InnerText);
                }

                case "Int16":
                {
                    return XmlConvert.ToInt16(element.InnerText);
                }

                case "UInt16":
                {
                    return XmlConvert.ToUInt16(element.InnerText);
                }

                case "Int32":
                {
                    return XmlConvert.ToInt32(element.InnerText);
                }

                case "UInt32":
                {
                    return XmlConvert.ToUInt32(element.InnerText);
                }

                case "Int64":
                {
                    return XmlConvert.ToInt64(element.InnerText);
                }

                case "UInt64":
                {
                    return XmlConvert.ToUInt64(element.InnerText);
                }

                case "Single":
                {
                    return XmlConvert.ToSingle(element.InnerText);
                }

                case "Double":
                {
                    return XmlConvert.ToDouble(element.InnerText);
                }

                case "String":
                {
                    return element.InnerText;
                }

                case "DateTime":
                {
                    return XmlConvert.ToDateTime(element.InnerText, XmlDateTimeSerializationMode.Utc);
                }

                case "NodeId":
                {
                    XmlNode child = element.FirstChild;

                    string id = null;

                    if (GetValue(element, ref child, "Identifier", out id))
                    {
                        return new NodeId(id);
                    }

                    break;
                }

                case "ExpandedNodeId":
                {
                    XmlNode child = element.FirstChild;

                    string id = null;

                    if (GetValue(element, ref child, "Identifier", out id))
                    {
                        return new NodeId(id);
                    }

                    break;
                }

                case "QualifiedName":
                {
                    QualifiedName value = new QualifiedName();

                    XmlNode child = element.FirstChild;

                    string namespaceIndex = null;

                    if (GetValue(element, ref child, "NamespaceIndex", out namespaceIndex))
                    {
                        value.NamespaceIndex = XmlConvert.ToUInt16(namespaceIndex);
                    }

                    string name = null;

                    if (GetValue(element, ref child, "Name", out name))
                    {
                        value.Name = name;
                    }

                    return value;
                }

                case "LocalizedText":
                {
                    LocalizedText value = new LocalizedText();

                    XmlNode child = element.FirstChild;

                    string locale = null;

                    if (GetValue(element, ref child, "Locale", out locale))
                    {
                        value.Locale = locale;
                    }

                    string text = null;

                    if (GetValue(element, ref child, "Text", out text))
                    {
                        value.Text = text;
                    }

                    return value;
                }

                case "StatusCode":
                {
                    StatusCode value = new StatusCode();

                    XmlNode child = element.FirstChild;

                    string code = null;

                    if (GetValue(element, ref child, "Code", out code))
                    {
                        value.Code = XmlConvert.ToUInt32(code); ;
                    }

                    return value;
                }

                case "ExtensionObject":
                {
                    ExtensionObject value = new ExtensionObject();

                    XmlNode child = element.FirstChild;

                    string typeId = null;

                    if (GetValue(element, ref child, "TypeId", out typeId))
                    {
                        value.TypeId = new ExpandedNodeId(typeId);
                    }

                    for (XmlNode node = child; node != null; node = node.NextSibling)
                    {
                        XmlElement element2 = child as XmlElement;

                        if (element2 != null)
                        {
                            if (element2.Name == "Body")
                            {
                                ExtensionObjectBody body = new ExtensionObjectBody();
                                body.Nodes = new XmlNode[] { GetFirstElement(element2) }; 
                                value.Body = body;
                            }

                            break;
                        }
                    }

                    return value;
                }
            }

            return null;
        }

        /// <summary>
        /// Returns the XML name for the system type.
        /// </summary>
        private string GetXmlNameFromType(Type type)
        {
            switch (type.Name)
            {
                case "Boolean": return "Boolean";
                case "Byte": return "Byte";
                case "SByte": return "SByte";
                case "Int16": return "Int16";
                case "UInt16": return "UInt16";
                case "Int32": return "Int32";
                case "UInt32": return "UInt32";
                case "Int64": return "Int64";
                case "UInt64": return "UInt64";
                case "Single": return "Float";
                case "Double": return "Double";
                case "String": return "String";
                case "DateTime": return "DateTime";
                case "NodeId": return "NodeId";
                case "ExpandedNodeId": return "ExpandedNodeId";
                case "QualifiedName": return "QualifiedName";
                case "LocalizedText": return "LocalizedText";
                case "StatusCode": return "StatusCode";
                case "ExtensionObject": return "ExtensionObject";
                case "Variant": return "Variant";
            }

            return null;
        }

        /// <summary>
        /// Returns the system type for the XML name.
        /// </summary>
        private Type GetTypeFromXmlName(string name)
        {
            switch (name)
            {
                case "Boolean": return typeof(Boolean);
                case "Byte": return typeof(Byte);
                case "SByte": return typeof(SByte);
                case "Int16": return typeof(Int16);
                case "UInt16": return typeof(UInt16);
                case "Int32": return typeof(Int32);
                case "UInt32": return typeof(UInt32);
                case "Int64": return typeof(Int64);
                case "UInt64": return typeof(UInt64);
                case "Float": return typeof(Single);
                case "Double": return typeof(Double);
                case "String": return typeof(String);
                case "DateTime": return typeof(DateTime);
                case "NodeId": return typeof(NodeId);
                case "ExpandedNodeId": return typeof(ExpandedNodeId);
                case "QualifiedName": return typeof(QualifiedName);
                case "LocalizedText": return typeof(LocalizedText);
                case "StatusCode": return typeof(StatusCode);
                case "ExtensionObject": return typeof(ExtensionObject);
                case "Variant": return typeof(Variant);
            }

            return null;
        }

        /// <summary>
        /// Adds the value to the XML element.
        /// </summary>
        private VariantValue CreateArray(XmlDocument document, Array array)
        {
            VariantValue variant = new VariantValue();

            XmlElement parent = document.CreateElement(
                "ListOf" + GetXmlNameFromType(array.GetType().GetElementType()),
                Namespaces.OpcUaXsd);

            for (int ii = 0; ii < array.Length; ii++)
            {
                object element = array.GetValue(ii);
                
                VariantValue child = CreateScalar(document, element);

                if (child != null && child.Nodes != null)
                {
                    for (int jj = 0; jj < child.Nodes.Length; jj++)
                    {
                        parent.AppendChild(child.Nodes[jj]);
                    }
                }
            }

            variant.Nodes = new XmlNode[] { parent };

            return variant;
        }

        /// <summary>
        /// Adds the value to the XML element.
        /// </summary>
        private VariantValue CreateScalar(XmlDocument document, object value)
        {
            VariantValue variant = new VariantValue();

            if (value == null)
            {
                return variant;
            }

            XmlElement element = null;

            switch (value.GetType().Name)
            {
                case "Boolean":
                {
                    element = document.CreateElement("Boolean", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((bool)value);
                    break;
                }

                case "Byte":
                {
                    element = document.CreateElement("Byte", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((byte)value);
                    break;
                }

                case "SByte":
                {
                    element = document.CreateElement("SByte", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((sbyte)value);
                    break;
                }

                case "Int16":
                {
                    element = document.CreateElement("Int16", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((short)value);
                    break;
                }

                case "UInt16":
                {
                    element = document.CreateElement("UInt16", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((ushort)value);
                    break;
                }

                case "Int32":
                {
                    element = document.CreateElement("Int32", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((int)value);
                    break;
                }

                case "UInt32":
                {
                    element = document.CreateElement("UInt32", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((uint)value);
                    break;
                }

                case "Int64":
                {
                    element = document.CreateElement("Int64", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((long)value);
                    break;
                }

                case "UInt64":
                {
                    element = document.CreateElement("UInt64", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((ulong)value);
                    break;
                }

                case "Single":
                {
                    element = document.CreateElement("Float", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((float)value);
                    break;
                }

                case "Double":
                {
                    element = document.CreateElement("Double", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((double)value);
                    break;
                }

                case "String":
                {
                    element = document.CreateElement("String", Namespaces.OpcUaXsd);
                    element.InnerText = (string)value;
                    break;
                }

                case "DateTime":
                {
                    element = document.CreateElement("DateTime", Namespaces.OpcUaXsd);
                    element.InnerText = XmlConvert.ToString((DateTime)value, XmlDateTimeSerializationMode.Utc);
                    break;
                }

                case "NodeId":
                {
                    element = document.CreateElement("NodeId", Namespaces.OpcUaXsd);
                    AddChild(document, element, "Identifier", ((NodeId)value).Identifier);
                    break;
                }

                case "ExpandedNodeId":
                {
                    element = document.CreateElement("ExpandedNodeId", Namespaces.OpcUaXsd);
                    AddChild(document, element, "Identifier", ((ExpandedNodeId)value).Identifier);
                    break;
                }

                case "QualifiedName":
                {
                    element = document.CreateElement("QualifiedName", Namespaces.OpcUaXsd);
                    AddChild(document, element, "NamespaceIndex", XmlConvert.ToString(((QualifiedName)value).NamespaceIndex));
                    AddChild(document, element, "Name", ((QualifiedName)value).Name);
                    break;
                }

                case "LocalizedText":
                {
                    element = document.CreateElement("LocalizedText", Namespaces.OpcUaXsd);
                    AddChild(document, element, "Locale", ((LocalizedText)value).Locale);
                    AddChild(document, element, "Text", ((LocalizedText)value).Text);
                    break;
                }

                case "StatusCode":
                {
                    element = document.CreateElement("StatusCode", Namespaces.OpcUaXsd);

                    uint? code = ((StatusCode)value).Code;

                    if (code != null && code.Value != StatusCodes.Good)
                    {
                        AddChild(document, element, "Code", XmlConvert.ToString(code.Value));
                    }

                    break;
                }

                case "ExtensionObject":
                {
                    element = document.CreateElement("ExtensionObject", Namespaces.OpcUaXsd);

                    ExtensionObject extension = (ExtensionObject)value;

                    if (extension != null)
                    {
                        XmlElement typeId = document.CreateElement("TypeId", Namespaces.OpcUaXsd);
                        element.AppendChild(typeId);
                        AddChild(document, typeId, "Identifier", extension.TypeId.Identifier);

                        XmlElement body = document.CreateElement("Body", Namespaces.OpcUaXsd);

                        if (extension.Body != null && extension.Body.Nodes != null && extension.Body.Nodes.Length > 0)
                        {
                            body.InnerXml = extension.Body.Nodes[0].OuterXml;
                        }

                        element.AppendChild(body);
                    }

                    break;
                }
            }

            variant.Nodes = new XmlNode[] { element };

            return variant;
        }

        /// <summary>
        /// Adds the value to the XML element.
        /// </summary>
        private void AddChild(XmlDocument document, XmlElement parent, string name, string value)
        {
            XmlElement element = document.CreateElement(name, Namespaces.OpcUaXsd);
            element.InnerText = value;
            parent.AppendChild(element);
        }

        /// <summary>
        /// Extracts a value from the XML element.
        /// </summary>
        private bool GetValue(XmlElement parent, ref XmlNode sibling, string name, out string value)
        {
            value = null;

            for (XmlNode child = sibling; child != null; child = child.NextSibling)
            {
                sibling = child.NextSibling;

                XmlElement element = child as XmlElement;

                if (element != null)
                {
                    if (element.Name == name && element.NamespaceURI == Namespaces.OpcUaXsd)
                    {
                        value = element.InnerText;
                        return true;
                    }

                    break;
                }
            }

            return false;
        }

        /// <summary>
        /// Returns the first child element for the parent.
        /// </summary>
        private XmlElement GetFirstElement(XmlElement parent)
        {
            for (XmlNode node = parent.FirstChild; node != null; node = node.NextSibling)
            {
                XmlElement element = node as XmlElement;

                if (element != null)
                {
                    return element;
                }
            }

            return null;
        }
        #endregion
    }
}
