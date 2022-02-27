using System.Text.Json.Serialization;

namespace UIConsole
{
    public class TeamDto
    {
        [JsonPropertyName("teamName")]
        public string? TeamName { get; set; }

        [JsonPropertyName("stadium")]
        public string? Stadium { get; set; }

        public static implicit operator List<object>(TeamDto v)
        {
            throw new NotImplementedException();
        }
    }
}
