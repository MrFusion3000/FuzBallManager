using Application.Responses;

namespace UIConsole
{
    public class GetOpposingTeams
    {
        internal static List<TeamResponse> GetOppTeams(List<TeamResponse> teams, Guid managedTeamId)
        {
            // Filter out opposing teams
            var AllTeamsAgainst = teams.Where(t => t.TeamID != managedTeamId).ToList();

            return AllTeamsAgainst;
        }

    }
}
