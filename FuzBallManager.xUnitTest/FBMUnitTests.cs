using Xunit;
using FuzBallManager.Domain;
using System;
using System.Collections.Generic;
using Xunit.Abstractions;

namespace FuzBallManager.xUnitTest
{
    public class FBMUnitTests
    {
        private readonly ITestOutputHelper output;

        public FBMUnitTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Theory]
        [InlineData(1,"United",50)]
        public void CreateTeamSucceed(int id, string name, int points)
        {
            var testSub1 = new Team()
            {
                TeamId = id,
                TeamName = name,
                Points = points
            };

            //testSub1.TeamId.Equals(1);
            Assert.True(testSub1 is not null);
        }

        //[Theory]
        //[InlineData(1, "United", 50)]
        //public void CreateTeamFail(int id, string name, int points)
        //{
        //    //Expected
        //    //int expectedTeamId = 1;
        //    //string expectedTeamName = "United";
        //    //int expectedPoints = 50;

        //    //Actual
        //    var testSub1 = new Team()
        //    {
        //        TeamId = id,
        //        TeamName = name,
        //        Points = points
        //    };

        //    //Assert
        //    //Assert.False(testSub1.TeamName == expectedTeamName);
        //    //Assert.NotEqual(expectedTeamName, testSub1.TeamName);
        //    //Assert.Equal(expectedTeamName, testSub1.TeamName, StringComparer.CurrentCultureIgnoreCase);
        //    Assert.False(testSub1 is not null);
        //}

        [Theory]
        [InlineData(1, "United", 50, 1, "United", 50)]
        [InlineData(1, null, 50, 1, null, 50)]
        public void CreatedTeamDataSucceded(int testid, string testname, int testpoints, int resultid, string resultname, int resultpoints)
        {
            //Expected
            int expectedTeamId = resultid;
            string expectedTeamName = resultname;
            int expectedPoints = resultpoints;

            //Actual
            var testSub1 = new Team()
            {
                TeamId = testid,
                TeamName = testname,
                Points = testpoints
            };

            //Assert
            Assert.True(expectedTeamId == testSub1.TeamId);
            Assert.True(expectedTeamName == testSub1.TeamName);
            Assert.True(expectedPoints == testSub1.Points);
        }

        [Theory]
        [MemberData(nameof(TestCreateTeamData))]
        public void CreatedTeamDataFailed(object expectedData, object actualData)
        {
            //Expected
            var expData = expectedData;

            //Actual
            var actData = actualData;

            output.WriteLine("Actual: {0}, Expected: {1}", actData, expData);

            Console.WriteLine(expData + " - " + actData);
            Assert.NotEqual(expData, actData);
            //Assert
            //Assert.False (actData == expData);
        }

        public static IEnumerable<object[]> TestCreateTeamData =>
            new List<object[]>
            {
                new object[] { new Team { TeamId = 1, TeamName = "United", Points = 50 }, new Team { TeamId = 1, TeamName = "United", Points = 50 } },
                new object[] { new Team { TeamId = 2, TeamName = "Liverpool", Points = 45 }, new Team { TeamId = 3, TeamName = "Liverpoool", Points = 4 } },
            };

        


        [Fact]
        public void TeamPassSucceed()
        {

        }

        [Fact]
        public void TeamPassFail()
        {

        }

        [Fact]
        public void TeamGoalForward()
        {

        }

        [Fact]
        public void TeamGoalAgainst()
        {

        }

        [Fact]
        public void TeamWin()
        {

        }

        [Fact]
        public void TeamLoose()
        {

        }
    }
}