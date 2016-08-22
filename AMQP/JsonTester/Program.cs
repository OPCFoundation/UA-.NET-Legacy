using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Opc.Ua;
using System.IO;
using Newtonsoft.Json;
using System.Xml;

namespace JsonTester
{
    class Program
    {
        static void Main(string[] args)
        {
            var bytes = File.ReadAllBytes(".\\JsonTester.exe.config");
            var text = new UTF8Encoding(false).GetString(bytes);
            int index = text.IndexOf("?>");

            if (index > 0)
            {
                text = text.Substring(index + 2);
            }
            
            StringBuilder buffer = new StringBuilder();
            ServiceMessageContext.GlobalContext.NamespaceUris.GetIndexOrAppend("http://mycompany.com/mynamespace1");
            ServiceMessageContext.GlobalContext.NamespaceUris.GetIndexOrAppend("http://mycompany.com/mynamespace2");

            JsonEncoder encoder = new JsonEncoder(ServiceMessageContext.GlobalContext, true);

            encoder.WriteBoolean("BooleanValue", true);
            encoder.WriteBooleanArray("BooleanArray", new bool[] { true, false, true });
            encoder.WriteInt32("Int32Value", 12345);
            encoder.WriteInt32Array("Int32Array", new int[] { 0, Int32.MaxValue, Int32.MinValue });
            encoder.WriteFloat("DoubleValue", Single.MinValue);
            encoder.WriteDoubleArray("DoubleArray", new double[] { 0, Double.MaxValue, Double.MinValue, Double.NaN, Double.NegativeInfinity, Double.PositiveInfinity, Double.Epsilon });
            encoder.WriteNodeId("NodeId", new NodeId(1234, 2));

            var encodeable = new ApplicationDescription()
            {
                ApplicationName = new LocalizedText("en", "MyApplication"),
                ApplicationType = ApplicationType.Server,
                ApplicationUri = "urn:MyHost:MyApplication",
                DiscoveryUrls = new StringCollection(new string[] { "opc.tcp://localhost:12345", "https://localhost:12346" }),
                ProductUri = "urn:MyCompany:MyApplication"
            };

            encoder.WriteEncodeable("Encodeable", encodeable, null);
            encoder.WriteExtensionObject("ExtensionObject", new ExtensionObject(encodeable));
            encoder.WriteVariant("VariantDouble", new Variant(3.1415));
            encoder.WriteVariant("VariantObject", new Variant(new ExtensionObject(encodeable)));

            DataValue dv = new DataValue()
            {
                WrappedValue = new Variant(7867),
                SourceTimestamp = DateTime.UtcNow
            };

            encoder.WriteDataValue("DataValue", dv);

            var json = encoder.Close();

            JsonDecoder decoder = new JsonDecoder(json, ServiceMessageContext.GlobalContext);

            var field1 = decoder.ReadBoolean("BooleanValue");
            var field2 = decoder.ReadBooleanArray("BooleanArray");
            var field3 = decoder.ReadInt32("Int32Value");
            var field4 = decoder.ReadInt32Array("Int32Array");
            var field5 = decoder.ReadFloat("DoubleValue");
            var field6 = decoder.ReadDoubleArray("DoubleArray");
            var field7 = decoder.ReadNodeId("NodeId");
            var field8 = decoder.ReadEncodeable("Encodeable", typeof(ApplicationDescription));
            var field9 = decoder.ReadExtensionObject("ExtensionObject");
            var field0 = decoder.ReadVariant("VariantDouble");
            var fieldA = decoder.ReadVariant("VariantObject");
            var fieldB = decoder.ReadDataValue("DataValue");

            JsonTextReader reader = new JsonTextReader(new StringReader(json));

            while (reader.Read())
            { 
                if (reader.Value != null)
                {
                    Console.WriteLine("Token: {0}, Value: {2} {1}", reader.TokenType, reader.Value, reader.Value.GetType().Name);
                }
                else
                {
                    Console.WriteLine("Token: {0}", reader.TokenType);
                }
            }

            Console.WriteLine(json);
        }
    }
}
