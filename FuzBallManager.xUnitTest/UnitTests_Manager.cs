using Application;
using UIConsole;
using Xunit;

namespace xUnitTest
{
    public class UnitTests_Manager
    {
        readonly ManagerRepo manager1 = new();
        readonly ManagerRepo manager2 = new();


        [Fact]
        public async void GetManagingTeamShouldWork()
        {
            //Fetch the Managers Teamname

            //Arrange
            string managerLastName = "Bumpa";
            ManagerJsonDto? teamManager = await manager1.GetManager(managerLastName);

            //Act
            string expected = "";
            string actual = teamManager.ManagingTeamName;

            //Assert
            Assert.Equal(expected, actual);
            actual = "";
        }

        [Fact]
        public async void GetManagingTeamShouldFail()
        {
            //Arrange
            string managerLastName = "Bumpa";

            //Manager? manager = new();
            ManagerJsonDto? teamManager = await manager2.GetManager(managerLastName);

            //Act
            string expected = "Manchester United";
            string actual = teamManager.ManagingTeamName;

            //Assert
            Assert.NotEqual(expected, actual);
        }
    }
}
