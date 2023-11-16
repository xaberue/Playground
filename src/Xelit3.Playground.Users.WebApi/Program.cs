using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Users.WebApi.Endpoints;
using Xelit3.Playground.Users.WebApi.Infrastructure;

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

app.SetupEndpoints();

app.Run();
