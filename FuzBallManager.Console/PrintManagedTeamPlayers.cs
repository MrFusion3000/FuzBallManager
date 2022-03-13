using ApiClient;
using Application.Responses;

namespace UIConsole;

public class PrintManagedTeamPlayers
{
    public static async void PrintTeamPlayers(ManagerResponse manager)
    {
        var ManagedTeam = await TeamClient.GetTeamById(manager.ManagingTeamID);
        List<PlayerResponse> TeamPlayers = await PlayerClient.GetAllPlayersByTeamName(ManagedTeam.TeamName);
        foreach (var player in TeamPlayers)
        {
            string FirstLetter = player.PlayerFirstName.Substring(0, 1);
            string PosLetter = player.PlayerPosition.Substring(0, 1);
            Console.WriteLine("{0} {1}.{2}\t{3}", PosLetter, FirstLetter, player.PlayerLastName, player.PlayerId, player.PlayerStats );
        }
    }
}
