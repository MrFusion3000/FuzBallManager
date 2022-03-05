using Domain.Entities;
using Domain.Repositories.Base;

namespace Domain.Repositories
{
    public interface IManagerRepository : IRepository<Manager>
    {
        Task<Manager> GetManagerByName(string name, CancellationToken cancellationToken);
    }
}
