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

        //Create list of each fixture with ManagerTeam as Home team and matchday every 3rd or 4th day depending on week
        foreach (var oppositeTeam in AllTeamsAgainst)
        {
            //Home match
            //take ManagerTeam.Id and oppositeTeam.Id + return a matchday from GetMatchday-function
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

            Console.WriteLine("{0} \t-\t {1}\t{2}", managedTeam, oppositeTeam.TeamName, newFixtureResponse.FixtureDate);
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

            Console.WriteLine(oppositeTeam.TeamName + "\t\t\t" + fixturedate.ToShortDateString());
        }
    }

    private static DateTime GetMatchday(int addDaysToMatchDay)
    {
        DateTime SeasonStart = new(1985, 04, 01);

        var MatchDay = SeasonStart.AddDays(addDaysToMatchDay);

        return MatchDay;
    }
}

