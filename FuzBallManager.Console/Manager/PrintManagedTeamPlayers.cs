using ApiClient;
using Application.Responses;
using System.Runtime.InteropServices;

namespace UIConsole.Manager;

public static class PrintManagedTeamPlayers
{
    static string PlayingNotPlayingInjured { get; set; }

    public static async Task PrintTeamPlayers()
    {
        PlayerClient playerClient = new();

        List<PlayerResponse> managedTeamPlayers = await PlayerClient.GetPlayersByManagedTeam(true);
        List<PlayerResponse> GoalKeepers = new();
        List<PlayerResponse> Defence = new();
        List<PlayerResponse> Midfield = new();
        List<PlayerResponse> Forwards = new();
        List<PlayerResponse> SortedTeam = new();

        int Picked = 0;

        //Fix Sorting function on PlayerPosition order (G, D, M, F)
        foreach (var player in managedTeamPlayers)
        {
            switch (player.PlayerPosition)
            {
                case "GK":
                    GoalKeepers.Add(player);
                    break;
                case "DF":
                    Defence.Add(player);
                    break;
                case "MF":
                    Midfield.Add(player);
                    break;
                case "FW":
                    Forwards.Add(player);
                    break;
                default:
                    break;
            }
        }

        var sortGK = GoalKeepers.OrderBy(g => g.PlayerShirtNo);
        var sortDF = Defence.OrderBy(g => g.PlayerShirtNo);
        var sortMF = Midfield.OrderBy(g => g.PlayerShirtNo);
        var sortFW = Forwards.OrderBy(g => g.PlayerShirtNo);

        SortedTeam.AddRange(sortGK);
        SortedTeam.AddRange(sortDF);
        SortedTeam.AddRange(sortMF);
        SortedTeam.AddRange(sortFW);

        foreach (var player in SortedTeam)
        {
            if (player.Playing == true) PlayingNotPlayingInjured = "P";
            else if (player.Playing == false || player.Playing == null) PlayingNotPlayingInjured = " ";
            else if (player.Injured == true) PlayingNotPlayingInjured = "i";

            string FirstLetter = player.PlayerFirstName[..1];
            string PosLetter = player.PlayerPosition[..1];

            switch (PosLetter)
            {
                case "G":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "D":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
                case "M":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "F":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
            }

            Console.Write($"{PosLetter} {FirstLetter}.{player.PlayerLastName}");
            Console.CursorLeft = 16;
            Console.WriteLine($"{player.PlayerShirtNo} \t{player.PlayerStats}\t{player.PlayerStats}\t{player.Value}\t{PlayingNotPlayingInjured}");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Picked = managedTeamPlayers.Count(t => t.Playing == true);
        }
        Console.Write($"PLAYERS PICKED: {Picked}\n");
    }
}
