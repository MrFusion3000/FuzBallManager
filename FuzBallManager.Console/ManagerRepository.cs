using System.Text.Json.Serialization;

namespace UIConsole
{
    public class ManagerRepository
    {
        [JsonPropertyName("firstName")]
        public string? FirstName { get; set; }

        [JsonPropertyName("lastName")]
        public string? LastName { get; set; }

        [JsonPropertyName("managingTeamName")]
        public string? ManagingTeamName { get; set; }
    }
}
