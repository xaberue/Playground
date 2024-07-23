using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Users.Shared.Models;
using Xelit3.Playground.Users.WebApi.Infrastructure;
using Xelit3.Playground.Users.WebApi.Models;

namespace Xelit3.Playground.Users.WebApi.Endpoints;


public static class EndpointsHelper
{
    internal static void SetupEndpoints(this WebApplication app)
    {
        app.MapGet("/users", async (UsersDbContext dbContext) =>
        {
            var users = await dbContext.Users
                .Select(x => new UserDto(x.Id, x.Name, x.Surname, x.Email, x.BirthDate, !x.IsUnder18(), x.Role))
                .ToListAsync();

            return Results.Ok(users);
        })
        .WithName("GetUsers")        
        .WithOpenApi();

        app.MapGet("/users/{id}", async (int id, UsersDbContext dbContext) =>
        {
            var entity = await dbContext.Users.FindAsync(id);

            if (entity is null)
            {
                return Results.NotFound();
            }
            var dto = new UserDto(entity.Id, entity.Name, entity.Surname, entity.Email, entity.BirthDate, !entity.IsUnder18(), entity.Role);

            return Results.Ok(dto);
        })
        .WithName("GetUser")
        .WithOpenApi();

        app.MapPost("/users", async (CreateUserDto userDto, UsersDbContext dbContext) =>
        {
            var entity = new User(userDto.Name, userDto.Surname, userDto.Email, userDto.Password, userDto.BirthDate);

            await dbContext.Users.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            var dto = new UserDto(entity.Id, entity.Name, entity.Surname, entity.Email, entity.BirthDate, !entity.IsUnder18(), entity.Role);

            return Results.Created("CreateUser", dto);
        })
        .WithName("CreateUser")
        .WithOpenApi();

        app.MapPut("/users", async (UpdateUserDto userDto, UsersDbContext dbContext) =>
        {
            var entity = await dbContext.Users.FindAsync(userDto.Id);

            if (entity is null)
            {
                return Results.NotFound();
            }

            entity.Update(userDto.Name, userDto.Surname, userDto.Email, userDto.BirthDate);

            await dbContext.SaveChangesAsync();

            var dto = new UserDto(entity.Id, entity.Name, entity.Surname, entity.Email, entity.BirthDate, !entity.IsUnder18(), entity.Role);

            return Results.Ok(dto);
        })
        .WithName("ModifyUser")
        .WithOpenApi();

        app.MapDelete("/users/{id}", async (int id, UsersDbContext dbContext) =>
        {
            var user = await dbContext.Users.FindAsync(id);

            if (user is null)
            {
                return Results.NotFound();
            }

            dbContext.Users.Remove(user);
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("DeleteUser")
        .WithOpenApi();
    }

}
