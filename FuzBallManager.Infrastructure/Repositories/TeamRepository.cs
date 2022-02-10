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
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(FBMContext FBMContext) : base(FBMContext) { }
        public async Task<IEnumerable<Team>> GetTeamByTeamName(string teamname)
        {
            return await _FBMContext.Teams
                .Where(m => m.TeamName == teamname)
                .ToListAsync();
          } 
    }
}
