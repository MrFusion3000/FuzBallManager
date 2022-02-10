using Domain.Entities;
using Infrastructure.Data;
using Infrastructure.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Domain.Repositories;
using Application.Queries;

namespace Infrastructure.Repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        public PlayerRepository(FBMContext FBMContext) : base(FBMContext) { }
        public async Task<IEnumerable<Player>> GetPlayerByLastName(string lastname)
        {
            return await _FBMContext.Players
                .Where(m => m.PlayerLastName == lastname)
                .ToListAsync();
        }
        //public async Task<List<Player>> GetAllPlayersAsync(GetAllPlayersQuery query, CancellationToken cancellationToken)
        //{
        //    return await _FBMContext.Players.ToListAsync();
        //}
    }
}
