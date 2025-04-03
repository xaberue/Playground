using Microsoft.Extensions.Caching.Hybrid;
using Xelit3.Playground.Caching.Hybrid.ApiService;
using Xelit3.Playground.Caching.ServiceDefaults;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddProblemDetails();

builder.Services.AddOpenApi();

builder.Services.AddMemoryCache();
builder.AddRedisDistributedCache("cache");

builder.Services.AddSingleton<CustomCacheService>();
builder.Services.AddHostedService<ScheduledBackgroundService>();

var app = builder.Build();

app.UseExceptionHandler();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.MapGet("/last-execution", async (CustomCacheService customCache) =>
{
    var lastExecution = await customCache.GetLastExecTimeAsync();

    return Results.Ok(lastExecution);
})
.WithName("GetLastExecution");

app.MapDefaultEndpoints();

app.Run();