using ApiClient;
using Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole
{
    public class CreateManager
    {
        public static async Task<ManagerJsonDto> CreatePlayerManagerAsync()
        {
            ManagerRepo managerRepo = new();

            Console.Write("Enter Manager Firstname: ");
            string firstname = Console.ReadLine();
            Console.Write("Enter Manager Lastname: ");
            string lastname = Console.ReadLine();

            //Get Manager profile
            var manager = await managerRepo.GetManager(lastname);
            //Get List of teams
            var teams = await TeamClient.GetAllTeams();

            //If Manager exists notify player (function not finished )
            if (manager != null)
            {
                Console.Write("Manager exists: " + manager.FirstName + " " + manager.LastName);
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine(manager.ManagingTeamName);
                Console.WriteLine("---------------------------------------------------------------------------------");
            }
            // Otherwise create Manager
            else
            {
                manager = new()
                {
                    FirstName = firstname,
                    LastName = lastname
                };

                //Print teams to screen
                PrintTeams.PrintTeamsToConsole(teams);
                //Ask player to choose team from list
                var managedTeam = ChooseManagedTeam.ChooseTeam(teams);

                //Save new Manager with chosen Name and Team to DB
                await ManagerRepo.Create(manager, managedTeam);
            }

            // Get fresh Manager profile
            var showManager = await managerRepo.GetManager(manager.LastName);

            return showManager;
        }
        
    }
}
