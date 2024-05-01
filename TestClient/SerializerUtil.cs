﻿using System.Runtime.InteropServices;
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
