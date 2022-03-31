using ApiClient;
using Application.Responses;

namespace UIConsole.Fixtures;

public static class InitFixtures
{
    public static async Task CalcSeasonFixturesAsync(ManagerResponse manager)
    {
        var managedTeamId = manager.ManagingTeamID;
        int AddDaysToMatchDay = 0;
        bool Odd = true;

        //--Add function for calculating season fixtures--
        var teams = await TeamClient.GetAllTeams();

        var AllTeamsAgainst = GetOpposingTeams.GetOppTeams(teams, managedTeamId);

        var CheckFixtureExist = await FixtureClient.GetAllFixtures();

        if (CheckFixtureExist.Any())
        {
            //Delete all rows in Table Fixture if any exists
            foreach (var fixture in CheckFixtureExist)
            {
                //TODO function to clear table in one go?
                await FixtureClient.Delete(fixture.FixtureID);
            }
            Console.WriteLine("Old fixtures deleted.");
        }
        DateTime SeasonStart = new(1985, 04, 01);

        //Create list of each fixture with ManagerTeam as Home team and matchday every 3rd or 4th day depending on week
        foreach (var oppositeTeam in AllTeamsAgainst)
        {
            //TODONTH - **refactor idea - shorter function that switches home/away-teams after given amount of matches (Home team + all Away teams)

            //Home match
            var fixturedate = GetMatchday(SeasonStart.AddDays(AddDaysToMatchDay));

            FixtureResponse newHomeFixture = new()
            {
                HomeTeamId = managedTeamId,
                AwayTeamId = oppositeTeam.TeamID,
                HomeTeamScore = 0,
                AwayTeamScore = 0,
                Attendance = 0,
                FixtureDate = fixturedate,
                Played = false
            };

            await FixtureClient.Create(newHomeFixture);

            (Odd, AddDaysToMatchDay) = OddEven(Odd, AddDaysToMatchDay);

            //Away match
            fixturedate = GetMatchday(SeasonStart.AddDays(AddDaysToMatchDay));

            FixtureResponse newAwayFixture = new()
            {
                HomeTeamId = oppositeTeam.TeamID,
                AwayTeamId = managedTeamId,
                HomeTeamScore = 0,
                AwayTeamScore = 0,
                Attendance = 0,
                FixtureDate = fixturedate,
                Played = false
            };

            await FixtureClient.Create(newAwayFixture);

            (Odd, AddDaysToMatchDay) = OddEven(Odd, AddDaysToMatchDay);
        }
    }

    private static DateTime GetMatchday(DateTime addDaysToMatchDay)
    {
        var MatchDay = addDaysToMatchDay;

        return MatchDay;
    }

    private static (bool,int) OddEven(bool odd, int addDays )
    {
        var Odd = odd;
        var AddDaysToMatchDay = addDays;

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
        return (Odd, AddDaysToMatchDay);
    }
}

