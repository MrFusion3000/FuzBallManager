using Application.Responses;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class ManagerClient : BaseClient
{
    private static Url GetManagerClient() => GetClient().AppendPathSegment("Manager");

    public static async Task<ManagerResponse> GetManagerByName(string name)
    {
        return await GetManagerClient().AppendPathSegment("GetManager").AppendPathSegment(name).GetJsonAsync<ManagerResponse>();
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