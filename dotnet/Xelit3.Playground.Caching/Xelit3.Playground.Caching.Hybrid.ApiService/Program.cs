using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Hybrid;
using System.Threading;
using Xelit3.Playground.Caching.Hybrid.ApiService;
using Xelit3.Playground.Caching.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.AddRedisDistributedCache("cache");
builder.Services.AddHybridCache(options =>
{
    options.DefaultEntryOptions = new HybridCacheEntryOptions
    {
        LocalCacheExpiration = TimeSpan.FromMinutes(60),
        Expiration = TimeSpan.FromMinutes(10)
    };
});

builder.Services.AddScoped<WeatherService>();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/weatherforecast", async (HybridCache cache, WeatherService service, CancellationToken cancellationToken) =>
{
    var forecasts = await cache.GetOrCreateAsync<WeatherForecast[]>("WEATHER_FORESCASTS", _ =>
        {
            return ValueTask.FromResult(service.GetWeatherForecasts());
        },
        tags: ["DOCTORS-GRID"],
        cancellationToken: cancellationToken
        );

    return forecasts;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.MapDefaultEndpoints();

app.Run();
