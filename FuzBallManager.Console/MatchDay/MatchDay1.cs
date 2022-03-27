using ApiClient;
using Application.Responses;
using UIConsole.Manager;

namespace UIConsole.MatchDay
{
    public class MatchDay1
    {
        //TODO BUG Can't run Match if not first visited Sell/List players ?!!?
        public static async void ShowPreMatch(ManagerResponse manager, List<PlayerResponse> managedTeamPlayers)
        {
            var fixture = await FixtureClient.GetNextFixture(false);
            var HomeTeam = await TeamClient.GetTeamById(fixture.HomeTeamId);
            var AwayTeam = await TeamClient.GetTeamById((Guid)fixture.AwayTeamId);
            var HomeTeamPlayers = await PlayerClient.GetPlayersByManagedTeam(true);
            var AwayTeamPlayers = await PlayerClient.GetPlayersByTeamName(AwayTeam.TeamName);
            await RndAwayTeam.RandomizeTeam(AwayTeamPlayers);
            var AwayTeamAllPlayers = await PlayerClient.GetPlayersByTeamName(AwayTeam.TeamName);
            AwayTeamPlayers = AwayTeamAllPlayers
           .FindAll(p => p.TeamID == AwayTeam.TeamID)
           .Where(p => p.TeamName == AwayTeam.TeamName)
           .ToList();


            int HomeTeamStats =0;
            int AwayTeamStats=0;

            foreach (var player in HomeTeamPlayers)
            {
                HomeTeamStats += player.PlayerStats.Value;
            }

            foreach (var player in AwayTeamPlayers)
            {
                AwayTeamStats += player.PlayerStats.Value;
            }

            Console.Clear();
            ConsoleKeyInfo menuChoice;

            Console.WriteLine($"\n\n\t\t{HomeTeam.TeamName}\t{AwayTeam.TeamName}");
            Console.WriteLine($"\nStats\t\t{HomeTeamStats}\t{AwayTeamStats}");
            Console.WriteLine("League Pos.\t\t 0\t0");
            while (true)
            {
                menuChoice = Console.ReadKey(true); //TODO Change to readline, restric to 2 char input?

                switch (menuChoice.Key)
                {
                    //case ConsoleKey.Escape:
                    //    ShowMenu.ShowTopMenu(manager, managedTeamPlayers);
                    //    break;
                    case ConsoleKey.Spacebar:
                        MatchDay2.PickTeam(manager, managedTeamPlayers);
                        break;
                }
            }
        }
    }
}
