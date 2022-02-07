using Domain.Entities;

namespace Infrastructure.Data
{
    public static class DbInitializer
    {
        public static void Initialize(PlayerContext playerContext)
        {
            if (playerContext.Players.Any())
            {
                return; //Db has been seeded
            }

            var team = new Domain.Entities.Team
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

            playerContext.Teams.Add(team);
            playerContext.SaveChanges();

            var players = new Player[]
            {
                new Player
                {
                PlayerFirstName = "Arthur",
                PlayerLastName = "Albinston",
                DateOfBirth = DateTime.Parse("14/07/1957"),
                PlayerPosition = "DF", //Defence
                PlayerStats = 50,
                TeamID = Guid.Parse("D58D5254-7889-47BA-A63A-5B5C79E02F34")
                },
            new Player
            {
                PlayerFirstName = "Gary",
                PlayerLastName = "Baily",
                DateOfBirth = DateTime.Parse("09/08/1958"),
                PlayerPosition = "GK", //Goal
                PlayerStats = 50,
                TeamID = Guid.Parse("D58D5254-7889-47BA-A63A-5B5C79E02F34")
            },
            new Player
            {
                PlayerFirstName = "Peter",
                PlayerLastName = "Barnes",
                DateOfBirth = DateTime.Parse("10/06/1957"),
                PlayerPosition = "FW", //Forward
                PlayerStats = 50,
                TeamID = Guid.Parse("D58D5254-7889-47BA-A63A-5B5C79E02F34")
            },
            new Player
            {
                PlayerFirstName = "Mark",
                PlayerLastName = "Dempsey",
                DateOfBirth = DateTime.Parse("14/01/1964"),
                PlayerPosition = "MF", //MidField
                PlayerStats = 50,
                TeamID = Guid.Parse("D58D5254-7889-47BA-A63A-5B5C79E02F34")
            }
            };

            for (int i = 0; i > players.Length; i++)
            {
                playerContext.Players.Add(players[i]);
            }
            playerContext.SaveChanges();
        }
    }
}
