using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetAllFixturesQuery : IRequest<List<Fixture>>
    {
    }
}
