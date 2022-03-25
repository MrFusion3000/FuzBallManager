using ApiClient;
using Application.Responses;

namespace UIConsole.Manager;

public class CreateManager
{
    public static async Task<ManagerResponse> CreatePlayerManagerAsync()
    {
        //InitManager initManager = new();

        Console.Write("\n\n   Type your name  ");
        string name = Console.ReadLine();

        var Manager = new ManagerResponse();
        //Get Manager profile
        //ManagerResponse Manager = await ManagerClient.GetManagerByName(name);
        //Get List of available teams
        List<TeamResponse> teams = await TeamClient.GetAllTeams();

        //If Manager exists notify player (function not finished )
        //if (Manager != null)
        //{
        //    //TODONTH Add "Load profile or create new?"
        //    //TODONTH Add reset game to default

        //    Console.WriteLine($"Manager {Manager.Name} exists");
        //}
        // Otherwise create new Manager
        //else
        //{
        Manager = new()
        {
            Name = name,
        };

        //Print teams to screen
        PrintTeams.PrintTeamsToConsole(teams);

        //Ask player to choose team from list
        var managedTeam = ChooseManagedTeam.ChooseTeam(teams);
        Manager.ManagingTeamID = managedTeam.TeamID;

        //Save new Manager with chosen Name and Team to DB
        await InitManager.CreateNewManager(Manager);
        //}

        // Get fresh Manager profile
        //var showManager = await ManagerClient.GetManagerByName(manager.Name);

        return Manager;
    }

}
