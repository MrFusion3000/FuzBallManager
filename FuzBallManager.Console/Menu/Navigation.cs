﻿using Application.Responses;

namespace UIConsole.Menu;

public class Navigation
{
    public static async void WaitKey(ConsoleKeyInfo menuChoice, ManagerResponse manager, List<PlayerResponse> managedTeamPlayers)
    {
        switch (menuChoice.Key)
        {
            case ConsoleKey.Escape:
                ShowMenu.ShowTopMenu(manager, managedTeamPlayers);
                break;
            case ConsoleKey.Spacebar:
                PlayGame.PlayGame.Matchday(manager, managedTeamPlayers);
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
                await SubstitutePlayer(managedTeamPlayers, PlayerNoConverted );
                break;
            default:
                break;
        }
    }

    public static string PlayerNo { get; set; }
    public static int PlayerNoConverted  { get; set; }
    private static int PrintOneToNine(Char keyChar)
    {
        PlayerNo += keyChar.ToString();
        PlayerNoConverted = int.Parse(PlayerNo);
        Console.Write(keyChar.ToString());

        return PlayerNoConverted;
    }

    private static async Task SubstitutePlayer(List<PlayerResponse> players, int playerNo)
    {
        //TODO Function for assigning Player to Team
        //TODO Check if team roster is filled (if = 11 players then Print message)
            Console.WriteLine(PlayerNo);

        await PlayerSubstitution.PlayerSubstitute(players, playerNo);
        PlayerNoConverted = 0;

    }
}
