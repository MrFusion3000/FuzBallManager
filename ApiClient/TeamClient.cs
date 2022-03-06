using ApiClient;
using Application;
using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class TeamClient : BaseClient
{

    //TODO add Async to Task names
    private static Url GetTeamClient() => GetClient().AppendPathSegment("Team");

    public static async Task<List<TeamResponse>> GetAllTeams()
    {
        return await GetTeamClient().GetJsonAsync<List<TeamResponse>>();
    }

    public static async Task<TeamResponse> GetTeamById(Guid teamId)
    {
        return await GetTeamClient().AppendPathSegment("GetTeamByTeamId").AppendPathSegment(teamId).GetJsonAsync<TeamResponse>();
    }

}