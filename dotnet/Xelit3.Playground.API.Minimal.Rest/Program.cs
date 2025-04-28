using Microsoft.AspNetCore.Http.Json;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.API.Minimal.Rest;
using Xelit3.Playground.API.Shared.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ToDoDataContext>(opt =>
{
    opt.UseSqlite("Data Source=ToDoDatabase.db");
});

/*How to configure globally Serialization, different options*/
//builder.Services.Configure<JsonOptions>(options =>
//{
//    options.SerializerOptions.PropertyNamingPolicy = null;
//    options.SerializerOptions.WriteIndented = true;
//    options.SerializerOptions.PropertyNameCaseInsensitive = true;

//    //options.SerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
//});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseUnhandledExceptionHandler();

app.MapEndpoints();

app.Run();
