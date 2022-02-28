using ApiClient;
using Application;
using Domain.Entities;
using System.Linq;

namespace UIConsole
{
    public class PrintTeams
    {
        public static async Task PrintTeamsToConsole(ManagerJsonDto manager)
        {
            var teams = await TeamClient.GetAllTeams();

            int i = 1;

            Console.WriteLine("CHOOSE TEAM TO MANAGE :\n");
            Console.WriteLine("NUMBER \t\tNAME");
            foreach (var team in teams)
            {
                //Console.SetCursorPosition(40, Console.CursorTop);
                Console.Write(" " + i + "\t\t{0}", team.TeamName + "\n");
                i++;
            }
            Console.WriteLine("Type team number of the team you want to manage\n");
            int chosenTeam = Int32.Parse(Console.ReadLine());


            var managedTeam = teams.ElementAtOrDefault(chosenTeam);
            Console.WriteLine("You chose : {0} {1}", chosenTeam, managedTeam);
            Console.ReadKey();
            }
    }
}
