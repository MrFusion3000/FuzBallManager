using ApiClient;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole;

public class PrintFixtures
{
    public static async void PrintAllFixtures()
    {
        //Only for development output
        List<FixtureResponse> AllFixtures = await FixtureClient.GetAllFixtures();
        List<TeamResponse> AllTeams = await TeamClient.GetAllTeams();

        foreach (var Fixture in AllFixtures)
        {
            var Team1 = AllTeams.Where(f => f.TeamID == Fixture.HomeTeamId).FirstOrDefault();
            var Team2 = AllTeams.Where(f => f.TeamID == Fixture.AwayTeamId).FirstOrDefault();


            string PrintFixture = Team1.TeamName + " - " + Team2.TeamName;
        Console.SetCursorPosition((Console.WindowWidth / 2 - PrintFixture.Length) / 2, Console.CursorTop);
        Console.WriteLine($"{PrintFixture} \t\t{Fixture.FixtureDate.ToShortDateString()}");
        }
    }

    public static void PrintAllFixtures(TeamResponse team1, TeamResponse team2, FixtureResponse newFixtureResponse)
    {
        //Only for development output
        string PrintFixture = team1.TeamName + " - " + team2.TeamName;
        Console.SetCursorPosition((Console.WindowWidth / 2 - PrintFixture.Length) / 2, Console.CursorTop);
        Console.WriteLine($"{PrintFixture} \t\t{newFixtureResponse.FixtureDate.ToShortDateString()}");
    }
}
