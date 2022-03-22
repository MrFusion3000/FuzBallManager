using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetPlayersByManagedTeamQuery : IRequest<List<Player>>
    {
        public bool InManagedTeam { get; set; }
    }
}
