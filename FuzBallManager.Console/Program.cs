namespace UIConsole;
class Program
{
    static async Task Main(string[] args)
    {
        ShowManager NewManager = new();

        Console.WriteLine("Enter Manager Lastname:\n");
        string lastname = Console.ReadLine();

        var manager = await NewManager.GetManager(lastname);

        if (manager != null)
        {
            Console.WriteLine(manager.FirstName + " " + manager.LastName);
            Console.SetCursorPosition(40, 3);
            Console.WriteLine(manager.ManagingTeamName);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        else
        {

        }

        var teams = await Teams.GetAllTeams();

        int i = 6;
        foreach (var team in teams)
        {
            if (!team.TeamName.Contains(manager.ManagingTeamName))
            {
                Console.WriteLine(team.TeamName);
                Console.SetCursorPosition(40, i++);
                Console.WriteLine(team.Stadium);
            }
        }
    }
}