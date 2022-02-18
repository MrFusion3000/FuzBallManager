using ApiClient;
using Domain.Entities;
using Mapster;

namespace UIConsole;

public class ShowManager
{
    //static readonly HttpClient client = new(); //refactored to class lib ApiClient
    //public readonly ManagerClient managerClient = new(); //refactored
    private Manager? playermanager = new();

    public async Task<ManagerRepository?> GetManager(string lastname)
    {
        //Refactored
        //client.BaseAddress = new Uri("Https://localhost:5001/api");
        //client.DefaultRequestHeaders.Accept.Clear();
        //client.DefaultRequestHeaders.Accept.Add(
        //    new MediaTypeWithQualityHeaderValue("application/json"));

        //string clientBaseAddress = client.BaseAddress.ToString() + "/Manager/GetManager/" + lastname;
        //var streamTaskGetManager = client.GetStreamAsync(clientBaseAddress);

        //var manager = await JsonSerializer.DeserializeAsync<ManagerRepository>(await streamTaskGetManager);

        //playermanager = await managerClient.GetManagerByLastName(lastname);

        playermanager = await ManagerClient.GetManagerByLastName(lastname);

        if (playermanager == null)
        {
            return default;
        }

        var playermanagerDto = playermanager.Adapt<ManagerRepository>();

        return playermanagerDto;
    }
}
