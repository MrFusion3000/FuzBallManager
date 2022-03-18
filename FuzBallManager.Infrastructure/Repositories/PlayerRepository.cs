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

            if (GetPlayer == null) return default;

            return GetPlayer;
        }

        public async Task<Guid> Update(Player command, CancellationToken cancellationToken)
        {
            var player = _FBMContext.Players.Where(a => a.PlayerID == command.PlayerID).FirstOrDefault();

            if (player == null)
            {
                return default;
            }
            else
            {
                player.PlayerFirstName = command.PlayerFirstName;
                player.PlayerLastName = command.PlayerLastName;
                player.PlayerStats = command.PlayerStats;
                player.PlayerPosition = command.PlayerPosition;
                player.DateOfBirth = command.DateOfBirth;
                player.TeamID = command.TeamID;
                player.TeamName = command.TeamName;
                player.Injured = command.Injured;
                player.InManagedTeam = command.InManagedTeam;

                await _FBMContext.SaveChangesAsync(cancellationToken);
                return player.PlayerID;
            }
        }
    }
}
