using Application.Queries;
using Domain.Entities;
using Domain.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
