namespace UIConsole;
class Program
{
    static async Task Main(string[] args)
    {
        ShowManager NewManager = new();

        Console.Write("Enter Manager Firstname: ");
        string firstname = Console.ReadLine();
        Console.Write("Enter Manager Lastname: ");
        string lastname = Console.ReadLine();

        var manager = await NewManager.GetManager(lastname);

        if (manager != null)
        {
            Console.Write("Manager exists: " + manager.FirstName + " " + manager.LastName);
            Console.SetCursorPosition(40, Console.CursorTop);
            Console.WriteLine(manager.ManagingTeamName);
            Console.WriteLine("---------------------------------------------------------------------------------");

        }
        else
        {
            PrintTeams printTeams = new ();
            await PrintTeams.PrintTeamsToConsole(manager);
            //Console.Write("Choose team:");
            //string choosenTeam = Console.ReadLine();
        }

        


    }
}