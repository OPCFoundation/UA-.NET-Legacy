using System;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using Amqp.Framing;
using Amqp.Sasl;
using System.IO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace AmqpSubscriber
{
    class Program
    {
        static bool RemoteCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            if (sslPolicyErrors != SslPolicyErrors.None)
            {
                Console.WriteLine("SSL Validation Error x509={0} Error={1}", certificate.Subject, sslPolicyErrors);
            }

            return true;
        }

        private class BrokerSettings
        {
            public string Broker;
            public string UserName;
            public string Password;
            public bool UseSasl;
            public string AmqpNodeName;
        }

        static void Main(string[] args)
        {
            try
            {
                DoSubscribe(args).Wait();
            }
            catch (Exception e)
            {
                var ie = e;

                while (ie != null)
                {
                    Console.WriteLine("ERROR [{0}] {1}", ie.GetType().Name, ie.Message);
                    ie = ie.InnerException;
                }
            }
        }

        static async Task DoSubscribe(string[] args)
        {
            Connection connection = null;
            Session session = null;
            ReceiverLink link = null;

            var settings = ParseArgs(args);
            System.Net.ServicePointManager.ServerCertificateValidationCallback += RemoteCertificateValidation;

            try
            {
                UriBuilder url = new UriBuilder(settings.Broker);

                if (!settings.UseSasl)
                {
                    if (!String.IsNullOrEmpty(settings.UserName))
                    {
                        url.UserName = Uri.EscapeDataString(settings.UserName);
                        url.Password = Uri.EscapeDataString(settings.Password);
                    }
                }

                url.Path += settings.AmqpNodeName;
                Console.WriteLine("ConnectingTo={0}", url.ToString());

                var address = new Address(url.ToString());

                ConnectionFactory factory = new ConnectionFactory();
                factory.SSL.RemoteCertificateValidationCallback += RemoteCertificateValidation;

                if (settings.UseSasl)
                {
                    factory.SASL.Profile = SaslProfile.External;
                }

                connection = await factory.CreateAsync(address);
                connection.Closed += new ClosedCallback(OnClosed);

                if (settings.UseSasl)
                { 
                    // var receiveTokenScopeUri = new Uri(string.Format("http://{0}/{1}", address.Host, settings.AmqpNodeName));
                    // var receiveToken = GenerateSharedAccessToken(m_settings.ReceiveKeyName, m_settings.ReceiveKeyValue, receiveTokenScopeUri, TimeSpan.FromMilliseconds(m_settings.TokenRenewalInterval));
                    // await AssociateNamespaceEntityTokenAsync(m_connection, receiveTokenScopeUri, receiveToken);
                }

                session = new Session(connection);
                session.Closed += new ClosedCallback(OnClosed);

                link = new ReceiverLink(session, "receiver-drain", settings.AmqpNodeName);
                link.Closed += new ClosedCallback(OnClosed);

                link.Start(5, OnMessageCallback);

                Console.WriteLine("Listening for Messages.\r\nHit a key to quit the application.");
                Console.ReadKey();
            }
            finally
            {
                if (link != null)
                {
                    await link.CloseAsync();
                }

                if (session != null)
                {
                    await session.CloseAsync();
                }

                if (connection != null)
                {
                    await connection.CloseAsync();
                }
            }
        }

        private static void OnClosed(AmqpObject sender, Error error)
        {
            Console.WriteLine("{0}: {1}", sender.GetType().Name, (error != null)?error.Description:"Closed");
        }

        static void OnMessageCallback(ReceiverLink receiver, Message message)
        {
            receiver.Accept(message);
            receiver.SetCredit(5);

            try
            {
                Console.WriteLine("======================================================================================");

                if (message.Properties != null)
                {
                    Console.WriteLine("MESSAGE_ID: {0}", message.Properties.MessageId);
                    Console.WriteLine("SUBJECT: {0}", message.Properties.Subject);
                    Console.WriteLine("PUBLISHER_ID: {0}", Encoding.UTF8.GetString(message.Properties.UserId));
                    Console.WriteLine("DATASET_WRITER_ID: {0}", message.Properties.GroupId);
                    Console.WriteLine("SEQUENCE_NUMBER: {0}", message.Properties.GroupSequence);
                }

                if (message.ApplicationProperties != null)
                {
                    Console.WriteLine("DATASET_CLASS_ID: {0}", message.ApplicationProperties["ua-class-id"]);
                    Console.WriteLine("METADATA_NODE_NAME: {0}", message.ApplicationProperties["ua-metadata-node-name"]);
                }

                Console.WriteLine("--------------------------------------------------------------------------------------");

                var bytes = message.GetBody<byte[]>();
                var json = Encoding.UTF8.GetString(bytes);
                JsonTextReader reader = new JsonTextReader(new StringReader(json));

                while (reader.Read())
                {
                    if (reader.TokenType == JsonToken.PropertyName)
                    {
                        var name = reader.Value.ToString();

                        if (reader.Read())
                        {
                            if (reader.Value != null)
                            {
                                Console.WriteLine("{0}: {1} ({2})", name, reader.Value, reader.ValueType.Name);
                                continue;
                            }
                        }

                        Console.WriteLine("{0}: {1}", name, reader.TokenType);
                        continue;
                    }

                    Console.WriteLine("{0}", reader.TokenType);
                }
            }
            catch (Exception e)
            {
                var ie = e;

                while (ie != null)
                {
                    Console.WriteLine("ERROR [{0}] {1}", ie.GetType().Name, ie.Message);
                    ie = ie.InnerException;
                }
            }
        }

        static BrokerSettings ParseArgs(string[] args)
        {
            BrokerSettings settings = new BrokerSettings();

            int pos = 0;

            while (pos < args.Length-1)
            {
                switch (args[pos])
                {
                    case "-h":
                    {
                        Console.WriteLine("AmqpSubscriber takes the following arguments to subscribe to a message broker \n");
                        Console.WriteLine("-b: Broker url \n");
                        Console.WriteLine("-u: Username \n");
                        Console.WriteLine("-p: Password \n");
                        Console.WriteLine("-t: AMQP NodeName \n");
                        Console.WriteLine("The Username and Password must be URL-encoded.");
                        Environment.Exit(0);
                        break;
                    }

                    case "-b":
                    {
                        settings.Broker = args[++pos];
                        break;
                    }

                    case "-u":
                    {
                        settings.UserName = Uri.UnescapeDataString(args[++pos]);
                        break;
                    }

                    case "-p":
                    {
                        settings.Password = Uri.UnescapeDataString(args[++pos]);
                        break;
                    }
                    
                    case "-t":
                    {
                        settings.AmqpNodeName = args[++pos];
                        break;
                    }

                    case "-sasl":
                    {
                        settings.UseSasl = args[++pos] == "true";
                        break;
                    }
                }

                pos++;
            }

            return settings;
        }
    }
}
