using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetFixtureHandler : IRequestHandler<GetFixtureQuery, Fixture>
    {
        private readonly IFixtureRepository _fixtureRepository;
        public GetFixtureHandler(IFixtureRepository fixtureRepository)
        {
            _fixtureRepository = fixtureRepository;
        }
        public async Task<Fixture> Handle(GetFixtureQuery request, CancellationToken cancellationToken)
        {
            var fixtureId = request.FixtureID;

            //var manager = await _managerRepository.GetManagerByLastName(lastname, cancellationToken);
            //var managerResponse = manager.Adapt<Manager>();

            //return manager;
            return (Fixture)await _fixtureRepository.GetByIdAsync(fixtureId);
        }
    }
}
