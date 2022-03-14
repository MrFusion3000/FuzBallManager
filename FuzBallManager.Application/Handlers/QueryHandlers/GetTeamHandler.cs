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
        private readonly ITeamRepository _teamRepo;

        public GetTeamHandler(ITeamRepository teamRepo)
        {
            _teamRepo = teamRepo;
        }
        public async Task<Team> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            var getreq = request.Adapt<TeamResponse>();
            var teamname = getreq.TeamName;

            return await _teamRepo.GetTeamByTeamName(teamname, cancellationToken);
        }
    }
}
