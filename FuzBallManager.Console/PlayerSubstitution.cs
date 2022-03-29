using ApiClient;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole
{
    public class PlayerSubstitution
    {
        public static async Task PlayerSubstitute(List<PlayerResponse> players, int playerNo)
        {
            foreach (var player in players)
            {
                if (player.PlayerShirtNo == playerNo)
                {
                    player.Playing = !player.Playing;
                    await PlayerClient.Update(player.PlayerID, player);
                }
            }
        }
    }
}
