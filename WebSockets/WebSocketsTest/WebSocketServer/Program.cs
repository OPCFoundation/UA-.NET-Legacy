using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.Security;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;

namespace WebSocketServer
{
    class Program
    {
        static X509Certificate2 m_certificate;

        static void Main(string[] args)
        {
            X509Store store = new X509Store(StoreName.My, StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);

            foreach (var certificate in store.Certificates.Find(X509FindType.FindBySubjectName, "localhost", false))
            {
                m_certificate = (X509Certificate2)certificate;
                break;
            }

            ListenAsync(IPAddress.Any, 8000).Wait();
        }
   
        public static async Task ListenAsync(IPAddress address, int port)
        {
            var m_listener = new TcpListener(address, port);
            m_listener.Start();

            do
            {
                var client = await m_listener.AcceptTcpClientAsync();

                try
                {
                    await AcceptConnection(client, CancellationToken.None);
                }
                catch (Exception e)
                {
                    String.Format("[TlsListener.ListenAsync] Could not accept new connection. [{0}] {1}", e.GetType().Name, e.Message);
                }
            }
            while (true);
        }

        private static string ExtractToken(string source, ref int offset, params char[] terminators)
        {
            int start = offset;

            while (offset < source.Length)
            {
                if (terminators != null)
                {
                    for (int ii = 0; ii < terminators.Length; ii++)
                    {
                        if (terminators[ii] == source[offset])
                        {
                            return source.Substring(start, offset++ - start).Trim();
                        }
                    }
                }

                offset++;
            }

            return null;
        }

        private static async Task SendErrorResponse(Stream ostrm, HttpStatusCode code)
        {
            using (var writer = new StreamWriter(ostrm, new UTF8Encoding(false), UInt16.MaxValue, false))
            {
                await writer.WriteAsync("HTTP/1.1 ");
                await writer.WriteAsync(((int)code).ToString());
                await writer.WriteAsync(" ");
                await writer.WriteAsync(code.ToString());
                await writer.WriteAsync("\r\n");
                await writer.WriteAsync("Date: ");
                await writer.WriteAsync(DateTime.Now.ToString("r"));
                await writer.WriteAsync("\r\n");
                await writer.WriteAsync("\r\n");
            }
        }

        private static async Task AcceptConnection(TcpClient client, CancellationToken cancellationToken)
        {
            var rawstream = client.GetStream();
            SslStream stream = new SslStream(rawstream, false);
            stream.AuthenticateAsServer(m_certificate, false, SslProtocols.Tls, true);

            client.NoDelay = true;

            var request = await ReceiveHeader(stream);

            StringBuilder response = new StringBuilder();

            int ii = 0;

            string method = ExtractToken(request, ref ii, ' ');
            string url = ExtractToken(request, ref ii, ' ');
            string version = ExtractToken(request, ref ii, '\n');

            if (version != "HTTP/1.1")
            {
                await SendErrorResponse(stream, HttpStatusCode.HttpVersionNotSupported);
                return;
            }

            if (method != "GET")
            {
                await SendErrorResponse(stream, HttpStatusCode.MethodNotAllowed);
                return;
            }

            Dictionary<string,string> headers = new Dictionary<string, string>();

            do
            {
                string name = ExtractToken(request, ref ii, ':');

                if (name == null)
                {
                    break;
                }

                string value = ExtractToken(request, ref ii, '\r');
                headers[name] = value;
            }
            while (true);

            string upgradeType = null;

            if (!headers.TryGetValue("Upgrade", out upgradeType) || String.Compare(upgradeType, "WebSocket", true) != 0)
            {
                await SendErrorResponse(stream, HttpStatusCode.BadRequest);
                return;
            }

            string encodedKey = null;

            if (!headers.TryGetValue("Sec-WebSocket-Key", out encodedKey))
            {
                await SendErrorResponse(stream, HttpStatusCode.BadRequest);
                return;
            }

            string acceptKey = encodedKey + "258EAFA5-E914-47DA-95CA-C5AB0DC85B11";
            var hash = new System.Security.Cryptography.SHA1Managed().ComputeHash(new UTF8Encoding(false).GetBytes(acceptKey));
            
            using (var writer = new StreamWriter(stream, new UTF8Encoding(false), UInt16.MaxValue, true))
            {
                await writer.WriteAsync("HTTP/1.1 101 SwitchingProtocols\r\n");
                await writer.WriteAsync("Date: ");
                await writer.WriteAsync(DateTime.Now.ToString("r"));
                await writer.WriteAsync("\r\n");
                await writer.WriteAsync("Connection: Upgrade");
                await writer.WriteAsync("\r\n");
                await writer.WriteAsync("Upgrade: WebSocket");
                await writer.WriteAsync("\r\n");
                await writer.WriteAsync("Sec-WebSocket-Accept: ");
                await writer.WriteAsync(Convert.ToBase64String(hash));
                await writer.WriteAsync("\r\n");
                await writer.WriteAsync("\r\n");
            }

            MonitorConnection(stream, cancellationToken);
        }

        private static void MonitorConnection(Stream connection, CancellationToken cancellationToken)
        {
            Task.Run(() => MonitorConnection(connection), cancellationToken);
        }

        private static async Task<bool> Read(Stream stream, byte[] buffer, int offset, int bytesToRead)
        {
            do
            {
                int bytesRead = await stream.ReadAsync(buffer, offset, bytesToRead);

                if (bytesRead == 0)
                {
                    return false;
                }

                offset += bytesRead;
                bytesToRead -= bytesRead;
            }
            while (bytesToRead > 0);

            return true;
        }

        public class Frame
        {
            public bool Final;
            public byte OpCode;
            public bool Masked;
            public byte[] Payload;
        }

        private static async Task SendCloseAsync(Stream stream, ushort code, string reason, bool masked)
        {
            Frame frame = new Frame();

            frame.Final = true;
            frame.OpCode = 0x08;
            frame.Masked = masked;

            if (!String.IsNullOrEmpty(reason))
            {
                frame.Payload = new byte[reason.Length + 2];
                new UTF8Encoding(false).GetBytes(reason, 0, reason.Length, frame.Payload, 2);
            }
            else
            {
                frame.Payload = new byte[2];
            }

            frame.Payload[0] = (byte)((code >> 8) & 0xFF);
            frame.Payload[1] = (byte)(code & 0xFF);

            await SendFrameAsync(stream, frame);
        }

        private static async Task SendPongAsync(Stream stream, Frame ping, bool masked)
        {
            Frame frame = new Frame();

            frame.Final   = true;
            frame.OpCode  = 0x0A;
            frame.Masked  = masked;
            frame.Payload = ping.Payload;

            await SendFrameAsync(stream, frame);
        }

        private static async Task SendFrameAsync(Stream stream, Frame frame)
        {
            byte[] buffer = new byte[20];

            buffer[0] = frame.OpCode;

            if (frame.Final)
            {
                buffer[0] |= 0x80;
            }

            int offset = 2;

            if (frame.Payload == null || frame.Payload.Length < 126)
            {
                buffer[1] = (byte)((frame.Payload == null) ? 0 : frame.Payload.Length);
            }
            else if (frame.Payload.Length <= UInt16.MaxValue)
            {
                buffer[1] = 126;
                buffer[2] = (byte)((frame.Payload.Length >> 8) & 0xFF);
                buffer[3] = (byte)(frame.Payload.Length & 0xFF);
                offset = 4;
            }
            else
            {
                buffer[1] = 127;
                buffer[2] = 0;
                buffer[3] = 0;
                buffer[4] = 0;
                buffer[5] = 0;
                buffer[6] = (byte)((frame.Payload.Length >> 24) & 0xFF);
                buffer[7] = (byte)((frame.Payload.Length >> 16) & 0xFF);
                buffer[8] = (byte)((frame.Payload.Length >> 8) & 0xFF);
                buffer[9] = (byte)(frame.Payload.Length & 0xFF);
                offset = 10;
            }

            if (frame.Payload != null && frame.Masked)
            {
                byte[] mask = new byte[4];
                new Random().NextBytes(mask);

                for (int ii = 0; ii < frame.Payload.Length; ii++)
                {
                    buffer[offset++] = mask[ii];
                }

                for (int ii = 0; ii < frame.Payload.Length; ii++)
                {
                    frame.Payload[ii] = (byte)(frame.Payload[ii] ^ mask[ii % 4]);
                }
            }

            await stream.WriteAsync(buffer, 0, offset);

            if (frame.Payload != null)
            {
                await stream.WriteAsync(frame.Payload, 0, frame.Payload.Length);
            }
        }
        private static void SwapBytes(byte[] buffer, int offset, int count)
        {
            for (int ii = 0; ii < count/2; ii++)
            {
                var msb = buffer[ii];
                buffer[ii] = buffer[count - ii - 1];
                buffer[count - ii - 1] = msb;
            }
        }

        private static async Task<Frame> ReadFrameAsync(Stream stream)
        {
            Frame frame = new Frame();

            byte[] buffer = new byte[20];
            await Read(stream, buffer, 0, 2);

            frame.Final  = (buffer[0] & 0x80) != 0;
            frame.OpCode = (byte)(buffer[0] & 0x0F);
            frame.Masked = (buffer[1] & 0x80) != 0;

            ulong payloadLength = (byte)(buffer[1] & 0x7F);

            if (payloadLength == 126)
            {
                await Read(stream, buffer, 0, 2);
                SwapBytes(buffer, 0, 2);
                payloadLength = BitConverter.ToUInt16(buffer, 0);
            }
            else if (payloadLength == 127)
            {
                await Read(stream, buffer, 0, 8);
                SwapBytes(buffer, 0, 8);
                payloadLength = BitConverter.ToUInt64(buffer, 0);
            }

            byte[] mask = null;

            if (frame.Masked)
            {
                mask = new byte[4];
                await Read(stream, mask, 0, 4);
            }

            if (payloadLength > 0)
            {
                var payload = new byte[payloadLength];
                await Read(stream, payload, 0, (int)payloadLength);

                if (mask != null)
                {
                    for (int ii = 0; ii < (int)payloadLength; ii++)
                    {
                        payload[ii] = (byte)(payload[ii] ^ mask[ii % 4]);
                    }
                }

                frame.Payload = payload;
            }

            return frame;
        }

        private static async Task MonitorConnection(Stream stream)
        {
            while (true)
            {
                var request = await ReadFrameAsync(stream);

                if (request.OpCode == 0x08)
                {
                    SwapBytes(request.Payload, 0, 2);
                    ushort code = BitConverter.ToUInt16(request.Payload, 0);

                    string reason = null;

                    if (request.Payload.Length > 2)
                    {
                        reason = Encoding.UTF8.GetString(request.Payload, 2, request.Payload.Length - 2);
                    }

                    Console.WriteLine("WebSocket Closed. Code={0} Reason={1}", code, reason);
                    stream.Close();
                    return;
                }

                if (request.OpCode == 0x09)
                {
                    Console.WriteLine("Sending Pong.");
                    await SendPongAsync(stream, request, false);
                    continue;
                }

                if (request.OpCode == 0x0A)
                {
                    Console.WriteLine("Received Pong.");
                    continue;
                }

                Console.WriteLine("Echo Request: {0}", Encoding.UTF8.GetString(request.Payload));

                Frame response = new Frame();

                response.Final = true;
                response.OpCode = 0x02;
                response.Masked = false;
                response.Payload = request.Payload;

                await SendFrameAsync(stream, response);
            }
        }

        public static async Task<string> ReceiveHeader(Stream stream)
        {
            byte[] chunk = new byte[UInt16.MaxValue];

            int offset = 0;

            while (true)
            {
                int bytesRead = await stream.ReadAsync(chunk, offset, 1);

                if (bytesRead == 0)
                {
                    throw new EndOfStreamException("Peer closed socket gracefully.");
                }

                if (offset > 4 && chunk[offset] == '\n')
                {
                    if (chunk[offset - 3] == '\r' && chunk[offset - 2] == '\n' && chunk[offset - 1] == '\r')
                    {
                        break;
                    }
                }

                offset++;
            }

            return Encoding.UTF8.GetString(chunk, 0, offset-1);
        }

        private static async Task<int> Receive(Stream istrm, ArraySegment<byte> buffer)
        {
            int bytesRead = 0;
            int start = buffer.Offset;

            do
            {
                int nextBlock = await istrm.ReadAsync(buffer.Array, start, buffer.Count - bytesRead);

                if (nextBlock == 0)
                {
                    break;
                }

                bytesRead += nextBlock;
                start += nextBlock;
            }
            while (bytesRead < buffer.Count);

            return bytesRead;
        }
    }
}
