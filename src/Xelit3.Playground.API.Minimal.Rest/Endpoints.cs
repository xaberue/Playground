using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.API.Minimal.Rest.Models;
using Xelit3.Playground.API.Shared.Data;
using Xelit3.Playground.API.Shared.Models;

namespace Xelit3.Playground.API.Minimal.Rest;

internal static class Endpoints
{

    internal static void MapEndpoints(this WebApplication app)
    {
        app.MapGet("/todos", (ToDoDataContext dbContext) =>
        {
            var todos = dbContext.ToDoItems
                .Select(x => new ToDoItemDto(x.Id, x.Title, x.Description, x.Status))
                .AsAsyncEnumerable();

            return todos;
        })
        .WithName("GetToDos")
        .WithOpenApi();


        app.MapPost("/todo", async (ToDoDataContext dbContext, ToDoItemCreationCommand command) =>
        {
            var entity = new ToDoItem(command.Title, command.Description);

            await dbContext.ToDoItems.AddAsync(entity);
            await dbContext.SaveChangesAsync();

            return Results.Created();
        })
        .WithName("CreateToDo")
        .WithOpenApi();

        app.MapPut("/todo", async (ToDoDataContext dbContext, ToDoItemEditionCommand command) =>
        {
            var entity = await dbContext.ToDoItems.FindAsync(command.Id);

            if (entity is null) return Results.NotFound();

            entity.Update(command.Title, command.Description);

            await dbContext.SaveChangesAsync();

            return Results.Ok();
        })
        .WithName("EditToDo")
        .WithOpenApi();

        app.MapPatch("/todo/status", async (ToDoDataContext dbContext, ToDoItemChangeStatusCommand command) =>
        {
            var entity = await dbContext.ToDoItems.FindAsync(command.Id);

            if(entity is null) return Results.NotFound();

            entity.ChangeStatus(command.Status);

            await dbContext.SaveChangesAsync();

            return Results.Ok();
        })
        .WithName("ChangeToDoStatus")
        .WithOpenApi();

        app.MapDelete("/todo", async (ToDoDataContext dbContext, int id) =>
        {
            var entity = await dbContext.ToDoItems.FindAsync(id);

            if (entity is null) return Results.NotFound();

            dbContext.Remove(entity);
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("DeleteToDo")
        .WithOpenApi();
    }

}
