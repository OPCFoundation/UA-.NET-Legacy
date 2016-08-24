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

namespace ServiceBusTester
{
    public class Options
    {
        public string BrokerUrl { get; set; }
        public string BrokerUserName { get; set; }
        public string BrokerPassword { get; set; }
        public string IncomingTerminus { get; set; }
        public string OutgoingTerminus { get; set; }
        public int ApiType { get; set; }
        public int RequestCount { get; set; }
        public int MessageSize { get; set; }
        public int ChunkSize { get; set; }
        public string ResultFile { get; set; }
                
        public Options(string[] args)
        {
            RequestCount = 1;
            MessageSize = 100;
            ChunkSize = 1024;

            Parse(args);
        }

        private void Usage()
        {
            Console.WriteLine("Usage: ServiceBusTester --broker <url> --in <queue>");
            Console.WriteLine("");
            Console.WriteLine("Create a connection, wait for messages on queue specified with --in.");
            Console.WriteLine("If a queue is specified with --out then test messages are sent to it.");
            Console.WriteLine("");
            Console.WriteLine("Options:");
            Console.WriteLine(" --broker [amqp://127.0.0.1:5672] - The AMQP 1.0 broker address.");
            Console.WriteLine(" --name <name>                    - The user or policy name needed to authenticate with the broker.");
            Console.WriteLine(" --key <key>                      - The password or key needed to authenticate with the broker.");
            Console.WriteLine(" --in <incoming>                  - The terminus used to receive messages.");
            Console.WriteLine(" --out <outgoing>                 - The terminus used by a client to send messages to the server.");
            Console.WriteLine(" --apitype                        - 0 = ServiceBus Queue API; 1 = AMQP Lite API; 2 = ServiceBus Topic API;");
            Console.WriteLine(" --count                          - The number of iterations.");
            Console.WriteLine(" --size                           - The size of the test message.");
            Console.WriteLine(" --chunksize                      - The size of the chunks to use when sending a message.");
            Console.WriteLine(" --resultfile                     - The name of the file to save the results.");
            Console.WriteLine(" --help                           - Print this message and exit");
            Console.WriteLine("");
            System.Environment.Exit(2);
        }

        private void Parse(string[] args)
        {
            int argCount = args.Length;
            int current = 0;

            while (current < argCount)
            {
                string arg = args[current];

                if (arg == "--help")
                {
                    Usage();
                }
                else if (arg == "--broker")
                {
                    this.BrokerUrl = args[++current];
                }
                else if (arg == "--name")
                {
                    this.BrokerUserName = Uri.UnescapeDataString(args[++current]);
                }
                else if (arg == "--key")
                {
                    this.BrokerPassword = Uri.UnescapeDataString(args[++current]);
                }
                else if (arg == "--in")
                {
                    this.IncomingTerminus = args[++current];
                }
                else if (arg == "--out")
                {
                    this.OutgoingTerminus = args[++current];
                }
                else if (arg == "--apitype")
                {
                    this.ApiType = Convert.ToInt32(args[++current]);
                }
                else if (arg == "--count")
                {
                    this.RequestCount = Convert.ToInt32(args[++current]);
                }
                else if (arg == "--size")
                {
                    this.MessageSize = Convert.ToInt32(args[++current]);
                }
                else if (arg == "--chunksize")
                {
                    this.ChunkSize = Convert.ToInt32(args[++current]);
                }
                else if (arg == "--resultfile")
                {
                    this.ResultFile = args[++current];
                }
                else
                {
                    throw new ArgumentException(String.Format("unknown argument \"{0}\"", arg));
                }

                current++;
            }
        }
    }
}
