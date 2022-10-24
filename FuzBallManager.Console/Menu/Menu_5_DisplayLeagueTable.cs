using Application.Responses;

namespace UIConsole.Menu;

public class Menu_5_DisplayLeagueTable
{
    public static void DisplayLeagueTable()
    {
        Console.Clear();
        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" POP\t\tTEAM\tF\tA\tPTS");

        menuChoice = Console.ReadKey(true);

        switch (menuChoice.Key)
        {
            case ConsoleKey.Escape:
            case ConsoleKey.Spacebar:
                //await ShowMenu.ShowTopMenu();
                break;
        }
    }
}
