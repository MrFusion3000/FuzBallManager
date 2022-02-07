using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class PlayerContext : DbContext
    {
        public PlayerContext(DbContextOptions<PlayerContext> options) : base(options) 
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
    }
}
