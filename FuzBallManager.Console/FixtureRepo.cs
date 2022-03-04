//using ApiClient;
//using Application.Responses;
//using Domain.Entities;
//using Mapster;

//namespace UIConsole;

//public class FixtureRepo
//{
//    private FixtureJsonDto fixture = new();

//    public async Task<FixtureJsonDto> GetFixture(Guid id)
//    {
//        fixture = await FixtureClient.GetFixtureById(id);

//        if (fixture == null)
//        {
//            return default;
//        }

//        var fixtureDto = fixture.Adapt<FixtureJsonDto>();

//        return fixtureDto;
//    }

//    internal static async Task GetAllFixtures()
//    {
//        await FixtureClient.GetAllFixtures();
//    }

//    public static async Task Create(FixtureResponse fixture)
//    {
//        var newFixture = fixture.Adapt<Fixture>();

//         newFixture = new Fixture()
//        {
//            //FixtureID = newfixture.FixtureID,
//            HomeTeamId = newFixture.HomeTeamId,
//            AwayTeamId = newFixture.AwayTeamId,
//            HomeTeamScore = newFixture.HomeTeamScore,
//            AwayTeamScore = newFixture.AwayTeamScore,
//            Attendance = newFixture.Attendance,
//            FixtureDate = newFixture.FixtureDate,
//            Played = newFixture.Played
//        };

//        await FixtureClient.Create(newFixture);
//    }
//}
