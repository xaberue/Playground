using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Users.WebApi.Endpoints;
using Xelit3.Playground.Users.WebApi.Infrastructure;

const string CORS_POLICY = "CorsPolicy";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<UsersDbContext>(options => options.UseInMemoryDatabase("Users"));

builder.Services.AddCors(options =>
{
    options.AddPolicy(CORS_POLICY, builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(CORS_POLICY);
app.SetupEndpoints();

app.Run();
