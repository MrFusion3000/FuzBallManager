using System.Text.Json.Serialization;

namespace Application
{
    public class PlayerDto
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("dateOfBirth")]
        public string? DateOfBirth { get; set; }

        [JsonPropertyName("playerPosition")]
        public int? PlayerPosition { get; set; }
    }
}
