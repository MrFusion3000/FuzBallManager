
namespace Application.Responses
{
    public class PlayerResponse
    {
        public Guid PlayerId { get; set; }
        public string? PlayerFirstName { get; set; }
        public string? PlayerLastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int PlayerPosition { get; set; }
        public int PlayerStats { get; set; }
    }
}
