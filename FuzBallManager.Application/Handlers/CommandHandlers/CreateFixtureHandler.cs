using Application.Commands;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.CommandHandlers
{
    public class CreateFixtureHandler : IRequestHandler<CreateFixtureCommand, FixtureResponse>
    {
        private readonly IFixtureRepository _FixtureRepo;
        public CreateFixtureHandler(IFixtureRepository FixtureRepository)
        {
            _FixtureRepo = FixtureRepository;
        }
        public async Task<FixtureResponse> Handle(CreateFixtureCommand request, CancellationToken cancellationToken)
        {
            var FixtureEntity = request.Adapt<Fixture>();

            ArgumentNullException.ThrowIfNull(FixtureEntity);

            var newFixture = await _FixtureRepo.AddAsync(FixtureEntity);
            var fixtureDto = newFixture.Adapt<FixtureResponse>();

            return fixtureDto;
        }
    }
}
