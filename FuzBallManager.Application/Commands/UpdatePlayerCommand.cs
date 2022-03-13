using MediatR;

namespace Application.Commands;

public class UpdatePlayerCommand : IRequest<Guid>
{
    public Guid PlayerID { get; set; }
    public string? PlayerFirstName { get; set; }
    public string? PlayerLastName { get; set; }
    public DateTime? DateOfBirth { get; set; }
    public string? PlayerPosition { get; set; }
    public int? PlayerStats { get; set; }
    public string? TeamName { get; set; }
}
