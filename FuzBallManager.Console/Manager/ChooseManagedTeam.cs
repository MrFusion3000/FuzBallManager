using Application.Responses;

namespace UIConsole
{
    public class ChooseManagedTeam
    {
        public static TeamResponse ChooseTeam(List<TeamResponse> teams)
        {
            bool success = false;
            TeamResponse managedTeam = null;

            while (!success)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n  Type team number of the team you want to\n  manage");
                Console.SetCursorPosition(2,23);
                //Console.ForegroundColor= ConsoleColor.White;
                string userInput = Console.ReadLine();
                success = int.TryParse(userInput, out int chosenTeam);

                managedTeam = teams.ElementAtOrDefault(chosenTeam - 1);

                //Console.WriteLine("  You chose : {0} {1}", chosenTeam, managedTeam);
            }

            return managedTeam;

        }
    }
}
