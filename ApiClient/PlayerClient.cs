using Application.Commands;
using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class PlayerClient : BaseClient
{
    //TODOLow add Async to Task names

    private static Url GetPlayerClient() => GetClient().AppendPathSegment("Player");

    public static async Task<List<PlayerResponse>> GetAllPlayers()
    {
        return await GetPlayerClient().GetJsonAsync<List<PlayerResponse>>();
    }

    public static async Task<List<PlayerResponse>> GetPlayersByTeamName(string teamName)
    {
        return await GetPlayerClient().AppendPathSegment("GetPlayersByTeamName").AppendPathSegment(teamName).GetJsonAsync<List<PlayerResponse>>();
    }

    public static async Task<PlayerResponse> GetPlayerById(Guid playerId)
    {
        return await GetPlayerClient().AppendPathSegment("GetPlayerByPlayerId").AppendPathSegment(playerId).GetJsonAsync<PlayerResponse>();
    }

    public static async Task<Guid> Update(Guid playerId, PlayerResponse player)
    {
        await GetPlayerClient().AppendPathSegment("UpdatePlayer").AppendPathSegment(player.PlayerID).PutJsonAsync(player);

        return playerId;
    }
}