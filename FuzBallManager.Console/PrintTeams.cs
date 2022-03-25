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
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" CHOOSE TEAM TO MANAGE :\n");
            Console.WriteLine(" NUMBER \tNAME");
            Console.ForegroundColor = ConsoleColor.White;

            //TODO set parameters for paging in interval of 16
            List<TeamResponse> teamPageChunk = (List<TeamResponse>)teams.GetRange(0,16);
            foreach (var team in teamPageChunk)
            {
                Console.Write("  " + i + "\t\t{0}", team.TeamName + "\n");
                i++;
            }
        }
    }
}
