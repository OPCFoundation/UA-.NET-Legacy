/* Copyright (c) 1996-2016, OPC Foundation. All rights reserved.

   The source code in this file is covered under a dual-license scenario:
     - RCL: for OPC Foundation members in good-standing
     - GPL V2: everybody else

   RCL license terms accompanied with this source code. See http://opcfoundation.org/License/RCL/1.00/

   GNU General Public License as published by the Free Software Foundation;
   version 2 of the License are accompanied with this source code. See http://opcfoundation.org/License/GPLv2

   This source code is distributed in the hope that it will be useful,
   but WITHOUT ANY WARRANTY; without even the implied warranty of
   MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using System.Threading.Tasks;

namespace Opc.Ua.Bindings
{
    /// <remarks />
    public static class AmqpUtils
    {
        /// <remarks />
        public static int AmqpDefaultPort = 5672;
        /// <remarks />
        public static int AmqpsDefaultPort = 5679;

        /// <remarks />
        public static byte[] CreateMessage(string prefix, int size)
        {
            foreach (var resourceName in Assembly.GetExecutingAssembly().GetManifestResourceNames())
            {
                if (resourceName.EndsWith("data.txt"))
                {
                    using (StreamReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName), Encoding.UTF8, false))
                    {
                        StringBuilder buffer = new StringBuilder();
                        buffer.AppendFormat("{0}[{1}] ", prefix, size);

                        var text = reader.ReadToEnd();

                        while (buffer.Length < size)
                        {
                            buffer.AppendFormat(text);
                        }

                        text = buffer.ToString();

                        if (text.Length > size)
                        {
                            text = text.Substring(0, size);
                        }

                        return Encoding.UTF8.GetBytes(text);
                    }
                }
            }

            return null;
        }
    }

    /// <remarks />
    public static class TimeUtils
    {
        private static object m_lock = new object();
        private static long m_epoch;
        private static long m_lastTick;

        /// <remarks />
        public static long GetTickCount()
        {
            long ticks = System.Environment.TickCount;

            lock (m_lock)
            {
                m_lastTick = ticks;

                if (ticks < m_lastTick)
                {
                    m_epoch++;
                }

                ticks += m_epoch;
            }

            return ticks;
        }
    }
}
