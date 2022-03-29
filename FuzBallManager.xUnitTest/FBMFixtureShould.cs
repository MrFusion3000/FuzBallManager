using ApiClient;
using UIConsole.MatchDay;
using Xunit;
using Xunit.Abstractions;

namespace xUnitTest
{
    public class FBMFixtureShould
    {
        private readonly ITestOutputHelper output;

        public FBMFixtureShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void HaveCorrectlyCalculatedMatchScores()
        {
            //Arr

            //Act
            var result = CalcMatchScore.MatchScore();

            //Ass
            Assert.InRange(result.Item1, 0, 10);
            output.WriteLine("Team 1 Score: {0}", result.Item1);
            Assert.InRange(result.Item2, 0, 10);
            output.WriteLine("Team 2 Score: {0}", result.Item2);

        }

        //readonly ShowTeam team = new();
        [Fact]
        public async void GetAllFixtures()
        {
            //Arr
            var fixtures = await FixtureClient.GetAllFixtures();

            //CalcFixtures calcFixtures = new();
            //Manager manager = new();
            //var teams = await team.GetTeams();

            //Act
            //manager = 

            //Ass
            //Assert.Throws<NotImplementedException>(() => calcFixtures.CalcSeasonFixturesAsync(manager));
            Assert.NotNull(fixtures);
            output.WriteLine($"Fixtures calculated: {fixtures.Count}");
        }
    }
}
