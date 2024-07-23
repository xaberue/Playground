using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.API.GraphQL.Queries;
using Xelit3.Playground.API.Shared.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDataContext>(opt =>
{
    opt.UseSqlite("Data Source=ToDoDatabase.db");
});

builder.Services
    .AddGraphQLServer()
    .AddQueryType<TodoQueries>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapGraphQL();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
