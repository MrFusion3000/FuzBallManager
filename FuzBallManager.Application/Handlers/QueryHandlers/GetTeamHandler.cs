using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetTeamHandler : IRequestHandler<GetTeamQuery, Team>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<Team> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var teamname = request.TeamName;

            return (Team)await _teamRepository.GetTeamByTeamName(teamname, cancellationToken);
        }
    }
}
