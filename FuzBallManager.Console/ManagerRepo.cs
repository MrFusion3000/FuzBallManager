using ApiClient;
using Application;
using Domain.Entities;
using Mapster;

namespace UIConsole;

public class ManagerRepo
{
    private ManagerJsonDto playermanager = new();

    public async Task<ManagerJsonDto> GetManager(string lastname)
    {
        playermanager = await ManagerClient.GetManagerByLastName(lastname);

        if (playermanager == null)
        {
            return default;
        }

        var playermanagerDto = playermanager.Adapt<ManagerJsonDto>();

        return playermanagerDto;
    }

    public static async Task Create(ManagerJsonDto newmanager, TeamJsonDto managingTeam)
    {
        var newPlayerManager = new Manager()
        {
            FirstName = newmanager.FirstName,
            LastName = newmanager.LastName,
            DateOfBirth = DateTime.UtcNow,
            Score = 0,
            Bank = 50000,
            ManagingTeamID = managingTeam.TeamID
        };

        await ManagerClient.Create(newPlayerManager);
    }
}
