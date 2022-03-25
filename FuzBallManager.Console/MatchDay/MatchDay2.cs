using ApiClient;
using Application.Responses;

namespace UIConsole.MatchDay
{
    public class MatchDay2
    {
        public static async void ShowPreMatch()
        {
            var fixture = await FixtureClient.GetNextFixture(false);
            var HomeTeam = await TeamClient.GetTeamById((Guid)fixture.HomeTeamId);
            var AwayTeam = await TeamClient.GetTeamById((Guid)fixture.AwayTeamId);

            Console.Clear();
            Console.WriteLine($"\n\n\t\t{HomeTeam.TeamName}\t{AwayTeam.TeamName}");
        }
    }
}
