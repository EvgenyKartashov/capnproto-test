using System.Runtime.InteropServices;
using System.Text;
using System.Text.Json;
using Capnp;
using CapnpGen;

namespace TestClient
{
    public class SerializerUtil
    {
        public static Test GenerateTestInstance(string email, string name, string phoneNumber1, string phoneNumber2)
        {
            Test content = new()
            {
                Birthdate = new Date { Day = 5, Month = 10, Year = 2000 },
                Email = email,
                Name = name,
                Phones =
                [
                    new Test.PhoneNumber { Number = phoneNumber1, TheType = Test.PhoneNumber.Type.home },
                new Test.PhoneNumber { Number = phoneNumber2, TheType = Test.PhoneNumber.Type.mobile },
            ],
            };

            return content;
        }

        public static byte[] SerializeCapnp(Test testContent)
        {
            var messageBuilder = MessageBuilder.Create();
            var writer = messageBuilder.BuildRoot<Test.WRITER>();

            testContent.serialize(writer);

            Span<byte> resultSpan = MemoryMarshal.Cast<ulong, byte>(writer.RawData);

            return resultSpan.ToArray();
        }

        public static byte[] SerializeJson(Models.Test testContent)
        {
            string serializedContent = JsonSerializer.Serialize(testContent);

            return Encoding.ASCII.GetBytes(serializedContent);
        }

        public static byte[] SerializeJson(Test testContent)
        {
            string serializedContent = JsonSerializer.Serialize(testContent);

            return Encoding.ASCII.GetBytes(serializedContent);
        }

        public static void DeserializeCapnp(byte[] byteArray)
        {
            using MemoryStream ms = new(byteArray);
            ms.Seek(0, SeekOrigin.Begin);

            WireFrame frame = Framing.ReadSegments(ms);
            DeserializerState deserializer = DeserializerState.CreateRoot(frame);
            Test.READER testContent = new(deserializer);

            Console.WriteLine(testContent.Name);
            Console.WriteLine(testContent.Email);
            Console.WriteLine(testContent.Birthdate);
            Console.WriteLine(testContent.Phones);
        }
    }
}
