using ApiClient;
using Application;
using Domain.Entities;
using Mapster;

namespace UIConsole;

public class ShowManager
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
}
