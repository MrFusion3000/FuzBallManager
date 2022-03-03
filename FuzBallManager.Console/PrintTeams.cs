using ApiClient;
using Application;
using Domain.Entities;

namespace UIConsole
{
    public class PrintTeams
    {
        public static void PrintTeamsToConsole(List<TeamJsonDto> teams)
        {
            //TODO Teams prints twice
            int i = 1;

            Console.WriteLine("CHOOSE TEAM TO MANAGE :\n");
            Console.WriteLine("NUMBER \t\tNAME");
            foreach (var team in teams)
            {
                //Console.SetCursorPosition(40, Console.CursorTop);
                Console.Write(" " + i + "\t\t{0}", team.TeamName + "\n");
                i++;
            }
        }
    }
}
