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

        //Get Manager profile
        ManagerResponse Manager = await ManagerClient.GetManagerByName(name);

        //In case Manager exists use existing / notify player (function not finished )
        if (Manager != null)
        {
            //TODONTH Add "Load profile or create new?"
            //TODONTH Add reset game to default

            Console.WriteLine($"Manager {Manager.Name} exists");
        }
        //Otherwise create new Manager
        else
        {
            Manager = new()
            {
                Name = name,
            };
        }

        //Get List of available teams
        TeamClient teamClient = new();
        List<TeamResponse> teams = await TeamClient.GetAllTeams();

        //Print teams to screen
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine(" CHOOSE TEAM TO MANAGE :\n");

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
