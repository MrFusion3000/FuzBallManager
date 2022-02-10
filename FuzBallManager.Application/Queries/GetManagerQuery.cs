using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetManagerQuery : IRequest<List<Manager>>
    {
    }
}
