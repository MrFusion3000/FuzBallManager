using System.Net.Http.Headers;
using System.Text.Json;
using UIConsole;

namespace ConsoleClient;
class Program
{
    static readonly HttpClient client = new();
    static async Task Main(string[] args)
    {
        var teams = await ProcessRepositories();

        if (teams != null)
        {
            Console.WriteLine(teams.FirstName + " " + teams.LastName + " " + teams.ManagingTeamName);
        }
        else
        {

        }
    }

    private static async Task<ManagerRepository?> ProcessRepositories()
    {
        //client.BaseAddress = new Uri("Https://localhost:5001/api");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        //var streamTaskGetTeams = client.GetStreamAsync("https://localhost:5001/api/Team");
        var streamTaskGetManager = client.GetStreamAsync("https://localhost:5001/api/Manager/GetManager/Bumpa");

        //var teams = await JsonSerializer.DeserializeAsync<List<TeamRepository>>(await streamTaskGetTeams);
        var managedTeam = await JsonSerializer.DeserializeAsync<ManagerRepository>(await streamTaskGetManager);

        if (managedTeam == null)
        {
            return default;
        }

        return managedTeam;
    }
}