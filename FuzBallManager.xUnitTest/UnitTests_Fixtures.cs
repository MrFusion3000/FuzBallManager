using Application;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UIConsole;
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
            //var result = CalcMatchResults.CalcTeamScore();

            //Ass
            //output.WriteLine("Goals by HomeTeam : {0}", result);
            //Assert.InRange((int)result, 0, 10);
        }

        [Fact]
        public void CalculateMatchScore()
        {
            //Arr

            //Fixture match = new();
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
        public void CalculateFixtures()
        {
            //Arr
            //CalcFixtures calcFixtures = new();
            //Manager manager = new();
            //var teams = await team.GetTeams();

            //Act
            //manager = 

            //Ass
            //Assert.Throws<NotImplementedException>(() => calcFixtures.CalcSeasonFixturesAsync(manager));
            output.WriteLine("Fixtures calculated.");

        }

        [Fact]
        public async void GetAllTeams()
        {
            //Arr
            //var teams = await team.GetTeams();

            //Act


            //Ass
            //Assert.NotNull(teams);
            //output.WriteLine("List of teams fetched. {0}", teams.TeamName);

        }

    }
}
