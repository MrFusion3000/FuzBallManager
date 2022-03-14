using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetPlayersByTeamNameQuery : IRequest<List<Player>>
    {
        public string TeamName { get; set; }
    }
}
