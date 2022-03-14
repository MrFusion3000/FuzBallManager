using Application.Commands;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class UpdateManagerHandler : IRequestHandler<UpdateManagerCommand, Guid>
{
    private readonly IManagerRepository _managerRepo;
    public UpdateManagerHandler(IManagerRepository managerRepo)
    {
        _managerRepo = managerRepo;
    }
    public async Task<Guid> Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
    {
        var managerEntity = request.Adapt<Manager>();

        ArgumentNullException.ThrowIfNull(managerEntity);

        await _managerRepo.UpdateAsync(managerEntity, cancellationToken);

        return default;
    }
}
