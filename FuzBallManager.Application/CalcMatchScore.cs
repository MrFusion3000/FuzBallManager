using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public class CalcMatchScore
    {
        public static int CalcTeamScore()
        {
            Random score = new();
            int TeamScore = score.Next(0, 10);

            //TODO Make algorithm to make it harder to score higher number of goals
            //TODO Take into account Team strength (Energy, Morale, Defence, Midfield, Attack)

            return TeamScore;
        }

        public static (int,int) MatchScore ()
        {
            (int, int) FinalMatchResult = (CalcTeamScore(), CalcTeamScore());

            return FinalMatchResult;
        }

        public static (int,int) MatchResult(Tuple<int, int> finalMatchResult)
        {
            int homeTeamScore = finalMatchResult.Item1;
            int awayTeamScore = finalMatchResult.Item2;
            int homeTeamPoints = 0;
            int awayTeamPoints = 0;

            if (homeTeamScore > awayTeamScore)
            {
                homeTeamPoints = 3;
            }
            else if(homeTeamScore < awayTeamScore)
            {
                awayTeamPoints = 3;
            }
            else
            {
                homeTeamPoints = 2;
                awayTeamPoints = 2;
            }

            return (homeTeamPoints, awayTeamPoints);
        }
    }
}
