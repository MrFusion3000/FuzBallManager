using Application.Responses;
using UIConsole.Menu;

namespace UIConsole;

public class ShowMenu
{
    public static void ShowTopMenu(ManagerResponse manager, List<PlayerResponse> managedTeamPlayers)
    {
        Console.Clear();

        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" TO -");
        Console.SetCursorPosition(31, 0);
        Console.WriteLine("TYPE -\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" Sell/list your players\t\t- a\n");
        Console.WriteLine(" Print score etc\t\t- s");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(" Obtain a loan\t\t\t- o\n");
        Console.WriteLine(" Pay off a loan\t\t\t- p\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" Display league table\t\t- d\n");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(" Change your\n Skill level\t\t\t- l\n");
        Console.WriteLine(" Change team or\n player names\t\t\t- c\n");
        Console.WriteLine(" Save game\t\t\t- k\n");
        Console.WriteLine(" Restore saved game\t\t- r\n");
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

        menuChoice = Console.ReadKey(true);

        WaitKey(menuChoice, manager, managedTeamPlayers);

    }

    private static void WaitKey(ConsoleKeyInfo menuChoice, ManagerResponse manager, List<PlayerResponse> managedTeamPlayers)
    {
        switch (menuChoice.Key)
        {
            case ConsoleKey.Escape:
                Console.WriteLine("End");
                break;

            case ConsoleKey.A:
                Menu_1_SellListPlayers.SellListPlayers(manager, managedTeamPlayers);
                break;
            case ConsoleKey.S:
                Menu_2_PrintScore.PrintScore(manager, managedTeamPlayers);
                break;
            case ConsoleKey.D:
                Menu_5_DisplayLeagueTable.DisplayLeagueTable(manager, managedTeamPlayers);
                break;
            case ConsoleKey.Spacebar:
                PlayGame.PlayGame.Matchday(manager, managedTeamPlayers);
                break;

            default:
                break;
        }
    }
}
