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
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Opc.Ua;
using Opc.Ua.Server;

namespace OSIsoft.UA.HAUnitTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass, DeploymentItem("TestData.xml")]
    public class AggregateUnitTest
    {
        #region private members
        private static Dictionary<string, TestData> TestData;
        private static Dictionary<AggregateType, NodeId> AggregateLookup;
        #endregion
        
        public AggregateUnitTest()
        {
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes

        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext) 
        {
            List<TestData> testData = TestDataSet.LoadFromXMLFile("TestData.xml");
            TestData = new Dictionary<string, TestData>();
            for (int i = 0; i < testData.Count; i++)
            {
                TestData.Add(testData[i].Name, testData[i]);
            }
            AggregateLookup = new Dictionary<AggregateType, NodeId>()
            {
                { AggregateType.AnnotationCount, Opc.Ua.ObjectIds.AggregateFunction_AnnotationCount },
                { AggregateType.Average, Opc.Ua.ObjectIds.AggregateFunction_Average },
                { AggregateType.Count, Opc.Ua.ObjectIds.AggregateFunction_Count },
                { AggregateType.Delta, Opc.Ua.ObjectIds.AggregateFunction_Delta },
                { AggregateType.DurationBad, Opc.Ua.ObjectIds.AggregateFunction_DurationBad },
                { AggregateType.DurationGood, Opc.Ua.ObjectIds.AggregateFunction_DurationGood },
                { AggregateType.DurationInState0, Opc.Ua.ObjectIds.AggregateFunction_DurationInStateZero},
                { AggregateType.DurationInState1, Opc.Ua.ObjectIds.AggregateFunction_DurationInStateNonZero},
                { AggregateType.End, Opc.Ua.ObjectIds.AggregateFunction_End },
                { AggregateType.Interpolative, Opc.Ua.ObjectIds.AggregateFunction_Interpolative },
                { AggregateType.Max, Opc.Ua.ObjectIds.AggregateFunction_Maximum },
                { AggregateType.MaxActualTime, Opc.Ua.ObjectIds.AggregateFunction_MaximumActualTime },
                { AggregateType.Min, Opc.Ua.ObjectIds.AggregateFunction_Minimum },
                { AggregateType.MinActualTime, Opc.Ua.ObjectIds.AggregateFunction_MinimumActualTime },
                { AggregateType.NumberOfTransitions, Opc.Ua.ObjectIds.AggregateFunction_NumberOfTransitions },
                { AggregateType.PercentBad, Opc.Ua.ObjectIds.AggregateFunction_PercentBad },
                { AggregateType.PercentGood, Opc.Ua.ObjectIds.AggregateFunction_PercentGood },
                { AggregateType.Range, Opc.Ua.ObjectIds.AggregateFunction_Range },
                { AggregateType.Start, Opc.Ua.ObjectIds.AggregateFunction_Start },
                { AggregateType.TimeAverage, Opc.Ua.ObjectIds.AggregateFunction_TimeAverage },
                { AggregateType.Total, Opc.Ua.ObjectIds.AggregateFunction_Total },
                { AggregateType.TotalizeAverage, Opc.Ua.ObjectIds.AggregateFunction_Total2},
                { AggregateType.WorstQuality, Opc.Ua.ObjectIds.AggregateFunction_WorstQuality }
            };
        }
        
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        #region AggregateType
        /// <summary>
        /// an enumeration type for aggregates. See [UA Part 13]
        /// </summary>
        public enum AggregateType
        {
            Interpolative,
            Average,
            TimeAverage,
            Total,
            TotalizeAverage,
            Min,
            Max,
            MinActualTime,
            MaxActualTime,
            Range,
            AnnotationCount,
            Count,
            DurationInState0,
            DurationInState1,
            NumberOfTransitions,
            Start,
            End,
            Delta,
            DurationGood,
            DurationBad,
            PercentGood,
            PercentBad,
            WorstQuality
        }
        #endregion

        #region generic test method
        void RunTest(AggregateType aggregate)
        {
            try
            {
                AggregateTestResultSet myResults = AggregateTestResultSet.LoadFromXMLFile(
                    String.Format(@"{0}TestResult.xml", Enum.GetName(typeof(AggregateType), aggregate)));

                for (int i = 0; i < myResults.Count; i++)
                {
                    AggregateTestResult testResult = myResults[i] as AggregateTestResult;

                    Debug.WriteLine(String.Format("Test Data: {0}", testResult.TestDataName));
                    Debug.WriteLine(String.Format("Start time: {0}\tEnd time: {1}\tInterval: {2}", 
                        testResult.Details.StartTime.TimeOfDay,
                        testResult.Details.EndTime.TimeOfDay,
                        testResult.Details.ProcessingInterval));
                    // get expected values
                    List<DataValue> expected = new List<DataValue>(testResult.DataValues.Count);
                    for (int ii = 0; ii < testResult.DataValues.Count; ii++)
                        expected.Add(testResult.DataValues[ii].GetDataValue());

                    // configure the aggregate calculator
                    NewAggregateFilter filter = new NewAggregateFilter()
                    {
                        StartTime = testResult.Details.StartTime,
                        EndTime = testResult.Details.EndTime,
                        AggregateType = AggregateLookup[aggregate],
                        AggregateConfiguration = TestData[myResults[i].TestDataName].Configuration.AggregateConfiguration,
                        ProcessingInterval = testResult.Details.ProcessingInterval
                    };
                    TestData testData = TestData[testResult.TestDataName];
                    AggregateCalculatorImpl calculator = Aggregators.CreateAggregator(filter, testData.Configuration.Stepped);
                    /*
                    calculator.Configuration = new AggregateConfiguration()
                    {
                        PercentDataBad = 0,
                        PercentDataGood = 100,
                        SteppedSlopedExtrapolation = false,
                        TreatUncertainAsBad = true
                    };
                     */
                    HistoryData rawHistoryData = new HistoryData();
                    for (int ii = 0; ii < testData.DataValues.Count; ii++)
                    {
                        DataValue dv = testData.DataValues[ii].GetDataValue();
                        rawHistoryData.DataValues.Add(dv);
                    }

                    HistoryData historyData = new HistoryData();
                    var sr = new ServiceResult(StatusCodes.Good);
                    foreach (DataValue raw in rawHistoryData.DataValues)
                    {
                        IList<DataValue> released = calculator.ProcessValue(raw, sr);
                        if (StatusCode.IsGood(sr.StatusCode) && released.Count > 0)
                        {
                            historyData.DataValues.AddRange(released);
                        }
                    }
                    var lsr = new ServiceResult(StatusCodes.Good);
                    historyData.DataValues.AddRange(calculator.ProcessTermination(lsr));

                    // obtain the actual values
                    List<DataValue> actual = new List<DataValue>(historyData.DataValues);

                    // compare the two value sets
                    bool assertion = true;
                    HelperMethods.CompareResults(expected, actual, testResult.TestDataName, assertion);
                    Console.WriteLine("Test {0} passed", i);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
                throw;
            }
        }
        #endregion

        /*
         * not sure if we need this test...
         * looks like this method will be tested in all agrregate functions.
        [TestMethod]
        public void StatusCodeTest()    
        {
        }
        */
        [DeploymentItem(@"TestResults\InterpolativeTestResult.xml"), TestMethod]
        public void InterpolativeTest()
        {
            RunTest(AggregateType.Interpolative);
        }

        [TestMethod, DeploymentItem(@"TestResults\AverageTestResult.xml")]
        public void AverageTest()
        {
            RunTest(AggregateType.Average);
        }

        [TestMethod, DeploymentItem(@"TestResults\TimeAverageTestResult.xml")]
        public void TimeAverageTest()
        {
            RunTest(AggregateType.TimeAverage);
        }

        [TestMethod, DeploymentItem(@"TestResults\TotalTestResult.xml")]
        public void TotalTest()
        {
            RunTest(AggregateType.Total);
        }

        [TestMethod, DeploymentItem(@"TestResults\TotalizeAverageTestResult.xml")]
        public void TotalizeAverageTest()
        {
            RunTest(AggregateType.TotalizeAverage);
        }

        [TestMethod, DeploymentItem(@"TestResults\MinTestResult.xml")]
        public void MinimumTest()
        {
            RunTest(AggregateType.Min);
        }

        [TestMethod, DeploymentItem(@"TestResults\MaxTestResult.xml")]
        public void MaximumTest()
        {
            RunTest(AggregateType.Max);
        }

        [TestMethod, DeploymentItem(@"TestResults\MinActualTimeTestResult.xml")]
        public void MinimumActualTimeTest()
        {
            RunTest(AggregateType.MinActualTime);
        }

        [TestMethod, DeploymentItem(@"TestResults\MaxActualTimeTestResult.xml")]
        public void MaximumActualTimeTest()
        {
            RunTest(AggregateType.MaxActualTime);
        }

        [TestMethod, DeploymentItem(@"TestResults\RangeTestResult.xml")]
        public void RangeTest()
        {
            RunTest(AggregateType.Range);
        }

        /*
         * This should be tested by HistoryReadProcessed call since it is implemented in that level.
         * 
        [TestMethod, DeploymentItem(@"TestResults\AnnotationTestResult.xml")]
        public void AnnotationCountTest()
        {
            RunTest(AggregateType.AnnotationCount);
        }
         */

        [TestMethod, DeploymentItem(@"TestResults\CountTestResult.xml")]
        public void CountTest()
        {
            RunTest(AggregateType.Count);
        }

        [TestMethod, DeploymentItem(@"TestResults\DurationInState0TestResult.xml")]
        public void DurationInState0Test()
        {
            RunTest(AggregateType.DurationInState0);
        }

        [TestMethod, DeploymentItem(@"TestResults\DurationInState1TestResult.xml")]
        public void DurationInState1Test()
        {
            RunTest(AggregateType.DurationInState1);
        }

        [TestMethod, DeploymentItem(@"TestResults\NumberOfTransitionsTestResult.xml")]
        public void NumberOfTransitionsTest()
        {
            RunTest(AggregateType.NumberOfTransitions);
        }

        [TestMethod, DeploymentItem(@"TestResults\StartTestResult.xml")]
        public void StartTest()
        {
            RunTest(AggregateType.Start);
        }

        [TestMethod, DeploymentItem(@"TestResults\EndTestResult.xml")]
        public void EndTest()
        {
            RunTest(AggregateType.End);
        }

        [TestMethod, DeploymentItem(@"TestResults\DeltaTestResult.xml")]
        public void DeltaTest()
        {
            RunTest(AggregateType.Delta);
        }
        
        [TestMethod, DeploymentItem(@"TestResults\DurationGoodTestResult.xml")]
        public void DurationGoodTest()
        {
            RunTest(AggregateType.DurationGood);
        }

        [TestMethod, DeploymentItem(@"TestResults\DurationBadTestResult.xml")]
        public void DurationBadTest()
        {
            RunTest(AggregateType.DurationBad);
        }

        [TestMethod, DeploymentItem(@"TestResults\PercentGoodTestResult.xml")]
        public void PercentGoodTest()
        {
            RunTest(AggregateType.PercentGood);
        }

        [TestMethod, DeploymentItem(@"TestResults\PercentBadTestResult.xml")]
        public void PercentBadTest()
        {
            RunTest(AggregateType.PercentBad);
        }

        [TestMethod, DeploymentItem(@"TestResults\WorstQualityResult.xml")]
        public void WorstQualityTest()
        {
            RunTest(AggregateType.WorstQuality);
        }
    }
}
