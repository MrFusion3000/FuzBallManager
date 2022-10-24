using Application.Responses;

namespace UIConsole.Menu;

//TODOHIGH 4 Print score etc

public class Menu_2_PrintScore
{
    public static void PrintScore()
    {

        Console.Clear();
        ConsoleKeyInfo menuChoice;

        Console.ForegroundColor = ConsoleColor.Magenta;
        //Console.WriteLine(" p : picked to play, i : injured");
        //Console.SetCursorPosition(31, 0);
        Console.ForegroundColor = ConsoleColor.White;
        //Console.WriteLine(" NAME\t\tNO.\tSKILL\tENERGY\tVALUE(£)");

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
