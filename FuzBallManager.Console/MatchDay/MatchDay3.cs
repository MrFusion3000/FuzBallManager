using ApiClient;
using Application.Responses;
using UIConsole.Manager;

namespace UIConsole.MatchDay;

public class MatchDay3
{
    public static int screenlines { get; private set; }

    public static async Task PreGameTeamStats()
    {
        var fixture = await FixtureClient.GetNextFixture(false);

        Console.Clear();

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($" {fixture.HomeTeamId}");
        //Console.SetCursorPosition(31, 0);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" NAME\t\tNO.\tSKILL\tENERGY\tVALUE(£)");

        //TODO Get player list
        await PrintManagedTeamPlayers.PrintTeamPlayers();

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nType player no. to add to team");

        Console.ForegroundColor = ConsoleColor.White;
        Console.SetCursorPosition(7, screenlines + 2);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Press ");
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write("SPACE BAR");
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" to continue");
        Console.ForegroundColor = ConsoleColor.White;

        ConsoleKeyInfo menuChoice3;

        while (true)
        {
            menuChoice3 = Console.ReadKey(true); //TODO Change to readline, restric to 2 char input?

            //TODO Function for assigning player no to menu switch

            //Navigation.WaitKey(menuChoice, manager, managedTeamPlayers);
            switch (menuChoice3.Key)
            {
                //case ConsoleKey.Escape:
                //    ShowMenu.ShowTopMenu(manager, managedTeamPlayers);
                //    break;
                case ConsoleKey.Spacebar:
                    Console.WriteLine("Play match");
                   // MatchDay4.();
                    break;
                default:
                    break;
            }
        }
    }
}
