using Domain.Entities;
using MediatR;

namespace Application.Queries
{
    public class GetNextFixtureQuery : IRequest<Fixture>
    {
        public Guid FixtureID { get; set; }
        public bool Played { get; set; }
    }
}
