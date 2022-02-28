using ApiClient;
using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class FixtureClient : BaseClient
{
    private static Url GetFixtureClient() => GetClient().AppendPathSegment("Fixture");

    public static async Task<List<Fixture>> GetAllFixtures()
    {
        return await GetFixtureClient().GetJsonAsync<List<Fixture>>();
    }

}