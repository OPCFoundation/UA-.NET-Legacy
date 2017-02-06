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
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Collections.Generic;

namespace Opc.Ua.StackTest
{
    #region Class Logger
    /// <summary>
    /// A class handling logging test events to a file.
    /// </summary>
    public class Logger
    {
        #region Constructors
        /// <summary>
        /// The default constructor.
        /// </summary>
        /// <param name="filepath">File path for the logger.</param>
        /// <param name="detailLevel">Log detail level.<see cref="TestLogDetailMasks"/></param>
        public Logger(string filepath, TestLogDetailMasks detailLevel)
        {
            m_filepath = filepath;
            m_detailLevel = detailLevel;
            m_serializer = new XmlSerializer(typeof(TestEvent), Namespaces.OpcUa + "Test");
        }
        #endregion

        #region Public Members
        /// <summary>
        /// Opens the log file.It writes the parameter tags in xml file
        /// </summary>
        /// <param name="secureChannelId">Channel Id.</param>
        /// <param name="testFilePath">Test case file path</param>
        /// <param name="randomFilePath">Random number generator file path.</param>
        public void Open(string secureChannelId, string testFilePath, string randomFilePath)
        {
            if (m_logger != null)
            {
                Close();
            }

            if (m_detailLevel == 0)
            {
                return;
            }

            m_logger = new XmlTextWriter(File.Open(m_filepath, FileMode.Create), Encoding.UTF8);
            m_logger.Formatting = Formatting.Indented;

            m_logger.WriteStartElement("TestLog", Namespaces.OpcUa + "Test");
            m_logger.WriteAttributeString("xmlns:xsi", "http://www.w3.org/2001/XMLSchema-instance");

            m_logger.WriteElementString("ProcessName", Namespaces.OpcUa + "Test", Process.GetCurrentProcess().MainModule.ModuleName);
            m_logger.WriteElementString("SecureChannelId", Namespaces.OpcUa + "Test", secureChannelId);
            m_logger.WriteElementString("TestCaseFile", Namespaces.OpcUa + "Test", new FileInfo(testFilePath).FullName);
            m_logger.WriteElementString("RandomDataFile", Namespaces.OpcUa + "Test", new FileInfo(randomFilePath).FullName);
            m_logger.WriteElementString("CreateTime", Namespaces.OpcUa + "Test", XmlConvert.ToString(DateTime.UtcNow, XmlDateTimeSerializationMode.Utc));
        }

        /// <summary>
        /// Closes the log file.
        /// </summary>
        public void Close()
        {
            if (m_logger != null)
            {
                m_logger.WriteEndElement();
                m_logger.Close();
                m_logger = null;
            }
        }

        /// <summary>
        /// Logs an event when a test case starts.
        /// </summary>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        public void LogStartEvent(TestCase testCase, int iteration)
        {
            // the start event can be logged each iteration or once per test case.
            if ((m_detailLevel & TestLogDetailMasks.AllsStarts) == 0)
            {
                if ((m_detailLevel & TestLogDetailMasks.FirstStart) == 0)
                {
                    return;
                }

                if (!TestUtils.IsSetupIteration(iteration))
                {
                    return;
                }
            }

            TestEvent events = new TestEvent();

            events.TestId = testCase.TestId;
            events.Timestamp = DateTime.UtcNow;
            events.Iteration = iteration;
            events.EventType = TestEventType.Started;

            LogEvent(events);
        }

        /// <summary>
        /// Logs an event when a test case completes sucessfully.
        /// </summary>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        public void LogCompleteEvent(TestCase testCase, int iteration)
        {
            // the complete event can be logged each iteration or once per test case.
            if ((m_detailLevel & TestLogDetailMasks.AllsEnds) == 0)
            {
                if ((m_detailLevel & TestLogDetailMasks.LastEnd) == 0)
                {
                    return;
                }

                if (!TestUtils.IsSetupIteration(iteration))
                {
                    return;
                }
            }

            TestEvent events = new TestEvent();

            events.TestId = testCase.TestId;
            events.Timestamp = DateTime.UtcNow;
            events.Iteration = iteration;
            events.EventType = TestEventType.Completed;

            LogEvent(events);
        }

        /// <summary>
        /// Logs an event when a test case cannot be validated.
        /// </summary>
        /// <param name="testId">Test case Id.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <param name="e">Exception to be logged.</param>
        public void LogNotValidatedEvent(uint testId, int iteration, Exception e)
        {
            if ((m_detailLevel & TestLogDetailMasks.Errors) == 0)
            {
                return;
            }

            TestEvent events = new TestEvent();

            events.TestId = testId;
            events.Timestamp = DateTime.UtcNow;
            events.Iteration = iteration;
            events.EventType = TestEventType.NotValidated;
            events.Details = new ServiceResult(e).ToLongString();

            LogEvent(events);
        }

        /// <summary>
        /// Logs an event when an error occurs during a test case.
        /// </summary>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        /// <param name="e">Exception to be logged.</param>
        public void LogErrorEvent(TestCase testCase, int iteration, Exception e)
        {
            if ((m_detailLevel & TestLogDetailMasks.Errors) == 0)
            {
                return;
            }

            TestEvent events = new TestEvent();

            events.TestId = testCase.TestId;
            events.Timestamp = DateTime.UtcNow;
            events.Iteration = iteration;
            events.EventType = TestEventType.Failed;
            events.Details = new ServiceResult(e).ToLongString();

            LogEvent(events);
        }

        /// <summary>
        /// Logs an event to the log.
        /// </summary>
        /// <param name="events">Test event.</param>
        public void LogEvent(TestEvent events)
        {
            lock (m_lock)
            {
                if (m_detailLevel == 0)
                {
                    return;
                }
                if (m_serializer == null || m_logger == null) return;

                m_serializer.Serialize(m_logger, events);

                if (m_TestLogEvent != null && events.EventType != TestEventType.StackEvents)
                {
                    m_TestLogEvent(this, events);
                }
            }
        }

        /// <summary>
        /// Logs stack events of an iteration
        /// </summary>
        /// <param name="stackEvents">List of stack events.</param>
        /// <param name="testCase">This parameter stores the test case related data.</param>
        /// <param name="iteration">This parameter stores the current iteration number.</param>
        public void LogStackEvents(List<StackEvent> stackEvents, TestCase testCase, int iteration)
        {
            if (stackEvents != null &&
                stackEvents.Count != 0 &&
                iteration != TestCases.TestSetupIteration &&
                iteration != TestCases.TestCleanupIteration
                )
            {
                StackEvent[] stackEventsArray = new StackEvent[stackEvents.Count];
                stackEvents.CopyTo(stackEventsArray);

                TestEvent testEvent = new TestEvent();
                testEvent.TestId = testCase.TestId;

                testEvent.Iteration = iteration;
                testEvent.EventType = TestEventType.StackEvents;
                testEvent.Timestamp = DateTime.UtcNow;
                testEvent.StackEvents = stackEventsArray;
                LogEvent(testEvent);
            }
        }

        /// <summary>
        /// This event notifies to the caller that application is logging the test event.
        /// </summary>
        public event TestLogEventHandler TestLogEvent
        {
            add
            {
                lock (m_lock)
                {
                    m_TestLogEvent += value;
                }
            }

            remove
            {
                lock (m_lock)
                {
                    m_TestLogEvent -= value; ;
                }
            }
        }
        #endregion

        #region Public Properties
        /// <summary>
        /// Checks if log file is opened or not.
        /// </summary>
        public bool IsOpened
        {
            get
            {
                lock (m_lock)
                {
                    return m_logger != null;
                }
            }

        }
        #endregion

        #region Private Fields        
        // File path for log.        
        private string m_filepath;
        
        // Test log detail level.      
        private TestLogDetailMasks m_detailLevel;
        
        // XmlTextWriter used to log the error in the file.        
        private XmlTextWriter m_logger;
        
        // Object of type XmlSerializer.        
        private XmlSerializer m_serializer;
        
        // Object of type TestLogEventHandler.        
        private event TestLogEventHandler m_TestLogEvent;
        
        // Object used for locking.        
        private object m_lock = new object();
        #endregion
    }
    #endregion

    #region Delegates
    /// <summary>
    /// The delegate used to receive test log event notifications.
    /// </summary>
    public delegate void TestLogEventHandler(Logger logger, TestEvent e);
    #endregion
}
