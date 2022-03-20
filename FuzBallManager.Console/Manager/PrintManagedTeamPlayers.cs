using ApiClient;
using Application.Responses;

namespace UIConsole.Manager;

public class PrintManagedTeamPlayers
{
    public static void PrintTeamPlayers(ManagerResponse manager, List<PlayerResponse> managedTeamPlayers)
    {
        var PlayingNotPlayingInjured = "P";

        //var ManagedTeam = await TeamClient.GetTeamById(manager.ManagingTeamID);
        //List<PlayerResponse> TeamPlayers = await PlayerClient.GetPlayersByTeamName(ManagedTeam.TeamName);
        foreach (var player in managedTeamPlayers)
        {
            if (player.Playing == true)
            {
                PlayingNotPlayingInjured = "P";

            }
            else if(player.Playing == false)
            {
                PlayingNotPlayingInjured = " ";
            }
            else
            {
                PlayingNotPlayingInjured = "I";
            }
            string FirstLetter = player.PlayerFirstName[..1];
            string PosLetter = player.PlayerPosition[..1];
            Console.WriteLine("{0} {1}.{2}\t{3} \t{4}\t{5}", PosLetter, FirstLetter, player.PlayerLastName, player.PlayerShirtNo, player.PlayerStats, PlayingNotPlayingInjured );
        }
    }
}
