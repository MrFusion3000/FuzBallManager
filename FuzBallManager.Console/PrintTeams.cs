using Application.Responses;

namespace UIConsole
{
    public class PrintTeams
    {
        public static void PrintTeamsToConsole(List<TeamResponse> teams)
        {
            //Teams prints
            int i = 1;

            Console.Clear();
            Console.WriteLine("CHOOSE TEAM TO MANAGE :\n");
            Console.WriteLine("NUMBER \t\tNAME");
            foreach (var team in teams)
            {
                Console.Write(" " + i + "\t\t{0}", team.TeamName + "\n");
                i++;
            }
        }
    }
}
