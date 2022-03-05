using Application.Queries;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetTeamByIdHandler : IRequestHandler<GetTeamByIdQuery, Team>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamByIdHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<Team> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
        {
            var getreq = request.Adapt<TeamResponse>();
            var teamid = getreq.TeamID;

            return await _teamRepository.GetTeamById(teamid, cancellationToken);
        }
    }
}
