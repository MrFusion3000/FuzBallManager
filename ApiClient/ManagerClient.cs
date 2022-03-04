using Application;
using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class ManagerClient : BaseClient
{
    private static Url GetManagerClient() => GetClient().AppendPathSegment("Manager");

    public static async Task<ManagerResponse> GetManagerByLastName(string lastname)
    {
        return await GetManagerClient().AppendPathSegment("GetManager").AppendPathSegment(lastname).GetJsonAsync<ManagerResponse>();
    }
    public static async Task Create(ManagerResponse manager)
    {
        await GetManagerClient().PostJsonAsync(manager);
    }

    public static async Task Update(ManagerResponse manager)
    {
        await GetManagerClient().PutJsonAsync(manager);
    }

}