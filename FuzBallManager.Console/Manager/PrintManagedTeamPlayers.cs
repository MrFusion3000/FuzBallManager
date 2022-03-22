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
            Console.WriteLine($"{PosLetter} {FirstLetter}.{player.PlayerLastName}"); 
            Console.CursorLeft = 13;
            Console.WriteLine($"{player.PlayerShirtNo} \t{player.PlayerStats}\t{PlayingNotPlayingInjured}" );
        }
    }
}
