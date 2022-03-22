using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetPlayersByManagedTeamQuery : IRequest<List<Player>>
    {
        public string InManagedTeam { get; set; }
    }
}
