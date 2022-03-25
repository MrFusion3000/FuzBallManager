
namespace Application.Responses;

public class PlayerResponse
{
    public Guid PlayerID { get; set; }
    public string? PlayerFirstName { get; set; }
    public string? PlayerLastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PlayerPosition { get; set; }
    public int? PlayerShirtNo { get; set; }
    public int? PlayerStats { get; set; }
    public Guid? TeamID { get; set; }
    public string? TeamName { get; set; }
    public bool? InManagedTeam { get; set; }
    public bool? Injured { get; set; }
    public int? Value { get; set; }
    public bool? Playing { get; set; }


    public override string? ToString() => TeamName;

}
