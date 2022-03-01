using ApiClient;
using Application;
using Domain.Entities;
using Mapster;

namespace UIConsole;

public class ShowTeam
{
    private List<TeamJsonDto> allteams = new();

    public async Task<TeamJsonDto> GetTeams()
    {
        allteams = await TeamClient.GetAllTeams();

        if (allteams == null)
        {
            return default;
        }

        var allteamsDto = allteams.Adapt<TeamJsonDto>();

        return (TeamJsonDto)allteamsDto;
    }
}
