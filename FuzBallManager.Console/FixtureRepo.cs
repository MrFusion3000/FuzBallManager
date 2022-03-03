using ApiClient;
using Application;
using Application.Responses;
using Domain.Entities;
using Mapster;

namespace UIConsole;

public class FixtureRepo
{
    private FixtureJsonDto fixture = new();

    public async Task<FixtureJsonDto> GetFixture(Guid id)
    {
        fixture = await FixtureClient.GetFixtureById(id);

        if (fixture == null)
        {
            return default;
        }

        var fixtureDto = fixture.Adapt<FixtureJsonDto>();

        return fixtureDto;
    }

    public static async Task Create(FixtureJsonDto newfixture, TeamJsonDto managingTeam, TeamJsonDto opponentTeam)
    {
        var newFixture = new Fixture()
        {
            FixtureID = newfixture.FixtureID,
            HomeTeamId = newfixture.HomeTeamId,
            AwayTeamId = newfixture.AwayTeamId,
            HomeTeamScore = newfixture.HomeTeamScore,
            AwayTeamScore = newfixture.AwayTeamScore,
            Attendance = newfixture.Attendance,
            FixtureDate = DateTime.UtcNow,
            Played = newfixture.Played         
        };

        await FixtureClient.Create(newFixture);
    }
}
