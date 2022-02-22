using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CalcMatchResults
    {
        public static int CalcHomeTeamScore ()
        {
            Random score = new();
            int TeamScore = score.Next(0, 10);

            return TeamScore;
        }

        public static int CalcAwayTeamScore()
        {
            Random score = new();
            int TeamScore = score.Next(0,10);

            return TeamScore;
        }

        public static (int,int) MatchResult ()
        {
            (int, int)? FinalMatchResult = (0, 0);

            return ((int, int))FinalMatchResult;
        }
    }
}
