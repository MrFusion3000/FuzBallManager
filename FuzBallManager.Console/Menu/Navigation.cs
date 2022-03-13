using Application.Responses;

namespace UIConsole.Menu;

public class Navigation
{
    public static void WaitKey(ConsoleKeyInfo menuChoice, ManagerResponse manager)
    {
        switch (menuChoice.Key)
        {
            case ConsoleKey.Escape:
                ShowMenu.ShowTopMenu(manager);
                break;
            case ConsoleKey.Spacebar:
                PlayGame.PlayGame.Matchday(manager);
                break;
            case ConsoleKey.D0:
            case ConsoleKey.D1:
            case ConsoleKey.D2:
            case ConsoleKey.D3:
            case ConsoleKey.D4:
            case ConsoleKey.D5:
            case ConsoleKey.D6:
            case ConsoleKey.D7:
            case ConsoleKey.D8:
            case ConsoleKey.D9:
                PrintOneToNine(menuChoice.KeyChar);
                break;
            case ConsoleKey.Enter:
                SubstitutePlayer();
                break;
            default:
                break;
        }
    }

    public static string playerNo { get; set; }
    private static void PrintOneToNine(Char keyChar)
    {
        playerNo += keyChar;
        Console.Write(keyChar.ToString());
    }

    private static void SubstitutePlayer()
    {
            Console.WriteLine(playerNo);
        playerNo = "";
    }
}
