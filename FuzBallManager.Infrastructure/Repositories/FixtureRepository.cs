using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;

namespace Infrastructure.Repositories
{
    public class FixtureRepository : Repository<Fixture>, IFixtureRepository
    {
        public FixtureRepository(FBMContext FBMContext) : base(FBMContext) { }
        //public async Task<Manager> GetManagerByLastName(string lastname, CancellationToken cancellationToken)
        //{
        //    var manager = await _FBMContext.Managers
        //        .FirstOrDefaultAsync(m => m.LastName == lastname, cancellationToken);

        //    if (manager == null) return default;

        //    var managerResponse = manager.Adapt<Manager>();

        //    return managerResponse;
        //}
    }
}
