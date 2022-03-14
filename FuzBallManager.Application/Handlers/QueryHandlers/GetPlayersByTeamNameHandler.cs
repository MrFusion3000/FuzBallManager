using Application.Queries;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetPlayersByTeamNameHandler : IRequestHandler<GetPlayersByTeamNameQuery, List<Player>>
    {
        private readonly IPlayerRepository _playerRepo;

        public GetPlayersByTeamNameHandler(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }
        public async Task<List<Player>> Handle(GetPlayersByTeamNameQuery request, CancellationToken cancellationToken)
        {
            var getreq = request.Adapt<PlayerResponse>();
            var teamname = getreq.TeamName;

            return (List<Player>)await _playerRepo.GetPlayersByTeamName(teamname, cancellationToken);
        }

    }
}
