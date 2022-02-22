using Application;
using Domain.Entities;
using System;
using UIConsole;
using Xunit;

namespace xUnitTest
{
    public class UnitTests_Fixtures
    {
        [Fact]
        public void CalculateMatchGivesHomeTeamWin()
        {
            //Arr

            //Act
            var result = CalcMatchResults.CalcHomeTeamScore();
            System.Console.WriteLine(result);

            //Ass
            Assert.InRange((int)result,0,10);
        }

        [Fact]
        public void CalculateMatchGivesAwayTeamWin()
        {
            //Arr

            //Act

            //Ass

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
            Assert.Throws<NotImplementedException> (() => calcFixtures.CalcSeasonFixtures());
        }

    }
}
