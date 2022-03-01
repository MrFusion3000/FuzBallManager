using System.Text.Json.Serialization;

namespace Application
{
    public class TeamJsonDto
    {
        public Guid TeamID { get; set; }
       
        [JsonPropertyName("teamName")]
        public string? TeamName { get; set; } = "Anonymice";

        [JsonPropertyName("stadium")]
        public string? Stadium { get; set; } = "AnonymouStadium";
        public int? Points { get; set; }
        public int? Wins { get; set; }
        public int? Draws { get; set; }
        public int? Lost { get; set; }
        public int? GoalsForward { get; set; }
        public int? GoalsAgainst { get; set; }

        public override string? ToString() => TeamName;
    }
}
