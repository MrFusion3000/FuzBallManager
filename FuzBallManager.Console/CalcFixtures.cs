using ApiClient;
using Domain.Entities;

namespace Application;

public class CalcFixtures
{
    public static async Task<List<Fixture>?> CalcSeasonFixturesAsync(ManagerJsonDto manager)
    {
        var managedTeamId = manager.ManagingTeamID;
        //TODO --Add function for calculating season fixtures--
        // Get All teams
        var teams = await TeamClient.GetAllTeams();

        // Filter out Player Managed Team
        var AllTeamsAgainst = teams.Where(t => t.TeamID != managedTeamId).ToList();

        //TODO Check how many teams to play against


        //TODO Create list of each fixture with ManagerTeam as Home team and matchday every Thursday
        foreach (var item in AllTeamsAgainst)
        {
            //TODO Home match

            //TODO Away match

            Console.WriteLine(item);
        }
        //TODO Create list of each fixture with ManagerTeam as Away team and matchday every Sunday
        //TODO Save lists to DB Table <Fixtures>
        return default;
    }
}

