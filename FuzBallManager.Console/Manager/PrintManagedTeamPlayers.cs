using Application.Responses;

namespace UIConsole.Manager;

public static class PrintManagedTeamPlayers
{
    static string PlayingNotPlayingInjured { get; set; }

    public static void PrintTeamPlayers(ManagerResponse manager, List<PlayerResponse> managedTeamPlayers)
    {
        //TODO Fix Sorting function on PlayerPosition order (G, D, M, F)
        foreach (var player in managedTeamPlayers)
        {
            if (player.Playing == true) PlayingNotPlayingInjured = "P";
            else if (player.Playing == false || player.Playing == null) PlayingNotPlayingInjured = " ";
            else if (player.Injured == true) PlayingNotPlayingInjured = "i";

            string FirstLetter = player.PlayerFirstName[..1];
            string PosLetter = player.PlayerPosition[..1];
            Console.Write($"{PosLetter} {FirstLetter}.{player.PlayerLastName}");
            Console.CursorLeft = 16;
            Console.WriteLine($"{player.PlayerShirtNo} \t{player.PlayerStats}\t{player.PlayerStats}\t{player.Value}\t{PlayingNotPlayingInjured}");
        }
    }
}
