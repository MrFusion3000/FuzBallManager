namespace FuzBallManager.Domain
{
    public class Player
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; } = "Anony Mouse";
        public int PlayerPosition { get; set; }
        public int PlayerStats { get; set; }
    

    public static Player Create(int playerId, string playerName, int playerPosition, int playerStats)
    {
        return new Player
        {
            PlayerId = playerId,
            PlayerName = playerName,
            PlayerPosition = playerPosition,
            PlayerStats = playerStats
        };
    }
    }
}