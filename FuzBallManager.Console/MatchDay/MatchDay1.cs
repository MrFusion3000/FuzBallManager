using ApiClient;

namespace UIConsole.MatchDay;

public class MatchDay1
{
    //TODO BUG Can't run Match if not first visited Sell/List players ?!!?
    public static async void ShowPreMatch()
    {
        var nextFixture = await FixtureClient.GetNextFixture(false);
        var HomeTeam = await TeamClient.GetTeamById(nextFixture.HomeTeamId);
        var AwayTeam = await TeamClient.GetTeamById((Guid)nextFixture.AwayTeamId);
        Console.Clear();
        Console.WriteLine("League Match : Division 1");
        Console.WriteLine($"\n\n\t\t{HomeTeam.TeamName}\t{AwayTeam.TeamName}");
        Console.WriteLine("League Pos.\t 0\t\t\t0");

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(7, 21);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Press ");
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("SPACE BAR");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" to continue");
        Console.ForegroundColor = ConsoleColor.White;

        ConsoleKeyInfo menuChoice1;

        while (true)
        {
            menuChoice1 = Console.ReadKey(true); //TODO Change to readline, restric to 2 char input?

            switch (menuChoice1.Key)
            {
                //case ConsoleKey.Escape:
                //    ShowMenu.ShowTopMenu(manager, managedTeamPlayers);
                //    break;
                case ConsoleKey.Spacebar:
                    MatchDay2.ShowTeamStats(HomeTeam, AwayTeam);
                    break;
                default:
                    Console.WriteLine("Nuthin.");
                    break;
            }
        }
    }
}
