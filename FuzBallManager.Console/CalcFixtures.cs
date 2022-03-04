using ApiClient;
using Application.Responses;
using UIConsole;

namespace Application;

public static class CalcFixtures
{
    public static async Task CalcSeasonFixturesAsync(ManagerResponse manager)
    {
        var managedTeamId = manager.ManagingTeamID;
        int AddDaysToMatchDay = 0;
        bool Odd = true;

        //TODO --Add function for calculating season fixtures--
        // Get All teams
        var teams = await TeamClient.GetAllTeams();

        // Filter outopposite teams
        var AllTeamsAgainst = teams.Where(t => t.TeamID != managedTeamId).ToList();

        //TODO Create list of each fixture with ManagerTeam as Home team and matchday every 3rd or 4th day depending on week
        //List<FixtureJsonDto> newFixtureJsonDto = new ();
        foreach (var oppositeTeam in AllTeamsAgainst)
        {
            //Home match
            //take ManagerTeam.Id and oppositeTeam.Id + return a matchday from GetMatchday-function
            var fixturedate = GetMatchday(AddDaysToMatchDay);

            FixtureResponse newFixtureResponse = new()
            {
                //FixtureID = Guid.NewGuid(),
                HomeTeamId = managedTeamId,
                AwayTeamId = oppositeTeam.TeamID,
                HomeTeamScore = 0,
                AwayTeamScore = 0,
                Attendance = 0,
                FixtureDate = DateTime.Now,
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

            //TODO Away match
            Console.WriteLine(manager.FirstName, manager.LastName, manager.ManagingTeamName, manager.Bank, manager.Score, manager.DateOfBirth);
            Console.WriteLine(oppositeTeam.TeamName, oppositeTeam.TeamID, oppositeTeam.GoalsForward, oppositeTeam.Draws, oppositeTeam.Lost, oppositeTeam.Points, oppositeTeam.Stadium, oppositeTeam.GoalsAgainst);
        }
        //TODO Create list of each fixture with ManagerTeam as Away team and matchday every Sunday
        //TODO Save lists to DB Table <Fixtures>
        return;
    }

    private static DateTime GetMatchday(int addDaysToMatchDay)
    {
        DateTime SeasonStart = new(1985, 04, 01);

        var MatchDay = SeasonStart.AddDays(addDaysToMatchDay);

        return MatchDay;
    }
}

