using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Videogames.WebApi.Models;

namespace Xelit3.Playground.Videogames.WebApi.Infrastructure;

public class VideogamesDbContext : DbContext
{

    public DbSet<Videogame> Videogames { get; set; }


    public VideogamesDbContext(DbContextOptions options)
        : base(options)
    { }

}
