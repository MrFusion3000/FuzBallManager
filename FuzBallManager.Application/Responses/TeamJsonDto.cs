using System.Text.Json.Serialization;

namespace Application
{
    public class TeamJsonDto
    {
        [JsonPropertyName("teamName")]
        public string? TeamName { get; set; } = "Anomymice";

        [JsonPropertyName("stadium")]
        public string? Stadium { get; set; } = "AnonymouStadium";

        public static implicit operator List<object>(TeamJsonDto v)
        {
            throw new NotImplementedException();
        }
    }
}
