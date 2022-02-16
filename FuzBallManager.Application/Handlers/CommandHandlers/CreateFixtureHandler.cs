using Application.Commands;
using Application.Mappers;
using Application.Responses;
using Domain.Entities;
using Domain.Repositories;
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
            var FixtureEntity = FixtureMapper.Mapper.Map<Fixture>(request);
            //if (FixtureEntity is null)
            //{
            //    throw new ApplicationException("issue with mapper");
            //}

            ArgumentNullException.ThrowIfNull(FixtureEntity);

            var newFixture = await _FixtureRepo.AddAsync(FixtureEntity);
            var FixtureResponse = FixtureMapper.Mapper.Map<FixtureResponse>(newFixture);

            return FixtureResponse;
        }
    }
}
