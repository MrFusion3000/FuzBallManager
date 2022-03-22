using ApiClient;
using Application.Responses;

namespace UIConsole.Manager;

public static class PrintManagedTeamPlayers
{
    static string PlayingNotPlayingInjured { get; set; }

    public static void PrintTeamPlayers(ManagerResponse manager, List<PlayerResponse> managedTeamPlayers)
    {
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
            else if(player.Injured == true)
            {
                PlayingNotPlayingInjured = "i";
            }
            string FirstLetter = player.PlayerFirstName[..1];
            string PosLetter = player.PlayerPosition[..1];
            Console.WriteLine("{0} {1}.{2}\t{3} \t{4}\t{5}", PosLetter, FirstLetter, player.PlayerLastName, player.PlayerShirtNo, player.PlayerStats, PlayingNotPlayingInjured );
        }
    }
}
