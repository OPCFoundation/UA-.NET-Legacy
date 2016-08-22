using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amqp;
using Amqp.Framing;
using Amqp.Sasl;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using System.Security.Cryptography;

namespace AmqpBrokerTester
{
    public partial class BrokerTesterForm : Form
    {
        private bool m_useSasl;
        private SenderLink m_senderLink;

        public BrokerTesterForm()
        {
            InitializeComponent();

            m_useSasl = true;

            EndpointUrlTextBox.Text = "amqps://opcfoundation-prototyping.servicebus.windows.net";
            AmqpNodeNameTextBox.Text = "MyServer";
            SenderTextBox.Text = "sender";
            SendKeyTextBox.Text = "rdOWB7cUiVIGkHJPD5YOF0b5Xukpa7u6XL4uS932mFA=";
            ReceiverTextBox.Text = "receiver";
            ReceiveKeyTextBox.Text = "wK7wFVR0rgZHpGQSjs35cySqiM8BLJLraYLoFCdMLjA=";
            MessageTextBox.Text = "Hello World!";
        }
        private bool RemoteCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        public static async Task AssociateNamespaceEntityTokenAsync(Connection connection, Uri entityUri, string sharedAccessToken)
        {
            var session = new Session(connection);
            string cbsClientAddress = "cbs-client-reply-to";
            var cbsSender = new SenderLink(session, "cbs-sender", "$cbs"); // link name is functionally insignificant
            var receiverAttach = new Attach()
            {
                Source = new Source() { Address = "$cbs" },
                Target = new Target() { Address = cbsClientAddress }
            };

            var cbsReceiver = new ReceiverLink(session, "cbs-receiver", receiverAttach, null); // link name is functionally insignificant
            //Utils.Trace("SAS token: {0}", sharedAccessToken);

            // construct the put-token message
            var request = new Amqp.Message(sharedAccessToken);
            request.Properties = new Amqp.Framing.Properties();
            request.Properties.MessageId = "1";
            request.Properties.ReplyTo = cbsClientAddress;
            request.ApplicationProperties = new ApplicationProperties();
            request.ApplicationProperties["operation"] = "put-token";
            request.ApplicationProperties["type"] = "servicebus.windows.net:sastoken";
            request.ApplicationProperties["name"] = entityUri.ToString();
            await cbsSender.SendAsync(request);

            //Utils.Trace("Request Properties: {0}", request.Properties);
            //Utils.Trace("Request ApplicationProperties: {0}", request.ApplicationProperties);

            // receive the response
            var response = await cbsReceiver.ReceiveAsync();
            if (response == null || response.Properties == null || response.ApplicationProperties == null)
            {
                throw new Exception("invalid response received");
            }

            // validate message properties and status code.
            Trace.WriteLine(TraceLevel.Information, " response: {0}", response.Properties);
            Trace.WriteLine(TraceLevel.Information, " response: {0}", response.ApplicationProperties);

            int statusCode = (int)response.ApplicationProperties["status-code"];
            var statusDescription = response.ApplicationProperties["status-description"];

            if (statusCode != (int)HttpStatusCode.Accepted && statusCode != (int)HttpStatusCode.OK)
            {
                throw new Exception("put-token message was not accepted. Error [" + statusCode + "] " + statusDescription);
            }

            // the sender/receiver may be kept open for refreshing tokens
            await cbsSender.CloseAsync();
            await cbsReceiver.CloseAsync();
            await session.CloseAsync();
        }

        public static string GenerateSharedAccessToken(string keyName, string keyValue, Uri requestUri, TimeSpan ttl)
        {
            // http://msdn.microsoft.com/en-us/library/azure/dn170477.aspx
            // the canonical Uri scheme is http because the token is not amqp specific
            // signature is computed from joined encoded request Uri string and expiry string

            TimeSpan sinceEpoch = DateTime.UtcNow - new DateTime(1970, 1, 1);
            var expiry = Convert.ToString((int)sinceEpoch.TotalSeconds + ttl.TotalSeconds);

            // string expiry = ((long)((DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc)) + ttl).TotalSeconds).ToString();
            string encodedUri = Uri.EscapeDataString(requestUri.ToString());

            string signature = null;

            var keyBytes = Encoding.UTF8.GetBytes(keyValue);
            var dataToSign = Encoding.UTF8.GetBytes(encodedUri + "\n" + expiry);

            using (var hmac = new HMACSHA256(keyBytes))
            {
                signature = Convert.ToBase64String(hmac.ComputeHash(dataToSign));
            }

            // server specific tokens - swat (simple web access token); jwat is the standard.
            return String.Format(
                System.Globalization.CultureInfo.InvariantCulture,
                "SharedAccessSignature sig={0}&se={1}&skn={2}&sr={3}",
                Uri.EscapeDataString(signature),
                Uri.EscapeDataString(expiry),
                Uri.EscapeDataString(keyName),
                encodedUri);
        }

        private async Task CreateReceiverLink()
        {
            UriBuilder url = new UriBuilder(EndpointUrlTextBox.Text);

            url.UserName = Uri.EscapeDataString(ReceiverTextBox.Text);
            url.Password = Uri.EscapeDataString(ReceiveKeyTextBox.Text);

            var amqpNodeName = AmqpNodeNameTextBox.Text;
            url.Path += amqpNodeName;

            var address = new Address(url.ToString());

            ConnectionFactory factory = new ConnectionFactory();
            factory.SSL.RemoteCertificateValidationCallback += RemoteCertificateValidation;

            if (m_useSasl)
            {
                factory.SASL.Profile = SaslProfile.External;
            }

            var connection = await factory.CreateAsync(address);
            connection.Closed += new ClosedCallback(OnReceiveClosed);

            if (m_useSasl)
            {
                var receiveTokenScopeUri = new Uri(string.Format("http://{0}/{1}", url.Host, amqpNodeName));
                var receiveToken = GenerateSharedAccessToken(ReceiverTextBox.Text, ReceiveKeyTextBox.Text, receiveTokenScopeUri, TimeSpan.FromMilliseconds(60000));
                await AssociateNamespaceEntityTokenAsync(connection, receiveTokenScopeUri, receiveToken);
            }

            var session = new Session(connection);
            session.Closed += new ClosedCallback(OnReceiveClosed);

            var link = new ReceiverLink(session, "receiver-drain", amqpNodeName);
            link.Closed += new ClosedCallback(OnReceiveClosed);

            link.Start(5, OnMessageCallback);

            ReceiveLogTextBox.AppendText(String.Format("{0} Waiting for messages.\r\n", DateTime.Now.ToString("HH:mm:ss")));
        }

        private async Task CreateSenderLink()
        {
            UriBuilder url = new UriBuilder(EndpointUrlTextBox.Text);

            url.UserName = Uri.EscapeDataString(SenderTextBox.Text);
            url.Password = Uri.EscapeDataString(SendKeyTextBox.Text);

            var amqpNodeName = AmqpNodeNameTextBox.Text;
            url.Path += amqpNodeName;

            var address = new Address(url.ToString());

            ConnectionFactory factory = new ConnectionFactory();
            factory.AMQP.ContainerId = Guid.NewGuid().ToString();
            factory.SSL.RemoteCertificateValidationCallback += RemoteCertificateValidation;

            if (m_useSasl)
            {
                factory.SASL.Profile = SaslProfile.External;
                address = new Address(url.Host, url.Port, null, null, "/", url.Scheme);
            }
            else
            {
                address = new Address(url.Host, url.Port, url.UserName, url.Password, amqpNodeName, url.Scheme);
            }

            var connection = await factory.CreateAsync(address);
            connection.Closed += new ClosedCallback(OnSenderClosed);

            var session = new Session(connection);
            session.Closed += new ClosedCallback(OnSenderClosed);

            if (m_useSasl)
            {
                var sendTokenScopeUri = new Uri(string.Format("http://{0}/{1}", url.Host, amqpNodeName));
                var sendToken = GenerateSharedAccessToken(SenderTextBox.Text, SendKeyTextBox.Text, sendTokenScopeUri, TimeSpan.FromMilliseconds(60000));
                await AssociateNamespaceEntityTokenAsync(connection, sendTokenScopeUri, sendToken);
            }

            var link = m_senderLink = new SenderLink(session, "sender-spout", amqpNodeName);
            link.Closed += new ClosedCallback(OnSenderClosed);

            SendLogTextBox.AppendText(String.Format("{0} Opened link for sending messages.\r\n", DateTime.Now.ToString("HH:mm:ss")));
        }

        private void OnSenderClosed(AmqpObject sender, Error error)
        {
            var message = String.Format("{0} [{1}] {2}\r\n", DateTime.Now.ToString("HH:mm:ss"), sender.GetType().Name, error.Description);
            SendLogTextBox.AppendText(message);
        }

        private void OnReceiveClosed(AmqpObject sender, Error error)
        {
            var message = String.Format("{0} [{1}] {2}\r\n", DateTime.Now.ToString("HH:mm:ss"), sender.GetType().Name, error.Description);
            ReceiveLogTextBox.AppendText(message);
        }

        private void OnMessageCallback(ReceiverLink receiver, Amqp.Message message)
        {
            receiver.Accept(message);
            receiver.SetCredit(5);

            var bytes = message.GetBody<byte[]>();
            var body = Encoding.UTF8.GetString(bytes);

            ReceiveLogTextBox.AppendText(String.Format("{0} Received Message [{1}] {2}.\r\n", DateTime.Now.ToString("HH:mm:ss"), message.Properties.MessageId, body));
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            var bytes = new UTF8Encoding(false).GetBytes(MessageTextBox.Text);

            var message = new Amqp.Message()
            {
                BodySection = new Data() { Binary = bytes }
            };

            message.Properties = new Amqp.Framing.Properties()
            {
                MessageId = Guid.NewGuid().ToString(),
                CorrelationId = Guid.NewGuid().ToString(),
                Subject = "ua-request",
                ContentType = "application/opcua+uabainry"
            };

            await m_senderLink.SendAsync(message);
            SendLogTextBox.AppendText(String.Format("{0} Sent Message [{1}] {2}.\r\n", DateTime.Now.ToString("HH:mm:ss"), message.Properties.MessageId, MessageTextBox.Text));
        }

        private async void ConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                await CreateReceiverLink();
            }
            catch (Exception exception)
            {
                var ie = exception;

                while (ie != null)
                {
                    ReceiveLogTextBox.AppendText(String.Format("{0} ERROR [{1}] {2}.\r\n", DateTime.Now.ToString("HH:mm:ss"), ie.GetType().Name, ie.Message));
                    ie = ie.InnerException;
                }
            }

            try
            {
                await CreateSenderLink();
            }
            catch (Exception exception)
            {
                var ie = exception;

                while (ie != null)
                {
                    SendLogTextBox.AppendText(String.Format("{0} ERROR [{1}] {2}.\r\n", DateTime.Now.ToString("HH:mm:ss"), ie.GetType().Name, ie.Message));
                    ie = ie.InnerException;
                }
            }
        }
    }
}
