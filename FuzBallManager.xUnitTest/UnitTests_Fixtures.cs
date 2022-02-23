using Application;
using System;
using Xunit;
using Xunit.Abstractions;

namespace xUnitTest
{
    public class UnitTests_Fixtures
    {
        private readonly ITestOutputHelper output;

        public UnitTests_Fixtures(ITestOutputHelper output)
        {
            this.output = output;
        }


        [Fact]
        public void CalculateMatchTeamScore()
        {
            //Function to determine the scored goals by a team in a given match
            //
            //Arr

            //Act
            var result = CalcMatchResults.CalcTeamScore();
            System.Console.WriteLine(result);

            //Ass
            output.WriteLine("Goals by HomeTeam : {0}", result);
            Assert.InRange((int)result, 0, 10);
        }

        [Fact]
        public void CalculateMatchGivesDraw()
        {
            //Arr
            //Fixture match = new();
            //Act
            var result = CalcMatchResults.MatchResult();

            //Ass
            Assert.Equal((0, 0), result);

        }

        [Fact]
        public void CalculateFixtures()
        {
            //Arr
            CalcFixtures calcFixtures = new();
            //Act

            //Ass
            Assert.Throws<NotImplementedException>(() => calcFixtures.CalcSeasonFixtures());
        }

    }
}
