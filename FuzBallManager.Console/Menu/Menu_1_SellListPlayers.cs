using Application.Responses;
using UIConsole.Manager;

namespace UIConsole;

//TODO 1 Sell/List your players (Only List players for now)

public class Menu_1_SellListPlayers
{
    public static async Task SellListPlayers()
    {
        Console.Clear();
        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n p : picked to play, i : injured");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" NAME\t\tNO.\tSKILL\tENERGY\tVALUE(£)");

        await PrintManagedTeamPlayers.PrintTeamPlayers();

        while (true)
        {
            menuChoice = Console.ReadKey(true);

            switch (menuChoice.Key)
            {
                case ConsoleKey.Escape:
                case ConsoleKey.Spacebar:
                    //ShowMenu.ShowTopMenu();
                    break;
            }
        }
    }
}
