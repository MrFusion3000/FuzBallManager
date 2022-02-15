using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetAllManagersQuery : IRequest<List<Manager>>
    {
    }
}
