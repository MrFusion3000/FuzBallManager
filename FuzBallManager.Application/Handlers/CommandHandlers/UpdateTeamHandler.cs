using Application.Commands;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class UpdateTeamHandler : IRequestHandler<UpdateTeamCommand, Guid>
{
    private readonly ITeamRepository _TeamRepo;
    public UpdateTeamHandler(ITeamRepository TeamRepository)
    {
        _TeamRepo = TeamRepository;
    }
    public async Task<Guid> Handle(UpdateTeamCommand request, CancellationToken cancellationToken)
    {
        var result = request.Adapt<Team>();
        if (result == null) return default;

        await _TeamRepo.UpdateAsync(result, cancellationToken);
        return default;
    }
}
