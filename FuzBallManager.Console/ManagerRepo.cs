using ApiClient;
using Application;
using Application.Responses;
using Domain.Entities;
using Mapster;

namespace UIConsole;

public class ManagerRepo
{
    private ManagerResponse playermanager = new();

    public async Task<ManagerResponse> GetManager(string lastname)
    {
        playermanager = await ManagerClient.GetManagerByLastName(lastname);

        if (playermanager == null)
        {
            return default;
        }

        //var playermanagerDto = playermanager.Adapt<ManagerJsonDto>();

        return playermanager;
    }

    public static async Task Create(ManagerResponse newmanager, TeamResponse managingTeam)
    {
        var newPlayerManager = new ManagerResponse()
        {
            FirstName = newmanager.FirstName,
            LastName = newmanager.LastName,
            DateOfBirth = DateTime.UtcNow,
            Score = 0,
            Bank = 50000,
            ManagingTeamID = managingTeam.TeamID,
            ManagingTeamName = null
        };

        await ManagerClient.Create(newPlayerManager);
    }
}
