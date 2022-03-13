using Application.Responses;
using UIConsole.Menu;

namespace UIConsole;

public class Menu_1_SellListPlayers
{
    public static void SellListPlayers(ManagerResponse manager)
    {
        Console.Clear();
        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" p : picked to play, i : injured");
        //Console.SetCursorPosition(31, 0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" NAME\t\tNO.\tSKILL\tENERGY\tVALUE(£)");

        menuChoice = Console.ReadKey(true);

        Navigation.WaitKey(menuChoice, manager);
    }
}
