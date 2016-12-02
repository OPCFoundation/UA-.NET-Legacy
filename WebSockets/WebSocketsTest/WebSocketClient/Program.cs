using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net.WebSockets;

namespace WebSocketClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Client().Wait();
            Console.ReadLine();
        }

        static readonly string[] s_Words = new string[] { "Red", "Orange", "Yellow", "Green", "Blue", "Indigo", "Violet" };

        static byte[] GetText(int length)
        {
            StringBuilder builder = new StringBuilder();
            var random = new Random();

            while (builder.Length < length)
            {
                if (builder.Length > 0)
                {
                    builder.Append(" ");
                }

                builder.Append(s_Words[random.Next() % s_Words.Length]);
            }

            while (builder.Length > length)
            {
                builder.Length = length;
            }

            return new UTF8Encoding(false).GetBytes(builder.ToString()); 
        }

        static bool RemoteCertificateValidationCallback(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certificate, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }

        static async Task Client()
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = RemoteCertificateValidationCallback;

            ClientWebSocket ws = new ClientWebSocket();
            //var uri = new Uri("wss://localhost:8000/");
            var uri = new Uri("wss://localhost:48043/");

            try
            {
                await ws.ConnectAsync(uri, CancellationToken.None);
                var buffer = new byte[UInt16.MaxValue*2];
                int length = 100;

                while (length < buffer.Length)
                {
                    var bytes = GetText(length);

                    await ws.SendAsync(new ArraySegment<byte>(bytes), WebSocketMessageType.Binary, true, CancellationToken.None);

                    var segment = new ArraySegment<byte>(buffer);
                    var result = await ws.ReceiveAsync(segment, CancellationToken.None);

                    if (result.MessageType == WebSocketMessageType.Close)
                    {
                        await ws.CloseAsync(WebSocketCloseStatus.InvalidMessageType, "I don't do binary", CancellationToken.None);
                        return;
                    }

                    int count = result.Count;
                    while (!result.EndOfMessage)
                    {
                        if (count >= buffer.Length)
                        {
                            await ws.CloseAsync(WebSocketCloseStatus.InvalidPayloadData, "That's too long", CancellationToken.None);
                            return;
                        }

                        segment = new ArraySegment<byte>(buffer, count, buffer.Length - count);
                        result = await ws.ReceiveAsync(segment, CancellationToken.None);
                        count += result.Count;
                    }

                    var message = Encoding.UTF8.GetString(buffer, 0, count);
                    Console.WriteLine(">" + message);
                    length *= 10;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
