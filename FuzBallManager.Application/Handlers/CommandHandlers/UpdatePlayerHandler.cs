using Application.Commands;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class UpdatePlayerHandler : IRequestHandler<UpdatePlayerCommand, Guid>
{
    private readonly IPlayerRepository _playerRepo;
    public UpdatePlayerHandler(IPlayerRepository playerRepo)
    {
        _playerRepo = playerRepo;
    }
    public async Task<Guid> Handle(UpdatePlayerCommand command, CancellationToken cancellationToken)
    {
        var playerEntity = command.Adapt<Player>();

        ArgumentNullException.ThrowIfNull(playerEntity);

        await _playerRepo.  Update(playerEntity, cancellationToken);

        return playerEntity.PlayerID;
    }
}
