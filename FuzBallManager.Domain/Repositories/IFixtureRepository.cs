using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories
{
    public interface IFixtureRepository : IRepository<Fixture>

    {
        Task<List<Fixture>> GetNextFixture(DateTime dateTime);
    }
}
