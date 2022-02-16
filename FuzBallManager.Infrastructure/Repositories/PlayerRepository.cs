using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(FBMContext FBMContext) : base(FBMContext) { }
        public async Task<Player> GetPlayerByFirstNameLastName(string firstName, string lastname, CancellationToken cancellationToken)
        {
            return await _FBMContext.Players
                .Where(m => m.PlayerLastName == lastname)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Player>> GetPlayersByTeamNameAsync(string teamName, CancellationToken cancellationToken)
        {
            return await _FBMContext.Players
                .Where(t => t.TeamName == teamName)
                .ToListAsync();
        }
    }
}
