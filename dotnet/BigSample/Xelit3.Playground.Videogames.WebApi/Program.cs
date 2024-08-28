using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Videogames.WebApi.Dtos;
using Xelit3.Playground.Videogames.WebApi.Infrastructure;
using Xelit3.Playground.Videogames.WebApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VideogamesDbContext>(x => 
{
    var connectionString = builder.Configuration.GetConnectionString("SqlServerConnectionString");
    x.UseSqlServer(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.ApplyMigrations();
}

app.UseHttpsRedirection();

var group = app.MapGroup("api");

group.MapGet("/all", (VideogamesDbContext dbContext) =>
{
    var all = dbContext.Videogames.AsAsyncEnumerable();

    return Results.Ok(all);
});

group.MapGet("/{id}", async (int id, VideogamesDbContext dbContext) =>
{
    var entity = await dbContext.Videogames.FindAsync(id);

    return entity is null ? Results.NotFound() : Results.Ok(entity);
});

group.MapPost("", async (VideogameCreationDto creationDto, VideogamesDbContext dbContext) => 
{
    var entity = new Videogame(creationDto.Name, creationDto.Publisher, creationDto.YearReleased, creationDto.Genre);

    await dbContext.AddAsync(entity);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/{entity.Id}", entity.ToDto());
});

group.MapPut("", async (VideogameEditionDto editionDto, VideogamesDbContext dbContext) =>
{
    var entity = await dbContext.Videogames.FindAsync(editionDto.Id);

    if (entity is null)
        return Results.NotFound();

    entity.Update(editionDto.Name, editionDto.Publisher, editionDto.YearReleased, editionDto.Genre);

    await dbContext.SaveChangesAsync();

    return Results.Ok(entity.ToDto());
});

group.MapDelete("/{id}", async (int id, VideogamesDbContext dbContext) =>
{
    var entity = await dbContext.Videogames.FindAsync(id);

    if (entity is null)
        return Results.NotFound();

    dbContext.Remove(entity);
    await dbContext.SaveChangesAsync();

    return Results.NoContent();
});

app.Run();