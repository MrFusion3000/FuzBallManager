using MediatR;

namespace Application.Commands;

public class UpdateFixtureCommand : IRequest<Guid>
{
    public Guid FixtureID { get; set; }
    public Guid HomeTeamId { get; set; }
    public Guid AwayTeamId { get; set; }
    public int HomeTeamScore { get; set; }
    public int AwayTeamScore { get; set; } 
    public int Attendance { get; set; }
    public DateTime FixtureDate { get; set; }
    public bool Played { get; set; }
}
