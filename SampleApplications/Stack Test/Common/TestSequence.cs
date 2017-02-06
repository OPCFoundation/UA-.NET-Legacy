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
using System.Text;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Opc.Ua.StackTest
{ 
    /// <summary>
    /// A sequence of test cases to run.
    /// </summary>
    public partial class TestSequence 
    {                
        #region Static Methods
        /// <summary>
        /// Loads a test sequence from a file.
        /// </summary>
        public static TestSequence Load(string filepath)
        {
            return Load(File.OpenRead(filepath));
        }
        
        /// <summary>
        /// Loads a test sequence from a stream.
        /// </summary>
        public static TestSequence Load(Stream istrm)
        {
			XmlTextReader reader = new XmlTextReader(istrm);

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TestSequence));
                
                TestSequence sequence = serializer.Deserialize(reader) as TestSequence;
                                
                uint lastId = 1;

                foreach (TestCase testcase in sequence.TestCase)
                {
                    if (testcase.TestId == 0)
                    {
                        testcase.TestId = lastId++;
                    }
                    else
                    {
                        if (testcase.TestId < lastId)
                        {
                            testcase.TestId = lastId++;
                        }
                        else
                        {
                            lastId = testcase.TestId+1;
                        }
                    }
                }

                return sequence;
            }
            finally
            {
                reader.Close();
            }
        }
        
        /// <summary>
        /// Saves a test sequence to a file.
        /// </summary>
        public static void Save(string filepath, TestSequence sequence)
        {
            Save(File.Open(filepath, FileMode.Create), sequence);
        }
        
        /// <summary>
        /// Saves a test sequence to a stream.
        /// </summary>
        public static void Save(Stream ostrm, TestSequence sequence)
        {
			XmlTextWriter writer = new XmlTextWriter(ostrm, Encoding.UTF8);
            writer.Formatting = Formatting.Indented;

            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(TestSequence));
                serializer.Serialize(writer, sequence);
            }
            finally
            {
                writer.Close();
            }
        }
        #endregion
    }
    
    /// <summary>
    /// Bits that indicate what level of detail to include in the logs.
    /// </summary>
    [Flags]
    public enum TestLogDetailMasks : int
    {
        /// <summary>
        /// Log all errors.
        /// </summary>
        Errors = 0x01,

        /// <summary>
        /// Log an event when starting the first iteration for a test case.
        /// </summary>
        FirstStart = 0x02,

        /// <summary>
        /// Log an event when starting the all iterations for a test case.
        /// </summary>
        AllsStarts = 0x04,

        /// <summary>
        /// Log an event after completing the last iteration for a test case.
        /// </summary>
        LastEnd = 0x08,

        /// <summary>
        /// Log an event after completing each iterations for a test case.
        /// </summary>
        AllsEnds = 0x10,

        /// <summary>
        /// Log first 24 bytes of random data used to create the request/response data.
        /// </summary>
        RandomData = 0x20        
    }
}
