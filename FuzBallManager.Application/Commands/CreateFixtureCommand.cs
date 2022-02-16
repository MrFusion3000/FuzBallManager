using Application.Responses;
using MediatR;

namespace Application.Commands
{
    public class CreateFixtureCommand : IRequest<FixtureResponse>
    {
        public Guid? HomeTeamId { get; set; } 
        public Guid? AwayTeamId { get; set; } 
        public int HomeTeamScore { get; set; }
        public int AwayTeamScore { get; set; }
        public int? Attendance { get; set; }
        public DateTime FixtureDate { get; set; }
        public bool Played { get; set; }
    }
}
