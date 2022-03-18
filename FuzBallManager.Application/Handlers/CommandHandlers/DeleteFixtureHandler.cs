using Application.Commands;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class DeleteFixtureHandler : IRequestHandler<DeleteFixtureCommand, Guid>
{
    private readonly IFixtureRepository _fixtureRepo;
    public DeleteFixtureHandler(IFixtureRepository fixtureRepo)
    {
        _fixtureRepo = fixtureRepo;
    }
    public async Task<Guid> Handle(DeleteFixtureCommand command, CancellationToken cancellationToken)
    {
        var fixtureEntity = command.Adapt<Fixture>();

        ArgumentNullException.ThrowIfNull(fixtureEntity);

        await _fixtureRepo.DeleteAsync(fixtureEntity, cancellationToken);

        return fixtureEntity.FixtureID;
    }
}
