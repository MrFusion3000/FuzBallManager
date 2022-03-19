using ApiClient;
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
            //TODOHIGH checks only if ANY fixtures exists, not for which team! So. wrong.
            //Delete all rows in Table Fixture

            foreach (var fixture in CheckFixtureExist)
            {
                await FixtureClient.Delete(fixture.FixtureID);
                //Get TeamName for each TeamID in Fixtures
                //var hometeam = teams.FirstOrDefault(f => f.TeamID == fixture.HomeTeamId);
                //var awayteam = teams.FirstOrDefault(f => f.TeamID == fixture.AwayTeamId);

                //PrintFixtures.PrintAllFixtures(hometeam, awayteam, fixture);
            }
            Console.WriteLine("Old fixtures deleted.");
        }
        DateTime SeasonStart = new(1985, 04, 01);

        //Create list of each fixture with ManagerTeam as Home team and matchday every 3rd or 4th day depending on week
        foreach (var oppositeTeam in AllTeamsAgainst)
        {
            //TODONTH - **refactor idea - shorter function that switches home/away-teams after given amount of matches (Home team + all Away teams)

            //Home match
            //take ManagerTeam.Id and oppositeTeam.Id + return a matchday from GetMatchday-function
            var fixturedate = GetMatchday(SeasonStart.AddDays(AddDaysToMatchDay));

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
        }

        //Create list of each fixture with ManagerTeam as Away team and matchday every 3rd or 4th day depending on week
        foreach (var oppositeTeam in AllTeamsAgainst)
        {
            //Away match
            //take ManagerTeam.Id and oppositeTeam.Id + return a matchday from GetMatchday-function
            var fixturedate = GetMatchday(SeasonStart.AddDays(AddDaysToMatchDay));

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
        }

        PrintFixtures.PrintAllFixtures();

        Console.WriteLine("Next Match:");
        PrintFixtures.PrintNextFixture();

        Console.ReadKey();
    }

    private static DateTime GetMatchday(DateTime addDaysToMatchDay)
    {
        //SeasonStart date is passed in to function
        //DateTime SeasonStart = new(1985, 04, 01);

        var MatchDay = addDaysToMatchDay;

        return MatchDay;
    }
}

