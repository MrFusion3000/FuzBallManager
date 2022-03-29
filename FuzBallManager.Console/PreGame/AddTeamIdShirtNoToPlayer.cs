using ApiClient;
using Application.Responses;
using Mapster;

namespace UIConsole.PreGame;

public class AddTeamIdShirtNoToPlayer
{
    public static async Task AddTeamIdShirtNoToPlayers()
    {
        List<int> AlreadyDrawnNumbers = new();

        var RndShirtNo = new Random();

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
                    //if (player.TeamID == null)
                    //{
                    player.TeamID = team.TeamID;
                    player.PlayerShirtNo = null;

                    // Rnd distinctive ShirtNo
                    while (player.PlayerShirtNo == null)
                    {
                        var plrShirtNo = RndShirtNo.Next(1, 99);
                        AlreadyDrawnNumbers.Add(plrShirtNo);
                        foreach (var item in AlreadyDrawnNumbers)
                        {
                            if (plrShirtNo != item) player.PlayerShirtNo = plrShirtNo;
                        }
                    }

                    var playerUpdate = player.Adapt<PlayerResponse>();

                    await PlayerClient.Update(player.PlayerID, playerUpdate);
                }
                Console.WriteLine($"All {team.TeamName} players TeamId's updated.");                

                await RndAwayTeam.RandomizeTeam(fetchedTeam);

            }
            Console.WriteLine($"All {team.TeamName} Players updated...");

        }
    }
}
