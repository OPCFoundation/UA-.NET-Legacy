using System;
using Opc.Ua;
using Opc.Ua.Server;
using Opc.Ua.Configuration;

namespace TestConsoleServer
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationType = ApplicationType.Server;
            application.ConfigSectionName = "TestConsoleServer";

            try
            {
                Console.WriteLine("Loading configuration.");
                application.LoadApplicationConfiguration(true);
                
                Console.WriteLine("Checking application certificate.");
                application.CheckApplicationInstanceCertificate(false, 0);
                
                Console.WriteLine("Starting server.");
                var server = new TestServer();
                application.Start(server);

                Console.WriteLine("Press <Enter> to stop server.");
                Console.ReadLine();
                application.Stop();
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR [{0}] {1}", e.GetType().Name, e.Message);
                Console.WriteLine("Press <Enter> to close application.");
                Console.ReadLine();
                return;
            }
        }
    }
}
