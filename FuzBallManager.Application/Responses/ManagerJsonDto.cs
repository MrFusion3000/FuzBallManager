//using System.Text.Json.Serialization;

//namespace Application
//{
//    public class ManagerJsonDto
//    {
//        [JsonPropertyName("firstName")]
//        public string? FirstName { get; set; }

//        [JsonPropertyName("lastName")]
//        public string? LastName { get; set; }

//        [JsonPropertyName("dateOfBirth")]
//        public DateTime DateOfBirth { get; set; } = DateTime.Now;

//        [JsonPropertyName("score")]
//        public int Score { get; set; } = 0;

//        [JsonPropertyName("bank")]
//        public int Bank { get; set; } = 0;

//        [JsonPropertyName("managingTeamID")]
//        public Guid ManagingTeamID { get; set; }

//        [JsonPropertyName("managingTeamName")]
//        public string? ManagingTeamName { get; set; }

//        public override string? ToString() => ManagingTeamName;

//    }
//}
