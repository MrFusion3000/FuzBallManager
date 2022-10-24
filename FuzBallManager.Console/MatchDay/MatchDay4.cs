using ApiClient;
using Application.Commands;
using Application.Responses;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace UIConsole.MatchDay
{
    public class MatchDay4
    {
        //public static FixtureResponse LatestFixture { get; set; }
        //TODO PopularScore for Attendance and Player offers

        public static async Task ShowGameStats()
         {
            var LatestFixture = await FixtureClient.GetNextFixture(false);

            var GameScore = MatchDay4.GameCalc();
            var Attendance = MatchDay4.Attendance();

            //Update the latest  match results
            var FixtureCmd = new UpdateFixtureCommand 
            {
                FixtureID = LatestFixture.FixtureID,
                FixtureDate = LatestFixture.FixtureDate,
                HomeTeamId = LatestFixture.HomeTeamId,
                AwayTeamId = LatestFixture.AwayTeamId,
                HomeTeamScore = GameScore.Item1,
                AwayTeamScore = GameScore.Item2,
                Attendance = Attendance,
                Played = true 
            };
            
            await FixtureClient.Update(LatestFixture.FixtureID, FixtureCmd );

            Console.Clear();

            Console.ForegroundColor = ConsoleColor.Magenta;

            //TODOHIGH Save score to DB Teams, not only the Fixture 

            Console.WriteLine($" {GameScore.Item1} - {GameScore.Item2}");

            var menuchoice = Console.ReadKey();

            if (menuchoice.Key == ConsoleKey.Spacebar)
            {
                //await ShowMenu.ShowTopMenu();
                //await MatchDay3.PreGameTeamStats();
                
            }
        }

        private static Tuple<int, int> GameCalc()
        {
            int HomeTeamScore = 0;
            int AwayTeamScore = 0;

            //TODOHIGH Calc match outcome
            //HomeTeamStats
            //AwayTeamStats
            //Time = 90 min
            //TODOHIGH Rnd no of possible scoring situations
            Random ScoringRounds = new Random();
            Random Goal = new();

            int PossibleScoringRounds = ScoringRounds.Next(0, 10);
            int GoalInNet = 0;
            for (int i = 0; i < PossibleScoringRounds; i++)
            {
                GoalInNet = Goal.Next(0, 2);
                HomeTeamScore += GoalInNet;
            }

            PossibleScoringRounds = ScoringRounds.Next(0, 10);
            for (int i = 0; i < PossibleScoringRounds; i++)
            {
                GoalInNet = Goal.Next(0, 2);
                AwayTeamScore += GoalInNet;
            }

            //TODOHIGH Based on Team Stats randomize which team gets the goal chance
            //TODOHIGH Save scores to db

            //TODONTH Rnd - injuries, yellow card, red card (each action recalculates the Team Stats)

            return Tuple.Create(HomeTeamScore, AwayTeamScore);

        }

        private static int Attendance()
        {
            Random People = new();

            var Attendance = People.Next(0,50000);
            return Attendance;
        }

        private static int CalcAGoal()
        {
            int Goal = 0;

            //1.0 TeamInPossession #True(Home) / #False(Away)

            //bool Posession = true;

            //1.1 RND passes before shot #Int
            //Loop
            //1.2 Who passes - Rnd TeamPlayer
            //1.3 RND pass success #True(Goto 1.4) / #False (Goto 1.1 with changed team)  Posession = !Posession;

            //1.4 Who recieves pass
            //1.5 Shot on goal
            //1.6 Goal? True/False
            //Start over 1.0 

            return Goal;
        }

    }
}
