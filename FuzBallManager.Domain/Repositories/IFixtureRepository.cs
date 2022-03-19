using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories
{
    public interface IFixtureRepository : IRepository<Fixture>
    {
        Task<Guid> Update(Fixture command, CancellationToken cancellationToken);

        Task<Guid> Delete(Fixture command, CancellationToken cancellationToken);

        Task<Fixture> GetNextFixture(Fixture request, CancellationToken cancellationToken);
    }
}
