using Application.Responses;

namespace UIConsole.Menu;

public class Menu_5_DisplayLeagueTable
{
    public static void DisplayLeagueTable(ManagerResponse manager, List<PlayerResponse> managedTeamPlayers)
    {
        Console.Clear();
        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" POP\t\tTEAM\tF\tA\tPTS");

        menuChoice = Console.ReadKey(true);

        Navigation.WaitKey(menuChoice, manager, managedTeamPlayers);
    }
}
