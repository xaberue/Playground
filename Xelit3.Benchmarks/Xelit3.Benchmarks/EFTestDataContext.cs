using Microsoft.EntityFrameworkCore;
using Xelit3.Tests.Model;

namespace Xelit3.Benchmarks;

public class EFTestDataContext : DbContext
{
    
    private readonly string _connectionString
        = "";

    public EFTestDataContext() { }

    public EFTestDataContext(string connectionString)
    {
        _connectionString = connectionString;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person<Guid>>(entity => 
        {
            entity.ToTable($"Persons_Guid");            
            entity.HasOne(x => x.Origin).WithMany(x => x.Citizens).HasForeignKey("OriginId").OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Address<Guid>>(entity =>
        {
            entity.ToTable($"Addresses_Guid");
            entity.HasOne(x => x.City).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(x => x.Person).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Country<Guid>>(entity =>
        {
            entity.ToTable($"Countries_Guid");
            entity.HasMany(x => x.Cities).WithOne(x => x.Country);
        });

        modelBuilder.Entity<City<Guid>>(entity =>
        {
            entity.ToTable($"Cities_Guid");
            entity.HasOne(x => x.Country).WithMany(x => x.Cities).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Post<Guid>>(entity =>
        {
            entity.ToTable($"Posts_Guid");
            entity.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey("AuthorId").OnDelete(DeleteBehavior.NoAction);
        });

        base.OnModelCreating(modelBuilder);
    }
}
