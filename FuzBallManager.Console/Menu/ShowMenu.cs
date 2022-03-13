using Application.Responses;
using UIConsole.Menu;

namespace UIConsole;

public class ShowMenu
{
    public static void ShowTopMenu(ManagerResponse manager)
    {
        Console.Clear();

        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" TO -");
        Console.SetCursorPosition(31, 0);
        Console.WriteLine("TYPE -\n");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" Sell/list your players\t\t- a");
        Console.WriteLine(" Print score etc\t\t- s");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(" Obtain a loan\t\t\t- o");
        Console.WriteLine(" Pay off a loan\t\t\t- p");
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" Display league table\t\t- d");
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine(" Change your\n Skill level\t\t\t- l");
        Console.WriteLine(" Change team or\n player names\t\t\t- c");
        Console.WriteLine(" Save game\t\t\t- k");
        Console.WriteLine(" Restore saved game\t\t- r");
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

        menuChoice = Console.ReadKey(true);

        WaitKey(menuChoice, manager);

    }

    private static void WaitKey(ConsoleKeyInfo menuChoice, ManagerResponse manager)
    {
        switch (menuChoice.Key)
        {
            case ConsoleKey.Escape:
                Console.WriteLine("End");
                break;

            case ConsoleKey.A:
                Menu_1_SellListPlayers.SellListPlayers(manager);
                break;
            case ConsoleKey.S:
                Menu_2_PrintScore.PrintScore(manager);
                break;
            case ConsoleKey.D:
                Menu_5_DisplayLeagueTable.DisplayLeagueTable(manager);
                break;
            case ConsoleKey.Spacebar:
                PlayGame.PlayGame.Matchday(manager);
                break;

            default:
                break;
        }
    }
}
