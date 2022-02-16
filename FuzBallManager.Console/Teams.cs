using System.Net.Http.Headers;
using System.Text.Json;


namespace UIConsole
{
    public class Teams
    {
        static readonly HttpClient client = new();

        public static async Task<List<TeamRepository>?> GetAllTeams()
        {
            //client.BaseAddress = new Uri("Https://localhost:5001/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTaskGetTeams = client.GetStreamAsync("https://localhost:5001/api/Team");

            var teams = await JsonSerializer.DeserializeAsync<List<TeamRepository>>(await streamTaskGetTeams);

            if (teams == null)
            {
                return null;
            }

            return teams;
        }
    }
}
