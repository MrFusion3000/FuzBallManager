using Application.Responses;
using UIConsole.Fixtures;
using UIConsole.Manager;
using UIConsole.MatchDay;
using UIConsole.Menu;
using UIConsole.PreGame;

namespace UIConsole;
class Program
{
    public static async Task Main(/*string[] args*/)
    {

        //***This Function Adds Team Id to Players With TeamID Null if not initiated + Add RND ShirtNo AND Setup Teams 11 starting players***
        //TODONTH Place in seed phase
        //await AddTeamIdShirtNoToPlayer.AddTeamIdShirtNoToPlayers();

        // Init Player Manager: FirstName, LastName, Managing Team (Default values: ManagerID: New Guid, DateOfBirth: Today, Score:0, Bank:50000)  
        //TODO Make a proper UserManagerClass
        //TODO Check if Manager exists/Question to use this or create new
        ManagerResponse UserPlayerManager = await CreateManager.CreatePlayerManagerAsync();

        //Init Season Fixtures (Home and Away Matches)
        await InitFixtures.CalcSeasonFixturesAsync(UserPlayerManager);

        //List<PlayerResponse> ManagedTeamPlayers = await InitManager.SetupManagedTeam(UserPlayerManager);
        await InitManager.SetupManagedTeam(UserPlayerManager);

        var gameOn = true;

        //Show Top Menu
        ShowMenu.ShowTopMenu();


        Console.WriteLine("END");
        while (gameOn)
        {         

        }
    }
}