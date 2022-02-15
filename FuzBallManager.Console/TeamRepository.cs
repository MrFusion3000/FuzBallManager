using System.Text.Json.Serialization;

namespace UIConsole
{
    public class TeamRepository
    {
        [JsonPropertyName("teamName")]
        public string? TeamName { get; set; }

        [JsonPropertyName("stadium")]
        public string? Stadium { get; set; }
    }
}
