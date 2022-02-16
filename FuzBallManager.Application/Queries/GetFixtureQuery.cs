using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetFixtureQuery : IRequest<Fixture>
    {
        public Guid? FixtureID { get; set; }
    }
}
