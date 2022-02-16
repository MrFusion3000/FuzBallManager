using Domain.Repositories;
using Domain.Entities;
using MediatR;
using Application.Queries;

namespace Application.Handlers.QueryHandlers
{
    public class GetAllFixturesHandler : IRequestHandler<GetAllFixturesQuery, List<Fixture>>
    {
        private readonly IFixtureRepository _fixtureRepository;
        public GetAllFixturesHandler(IFixtureRepository fixtureRepository)
        {
            _fixtureRepository = fixtureRepository;
        }
        public async Task<List<Fixture>> Handle(GetAllFixturesQuery request, CancellationToken cancellationToken)
        {
            return (List<Fixture>) await _fixtureRepository.GetAllAsync();
        }
    }
}
