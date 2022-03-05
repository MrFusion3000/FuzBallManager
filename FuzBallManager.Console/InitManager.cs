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
}
