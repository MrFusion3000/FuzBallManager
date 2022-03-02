using System.Text.Json.Serialization;

namespace Application
{
    public class ManagerJsonDto
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("managingTeamID")]
        public Guid ManagingTeamID { get; set; }

        [JsonPropertyName("managingTeamName")]
        public string? ManagingTeamName { get; set; }

        public override string? ToString() => ManagingTeamName;

    }
}
