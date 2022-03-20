using Application.Responses;

namespace UIConsole.Fixtures
{
    public class GetOpposingTeams
    {
        public static List<TeamResponse> GetOppTeams(List<TeamResponse> teams, Guid managedTeamId)
        {
            // Filter out opposing teams
            var AllTeamsAgainst = teams.Where(t => t.TeamID != managedTeamId).ToList();

            return AllTeamsAgainst;
        }

    }
}
