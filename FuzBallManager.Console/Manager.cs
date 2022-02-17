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

        public  async Task<ManagerRepository?> GetManager(string lastname)
        {

            client.BaseAddress = new Uri("Https://localhost:5001/api");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string clientBaseAddress = client.BaseAddress.ToString() + "/Manager/GetManager/" + lastname;
            var streamTaskGetManager = client.GetStreamAsync(clientBaseAddress);

            var manager = await JsonSerializer.DeserializeAsync<ManagerRepository>(await streamTaskGetManager);

            if (manager == null)
            {
                return default;
            }

            return manager;
        }
    }
}
