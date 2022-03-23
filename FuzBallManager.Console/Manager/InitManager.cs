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

        Console.WriteLine("Managed Team Players filtered...");

        await InitPlayers.InitThePlayers(AllPlayers);

        Console.WriteLine("Roster initiated...");

        await RndTeam.RandomizeTeam(ManagedTeamPlayers);

        ManagedTeamPlayers = await PlayerClient.GetPlayersByManagedTeam(true);
        return ManagedTeamPlayers;
    }
}
