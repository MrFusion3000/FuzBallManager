﻿using UIConsole;
using Xunit;

namespace xUnitTest
{
    public class UnitTests
    {
        ShowManager manager = new();

        [Fact]
        public async void GetManagingTeamShouldWork()
        {
            //Arrange
            //Manager? manager = new();
            ManagerRepository teamManager = await manager.GetManager("Bumpa");

            //Act
            string expected = "";
            string actual = teamManager.ManagingTeamName;

            //Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void GetManagingTeamShouldFail()
        {
            //Arrange
            //Manager? manager = new();
            ManagerRepository? teamManager = await manager.GetManager("Bumpa");

            //Act
            string expected = "Manchester United";
            string actual = teamManager.ManagingTeamName;

            //Assert
            Assert.NotEqual(expected, actual);
        }



    }
}