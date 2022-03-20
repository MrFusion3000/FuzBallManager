using Domain.Entities;

namespace Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(FBMContext FBMContext)
        {
            FBMContext.Database.EnsureCreated();

            if (FBMContext.Players.Any())
            {
                return; //Db has been seeded
            }

            var team = new Team
            {
                //TeamID = Guid.Parse("D58D5254-7889-47BA-A63A-5B5C79E02F34"),
                TeamName = "Manchester United",
                Points = 0,
                Wins = 0,
                Draws = 0,
                Lost = 0,
                GoalsForward = 0,
                GoalsAgainst = 0,
                Stadium = "Old Trafford"
            };

            FBMContext.Teams.Add(team);
            FBMContext.SaveChanges();

            Guid getTeam = team.TeamID;

            var players = new Player[]
            {
                new Player
                {
                PlayerFirstName = "Arthur",
                PlayerLastName = "Albinston",
                DateOfBirth = DateTime.Parse("14/07/1957"),
                PlayerPosition = "DF", //Defence
                PlayerStats = 50,
                TeamID = getTeam
                },
            new Player
            {
                PlayerFirstName = "Gary",
                PlayerLastName = "Baily",
                DateOfBirth = DateTime.Parse("09/08/1958"),
                PlayerPosition = "GK", //Goal
                PlayerStats = 50,
                TeamID = getTeam
            },
            new Player
            {
                PlayerFirstName = "Peter",
                PlayerLastName = "Barnes",
                DateOfBirth = DateTime.Parse("10/06/1957"),
                PlayerPosition = "FW", //Forward
                PlayerStats = 50,
                TeamID = getTeam
            },
            new Player
            {
                PlayerFirstName = "Mark",
                PlayerLastName = "Dempsey",
                DateOfBirth = DateTime.Parse("14/01/1964"),
                PlayerPosition = "MF", //MidField
                PlayerStats = 50,
                TeamID = getTeam
            }
            };

            for (int i = 0; i > players.Length; i++)
            {
                FBMContext.Players.Add(players[i]);
            }
            FBMContext.SaveChanges();
        }
    }
}
