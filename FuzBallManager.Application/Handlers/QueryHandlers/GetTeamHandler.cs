using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetTeamHandler : IRequestHandler<GetTeamQuery, List<Team>>
    {
        private readonly ITeamRepository _teamRepository;

        public GetTeamHandler(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        public async Task<List<Team>> Handle(GetTeamQuery request, CancellationToken cancellationToken)
        {
            return (List<Team>)await _teamRepository.GetAllAsync();
        }
    }
}
