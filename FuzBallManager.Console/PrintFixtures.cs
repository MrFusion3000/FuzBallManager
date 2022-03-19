﻿using ApiClient;
using Application.Responses;

namespace UIConsole;

public class PrintFixtures
{
    public static async void PrintAllFixtures()
    {
        List<FixtureResponse> AllFixtures = await FixtureClient.GetAllFixtures();
        List<TeamResponse> AllTeams = await TeamClient.GetAllTeams();

        foreach (var fixture in AllFixtures)
        {
            var Team1 = AllTeams.Where(f => f.TeamID == fixture.HomeTeamId).FirstOrDefault();
            var Team2 = AllTeams.Where(f => f.TeamID == fixture.AwayTeamId).FirstOrDefault();

            string PrintFixture = Team1.TeamName + " - " + Team2.TeamName;
            Console.SetCursorPosition((Console.WindowWidth / 2 - PrintFixture.Length) / 2, Console.CursorTop);
            Console.WriteLine($"{PrintFixture} \t\t{fixture.FixtureDate.ToShortDateString()}");
        }
    }

    public static async void PrintNextFixture()
    {
        //TODO Get next Fixture where Played == false
        FixtureResponse NextFixture = await FixtureClient.GetNextFixture(false);
        List<TeamResponse> AllTeams = await TeamClient.GetAllTeams();

        var Team1 = AllTeams.Where(f => f.TeamID == NextFixture.HomeTeamId).FirstOrDefault();
        var Team2 = AllTeams.Where(f => f.TeamID == NextFixture.AwayTeamId).FirstOrDefault();

        //Only for development output
        string PrintFixture = Team1.TeamName + " - " + Team2.TeamName;
        Console.SetCursorPosition((Console.WindowWidth / 2 - PrintFixture.Length) / 2, Console.CursorTop);
        Console.WriteLine($"{PrintFixture} \t\t{NextFixture.FixtureDate.ToShortDateString()}");
    }
}
