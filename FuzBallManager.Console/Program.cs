using Application.Responses;
using UIConsole.Fixtures;
using UIConsole.Manager;

namespace UIConsole;
class Program
{
    static async Task Main(/*string[] args*/)
    {
        //***This Function Adds Team Id to Players With TeamID Null if not initiated***
        //await AddTeamIdToPlayer.AddTeamIdToPlayers();
 
        // Init Player Manager: FirstName, LastName, Managing Team (Default values: ManagerID: New Guid, DateOfBirth: Today, Score:0, Bank:50000)  
        //TODO Check if Manager exists/Question to use this or create new
        ManagerResponse UserPlayerManager = await CreateManager.CreatePlayerManagerAsync();

        //Init Season Fixtures (Home and Away Matches)
        await InitFixtures.CalcSeasonFixturesAsync(UserPlayerManager);


        List<PlayerResponse> ManagedTeamPlayers = await InitManager.SetupManagedTeam(UserPlayerManager);

        //Show Top Menu
        ShowMenu.ShowTopMenu(UserPlayerManager, ManagedTeamPlayers);


        //TODO 1 Sell/List your players
        //TODO 4 Print score etc
        //TODO 5.1 Obtain a loan
        //TODO 5.2 Pay off loan
        //TODO 3 Display league table
        //TODO 6 Change your skill level
        //TODO 7 Change team or player names
        //TODO 8.1 Save game
        //TODO 8.2 Restore saved game
        //TODO 2 Press SPACE BAR to continue
        //TODO RND 11 players for Managed team
    }
}