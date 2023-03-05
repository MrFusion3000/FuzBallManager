using ApiClient;

namespace UIConsole.MatchDay;

public class MatchDay1
{
    //TODO BUG Can't run Match if not first visited Sell/List players ?!!?
    public static async Task ShowPreMatch()
    {
        while (true)
        {
            var nextFixture = await FixtureClient.GetNextFixture(false);
            TeamClient teamClient = new();
            var HomeTeam = await TeamClient.GetTeamById(nextFixture.HomeTeamId);
            var AwayTeam = await TeamClient.GetTeamById((Guid)nextFixture.AwayTeamId);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("\nLeague Match : ");
            Console.BackgroundColor = ConsoleColor.Yellow;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.Write("Division 1");
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n************************************************************");
            Console.WriteLine($"\n\t\t{HomeTeam.TeamName}\t{AwayTeam.TeamName}");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("League Pos.\t 0\t\t\t0");
            Console.WriteLine("\n************************************************************");

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


            menuChoice1 = Console.ReadKey(true);

            switch (menuChoice1.Key)
            {
                case ConsoleKey.Spacebar:
                    await MatchDay2.CalcTeamStats(HomeTeam, AwayTeam);
                    //await MatchDay3.PreGameTeamStats();
                    break;

                default:
                    break;
            }
        }
    }
}
