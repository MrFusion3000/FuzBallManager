﻿using ApiClient;
using Application;
using Application.Responses;
using System;
using UIConsole;
using Xunit;

namespace xUnitTest
{
    public class ManagerShould
    {
        // *** Start API first in Package Manager using 'dotnet run' ***

        //readonly InitManager manager1 = new();
        //readonly InitManager manager2 = new();

        [Fact]
        public async void HaveAName()
        {
            //Fetch the Managers Name

            //Arrange
            string managerName = "Lord Manager";
            ManagerResponse teamManager = await ManagerClient.GetManagerByName(managerName);

            //Act
            string expected = "Lord Manager";
            string? actual = teamManager.Name;

            //Assert
            Assert.Equal(expected, actual);
            //actual = "";
        }

        [Fact]
        public async void HaveATeamWithID()
        {
            //Fetch the Managers Name

            //Arrange
            string managerName = "Lord Manager";
            ManagerResponse teamManager = await ManagerClient.GetManagerByName(managerName);

            //Act
            Guid expected = Guid.Parse("b5d4e653-7e8d-ec11-8465-244bfe57fd18");
            Guid actual = teamManager.ManagingTeamID;

            //Assert
            Assert.Equal(expected, actual);
            //actual = "";
        }

        [Fact]
        public async void HaveATeamWithNameBasedOnID()
        {
            //Fetch the Managers Name

            //Arrange
            string managerName = "Lord Manager";
            ManagerResponse teamManager = await ManagerClient.GetManagerByName(managerName);
            TeamResponse Team = await TeamClient.GetTeamById(teamManager.ManagingTeamID);

            //Act
            string expected = "Manchester United";
            string? actual = Team.TeamName;

            //Assert
            Assert.Equal(expected, actual);
            //actual = "";
        }

        [Fact]
        public async void NotHaveWrongManagingTeamName()
        {
            //Arrange
            //string managerName = "Lord Manager";
            Guid managedTeamId = Guid.Parse("b5d4e653-7e8d-ec11-8465-244bfe57fd18");
            //ManagerResponse teamManager = await ManagerClient.GetManagerByName(managerName);
            TeamResponse managedTeam = await TeamClient.GetTeamById(managedTeamId);

            //Act
            string expected = "Manchester City";
            string? actual = managedTeam.TeamName;

            //Assert
            Assert.NotEqual(expected, actual);
            //}
        }
    }
}
