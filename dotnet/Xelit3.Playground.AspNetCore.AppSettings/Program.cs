#if !DEBUG
using Azure.Identity;
#endif
using Xelit3.Playground.AspNetCore.AppSettings;

var builder = WebApplication.CreateBuilder(args);

#if !DEBUG
var keyVaulUrl = builder.Configuration["AzureKeyVaultUrl"];
if(keyVaulUrl == null)
    throw new ArgumentNullException("AzureKeyVaultUrl must be configured for the given environment");

builder.Configuration.AddAzureKeyVault(new Uri(keyVaulUrl), new DefaultAzureCredential());
#endif

var settings = builder.Configuration.GetSection("ExternalServices").Get<Settings>();

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

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
