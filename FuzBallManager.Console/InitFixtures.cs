﻿using ApiClient;
using Application.Responses;
using UIConsole;

namespace Application;

public static class InitFixtures
{
    public static async Task CalcSeasonFixturesAsync(ManagerResponse manager)
    {
        var managedTeamId = manager.ManagingTeamID;
        var managedTeam = await TeamClient.GetTeamById(managedTeamId);
        int AddDaysToMatchDay = 0;
        bool Odd = true;

        //--Add function for calculating season fixtures--
        // Get All teams
        var teams = await TeamClient.GetAllTeams();

        // Filter out opposite teams
        var AllTeamsAgainst = teams.Where(t => t.TeamID != managedTeamId).ToList();

        var CheckFixtureExist = await FixtureClient.GetAllFixtures();

        if (CheckFixtureExist.Any())
        {
            //TODO checks only if ANY fixtures exists, not for which team! So, wrong!
            //TODO Delete all rows in Table Fixture

            foreach (var fixture in CheckFixtureExist)
            {
                var hometeam = teams.FirstOrDefault(f => f.TeamID == fixture.HomeTeamId);
                var awayteam = teams.FirstOrDefault(f => f.TeamID == fixture.AwayTeamId);

                PrintFixtures.PrintAllFixtures(hometeam, awayteam, fixture);
            }
        }
        else
        {
            DateTime SeasonStart = new(1985, 04, 01);

            //Create list of each fixture with ManagerTeam as Home team and matchday every 3rd or 4th day depending on week
            foreach (var oppositeTeam in AllTeamsAgainst)
            {
                //Home match
                //take ManagerTeam.Id and oppositeTeam.Id + return a matchday from GetMatchday-function
                //TODO NTH **refactor idea - shorter function that switches home/away-teams after given amount of matches (Home team + all Away teams)

                var fixturedate = GetMatchday(AddDaysToMatchDay);

                FixtureResponse newFixtureResponse = new()
                {
                    HomeTeamId = managedTeamId,
                    AwayTeamId = oppositeTeam.TeamID,
                    HomeTeamScore = 0,
                    AwayTeamScore = 0,
                    Attendance = 0,
                    FixtureDate = fixturedate,
                    Played = false
                };

                await FixtureClient.Create(newFixtureResponse);

                if (Odd == true)
                {
                    AddDaysToMatchDay += 3;
                    Odd = false;
                }
                else
                {
                    AddDaysToMatchDay += 4;
                    Odd = true;
                }

                //Only for development output
                //string PrintFixture = managedTeam.TeamName + " - " + oppositeTeam.TeamName;
                //Console.SetCursorPosition((Console.WindowWidth / 2 - PrintFixture.Length) / 2, Console.CursorTop);
                //Console.WriteLine($"{PrintFixture} \t\t{newFixtureResponse.FixtureDate.ToShortDateString()}");

                PrintFixtures.PrintAllFixtures (managedTeam, oppositeTeam, newFixtureResponse);
            }

            //Create list of each fixture with ManagerTeam as Away team and matchday every 3rd or 4th day depending on week
            foreach (var oppositeTeam in AllTeamsAgainst)
            {
                //Away match
                //take ManagerTeam.Id and oppositeTeam.Id + return a matchday from GetMatchday-function
                var fixturedate = GetMatchday(AddDaysToMatchDay);

                FixtureResponse newFixtureResponse = new()
                {
                    HomeTeamId = oppositeTeam.TeamID,
                    AwayTeamId = managedTeamId,
                    HomeTeamScore = 0,
                    AwayTeamScore = 0,
                    Attendance = 0,
                    FixtureDate = fixturedate,
                    Played = false
                };

                await FixtureClient.Create(newFixtureResponse);

                if (Odd == true)
                {
                    AddDaysToMatchDay += 3;
                    Odd = false;
                }
                else
                {
                    AddDaysToMatchDay += 4;
                    Odd = true;
                }

                //Only for development output
                //string PrintFixture = oppositeTeam.TeamName + " - " + managedTeam.TeamName;
                //TODO refactor to own class
                //Console.SetCursorPosition((Console.WindowWidth / 2 - PrintFixture.Length) / 2, Console.CursorTop);
                //Console.WriteLine($"{PrintFixture} \t\t{newFixtureResponse.FixtureDate.ToShortDateString()}");

                PrintFixtures.PrintAllFixtures(oppositeTeam, managedTeam, newFixtureResponse);

            }
        }

        Console.ReadKey();
    }

    private static DateTime GetMatchday(int addDaysToMatchDay)
    {
        //TODO Change so that SeasonStart date is passed in to function (as of now the 2nd half starts at the same as the first)
        DateTime SeasonStart = new(1985, 04, 01);

        var MatchDay = SeasonStart.AddDays(addDaysToMatchDay);

        return MatchDay;
    }
}

