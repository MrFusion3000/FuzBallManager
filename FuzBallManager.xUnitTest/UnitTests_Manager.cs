using ApiClient;
using Application;
using Application.Responses;
using System;
using UIConsole;
using Xunit;

namespace xUnitTest
{
    public class UnitTests_Manager
    {
        //readonly InitManager manager1 = new();
        //readonly InitManager manager2 = new();


        //[Fact]
        //public async void GetManagingTeamShouldWork()
        //{
        //    //Fetch the Managers Teamname

        //    //Arrange
        //    string managerName = "Lord Manager";
        //    ManagerResponse teamManager = await ManagerClient.GetManagerByName(managerName);

        //    //Act
        //    string expected = "Manchester United";
        //    string actual = teamManager.ManagingTeamName;

        //    //Assert
        //    Assert.Equal(expected, actual);
        //    //actual = "";
        //}

        //[Fact]
        //public async void GetManagingTeamShouldFail()
        //{
        //    //Arrange
        //    string managerName = "Lord Manager";
        //    Guid managedTeamId = Guid.Parse("b5d4e653-7e8d-ec11-8465-244bfe57fd18");
        //    //Manager? manager = new();
        //    ManagerResponse teamManager = await ManagerClient.GetManagerByName(managerName);
        //    TeamResponse managedTeam = await TeamClient.GetTeamById(managedTeamId);

        //    //Act
        //    string expected = "Manchester United";
        //    string? actual = managedTeam.TeamName;

        //    //Assert
        //    Assert.NotEqual(expected, actual);
        //}
    }
}
