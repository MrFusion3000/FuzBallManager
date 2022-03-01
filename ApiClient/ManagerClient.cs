using ApiClient;
using Application;
using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class ManagerClient : BaseClient
{
    private static Url GetManagerClient() => GetClient().AppendPathSegment("Manager");

    public static async Task<ManagerJsonDto> GetManagerByLastName(string lastname)
    {
        return await GetManagerClient().AppendPathSegment("GetManager").AppendPathSegment(lastname).GetJsonAsync<ManagerJsonDto>();
    }
    public static async     Task
Create(Manager manager)
    {
        await GetManagerClient().PostJsonAsync(manager);
    }

}