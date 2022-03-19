using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using Mapster;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetNextFixtureHandler : IRequestHandler<GetNextFixtureQuery, Fixture>
    {
        private readonly IFixtureRepository _fixtureRepo;
        public GetNextFixtureHandler(IFixtureRepository fixtureRepo)
        {
            _fixtureRepo = fixtureRepo;
        }
        public async Task<Fixture> Handle(GetNextFixtureQuery request, CancellationToken cancellationToken)
        {
            //var fixtureId = request.FixtureID;
            var nextFixture = request.Adapt<Fixture>();

            return await _fixtureRepo.GetNextFixture(nextFixture, cancellationToken);
        }
    }
}
