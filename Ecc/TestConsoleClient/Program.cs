using System;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;

namespace TestConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationType   = ApplicationType.Client;
            application.ConfigSectionName = "TestConsoleClient";

            try
            {
                Console.WriteLine("Loading configuration.");
                application.LoadApplicationConfiguration(true);
                
                Console.WriteLine("Checking application certificate.");
                application.CheckApplicationInstanceCertificate(false, 0);
                
                var configuration = application.ApplicationConfiguration;

                Console.WriteLine("Selecting best endpoint.");
                string serverUrl = "opc.tcp://localhost:62546";
                bool useSecurity = true;

                EndpointDescription endpointDescription = EndpointDescription.SelectEndpoint(configuration, serverUrl, useSecurity);
                EndpointConfiguration endpointConfiguration = EndpointConfiguration.Create(configuration);
                ConfiguredEndpoint endpoint = new ConfiguredEndpoint(null, endpointDescription, endpointConfiguration);
                
                Console.WriteLine("Create session.");
                var session = Session.Create(
                    configuration,
                    endpoint,
                    false,
                    true,
                    application.ApplicationName,
                    60000,
                    null,
                    null);
                
                ReadValueIdCollection nodesToRead = new ReadValueIdCollection();

                nodesToRead.Add(new ReadValueId()
                {
                    NodeId = VariableIds.Server_ServerStatus_CurrentTime,
                    AttributeId = Attributes.Value
                });

                DataValueCollection results = null;
                DiagnosticInfoCollection diagnosticInfos = null;
                session.Read(null, 0, TimestampsToReturn.Both, nodesToRead, out results, out diagnosticInfos);
                Console.WriteLine("Current Time: {0}", results[0].WrappedValue.ToString());

                Console.WriteLine("Close session.");
                session.Close();

                Console.WriteLine("Press <Enter> to close application.");
                Console.ReadLine();
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
