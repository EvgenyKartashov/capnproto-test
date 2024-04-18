using System.Text.Json.Serialization;

namespace TestClient.Models
{
    public class Test
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("birthdate")]
        public Date BirthDate { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("phones")]
        public List<PhoneNumber> Phones { get; set; }
    }

    public class Date
    {
        [JsonPropertyName("year")]
        public short Year { get; set; }

        [JsonPropertyName("month")]
        public byte Month { get; set; }

        [JsonPropertyName("day")]
        public byte Day { get; set; }
    }

    public class PhoneNumber
    {
        [JsonPropertyName("number")]
        public string Number { get; set; }

        [JsonPropertyName("type")]
        public PhoneType Type { get; set; }
    }

    public enum PhoneType
    {
        Mobile,
        Home,
        Work
    }
}
