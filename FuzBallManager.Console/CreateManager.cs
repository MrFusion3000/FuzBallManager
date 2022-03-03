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

            var manager = await managerRepo.GetManager(lastname);
            var teams = await TeamClient.GetAllTeams();

            if (manager != null)
            {
                Console.Write("Manager exists: " + manager.FirstName + " " + manager.LastName);
                Console.SetCursorPosition(40, Console.CursorTop);
                Console.WriteLine(manager.ManagingTeamName);
                Console.WriteLine("---------------------------------------------------------------------------------");
            }
            else
            {
                manager = new()
                {
                    FirstName = firstname,
                    LastName = lastname
                };
                PrintTeams.PrintTeamsToConsole(teams);
                var managedTeam = ChooseManagedTeam.ChooseTeam(teams);

                //Save new Manager with chosen Name and Team from the team-list to DB
                //ShowManager showManager = new ();
                await ManagerRepo.Create(manager, managedTeam);
            }

            // Get fresh Manager profile
            var showManager = await managerRepo.GetManager(manager.LastName);

            return showManager;
        }
        
    }
}
