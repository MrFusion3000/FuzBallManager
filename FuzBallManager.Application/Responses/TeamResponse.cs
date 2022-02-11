namespace Application.Responses
{
    public class TeamResponse
    {
        public Guid TeamID { get; set; }
        public string? TeamName { get; set; }
        public int? Points { get; set; }
        public int? Wins { get; set; }
        public int? Draws { get; set; }
        public int? Lost { get; set; }
        public int? GoalsForward { get; set; }
        public int? GoalsAgainst { get; set; }
        public string? Stadium { get; set; }
    }
}
