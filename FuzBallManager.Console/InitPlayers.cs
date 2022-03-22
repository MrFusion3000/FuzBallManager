using ApiClient;
using Application.Responses;

namespace UIConsole
{
    public class InitPlayers
    {
        public static async void InitThePlayers(List<PlayerResponse> allplayers)
        {
            var AllPlayers = allplayers;
            //TODO ** Set properties to default **
            // InManagedTeam = false
            // Injured = false
            // Playing = false
            foreach (var player in AllPlayers)
            {
                player.InManagedTeam = false;
                player.Injured = false;
                player.Playing = false;
                await PlayerClient.Update(player.PlayerID, player);
            }
        }
        //TODO PlayerShirtNo (function to RND a shirtNo only once per team, or just number them top to bottom 1--x)
        //TODO Init all players PlayerStats  with RND (50-80)
        //TODO Set Player Value to (5000 * Player Stats)

    }
}
