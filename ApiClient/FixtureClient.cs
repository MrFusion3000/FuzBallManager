using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;

namespace ApiClient;
public class FixtureClient : BaseClient
{
    private static Url GetFixtureClient() => GetClient().AppendPathSegment("Fixture");

    public static async Task<List<FixtureJsonDto>> GetAllFixtures()
    {
        return await GetFixtureClient().GetJsonAsync<List<FixtureJsonDto>>();
    }

    public static async Task<FixtureJsonDto> GetFixtureById(Guid fixtureId)
    {
        return await GetClient().GetJsonAsync<FixtureJsonDto>();
    }

    public static async Task Create(Fixture newFixture)
    {
        await GetFixtureClient().PostJsonAsync(newFixture);
    }
}