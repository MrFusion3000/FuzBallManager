using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;

namespace Application.Handlers.QueryHandlers
{
    public class GetAllTeamsHandler : IRequestHandler<GetAllTeamsQuery, List<Team>>
    {
        private readonly ITeamRepository _teamRepo;

        public GetAllTeamsHandler(ITeamRepository teamRepository)
        {
            _teamRepo = teamRepository;
        }
        public async Task<List<Team>> Handle(GetAllTeamsQuery request, CancellationToken cancellationToken)
        {
            return (List<Team>)await _teamRepo.GetAllAsync();
        }
     }
}
