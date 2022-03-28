using ApiClient;
using Application.Responses;
using UIConsole.Manager;

namespace UIConsole.MatchDay;

public class MatchDay2
{
    public static async void ShowTeamStats(TeamResponse homeTeam, TeamResponse awayTeam)
    {
        var HomeTeamPlayers = await PlayerClient.GetPlayersByTeamName(homeTeam.TeamName);
        var AwayTeamPlayers = await PlayerClient.GetPlayersByTeamName(awayTeam.TeamName);
        await RndAwayTeam.RandomizeTeam(AwayTeamPlayers);
        var AwayTeamAllPlayers = await PlayerClient.GetPlayersByTeamName(awayTeam.TeamName);

        AwayTeamPlayers = AwayTeamAllPlayers
       .FindAll(p => p.TeamName == awayTeam.TeamName)
       .Where(p => p.Playing == true)
       .ToList();

        int HomeTeamStats = 0;
        int AwayTeamStats = 0;


        foreach (var player in HomeTeamPlayers)
        {
            HomeTeamStats += player.PlayerStats.Value;
        }

        foreach (var player in AwayTeamPlayers)
        {
            AwayTeamStats += player.PlayerStats.Value;
        }

        HomeTeamStats /= 11;
        AwayTeamStats /= 11;

        Console.Clear();
        Console.WriteLine($"\n\n\t\t{homeTeam.TeamName}\t{awayTeam.TeamName}");
        Console.WriteLine($"\nStats\t\t{HomeTeamStats}\t\t{AwayTeamStats}");

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Magenta;
        //Console.SetCursorPosition(31, 0);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" NAME\t\tNO.\tSKILL\tENERGY\tVALUE(£)");

        //Console.ForegroundColor = ConsoleColor.Magenta;
        //int PlayersPicked = 0;
        //Console.WriteLine("PLAYERS PICKED: {0}", PlayersPicked);

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(7, 14);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Press ");
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("SPACE BAR");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" to continue");
        Console.ForegroundColor = ConsoleColor.White;

        var menuchoice = Console.ReadKey();

        if (menuchoice.Key == ConsoleKey.Enter)
        {
            MatchDay3.PreGameTeamStats();
        }
    }
}
