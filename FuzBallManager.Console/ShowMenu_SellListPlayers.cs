using UIConsole;

namespace UIConsole;

public class ShowMenu_SellListPlayers
{
    public static void SellListPlayers()
    {
        Console.Clear();
        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" p : picked to play, i : injured");
        //Console.SetCursorPosition(31, 0);
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine(" NAME\t\tNO.\tSKILL\tENERGY\tVALUE(£)");

        menuChoice = Console.ReadKey(true);

        WaitKey(menuChoice);

    }

    private static void WaitKey(ConsoleKeyInfo menuChoice)
    {

            switch (menuChoice.Key)
            {
                case ConsoleKey.Escape:
                ShowMenu.ShowTopMenu();
                    break;


            }


    }
}
