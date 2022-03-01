using Application.Queries;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
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
            var getreq = request.Adapt<TeamResponse>();
            var teamname = getreq.TeamName;

            return await _teamRepository.GetTeamByTeamName(teamname, cancellationToken);
        }
    }
}
