using Application.Responses;
using Domain.Entities;
using Application.Mappers;
using Application.Commands;
using MediatR;
using Domain.Repositories;

namespace Application.Handlers.CommandHandlers
{
    public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, PlayerResponse>
    {
        private readonly IPlayerRepository _playerRepo;
        public CreatePlayerHandler(IPlayerRepository playerRepository)
        {
            _playerRepo = playerRepository;
        }
        public async Task <PlayerResponse> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var playerEntity = PlayerMapper.Mapper.Map<Player> (request);
            if(playerEntity is null)
            {
                throw new ApplicationException("issue with mapper");
            }

            var newPlayer = await _playerRepo.AddAsync(playerEntity);
            var playerResponse = PlayerMapper.Mapper.Map<PlayerResponse>(newPlayer);

            return playerResponse;
        }
    }
}
