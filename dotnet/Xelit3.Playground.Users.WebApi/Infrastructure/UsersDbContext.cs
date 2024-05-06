using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Users.WebApi.Models;

namespace Xelit3.Playground.Users.WebApi.Infrastructure;


public class UsersDbContext : DbContext
{
    public UsersDbContext(DbContextOptions<UsersDbContext> options) 
        : base(options)
    { }

    public DbSet<User> Users { get; set; }
}

