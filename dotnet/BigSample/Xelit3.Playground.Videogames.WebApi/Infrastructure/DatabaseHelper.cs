using Microsoft.EntityFrameworkCore;

namespace Xelit3.Playground.Videogames.WebApi.Infrastructure;

public static class DatabaseHelper
{

    public static void ApplyMigrations(this IApplicationBuilder app)
    {
        using var scope = app.ApplicationServices.CreateScope();
        using var dbContext = scope.ServiceProvider.GetRequiredService<VideogamesDbContext>();

        dbContext.Database.Migrate();
    }
}
