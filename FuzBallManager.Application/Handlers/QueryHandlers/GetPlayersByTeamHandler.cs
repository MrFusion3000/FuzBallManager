using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetPlayersByTeamHandler : IRequestHandler<GetPlayersByTeamNameQuery, List<Player>>
    {
        private readonly IPlayerRepository _playerRepo;
        public GetPlayersByTeamHandler(IPlayerRepository playerRepository)
        {
            _playerRepo = playerRepository;
        }
        public async Task<List<Player>> Handle(GetPlayersByTeamNameQuery request, CancellationToken cancellationToken)
        {
            var teamname = request.TeamName;

            return (List<Player>)await _playerRepo.GetPlayersByTeamNameAsync(teamname, cancellationToken);
        }

    }
}
