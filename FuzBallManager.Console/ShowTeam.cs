using ApiClient;
using Application;
using Application.Responses;
using Domain.Entities;
using Mapster;

namespace UIConsole;

public class ShowTeam
{
    private List<TeamResponse> allteams = new();

    public async Task<List<TeamResponse>> GetTeams()
    {
        allteams = await TeamClient.GetAllTeams();

        if (allteams == null)
        {
            return default;
        }

        return allteams;
    }
}
