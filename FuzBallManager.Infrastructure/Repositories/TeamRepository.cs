using Application;
using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TeamRepository : Repository<Team>, ITeamRepository
    {
        public TeamRepository(FBMContext FBMContext) : base(FBMContext) { }
        public async Task<Team> GetTeamByTeamName(string teamname, CancellationToken cancellationToken)
        {
            return await _FBMContext.Teams
                .Where(m => m.TeamName == teamname)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<Team> GetTeamById(Guid teamid, CancellationToken cancellationToken)
        {
            return await _FBMContext.Teams
                .Where(m => m.TeamID == teamid)
                .FirstOrDefaultAsync(cancellationToken);
        }
    }
}
