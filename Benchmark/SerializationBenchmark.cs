using BenchmarkDotNet.Attributes;
using My.CSharp.Namespace;
using TestClient;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class SerializationBenchmark
    {
        Test testCapnpContent = default!;
        TestClient.Models.Test testJsonContent = default!;

        byte[] byteArrayToDeserializeCapnp = default!;
        byte[] byteArrayToDeserializeJson = default!;

        [GlobalSetup]
        public void Setup()
        {
            testCapnpContent = SerializerUtil.GenerateTestInstance("testEmail.q", "testName", "testPhoneNumber1", "testPhoneNumber2");
            testJsonContent = SerializerUtil.GenerateTestJsonInstance("testEmail.q", "testName", "testPhoneNumber1", "testPhoneNumber2");

            byteArrayToDeserializeCapnp = SerializerUtil.SerializeCapnp(testCapnpContent).ToArray();
            byteArrayToDeserializeJson = SerializerUtil.SerializeJson(testJsonContent);
        }

        [Benchmark]
        public void SerializeCapnp()
        {
            _ = SerializerUtil.SerializeCapnp(testCapnpContent).ToArray();
        }

        [Benchmark]
        public void DeserializeCapnp()
        {
            _ = SerializerUtil.DeserializeCapnp(byteArrayToDeserializeCapnp);
        }

        [Benchmark]
        public void SerializeJson()
        {
            _ = SerializerUtil.SerializeJson(testJsonContent);
        }

        [Benchmark]
        public void DeserializeJson()
        {
            _ = SerializerUtil.DeserializeJson(byteArrayToDeserializeJson);
        }
    }
}
