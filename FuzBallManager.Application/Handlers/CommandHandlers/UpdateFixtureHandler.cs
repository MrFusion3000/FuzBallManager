using Application.Commands;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers;

public class UpdateFixtureHandler : IRequestHandler<UpdateFixtureCommand, Guid>
{
    private readonly IFixtureRepository _fixtureRepo;
    public UpdateFixtureHandler(IFixtureRepository fixtureRepo)
    {
        _fixtureRepo = fixtureRepo;
    }
    public async Task<Guid> Handle(UpdateFixtureCommand command, CancellationToken cancellationToken)
    {
        var fixtureEntity = command.Adapt<Fixture>();

        ArgumentNullException.ThrowIfNull(fixtureEntity);

        await _fixtureRepo.Update(fixtureEntity, cancellationToken);

        return fixtureEntity.FixtureID;
    }
}
