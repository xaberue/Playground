using Serilog;
using Serilog.Exceptions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Host.UseSerilog((context, configuration) =>
{
    configuration
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails()
        .WriteTo.Console();
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", (ILoggerFactory loggerFactory) =>
{
    var logger = loggerFactory.CreateLogger("WeatherForecast");

    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();

    logger.LogInformation("Request finnished {PlaceHolderName:MMMM dd, yyyy}", DateTimeOffset.UtcNow);
    logger.LogInformation("Weather forecast response [ToString()]: {response}", forecast);
    logger.LogInformation("Weather forecast response [Serialization]: {@response}", forecast);

    try
    {
        throw new Exception("This is a test exception");
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Weather forecast error {message}", ex.Message);
    }
    return forecast;
})
.WithName("GetWeatherForecast");

app.Run();

public record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
