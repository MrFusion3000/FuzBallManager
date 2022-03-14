using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetAllPlayersQuery : IRequest<List<Player>>
    {
        //public string? TeamName { get; set; }
    }
}
