using System.Text.Json.Serialization;

namespace Application.Responses
{
    public class FixtureJsonDto
    {
        //[JsonPropertyName("fixtureId")]
        //public Guid FixtureID { get; set; }

        [JsonPropertyName("homeTeamId")]
        public Guid HomeTeamId { get; set; }

        [JsonPropertyName("awayTeamId")]
        public Guid AwayTeamId { get; set; }

        [JsonPropertyName("homeTeamScore")]
        public int? HomeTeamScore { get; set; }

        [JsonPropertyName("awayTeamScore")]
        public int? AwayTeamScore { get; set; }

        [JsonPropertyName("attendance")]
        public int? Attendance { get; set; }

        [JsonPropertyName("fixtureDate")]
        public DateTime FixtureDate { get; set; }

        [JsonPropertyName("played")]
        public bool Played { get; set; }
    }
}
