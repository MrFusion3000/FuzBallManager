using ApiClient;
using Xunit;
using Xunit.Abstractions;

namespace xUnitTest
{
    public class FBMTeamsShould
    {
        private readonly ITestOutputHelper output;

        public FBMTeamsShould(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public async void GetAllTeams()
        {
            //Arr
            var teams = await TeamClient.GetAllTeams();

            //Act

            //Ass
            Assert.NotNull(teams);
            output.WriteLine("List of teams fetched. {0}", teams.Count);

        }

    }
}
