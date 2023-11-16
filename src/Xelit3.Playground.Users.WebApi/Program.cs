using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Users.WebApi.Infrastructure;
using Xelit3.Playground.Users.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UsersDbContext>(options => options.UseInMemoryDatabase("Users"));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/users", (UsersDbContext dbContext) => 
{ 
    var users = dbContext.Users.ToListAsync();

    return Results.Ok(users);
})
.WithName("GetUsers")
.WithOpenApi();

app.MapGet("/users/{id}", (int id, UsersDbContext dbContext) =>
{
    var user = dbContext.Users.FindAsync(id);

    return Results.Ok(user);
})
.WithName("GetUser")
.WithOpenApi();

app.MapPost("/users", (CreateUserDto userDto, UsersDbContext dbContext) =>
{
    var user = new User(userDto.Name, userDto.Surname, userDto.Email, userDto.Password, userDto.BirthDate);
    
    dbContext.Users.Add(user);
    dbContext.SaveChanges();

    return Results.Created();
})
.WithName("CreateUser")
.WithOpenApi();

app.MapPut("/users", async (UpdateUserDto userDto, UsersDbContext dbContext) =>
{
    var user = await dbContext.Users.FindAsync(userDto.Id);
    
    if (user is null)
    {
        return Results.NotFound();
    }
    
    user.Update(userDto.Name, userDto.Surname, userDto.Email, userDto.BirthDate);
    
    dbContext.Users.Update(user);
    dbContext.SaveChanges();
    
    return Results.Ok();
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
    dbContext.SaveChanges();
    
    return Results.NoContent();
})
.WithName("DeleteUser")
.WithOpenApi();

app.Run();
