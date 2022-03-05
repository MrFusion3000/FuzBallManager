using ApiClient;
using Application.Responses;

namespace UIConsole;

public class CreateManager
{
    public static async Task<ManagerResponse> CreatePlayerManagerAsync()
    {
        //InitManager initManager = new();

        Console.Write("Enter Manager Firstname: ");
        string name = Console.ReadLine();
        //Console.Write("Enter Manager Lastname: ");
        //string lastname = Console.ReadLine();

        //Get Manager profile
        var manager = await ManagerClient.GetManagerByName(name);
        //Get List of teams
        var teams = await TeamClient.GetAllTeams();

        //If Manager exists notify player (function not finished )
        if (manager != null)
        {
            Console.Write("Manager exists: " + manager.Name);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine(manager.ManagingTeamName);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        // Otherwise create Manager
        else
        {
            manager = new()
            {
                Name = name,
                //LastName = lastname,
            };

            //Print teams to screen
            PrintTeams.PrintTeamsToConsole(teams);

            //Ask player to choose team from list
            var managedTeam = ChooseManagedTeam.ChooseTeam(teams);
            manager.ManagingTeamID = managedTeam.TeamID;

            //Save new Manager with chosen Name and Team to DB
            await InitManager.Create(manager);
        }

        // Get fresh Manager profile
        var showManager = await ManagerClient.GetManagerByName(manager.Name);

        return showManager;
    }

}
