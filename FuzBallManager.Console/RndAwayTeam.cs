using ApiClient;
using Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole
{
    internal class RndAwayTeam
    {
        internal static async Task RandomizeTeam(List<PlayerResponse> awayTeamPlayers)
        {
            var AwayTeamPlayers = awayTeamPlayers;

            //Get list of players for managed team (already refactored this 4 times :-) )
            //Randomize 11 player numbers to join team from ManagedTeamplayers
            Random rndPlayer = new();
            int AddUp = 11;
            List<int> UsedNumbs = new();

            for (int j = 0; j < AwayTeamPlayers.Count; j++)
            {
                UsedNumbs.Add(j);
            }

            int n = AwayTeamPlayers.Count;

            for (int i = 0; i < n - 1; i++)
            {
                int r = i + rndPlayer.Next(n - i);
                (UsedNumbs[i], UsedNumbs[r]) = (UsedNumbs[r], UsedNumbs[i]);
            }

            for (int i = 0; i < AddUp; i++)
            {
                var JoinTeam = AwayTeamPlayers[UsedNumbs[i]];
                //JoinTeam.InManagedTeam = true;
                JoinTeam.Playing = true;

                //TODO Refactor to update range
                await PlayerClient.Update(JoinTeam.PlayerID, JoinTeam);
            }
        }
    }
}
