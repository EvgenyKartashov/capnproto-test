using CapnpGen;
using TestClient;

internal class Program
{
    private static async Task Main(string[] args)
    {        
        try
        {
            using HttpClient client = new();

            Test testContent = SerializerUtil.GenerateTestInstance("testEmail.q", "testName", "testPhoneNumber1", "testPhoneNumber2");
            byte[] byteArray = SerializerUtil.SerializeCapnp(testContent);
            byte[] byteArray1 = SerializerUtil.SerializeJson(testContent);
            HttpRequestMessage request = GetRequestMessage(byteArray, HttpMethod.Post, "http://localhost:5009/api/test/test-method");
            //DeserializeCapnp(byteArray);

            Console.WriteLine("sending request");
            HttpResponseMessage result = await client.SendAsync(request);
            result.EnsureSuccessStatusCode();
            Console.WriteLine("request has been sent");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static HttpRequestMessage GetRequestMessage(byte[] byteArray, HttpMethod httpMethod, string address)
    {
        HttpRequestMessage request = new(httpMethod, address)
        {
            Content = new ByteArrayContent(byteArray),
        };
        request.Content.Headers.Add("Content-Type", "application/octet-stream");

        return request;
    }
}