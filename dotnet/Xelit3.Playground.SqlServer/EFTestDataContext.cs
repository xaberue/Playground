using Microsoft.EntityFrameworkCore;
using Xelit3.Tests.Model.Models;
using Xelit3.Tests.Model.Views;

namespace Xelit3.Playground.SqlServer;

public class EFTestDataContext : DbContext
{

    private readonly string _connectionString;


    public DbSet<Person<Guid>> Persons { get; set; }
    public DbSet<Address<Guid>> Addresses { get; set; }
    public DbSet<Country<Guid>> Countries { get; set; }
    public DbSet<City<Guid>> Cities { get; set; }
    public DbSet<Post<Guid>> Posts { get; set; }
    public DbSet<PersonSimpleView> PersonSimpleQuery { get; private set; }
    public DbSet<PersonFullView> PersonFullQuery { get; private set; }


    public EFTestDataContext(string connectionString = "Data Source=localhost;Initial Catalog=Test;Integrated Security=True;TrustServerCertificate=True")
    {
        _connectionString = connectionString;
    }


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString)
            .LogTo(Console.WriteLine)
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PersonSimpleView>().ToView("PersonsSimpleView").HasKey(x => x.Id);
        modelBuilder.Entity<PersonFullView>().ToView("PersonsFullView").HasNoKey();

        #region Test Model GUID

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

        #endregion

        #region Test Model INT

        modelBuilder.Entity<Person<int>>(entity =>
        {
            entity.ToTable($"Persons_int");
            entity.HasOne(x => x.Origin).WithMany(x => x.Citizens).HasForeignKey("OriginId").OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Address<int>>(entity =>
        {
            entity.ToTable($"Addresses_int");
            entity.HasOne(x => x.City).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(x => x.Person).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Country<int>>(entity =>
        {
            entity.ToTable($"Countries_int");
            entity.HasMany(x => x.Cities).WithOne(x => x.Country);
        });

        modelBuilder.Entity<City<int>>(entity =>
        {
            entity.ToTable($"Cities_int");
            entity.HasOne(x => x.Country).WithMany(x => x.Cities).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Post<int>>(entity =>
        {
            entity.ToTable($"Posts_int");
            entity.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey("AuthorId").OnDelete(DeleteBehavior.NoAction);
        });

        #endregion

        #region Test Model LONG

        modelBuilder.Entity<Person<long>>(entity =>
        {
            entity.ToTable($"Persons_long");
            entity.HasOne(x => x.Origin).WithMany(x => x.Citizens).HasForeignKey("OriginId").OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Address<long>>(entity =>
        {
            entity.ToTable($"Addresses_long");
            entity.HasOne(x => x.City).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.NoAction);
            entity.HasOne(x => x.Person).WithMany(x => x.Addresses).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Country<long>>(entity =>
        {
            entity.ToTable($"Countries_long");
            entity.HasMany(x => x.Cities).WithOne(x => x.Country);
        });

        modelBuilder.Entity<City<long>>(entity =>
        {
            entity.ToTable($"Cities_long");
            entity.HasOne(x => x.Country).WithMany(x => x.Cities).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Post<long>>(entity =>
        {
            entity.ToTable($"Posts_long");
            entity.HasOne(x => x.Author).WithMany(x => x.Posts).HasForeignKey("AuthorId").OnDelete(DeleteBehavior.NoAction);
        });

        #endregion


        base.OnModelCreating(modelBuilder);
    }
}
