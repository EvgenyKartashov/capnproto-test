using System.Text;
using System.Text.Json;
using Capnp;
using My.CSharp.Namespace;

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
                    new PhoneNumber { Number = phoneNumber1, Type = PhoneNumberType.home },
                    new PhoneNumber { Number = phoneNumber2, Type = PhoneNumberType.mobile },
                ],
            };

            return content;
        }

        public static Models.Test GenerateTestJsonInstance(string email, string name, string phoneNumber1, string phoneNumber2)
        {
            Models.Test content = new()
            {
                BirthDate = new Models.Date { Day = 5, Month = 10, Year = 2000 },
                Email = email,
                Name = name,
                Phones =
                [
                    new Models.PhoneNumber { Number = phoneNumber1, Type = Models.PhoneType.Home },
                    new Models.PhoneNumber { Number = phoneNumber2, Type = Models.PhoneType.Mobile },
                ],
            };

            return content;
        }

        public static MemoryStream SerializeCapnp(Test test)
        {
            var msg = MessageBuilder.Create();
            var root = msg.BuildRoot<Test.WRITER>();
            test.serialize(root);

            var ms = new MemoryStream();
            var pump = new FramePump(ms);
            pump.Send(msg.Frame);
            ms.Seek(0, SeekOrigin.Begin);

            return ms;
        }

        public static byte[] SerializeJson(Models.Test testContent)
        {
            string serializedContent = JsonSerializer.Serialize(testContent);

            return Encoding.UTF8.GetBytes(serializedContent);
        }

        public static byte[] SerializeJson(Test testContent)
        {
            string serializedContent = JsonSerializer.Serialize(testContent);

            return Encoding.UTF8.GetBytes(serializedContent);
        }

        public static void DeserializeCapnp(byte[] byteArray)
        {
            using MemoryStream ms = new(byteArray);
            var frame = Framing.ReadSegments(ms);

            var deserializer = DeserializerState.CreateRoot(frame);
            var reader = new Test.READER(deserializer);

            Console.WriteLine(reader.Name);
            Console.WriteLine(reader.Email);
            Console.WriteLine(reader.Birthdate);
            Console.WriteLine(reader.Phones);
        }
    }
}
