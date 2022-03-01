using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Domain.Repositories;
using Domain.Entities;
using MediatR;
using Mapster;

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
            //var playerEntity = PlayerMapper.Mapper.Map<Player> (request);
            var playerEntity = request.Adapt<Player>();

            //if(playerEntity is null)
            //{
            //    throw new ApplicationException("issue with mapper");
            //}
            ArgumentNullException.ThrowIfNull(playerEntity);

            var newPlayer = await _playerRepo.AddAsync(playerEntity);
            //var playerResponse = PlayerMapper.Mapper.Map<PlayerResponse>(newPlayer);
            var playerResponse = request.Adapt<PlayerResponse>();


            return playerResponse;
        }
    }
}
