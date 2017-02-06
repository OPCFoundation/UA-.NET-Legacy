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
using System.Text;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Reflection;
using System.IO;
using System.ComponentModel;
using System.Xml;
using System.Runtime.Serialization;

using Opc.Ua.Client.Controls;
using Opc.Ua.Sample.Controls;

namespace Opc.Ua.StackTest
{
    static class Program
    {
        static byte[] Encode(TestStackRequest request1, ServiceMessageContext context1, bool binary)
        {
            if (binary)
            {
                return BinaryEncoder.EncodeMessage(request1, context1);
            }
            else
            {
                ServiceMessageContext.ThreadContext = context1;

                MemoryStream ostrm = new MemoryStream();

                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Encoding = System.Text.Encoding.UTF8;

                using (XmlWriter writer = XmlWriter.Create(ostrm, settings))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(TestStackRequest));
                    serializer.WriteObject(writer, request1);
                }

                return ostrm.ToArray();
            }
        }

        static TestStackRequest Decode(byte[] message, ServiceMessageContext context1, bool binary)
        {
            if (binary)
            {
                return (TestStackRequest)BinaryDecoder.DecodeMessage(message, null, context1);
            }
            else
            {
                ServiceMessageContext.ThreadContext = context1;

                MemoryStream istrm = new MemoryStream(message);
                XmlReaderSettings settings = new XmlReaderSettings();

                using (XmlReader reader = XmlReader.Create(istrm, settings))
                {
                    DataContractSerializer serializer = new DataContractSerializer(typeof(TestStackRequest));
                    return (TestStackRequest)serializer.ReadObject(reader);
                }
            }
        }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception exception)
            {
				GuiUtils.HandleException("UA StackTest Client", MethodBase.GetCurrentMethod(), exception);
            }     
        }
    }
}
