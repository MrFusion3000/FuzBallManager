using Application.Responses;
using UIConsole.Manager;

namespace UIConsole.MatchDay;

public class MatchDay3
{
    public static void PreGameTeamStats(ManagerResponse manager, List<PlayerResponse> managedTeamPlayers, FixtureResponse fixture)
    {
        Console.Clear();
        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine($" {fixture.HomeTeamId}");
        //Console.SetCursorPosition(31, 0);
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(" NAME\t\tNO.\tSKILL\tENERGY\tVALUE(£)");

        //TODO Get player list
        PrintManagedTeamPlayers.PrintTeamPlayers(manager, managedTeamPlayers);

        //Console.ForegroundColor = ConsoleColor.Magenta;
        //int PlayersPicked = 0;
        //Console.WriteLine("PLAYERS PICKED: {0}", PlayersPicked);

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


        while (true)
        {
            menuChoice = Console.ReadKey(true); //TODO Change to readline, restric to 2 char input?

            //TODO Function for assigning player no to menu switch

            //Navigation.WaitKey(menuChoice, manager, managedTeamPlayers);
            switch (menuChoice.Key)
            {
                //case ConsoleKey.Escape:
                //    ShowMenu.ShowTopMenu(manager, managedTeamPlayers);
                //    break;
                case ConsoleKey.Spacebar:
                    MatchDay2.PickTeam(manager, managedTeamPlayers);
                    break;
            }
        }
    }
}
