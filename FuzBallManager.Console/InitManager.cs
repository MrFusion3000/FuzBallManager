using ApiClient;
using Application.Responses;

namespace UIConsole;

public class InitManager
{

    public static async Task Create(ManagerResponse newmanager)
    {
        var newPlayerManager = new ManagerResponse()
        {
            Name = newmanager.Name,
            //LastName = newmanager.LastName,
            DateOfBirth = DateTime.UtcNow,
            Score = 0,
            Bank = 50000,
            ManagingTeamID = newmanager.ManagingTeamID,
            ManagingTeamName = null
        };

        await ManagerClient.Create(newPlayerManager);
    }

    public static async Task SetupManagedTeam(ManagerResponse newmanager)
    {
        var ManagedTeam = await TeamClient.GetTeamById(newmanager.ManagingTeamID);
        var ManagedTeamPlayers = await PlayerClient.GetPlayersByTeamName(ManagedTeam.TeamName);

        //Get list of players for managed team
        //Randomize 11 player numbers to join team from ManagedTeamplayers (ManagedTeamPlayer.count)
        Random rndPlayer = new();

        // Create List to save the 11 TeamPlayers in
        for (int i = 0; i < 9; i++)
        {
            var JoinTeam = ManagedTeamPlayers[rndPlayer.Next(1,11)];
            //TODO Check if player already in team (InManagedTeam = true)
            JoinTeam.InManagedTeam = true;

            Console.WriteLine($"Name: {JoinTeam.PlayerLastName}, {JoinTeam.InManagedTeam}");
        }

        //Save Team Id to each Player
        //TODO Change Player Entity: Add  

        Console.ReadKey();

    }
}
