using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ManagerRepository : Repository<Manager>, IManagerRepository
    {
        public ManagerRepository(FBMContext FBMContext) : base(FBMContext) { }
        public async Task<Manager> GetManagerByLastName(string lastname, CancellationToken cancellationToken)
        {
            var manager = await _FBMContext.Managers
                .FirstOrDefaultAsync(m => m.LastName == lastname, cancellationToken);

            if (manager == null) return default;

            var managerResponse = manager.Adapt<Manager>();

            return managerResponse;
        }
    }
}
