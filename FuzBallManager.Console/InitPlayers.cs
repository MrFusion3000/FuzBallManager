using ApiClient;
using Application.Responses;

namespace UIConsole
{
    public class InitPlayers
    {
        public static async Task InitThePlayers(List<PlayerResponse> allplayers)
        {
            var AllPlayers = allplayers;
            Random RndStats = new();
            PlayerClient playerClient = new();

            // ** Set properties to default **
            //PlayerShirtNo (function to RND a shirtNo only once per team)
            //Init all players PlayerStats  with RND (20-50)
            //Set Player Value to (500 * Player Stats)
            foreach (var player in AllPlayers)
            {
                if (player.InManagedTeam == true) player.InManagedTeam = false;
                if (player.Injured == true) player.Injured = false;
                if (player.Playing == true || player.Playing == null) player.Playing = false;
                //rnd PlayerStats
                if (player.PlayerStats == 0 || player.PlayerStats ==  null) player.PlayerStats = RndStats.Next(20,50);
                //TODO rnd Value based on PlayerStats
                if (player.Value == 0 || player.Value == null) player.Value = player.PlayerStats * 500;
                await playerClient.Update(player.PlayerID, player);
            }
        }
        

    }
}
