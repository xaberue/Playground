using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Users.WebApi.Infrastructure;

namespace Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration
{
    public class DbContextHelper
    {
        public static UsersDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<UsersDbContext>();
            optionsBuilder.UseInMemoryDatabase("Users");
            var context = new UsersDbContext(optionsBuilder.Options);

            return context;
        }
    }
}
