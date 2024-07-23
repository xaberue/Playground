using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.API.Shared.Models;

namespace Xelit3.Playground.API.Shared.Data;

public class AppIdentityDbContext : IdentityDbContext<AppUser> 
{

    public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options) 
        : base(options)
    { }
}
