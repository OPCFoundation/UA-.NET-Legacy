/* ========================================================================
 * Copyright (c) 2005-2013 The OPC Foundation, Inc. All rights reserved.
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
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Runtime.Serialization;
using System.Diagnostics;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Opc.Ua;

namespace OSIsoft.UA.HAUnitTest
{
    public static class HelperMethods
    {
        public static void CompareResults(IEnumerable<DataValue> expected, IEnumerable<DataValue> actual, string dataSetName, bool assertion)
        {
            List<DataValue> actualList = new List<DataValue>(actual);
            List<DataValue> expectedList = new List<DataValue>(expected);

            Assert.AreEqual(expectedList.Count, actualList.Count, "Number of DataValue in actual result is not expected");

            for(int i = 0; i < expectedList.Count; i++)
            {
                Debug.Write(String.Format("Expected: {0} ({1}) @ {2:HH:mm:ss.fff}, ", expectedList[i].Value, expectedList[i].StatusCode, expectedList[i].SourceTimestamp));
                if(actualList[i].Value is double || actualList[i].Value is float)
                    actualList[i].Value = Math.Round(Convert.ToDouble(actualList[i].Value), 1, MidpointRounding.AwayFromZero);
                Debug.WriteLine(String.Format("Actual: {0} ({1}) @ {2:HH:mm:ss.fff}", actualList[i].Value, actualList[i].StatusCode, actualList[i].SourceTimestamp));
                if (assertion)
                {
                    // Assert.IsTrue(actualList.Contains(ex), "cannot find data value @ {0} in the result from DataSet {1}: Value = {2}, Code = {3}",
                    //    ex.SourceTimestamp, dataSetName, ex.Value, ex.StatusCode);
                    Assert.AreEqual(expectedList[i].SourceTimestamp, actualList[i].SourceTimestamp, String.Format("timestamps are different, ({0})", dataSetName));
                    if (actualList[i].Value is int)
                        actualList[i].Value = Convert.ToDouble(actualList[i].Value);
                    Assert.AreEqual(expectedList[i].Value, actualList[i].Value, String.Format("values are different, ({0})", dataSetName));
                    /*
                     * Turn off status code checking temporarily. Need an aggrement on StatusCode calculation
                     */
                    uint code1 = expectedList[i].StatusCode.Code & ~((uint)0x0400),
                        code2 = actualList[i].StatusCode.Code & ~((uint)0x0400);
                    Assert.AreEqual(code1, code2, String.Format("status codes are different, ({0})", dataSetName));
                }
            }
        }
        public static object LoadXMLFile(string filePath, Type type)
        {
            FileInfo file = new FileInfo(filePath);
            XmlTextReader reader = new XmlTextReader(file.Open(FileMode.Open, FileAccess.Read));

            try
            {
                DataContractSerializer serializer = new DataContractSerializer(type);
                return serializer.ReadObject(reader, false);
            }
            finally
            {
                reader.Close();
            }
        }

        public static IEnumerable<DataValue> GetDataValues(IEnumerable<DataValueEntry> data)
        {
            foreach (DataValueEntry entry in data)
                yield return entry.GetDataValue();
        }
    }
}
