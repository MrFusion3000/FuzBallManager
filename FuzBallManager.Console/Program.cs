﻿namespace UIConsole;
class Program
{
    //static readonly HttpClient client = new();
    static async Task Main(string[] args)
    {
        var manager = await Manager.GetManager();

        if (manager != null)
        {
            Console.WriteLine(manager.FirstName + " " + manager.LastName);
            Console.SetCursorPosition(40, 0);
            Console.WriteLine(manager.ManagingTeamName);
            Console.WriteLine("---------------------------------------------------------------------------------");
        }
        else
        {

        }

        var teams = await Teams.GetAllTeams();

        int i = 2;
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