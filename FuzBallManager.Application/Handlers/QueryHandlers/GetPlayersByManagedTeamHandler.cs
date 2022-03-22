using Application.Queries;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetPlayersByManagedTeamHandler : IRequestHandler<GetPlayersByManagedTeamQuery, List<Player>>
    {
        private readonly IPlayerRepository _playerRepo;

        public GetPlayersByManagedTeamHandler(IPlayerRepository playerRepo)
        {
            _playerRepo = playerRepo;
        }
        public async Task<List<Player>> Handle(GetPlayersByManagedTeamQuery request, CancellationToken cancellationToken)
        {
            var getreq = request.Adapt<PlayerResponse>();
            bool inmanagedteam = (bool)getreq.InManagedTeam;

            return (List<Player>)await _playerRepo.GetPlayersByManagedTeam(inmanagedteam, cancellationToken);
        }

    }
}
