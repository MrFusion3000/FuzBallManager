using UIConsole;
using Xunit;

namespace xUnitTest
{
    public class UnitTests_Manager
    {
        readonly ShowManager manager1 = new();
        readonly ShowManager manager2 = new();


        [Fact]
        public async void GetManagingTeamShouldWork()
        {
            //Fetch the Managers Teamname

            //Arrange
            string managerLastName = "Bumpa";
            ManagerDto? teamManager = await manager1.GetManager(managerLastName);

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
            ManagerDto? teamManager = await manager2.GetManager(managerLastName);

            //Act
            string expected = "Manchester United";
            string actual = teamManager.ManagingTeamName;

            //Assert
            Assert.NotEqual(expected, actual);
        }
    }
}
