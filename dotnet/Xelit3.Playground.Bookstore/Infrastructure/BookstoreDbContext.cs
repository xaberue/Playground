using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Domain.Models;

namespace Xelit3.Playground.Bookstore.Infrastructure;

public class BookstoreDbContext : DbContext
{

    public DbSet<Client> Clients { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Lend> Lends { get; set; }
    public DbSet<Purchase> Purchases { get; set; }


    public BookstoreDbContext(DbContextOptions options) 
        : base(options)
    { }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>(e => 
        {
            e.HasIndex(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();

            e.HasMany(p => p.Lends).WithOne(e => e.Client);
            e.HasMany(p => p.Purchases).WithOne(e => e.Client);
        });

        modelBuilder.Entity<Book>(e =>
        {
            e.HasIndex(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();

            e.HasMany(p => p.Purchases).WithMany(p => p.Books);
            e.HasMany(p => p.Lends).WithMany(p => p.Books);
        });

        modelBuilder.Entity<Lend>(e =>
        {
            e.HasIndex(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
        });

        modelBuilder.Entity<Purchase>(e =>
        {
            e.HasIndex(p => p.Id);
            e.Property(p => p.Id).ValueGeneratedOnAdd();
        });
    }

}
