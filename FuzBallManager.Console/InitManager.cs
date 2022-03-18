using ApiClient;
using Application.Responses;

namespace UIConsole;

//TODO Rethink structure (ex. load data into memory once and save only after each fixture)

public class InitManager
{
    public static async Task CreateNewManager(ManagerResponse newmanager)
    {
        var newPlayerManager = new ManagerResponse()
        {
            Name = newmanager.Name,
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

        //Clean all players fom roster
        foreach (var player in ManagedTeamPlayers)
        {
            player.InManagedTeam = false;
            await PlayerClient.Update(player.PlayerID, player);

            //***Only for Dev***
            //Console.WriteLine($"Name: {player.PlayerLastName}, {player.InManagedTeam}");
            //***
        }

        //***Only for Dev***
        //Console.WriteLine(ManagedTeamPlayers.Count(c => c.InManagedTeam == true));
        //***

        //Get list of players for managed team
        //Randomize 11 player numbers to join team from ManagedTeamplayers
        Random rndPlayer = new();

        //if player already been randomized to team (InManagedTeam = true) iterate until count = 11
        while (ManagedTeamPlayers.Count(m => m.InManagedTeam == true) <= 9)
        {
            var JoinTeam = ManagedTeamPlayers[rndPlayer.Next(1, ManagedTeamPlayers.Count)];
            JoinTeam.InManagedTeam = true;

            //Save Team Id to each Player 
            //TODO Change to update range
            await PlayerClient.Update(JoinTeam.PlayerID, JoinTeam);

            //***Only for dev
            //Console.WriteLine($"Name: {JoinTeam.PlayerLastName}, {JoinTeam.InManagedTeam}");
            //***
        }

        Console.ReadKey();

    }
}
