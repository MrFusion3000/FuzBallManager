using Application.Responses;
using System.Runtime.InteropServices;
using UIConsole.Fixtures;
using UIConsole.Manager;
using UIConsole.PreGame;

namespace UIConsole;
class Program
{
    static async Task Main(/*string[] args*/)
    {
        //***This Function Adds Team Id to Players With TeamID Null if not initiated + Add RND ShirtNo***
        //TODONTH Place in seed phase
        //await AddTeamIdShirtNoToPlayer.AddTeamIdShirtNoToPlayers();
 
        // Init Player Manager: FirstName, LastName, Managing Team (Default values: ManagerID: New Guid, DateOfBirth: Today, Score:0, Bank:50000)  
        //TODO Make a proper UserManagerClass
        //TODO Check if Manager exists/Question to use this or create new
        ManagerResponse UserPlayerManager = await CreateManager.CreatePlayerManagerAsync();

        //Init Season Fixtures (Home and Away Matches)
        await InitFixtures.CalcSeasonFixturesAsync(UserPlayerManager);

        List<PlayerResponse> ManagedTeamPlayers = await InitManager.SetupManagedTeam(UserPlayerManager);

        //Show Top Menu
        ShowMenu.ShowTopMenu(UserPlayerManager, ManagedTeamPlayers);


        //TODONTH 5.1 Obtain a loan
        //TODONTH 5.2 Pay off loan
        //TODOHIGH 3 Display league table
        //TODONTH 6 Change your skill level
        //TODONTH 7 Change team or player names
        //TODONTH 8.1 Save game
        //TODONTH 8.2 Restore saved game
        //TODO 2 Press SPACE BAR to continue
    }
}