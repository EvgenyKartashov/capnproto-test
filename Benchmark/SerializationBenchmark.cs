using BenchmarkDotNet.Attributes;
using CapnpGen;
using TestClient;

namespace Benchmark
{
    [MemoryDiagnoser]
    public class SerializationBenchmark
    {
        Test testContent = default!;

        [GlobalSetup]
        public void Setup()
        {
            testContent = SerializerUtil.GenerateTestInstance("testEmail.q", "testName", "testPhoneNumber1", "testPhoneNumber2");
        }

        [Benchmark]
        public void Capnp()
        {
            byte[] byteArray = SerializerUtil.SerializeCapnp(testContent);
        }

        [Benchmark]
        public void Json()
        {
            byte[] byteArray = SerializerUtil.SerializeJson(testContent);
        }
    }
}
