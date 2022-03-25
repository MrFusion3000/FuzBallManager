using Application.Responses;
using UIConsole.Manager;
using UIConsole.Menu;

namespace UIConsole;

//TODO 1 Sell/List your players (Only List players for now)

public class Menu_1_SellListPlayers
{
    public static void SellListPlayers(ManagerResponse manager, List<PlayerResponse> managedTeamPlayers)
    {
        Console.Clear();
        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("\n p : picked to play, i : injured");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" NAME\t\tNO.\tSKILL\tENERGY\tVALUE(£)");

        PrintManagedTeamPlayers.PrintTeamPlayers(manager, managedTeamPlayers);

        while (true)
        {
            menuChoice = Console.ReadKey(true);

            Navigation.WaitKey(menuChoice, manager, managedTeamPlayers);
        }
    }
}
