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

namespace Opc.Ua.Server
{
    public abstract class StartEndAggregate : NonInterpolatingCalculator
    {
        protected abstract DataValue GetDataValue(List<DataValue> dvList);
        public override DataValue Compute(IAggregationContext context, TimeSlice bucket, AggregateState state)
        {
            List<DataValue> l = new List<DataValue>(bucket.Values);
            DataValue dv = l.Count > 0 ? GetDataValue(l) : null;
            if (SteppedVariable && dv == null)
                dv = bucket.LateBound.Value;

            DataValue retval = new DataValue();
            StatusCode code = StatusCodes.BadNoData;
            if (dv != null)
            {
                code = StatusCode.IsNotGood(dv.StatusCode)
                    ? StatusCodes.UncertainDataSubNormal
                    : StatusCodes.Good;
                retval.SourceTimestamp = dv.SourceTimestamp;
                retval.Value = dv.Value;
                code.AggregateBits = AggregateBits.Raw;
                if (bucket.Incomplete) code.AggregateBits |= AggregateBits.Partial;
            }
            else
            {
                retval.SourceTimestamp = bucket.From;
            }
            retval.StatusCode = code;
            return retval;
        }
    }

    public class EndAggregate : StartEndAggregate
    {
        protected override DataValue GetDataValue(List<DataValue> dvList)
        {
            return dvList[dvList.Count - 1];
        }
    }
}
