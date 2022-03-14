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

        public Task<Player> GetPlayerByLastName(string lastName, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public async Task<Player> GetPlayerByFirstNameLastName(string firstName, string lastname, CancellationToken cancellationToken)
        //{
        //    //TODO add FirstName filter
        //    return await _FBMContext.Players
        //        .Where(m => m.PlayerLastName == lastname)
        //        .FirstOrDefaultAsync(cancellationToken);
        //}

        public async Task<List<Player>> GetPlayersByTeamName(string teamname, CancellationToken cancellationToken)
        {
            var GetPlayer =
            await _FBMContext.Players
                .Where(t => t.TeamName == teamname)
                .ToListAsync(cancellationToken);

            if(GetPlayer == null)return default;

            return GetPlayer;
        }
    }
}
