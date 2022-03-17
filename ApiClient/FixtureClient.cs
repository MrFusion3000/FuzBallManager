using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;
using Mapster;

namespace ApiClient;
public class FixtureClient : BaseClient
{
    private static Url GetFixtureClient() => GetClient().AppendPathSegment("Fixture");

    public static async Task<List<FixtureResponse>> GetAllFixtures()
    {
        return await GetFixtureClient().GetJsonAsync<List<FixtureResponse>>();
    }

    public static async Task<FixtureResponse> GetFixtureById(Guid fixtureId)
    {
        return await GetFixtureClient().AppendPathSegment(fixtureId).GetJsonAsync<FixtureResponse>();
    }

    public static async Task Create(FixtureResponse newFixture)
    {
        var fixture = newFixture.Adapt<Fixture>();

        await GetFixtureClient().PostJsonAsync(fixture);
    }
}