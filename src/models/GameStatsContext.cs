using Microsoft.EntityFrameworkCore;

public class GameStatsContext : DbContext
{
    public GameStatsContext(DbContextOptions<GameStatsContext> options)
        : base(options)
    {
    }

    public DbSet<GameStats> GameStatsItems { get; set; }
}
