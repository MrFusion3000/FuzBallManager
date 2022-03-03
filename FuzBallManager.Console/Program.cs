using ApiClient;
using Application;

namespace UIConsole;
class Program
{
    static async Task Main(string[] args)
    {
        // Player Init Manager: FirstName, LastName, Managing Team (Default values: ManagerID: New Guid, DateOfBirth: Today, Score:0, Bank:50000)  
        ManagerJsonDto showManager = await CreateManager.CreatePlayerManagerAsync();

        //Init 
        await CalcFixtures.CalcSeasonFixturesAsync(showManager);


    }
}