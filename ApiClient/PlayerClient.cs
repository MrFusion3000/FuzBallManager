using ApiClient;
using Application;
using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class PlayerClient : BaseClient
{

    //TODO add Async to Task names
    private static Url GetPlayerClient() => GetClient().AppendPathSegment("Player");

    public static async Task<List<PlayerResponse>> GetAllPlayers()
    {
        return await GetPlayerClient().GetJsonAsync<List<PlayerResponse>>();
    }

    public static async Task<List<PlayerResponse>> GetAllPlayersByTeamName(string teamName)
    {
        return await GetPlayerClient().AppendPathSegment("GetByTeamName").AppendPathSegment(teamName).GetJsonAsync<List<PlayerResponse>>();
    }

    public static async Task<PlayerResponse> GetPlayerById(Guid playerId)
    {
        return await GetPlayerClient().AppendPathSegment("GetPlayerByPlayerId").AppendPathSegment(playerId).GetJsonAsync<PlayerResponse>();
    }

}