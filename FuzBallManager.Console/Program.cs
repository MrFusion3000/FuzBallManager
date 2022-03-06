using ApiClient;
using Application;
using Application.Responses;

namespace UIConsole;
class Program
{
    static async Task Main(/*string[] args*/)
    {
        // Player Init Manager: FirstName, LastName, Managing Team (Default values: ManagerID: New Guid, DateOfBirth: Today, Score:0, Bank:50000)  
        ManagerResponse NewManager = await CreateManager.CreatePlayerManagerAsync();

        //Init Season Fixtures (Home and Away Matches)
        await InitFixtures.CalcSeasonFixturesAsync(NewManager);

        await FixtureClient.GetAllFixtures();

    }
}