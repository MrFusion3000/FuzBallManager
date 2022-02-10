using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ManagerRepository : Repository<Manager>, IManagerRepository
    {
        public ManagerRepository(FBMContext FBMContext) : base(FBMContext) { }
        public async Task<IEnumerable<Manager>> GetManagerByLastName(string lastname)
        {
            return await _FBMContext.Managers
                .Where(m => m.LastName == lastname)
                .ToListAsync();
        }
    }
}
