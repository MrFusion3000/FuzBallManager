﻿using Application.Commands;
using Application.Responses;
using Domain.Entities;
using Flurl;
using Flurl.Http;
using Mapster;

namespace ApiClient;
public class FixtureClient : BaseClient
{
    #region API Calls
    private static Url GetFixtureClient() => GetClient().AppendPathSegment("Fixture");

    public static async Task<List<FixtureResponse>> GetAllFixtures()
    {
        return await GetFixtureClient().GetJsonAsync<List<FixtureResponse>>();
    }

    public static async Task<FixtureResponse> GetFixtureById(Guid fixtureId)
    {
        return await GetFixtureClient().AppendPathSegment(fixtureId).GetJsonAsync<FixtureResponse>();
    }

    public static async Task<FixtureResponse> GetNextFixture(bool played)
    {
        return await GetFixtureClient().AppendPathSegment("GetNextFixture").AppendPathSegment(played).GetJsonAsync<FixtureResponse>();
    }

    public static async Task Create(FixtureResponse newFixture)
    {
        var fixture = newFixture.Adapt<Fixture>();

        await GetFixtureClient().PostJsonAsync(fixture);
    }

    public static async Task<Guid> Update(Guid fixtureId, UpdateFixtureCommand fixture)
    {
        await GetFixtureClient().AppendPathSegment("UpdateFixture").AppendPathSegment(fixture.FixtureID).PutJsonAsync(fixture);

        return fixtureId;
    }

    public static async Task<Guid> Delete(Guid id)
    {
        await GetFixtureClient().AppendPathSegment("DeleteFixture").AppendPathSegment(id).DeleteAsync();

        return id;
    }
    #endregion
}