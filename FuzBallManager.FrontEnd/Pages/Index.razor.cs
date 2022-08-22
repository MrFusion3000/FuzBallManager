using System;
using Microsoft.AspNetCore.Components;

namespace FuzBallManager.FrontEnd.Pages
{

    public partial class ManagerShow
    {
        //private Manager = 5;
        public readonly ManagerClient Manager = new ();
        private List<ManagerResponse> Managers = new List<ManagerResponse>();

        //[Inject]
        //protected IManager ManagerApiService { get; set; }

        //private async Task HandleValidSubmit()
        //{
        //    Manager = await ManagerClient.GetManagerByName("Nico");
        //}

        //private void HandleValidSubmit() { }
        

    }

}