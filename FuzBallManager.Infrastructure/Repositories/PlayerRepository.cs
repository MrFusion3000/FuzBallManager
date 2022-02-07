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
        public PlayerRepository(PlayerContext playerContext) : base(playerContext) { }
        public async Task<IEnumerable<Player>> GetPlayerByLastName(string lastname)
        {
            return await _playerContext.Players
                .Where(m => m.PlayerLastName == lastname)
                .ToListAsync();
        }
        //public async Task<List<Player>> GetAllPlayersAsync(GetAllPlayersQuery query, CancellationToken cancellationToken)
        //{
        //    return await _playerContext.Players.ToListAsync();
        //}
    }
}
