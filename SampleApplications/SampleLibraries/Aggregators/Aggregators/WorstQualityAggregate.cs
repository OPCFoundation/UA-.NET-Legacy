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
using System.Globalization;
using System.Diagnostics;

namespace Opc.Ua.Server
{
    public class WorstQualityAggregate: NonInterpolatingCalculator
    {
        public override DataValue Compute(IAggregationContext context, TimeSlice bucket, AggregateState state)
        {
            StatusCode returnCode = StatusCodes.BadNoData;
            foreach(DataValue dv in bucket.Values)
            {
                if (returnCode == StatusCodes.BadNoData)
                {
                    returnCode = dv.StatusCode;
                }
                else
                {
                    // StatusCodes.Bad = 0x80000000
                    // StatusCodes.Uncertain = 0x40000000
                    // StatusCodes.Good = 0x00000000
                    uint code = dv.StatusCode.Code >> 28;   // 7 Hexadecimal digits = 28 binary digits.
                    switch (code)
                    {
                        case 8: // 8 is maximum
                            returnCode = StatusCodes.Bad;
                            break;
                        case 4:
                            if(StatusCode.IsNotBad(returnCode))
                                returnCode = StatusCodes.Uncertain;
                            break;
                        case 0: // 0 is minimum 
                            break;
                        default:
                            Debug.Assert(true, "should not touch this line");
                            throw new Exception(String.Format("Unknown error in WorstQuality aggregate calculation, code = {0}", dv.StatusCode));
                    }
                }
            }
            DataValue retVal = new DataValue() { SourceTimestamp = bucket.From };
            if (returnCode != StatusCodes.BadNoData)
            {
                retVal.Value = returnCode;
                StatusCode status = StatusCodes.Good;
                status.AggregateBits |= AggregateBits.Calculated;
                if (bucket.Incomplete) status.AggregateBits |= AggregateBits.Partial;
                retVal.StatusCode = status;
            }
            else
            {
                retVal.StatusCode = returnCode;
            }
            return retVal;
        }
    }
}
