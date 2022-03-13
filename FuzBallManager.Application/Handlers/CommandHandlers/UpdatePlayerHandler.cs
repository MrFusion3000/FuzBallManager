using Application.Commands;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class UpdatePlayerHandler : IRequestHandler<UpdatePlayerCommand, Guid>
{
    private readonly IPlayerRepository _playerRepo;
    public UpdatePlayerHandler(IPlayerRepository playerRepository)
    {
        _playerRepo = playerRepository;
    }
    public async Task<Guid> Handle(UpdatePlayerCommand request, CancellationToken cancellationToken)
    {
        var result = request.Adapt<Player>();
        if (result == null) return default;

        await _playerRepo.UpdateAsync(result, cancellationToken);
        return default;
    }
}
