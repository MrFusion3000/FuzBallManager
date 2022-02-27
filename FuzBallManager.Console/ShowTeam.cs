using ApiClient;
using Domain.Entities;
using Mapster;

namespace UIConsole;

public class ShowTeam
{
    private List<Team> allteams = new();

    public async Task<TeamDto> GetTeams()
    {


        allteams = await TeamClient.GetAllTeams();

        if (allteams == null)
        {
            return default;
        }

        var allteamsDto = allteams.Adapt<TeamDto>();

        return (TeamDto)allteamsDto;
    }
}
