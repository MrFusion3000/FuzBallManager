using ApiClient;
using Application.Responses;

namespace UIConsole;

public class PrintManagedTeamPlayers
{
    public static async void PrintTeamPlayers(ManagerResponse manager)
    {
        var ManagedTeam = await TeamClient.GetTeamById(manager.ManagingTeamID);
        List<PlayerResponse> TeamPlayers = await PlayerClient.GetPlayersByTeamName(ManagedTeam.TeamName);
        foreach (var player in TeamPlayers)
        {
            string FirstLetter = player.PlayerFirstName[..1];
            string PosLetter = player.PlayerPosition[..1];
            Console.WriteLine("{0} {1}.{2}\t{3}, {4}", PosLetter, FirstLetter, player.PlayerLastName, player.PlayerID, player.PlayerStats );
        }
    }
}
