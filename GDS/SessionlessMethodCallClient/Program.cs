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
using System.Net.Http;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace SessionlessMethodCallClient
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Net.ServicePointManager.ServerCertificateValidationCallback = HttpsCertificateValidation;
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12 | System.Net.SecurityProtocolType.Tls;

            string authorizationUrl = String.Format("https://{0}:54333/connect/token", System.Net.Dns.GetHostName().ToLowerInvariant());

            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters["grant_type"] = "client_credentials";
            parameters["client_id"] = "urn:localhost:OAuth2TestClient";
            parameters["client_secret"] = "secret";
            parameters["scope"] = "pubsub";
            parameters["resource"] = "urn:opcfoundation.org:ua:oauth2:resource:site";

            HttpClient client = new HttpClient();
            FormUrlEncodedContent content = new FormUrlEncodedContent(parameters);
            var response = client.PostAsync(authorizationUrl, content).Result;

            var json = response.Content.ReadAsStringAsync().Result;
            var body = JObject.Parse(json);

            string error = (string)body["error"];
            string accessToken = null;

            if (error != null)
            {
                Console.WriteLine("ERROR Getting AccessToken: " + error);
            }
            else
            {
                accessToken = (string)body["access_token"];
            }

            Console.WriteLine("");
            Console.WriteLine("TEST Valid Group");
            GetSecurityKeys("Group1", accessToken);

            Console.WriteLine("");
            Console.WriteLine("TEST Valid Group - No Access");
            GetSecurityKeys("Group2", accessToken);

            Console.WriteLine("");
            Console.WriteLine("TEST Invalid Group");
            GetSecurityKeys("Group3", accessToken);

            Console.WriteLine("TEST COMPLETE!");
            Console.ReadKey();
        }

        static JObject ToUInt32(uint value) { return JObject.Parse("{\"Type\":7,\"Body\":" + value.ToString() + "}"); }
        static JObject ToString(string value) { return JObject.Parse("{\"Type\":12,\"Body\":\"" + value.ToString() + "\"}"); }
        static JToken ToNodeId(uint value) { return "i=" + value.ToString(); }

        static void GetSecurityKeys(string groupName, string accessToken)
        {
            string serverUrl = String.Format("https://{0}:58811/", System.Net.Dns.GetHostName().ToLowerInvariant());

            var request = new JObject();
            request.Add("ServiceId", 710);

            var body = new JObject();
            var list = new JArray();
            var item = new JObject();
            item.Add("ObjectId", ToNodeId(14443));
            item.Add("MethodId", ToNodeId(15215));
            var inargs = new JArray();
            inargs.Add(ToString(groupName));
            inargs.Add(ToUInt32(4));
            item.Add("InputArguments", inargs);
            list.Add(item);
            body.Add("MethodsToCall", list);

            request.Add("Body", body);

            StringContent content = new StringContent(request.ToString(Formatting.None));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/opcua+uajson");

            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            var response = client.PostAsync(serverUrl, content).Result;
            Console.WriteLine(response.ReasonPhrase);

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine("ERROR Getting during HTTP post: " + response.ReasonPhrase);
                return;
            }

            var json = response.Content.ReadAsStringAsync().Result;
            body = JObject.Parse(json);

            var pos = body["Body"];

            pos = (pos != null) ? pos["ResponseHeader"] : null;
            pos = (pos != null) ? pos["ServiceResult"] : null;

            if (pos != null && pos.Type == JTokenType.Integer)
            {
                uint code = (uint)pos;

                if ((code & 0x80000000) != 0)
                {
                    Console.WriteLine("ERROR Getting SecurityKeys: " + code.ToString());
                    return;
                }
            }

            pos = body["Body"];
            pos = (pos != null) ? pos["Results"] : null;
            pos = (pos != null) ? pos[0] : null;

            var error = (pos != null) ? pos["StatusCode"] : null;

            if (error != null)
            {
                Console.WriteLine("ERROR Getting SecurityKeys: " + (string)error);
            }
            else
            {
                Console.WriteLine("SUCCESS Getting SecurityKeys");

                pos = (pos != null) ? pos["OutputArguments"] : null;

                var array = (JArray)pos;

                for (int ii = 0; ii < array.Count; ii++)
                {
                    var value = array[ii];
                    value = value["Body"];

                    if (value != null)
                    {
                        Console.WriteLine("[{0}] {1}", ii, value.ToString());
                    }
                }
            }
        }

        private static bool HttpsCertificateValidation(
            object sender,
            X509Certificate cert,
            X509Chain chain,
            System.Net.Security.SslPolicyErrors error)
        {
            Console.WriteLine("Could not verify SSL certificate: {0} {1}", cert.Subject, error);
            return true;
        }
    }
}
