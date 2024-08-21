using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.EFCore.WebApi.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<VideogamesDbContext>(x => 
{
    x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerConnectionString"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();