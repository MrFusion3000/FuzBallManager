namespace UIConsole;

public class ShowMenu
{
    public static void ShowTopMenu()
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
        Console.WriteLine(" Obtain a loan\t\t\t- o");
        Console.WriteLine(" Pay off a loan\t\t\t- p");
        Console.WriteLine(" Display league table\t\t- d");
        Console.WriteLine(" Change your\n Skill level\t\t\t- l");
        Console.WriteLine(" Change team or\n player names\t\t\t- c");
        Console.WriteLine(" Save game\t\t\t- k");
        Console.WriteLine(" Restore saved game\t\t- r");
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

        WaitKey(menuChoice);

    }

    private static void WaitKey(ConsoleKeyInfo menuChoice)
    {
            switch (menuChoice.Key)
            {
                case ConsoleKey.Escape:
                    Console.WriteLine("End");
                    break;

                case ConsoleKey.A:
                ShowMenu_SellListPlayers.SellListPlayers();
                break;
            }
    }
}
