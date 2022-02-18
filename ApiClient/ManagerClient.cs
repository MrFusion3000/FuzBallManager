using ApiClient;
using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class ManagerClient : BaseClient
{
    private static Url GetManagerClient() => GetClient().AppendPathSegment("Manager");

    public static async Task<Manager> GetManagerByLastName(string lastname)
    {
        //return await GetRoomClient().AppendPathSegment("GetByIdAndDateTime").SetQueryParams(new { id, queryDatee }).GetJsonAsync<RoomDto>();
        return await GetManagerClient().AppendPathSegment("GetManager").AppendPathSegment(lastname).GetJsonAsync<Manager>();
    }

    //public async Task<Manager> GetManagerAsync()
    //{
    //    return await GetManagerClient().GetJsonAsync<Manager>();
    //}
}