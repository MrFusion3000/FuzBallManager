using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FuzBallManager.Domain
{
    public class Team
    {
        public int TeamId { get; set; }
        public string TeamName { get; set; } = "Team Null";
        //public List<Player>? Players { get; set; }
        public int Points { get; set; }

        public static Team Create(int teamId, string teamName, int points)
        {
            return new Team()
            {
                TeamId = teamId,
                TeamName = teamName,
                Points = points
                //Players = players
            };
        }
    }
}
