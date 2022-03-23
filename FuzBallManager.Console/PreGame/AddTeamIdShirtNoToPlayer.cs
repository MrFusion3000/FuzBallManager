using ApiClient;
using Application.Responses;
using Mapster;

namespace UIConsole.PreGame;

public class AddTeamIdShirtNoToPlayer
{
    public static async Task AddTeamIdToPlayers()
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

                    Console.WriteLine($"Player: {player.PlayerFirstName} {player.PlayerLastName} updated with Team Name: {team.TeamName} & ShirtNo: {player.PlayerShirtNo}");
                    var playerUpdate = player.Adapt<PlayerResponse>();

                    //Console.WriteLine($"{player.PlayerID}, {playerUpdate.PlayerLastName}");

                    await PlayerClient.Update(player.PlayerID, playerUpdate);
                    //}
                    //else
                    //{
                    //    Console.WriteLine($"Player: {player.PlayerLastName} already updated");
                    //}
                }
                Console.WriteLine($"All {team.TeamName} players TeamId's updated.");
                //Console.ReadKey();
            }

        }
    }
}
