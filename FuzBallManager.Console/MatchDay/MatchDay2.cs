using ApiClient;
using Application.Responses;
using UIConsole.Manager;

namespace UIConsole.MatchDay;

public class MatchDay2
{

    public static async Task ShowTeamStats(TeamResponse homeTeam, TeamResponse awayTeam)
    {
        PlayerClient playerClient = new();

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
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($"\n\n\t\t{homeTeam.TeamName}\t{awayTeam.TeamName}");

        Console.WriteLine($"\nStats\t\t{HomeTeamStats}\t\t{AwayTeamStats}");

        //Console.Clear();

        //Console.ForegroundColor = ConsoleColor.Magenta;
        ////Console.SetCursorPosition(31, 0);
        //Console.ForegroundColor = ConsoleColor.Yellow;
        //Console.WriteLine(" NAME\t\tNO.\tSKILL\tENERGY\tVALUE(£)");

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

        ConsoleKeyInfo menuChoice2;

        while (true)
        {
            menuChoice2 = Console.ReadKey(true); //TODO Change to readline, restric to 2 char input?

            //TODO Function for assigning player no to menu switch

            //Navigation.WaitKey(menuChoice, manager, managedTeamPlayers);
            switch (menuChoice2.Key)
            {
                //case ConsoleKey.Escape:
                //    ShowMenu.ShowTopMenu(manager, managedTeamPlayers);
                //    break;
                case ConsoleKey.T:
                    await MatchDay3.PreGameTeamStats();
                    break;
                case ConsoleKey.Spacebar:
                    Console.WriteLine("Play match");
                    // MatchDay4.();
                    break;
                default:
                    break;
            }
        }

        //var menuchoice = Console.ReadKey();

        //TODO Switch statement t=PreGameTeamStats, Space=GameCalc 
        //if (menuchoice.Key == ConsoleKey.T)
        //{
        //    await MatchDay3.PreGameTeamStats();
        //}
    }
}
