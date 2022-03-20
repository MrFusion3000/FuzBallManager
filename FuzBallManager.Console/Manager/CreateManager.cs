using ApiClient;
using Application.Responses;

namespace UIConsole.Manager;

public class CreateManager
{
    public static async Task<ManagerResponse> CreatePlayerManagerAsync()
    {
        //InitManager initManager = new();

        Console.Write("Enter Manager name: ");
        string name = Console.ReadLine();

        //Get Manager profile
        ManagerResponse Manager = await ManagerClient.GetManagerByName(name);
        //Get List of available teams
        List<TeamResponse> teams = await TeamClient.GetAllTeams();

        //If Manager exists notify player (function not finished )
        if (Manager != null)
        {
            //TODONTH Add "Load profile or create new?"
            //TODONTH Add reset game to default

            //var managedTeamName = await TeamClient.GetTeamById(manager.ManagingTeamID);
            Console.WriteLine($"Manager {Manager.Name} exists");

            Console.WriteLine("---------------------------------------------------------------------------------");
            Console.ReadKey();
        }
        // Otherwise create Manager
        else
        {
            Manager = new()
            {
                Name = name,
                //LastName = lastname,
            };

            //Print teams to screen
            PrintTeams.PrintTeamsToConsole(teams);

            //Ask player to choose team from list
            var managedTeam = ChooseManagedTeam.ChooseTeam(teams);
            Manager.ManagingTeamID = managedTeam.TeamID;

            //Save new Manager with chosen Name and Team to DB
            await InitManager.CreateNewManager(Manager);
        }

        // Get fresh Manager profile
        //var showManager = await ManagerClient.GetManagerByName(manager.Name);

        return Manager;
    }

}
