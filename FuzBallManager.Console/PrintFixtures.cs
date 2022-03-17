using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole;

public class PrintFixtures
{
    public static void PrintAllFixtures(TeamResponse team1, TeamResponse team2, FixtureResponse newFixtureResponse)
    {
        //Only for development output
        string PrintFixture = team1.TeamName + " - " + team2.TeamName;
        Console.SetCursorPosition((Console.WindowWidth / 2 - PrintFixture.Length) / 2, Console.CursorTop);
        Console.WriteLine($"{PrintFixture} \t\t{newFixtureResponse.FixtureDate.ToShortDateString()}");
    }
}
