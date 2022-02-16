using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace UIConsole
{
    public class Manager
{
        static readonly HttpClient client = new();

        public static async Task<ManagerRepository?> GetManager()
        {
            //client.BaseAddress = new Uri("Https://localhost:5001/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var streamTaskGetManager = client.GetStreamAsync("https://localhost:5001/api/Manager/GetManager/Bumpa");

            var manager = await JsonSerializer.DeserializeAsync<ManagerRepository>(await streamTaskGetManager);

            if (manager == null)
            {
                return default;
            }

            return manager;
        }
    }
}
