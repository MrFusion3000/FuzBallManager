using ApiClient;
using Domain.Entities;
using Mapster;

namespace UIConsole
{
    public class AddTeamIdToPlayer
    {
        public static async Task AddTeamIdToPlayers()
        {
            //Fetch team from db table Team
            var allTeams = await TeamClient.GetAllTeams();
            //Fetch players from db table Player matching fetched team name
            foreach (var team in allTeams)
            {
                var fetchedTeam = await PlayerClient.GetPlayersByTeamName(team.TeamName);
                if (fetchedTeam != null)
                {
                    //Update player with Team ID from db table Team
                    foreach (var player in fetchedTeam)
                    {
                        player.TeamID = team.TeamID;
                        Console.WriteLine($"Player: {player.PlayerFirstName} {player.PlayerLastName} updated with Team Name: {team.TeamName}, TeamId: {team.TeamID}");
                        await PlayerClient.Update(player);

                        Console.ReadKey();
                    }
                }

            }
        }
    }
}
