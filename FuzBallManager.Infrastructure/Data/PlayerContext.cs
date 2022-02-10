using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class FBMContext : DbContext
    {
        public FBMContext(DbContextOptions<FBMContext> options) : base(options) 
        {
        }
        public DbSet<Player> Players { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }
}
