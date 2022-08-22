using Application.Commands;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers
{
    public class CreatePlayerHandler : IRequestHandler<CreatePlayerCommand, PlayerResponse>
    {
        private readonly IPlayerRepository _playerRepo;
        public CreatePlayerHandler(IPlayerRepository playerRepository)
        {
            _playerRepo = playerRepository;
        }
        public async Task<PlayerResponse> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
        {
            var playerEntity = request.Adapt<Player>();

            ArgumentNullException.ThrowIfNull(playerEntity);

            var newPlayer = await _playerRepo.AddAsync(playerEntity, cancellationToken);
            var playerResponse = newPlayer.Adapt<PlayerResponse>();

            return playerResponse;
        }
    }
}
