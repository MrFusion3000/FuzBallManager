using Application.Commands;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class UpdateManagerHandler : IRequestHandler<UpdateManagerCommand, Guid>
{
    private readonly IManagerRepository _managerRepo;
    public UpdateManagerHandler(IManagerRepository managerRepository)
    {
        _managerRepo = managerRepository;
    }
    public async Task<Guid> Handle(UpdateManagerCommand request, CancellationToken cancellationToken)
    {
        var result = request.Adapt<Manager>();
        if (result == null) return default;

        await _managerRepo.UpdateAsync(result, cancellationToken);
        return default;
    }
}
