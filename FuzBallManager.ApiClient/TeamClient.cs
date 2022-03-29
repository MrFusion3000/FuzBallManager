using Application.Responses;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class TeamClient : BaseClient
{
    //TODOLow add Async to Task names
    private static Url GetTeamClient() => GetClient().AppendPathSegment("Team");

    public async Task<List<TeamResponse>> GetAllTeams()
    {
        return await GetTeamClient().GetJsonAsync<List<TeamResponse>>();
    }

    public async Task<TeamResponse> GetTeamById(Guid teamId)
    {
         return await GetTeamClient().AppendPathSegment("GetTeamByTeamId").AppendPathSegment(teamId).GetJsonAsync<TeamResponse>();
    }
}