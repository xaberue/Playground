using Microsoft.EntityFrameworkCore;

namespace Xelit3.Playground.Scheduling.TickerqDemo;

public class AppDbContext : DbContext
{

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }

    public DbSet<User> Users { get; set; }
    public DbSet<Notification> Notifications { get; set; }
}
