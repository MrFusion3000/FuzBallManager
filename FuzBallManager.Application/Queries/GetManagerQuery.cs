using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetManagerQuery : IRequest<Manager>
    {
        public string? Name { get; set; }
    }
}
