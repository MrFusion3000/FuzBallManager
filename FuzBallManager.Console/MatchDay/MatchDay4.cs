using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole.MatchDay
{
    public class MatchDay4
    {
        public static async Task ShowGameStats()
        {
            var GameScore = MatchDay4.GameCalc();

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($" {GameScore.Item1} - {GameScore.Item2}");

            var menuchoice = Console.ReadKey();

            if (menuchoice.Key == ConsoleKey.Spacebar)
            {
                await ShowMenu.ShowTopMenu();
                //await MatchDay3.PreGameTeamStats();
            }
        }

        private static Tuple<int, int> GameCalc()
        {
            int HomeTeamScore = 2;
            int AwayTeamScore = 1;

            //TODOHIGH Calc match outcome

            //HomeTeamStats
            //AwayTeamStats
            //Time = 90 min
            //TODOHIGH Rnd no of possible scoring situations
            //TODOHIGH Based on Team Stats randomize which team gets the goal chance
            //TODOHIGH Save scores to db
            //TODONTH Rnd - injuries, yellow card, red card (each action recalculates the Team Stats)

            return Tuple.Create(HomeTeamScore, AwayTeamScore);
        }

    }
}
