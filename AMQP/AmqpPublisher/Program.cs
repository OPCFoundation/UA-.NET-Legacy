using System;
using System.Text;
using System.Threading.Tasks;
using Amqp;
using Amqp.Framing;
using Amqp.Sasl;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace AmqpPublisher
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

        private class MessageHeader
        {
            public string MessageId;
            public string Subject;
            public string ContentType;
            public string PublisherId;
            public string DataSetWriterId;
            public uint SequenceNumber;
            public string DataSetClassId;
            public string MetaDataNodeName;
        }

        static void SetMessageHeader(Message message, MessageHeader header)
        {
            if (message.Properties == null)
            {
                message.Properties = new Properties();
            }

            message.Properties.MessageId = header.MessageId;
            message.Properties.Subject = header.Subject;
            message.Properties.ContentType = header.ContentType;

            if (!String.IsNullOrEmpty(header.DataSetWriterId))
            {
                message.Properties.GroupId = header.DataSetWriterId;
                message.Properties.GroupSequence = header.SequenceNumber;
            }

            if (message.ApplicationProperties == null)
            {
                message.ApplicationProperties = new ApplicationProperties();
            }

            if (!String.IsNullOrEmpty(header.PublisherId))
            {
                message.ApplicationProperties["ua-pubid"] = header.PublisherId;
            }

            if (!String.IsNullOrEmpty(header.DataSetClassId))
            {
                message.ApplicationProperties["ua-clsid"] = header.DataSetClassId;
            }

            if (!String.IsNullOrEmpty(header.MetaDataNodeName))
            {
                message.ApplicationProperties["ua-mdata"] = header.MetaDataNodeName;
            }
        }

        static void Main(string[] args)
        {
            try
            {
                DoPublish(args).Wait();
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

        static async Task DoPublish(string[] args)
        {
            Connection connection = null;
            Session session = null;
            SenderLink link = null;

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

                link = new SenderLink(session, "sender-spout", settings.AmqpNodeName);
                link.Closed += new ClosedCallback(OnClosed);

                MessageHeader header = new MessageHeader();

                header.Subject = "ua-data";
                header.ContentType = "application/opcua+uajson";
                header.PublisherId = "MyPublisher";
                header.DataSetWriterId = "MyDataSetWriter";
                header.SequenceNumber = 0;
                header.DataSetClassId = "MyDataSetClass";
                header.MetaDataNodeName = "MetaDataTopicName";

                for (int cycle = 1; cycle <= 10; cycle++)
                {
                    StringBuilder body = new StringBuilder();

                    body.Append("{ \"EventId\": \"");
                    body.Append(Convert.ToBase64String(Guid.NewGuid().ToByteArray()));
                    body.Append("\", \"SourceNode\": { \"Id\": \"i=2253\" }, \"SourceName\": \"System\", \"EventType\": { \"Id\": \"i=11446\" }, \"Time\": \"");
                    body.Append(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
                    body.Append("\", \"ReceiveTime\": \"");
                    body.Append(DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffZ"));
                    body.Append("\", \"Message\": \"The system cycle '");
                    body.Append(cycle);
                    body.Append("' has started.\", \"Severity\": 2 }");

                    Message message = new Message()
                    {
                        BodySection = new Data() { Binary = new UTF8Encoding(false).GetBytes(body.ToString()) }
                    };

                    header.MessageId = Guid.NewGuid().ToString();
                    header.SequenceNumber += 1;
                    SetMessageHeader(message, header);

                    await link.SendAsync(message);

                    Console.WriteLine("Send Message: {0}", body.ToString());
                    System.Threading.Thread.Sleep(1000);
                }

                Console.WriteLine("Send all Messages.\r\nHit a key to quit the application.");
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
                        Console.WriteLine("AmqpPubisher takes the following arguments to publish to a message broker \n");
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
