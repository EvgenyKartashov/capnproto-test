using BenchmarkDotNet.Attributes;
using CapnpGen;
using TestClient;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class SerializationBenchmark
    {
        Test testCapnpContent = default!;
        TestClient.Models.Test testJsonContent = default!;

        [GlobalSetup]
        public void Setup()
        {
            testCapnpContent = SerializerUtil.GenerateTestInstance("testEmail.q", "testName", "testPhoneNumber1", "testPhoneNumber2");
            testJsonContent = SerializerUtil.GenerateTestJsonInstance("testEmail.q", "testName", "testPhoneNumber1", "testPhoneNumber2");
        }

        [Benchmark]
        public void Capnp()
        {
            byte[] byteArray = SerializerUtil.SerializeCapnp(testCapnpContent);
        }

        [Benchmark]
        public void JsonCapnp()
        {
            byte[] byteArray = SerializerUtil.SerializeJson(testCapnpContent);
        }

        [Benchmark]
        public void Json()
        {
            byte[] byteArray = SerializerUtil.SerializeJson(testJsonContent);
        }
    }
}
