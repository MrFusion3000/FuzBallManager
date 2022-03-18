using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories
{
    public interface IFixtureRepository : IRepository<Fixture>
    {
        //Task<Fixture> GetNextFixture(DateTime dateTime, CancellationToken cancellationToken);
        Task<Guid> Update(Fixture command, CancellationToken cancellationToken);

    }
}
