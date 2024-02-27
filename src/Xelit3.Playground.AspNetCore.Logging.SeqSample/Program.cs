using Microsoft.AspNetCore.Mvc;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Logging.AddJsonConsole();
builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        //.MinimumLevel.Debug()
        //.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails()
        .WriteTo.Seq("http://localhost:5341")
        .WriteTo.Console();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", ([FromServices] ILoggerFactory loggerFactory) =>
{    
    var logger = loggerFactory.CreateLogger("GetWeatherForecast");
    WeatherForecast[] forecasts = [];
    try
    {
        using (logger.BeginScope("User: {user}", "test@email.com"))
        {
            logger.LogInformation("Getting weather forecast");

            forecasts = Enumerable.Range(1, 5).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
                .ToArray();

            throw new Exception("This is a test exception simulating a real error");
        }        
    }
    catch (Exception ex)
    {
        logger.LogError(100, ex, "Error occured: {reason}", "unexpected reason");
    }
    return forecasts;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}