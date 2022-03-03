using ApiClient;
using Application;
using Domain.Entities;

namespace UIConsole
{
    public class ChooseManagedTeam
    {
        public static TeamJsonDto ChooseTeam(List<TeamJsonDto> teams)
        {
            Console.WriteLine("Type team number of the team you want to manage\n");
            int chosenTeam = Int32.Parse(Console.ReadLine());

            var managedTeam = teams.ElementAtOrDefault(chosenTeam - 1);
            Console.WriteLine("You chose : {0} {1}, {2}", chosenTeam, managedTeam, managedTeam.TeamID);
            Console.ReadKey();

            return managedTeam;
        }
    }
}
