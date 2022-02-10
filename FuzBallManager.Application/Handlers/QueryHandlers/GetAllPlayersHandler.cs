using Domain.Repositories;
using Domain.Entities;
using MediatR;
using Application.Queries;

namespace Application.Handlers.QueryHandlers
{
    public class GetAllPlayersHandler : IRequestHandler<GetAllPlayersQuery, List<Player>>
    {
        private readonly IPlayerRepository _playerRepo;
        public GetAllPlayersHandler(IPlayerRepository playerRepository)
        {
            _playerRepo = playerRepository;
        }
        public async Task<List<Player>> Handle(GetAllPlayersQuery request, CancellationToken cancellationToken)
        {                
                return (List<Player>) await _playerRepo.GetAllAsync();
        }

    }
}
