using Microsoft.Extensions.Caching.StackExchangeRedis;
using Xelit3.Playground.Caching.Fusion.ApiService;
using ZiggyCreatures.Caching.Fusion;
using ZiggyCreatures.Caching.Fusion.Backplane.StackExchangeRedis;
using ZiggyCreatures.Caching.Fusion.Serialization.SystemTextJson;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();

//builder.Services.AddFusionCache();

var cacheConnectionString = builder.Configuration.GetConnectionString("cache");

//builder.Services.AddOpenTelemetry()
//  // SETUP TRACES
//  .WithTracing(tracing => tracing
//    .AddFusionCacheInstrumentation()
//    .AddConsoleExporter() // OR ANY ANOTHER EXPORTER
//  )
//  // SETUP METRICS
//  .WithMetrics(metrics => metrics
//    .AddFusionCacheInstrumentation()
//    .AddConsoleExporter() // OR ANY ANOTHER EXPORTER
//  );

builder.Services.AddFusionCache()
    .WithOptions(options =>
    {
        options.DistributedCacheCircuitBreakerDuration = TimeSpan.FromSeconds(2);

        // CUSTOM LOG LEVELS
        options.FailSafeActivationLogLevel = LogLevel.Debug;
        options.SerializationErrorsLogLevel = LogLevel.Warning;
        options.DistributedCacheSyntheticTimeoutsLogLevel = LogLevel.Debug;
        options.DistributedCacheErrorsLogLevel = LogLevel.Error;
        options.FactorySyntheticTimeoutsLogLevel = LogLevel.Debug;
        options.FactoryErrorsLogLevel = LogLevel.Error;
    })
    .WithDefaultEntryOptions(new FusionCacheEntryOptions
    {
        // CACHE DURATION
        Duration = TimeSpan.FromMinutes(1),

        // FAIL-SAFE OPTIONS
        IsFailSafeEnabled = true,
        FailSafeMaxDuration = TimeSpan.FromHours(2),
        FailSafeThrottleDuration = TimeSpan.FromSeconds(30),

        // FACTORY TIMEOUTS
        FactorySoftTimeout = TimeSpan.FromMilliseconds(100),
        FactoryHardTimeout = TimeSpan.FromMilliseconds(1500), //SyntheticTimeoutException 

        // JITTERING
        JitterMaxDuration = TimeSpan.FromSeconds(2)
    })
    .WithDistributedCache(
        new RedisCache(new RedisCacheOptions() { Configuration = cacheConnectionString })
    )
    //.WithBackplane(
    //    new RedisBackplane(new RedisBackplaneOptions() { Configuration = "CONNECTION STRING" })
    //)
    .WithSerializer(new FusionCacheSystemTextJsonSerializer());


builder.Services.AddSingleton<WeatherService>();

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/weatherforecast", (IFusionCache cache, WeatherService weatherService) =>
{
    var forecasts = cache.GetOrSet(
        $"WEATHER",
        _ => weatherService.GetWeatherForecasts()
    );

    //With specific cache live time
    //var forecasts = cache.GetOrSet(
    //    $"WEATHER",
    //    _ => weatherService.GetWeatherForecasts(),
    //    options => options.SetDuration(TimeSpan.FromMinutes(1))
    //);

    if (forecasts is null)
        return Results.NotFound();

    return Results.Ok(forecasts);
});

app.Run();
