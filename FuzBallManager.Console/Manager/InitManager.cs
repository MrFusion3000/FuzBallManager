using ApiClient;
using Application.Responses;

namespace UIConsole.Manager;

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

    public static async Task<List<PlayerResponse>> SetupManagedTeam(ManagerResponse newmanager)
    {
        var ManagedTeam = await TeamClient.GetTeamById(newmanager.ManagingTeamID);
        Console.WriteLine("Managed Team fetched...");
        var AllPlayers = await PlayerClient.GetAllPlayers();
        Console.WriteLine("All Players fetched...");
        var ManagedTeamPlayers = AllPlayers.FindAll(p => p.TeamID == ManagedTeam.TeamID).ToList();
        //var ManagedTeamPlayers = await PlayerClient.GetPlayersByTeamName(ManagedTeam.TeamName);
        Console.WriteLine("Managed Team Players filtered...");

        //Clean all players fom roster
        foreach (var player in AllPlayers)
        {
            player.InManagedTeam = false;
            player.Injured = false;
            player.Playing = false;
            await PlayerClient.Update(player.PlayerID, player);
        }
        Console.WriteLine("Roster initiated...");

        //Get list of players for managed team (already refactored this 3 times :-) )
        //Randomize 10 player numbers to join team from ManagedTeamplayers
        Random rndPlayer = new();
        int AddUp = 10;

        for (int i = 0; i < AddUp; i++)
        {
            var JoinTeam = ManagedTeamPlayers[rndPlayer.Next(1, ManagedTeamPlayers.Count)];

            JoinTeam.InManagedTeam = true;

            //TODO Refactor to update range
            await PlayerClient.Update(JoinTeam.PlayerID, JoinTeam);
        }

        ManagedTeamPlayers =await PlayerClient.GetPlayersByManagedTeam(true);
        //Console.ReadKey();
        return ManagedTeamPlayers;
    }
}
