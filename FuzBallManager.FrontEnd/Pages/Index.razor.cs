
namespace FuzBallManager.FrontEnd.Pages;

public partial class Manager
{
    private ManagerResponse Manager = new ();
    private List<ManagerResponse> Managers = new List<ManagerResponse>();

    [Inject]
    protected IManager ManagerApiService { get; set; }

    private async Task HandleValidSubmit()
    {
        Manager = await ManagerClient.GetManagerByName("Nico");
    }

    private void HandleValidSubmit() { }
}