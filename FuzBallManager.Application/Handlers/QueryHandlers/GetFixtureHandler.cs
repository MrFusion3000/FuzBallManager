using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetFixtureHandler : IRequestHandler<GetFixtureQuery, Fixture>
    {
        private readonly IFixtureRepository _fixtureRepo;
        public GetFixtureHandler(IFixtureRepository fixtureRepo)
        {
            _fixtureRepo = fixtureRepo;
        }
        public async Task<Fixture> Handle(GetFixtureQuery request, CancellationToken cancellationToken)
        {
            var fixtureId = request.FixtureID;

            return (Fixture)await _fixtureRepo.GetByIdAsync(fixtureId);
        }
    }
}
