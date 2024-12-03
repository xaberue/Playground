using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using System.ComponentModel;

var builder = WebApplication.CreateBuilder(args);

//Cache mechanism
builder.Services.AddOutputCache(options =>
{
    options.AddBasePolicy(policy => policy.Expire(TimeSpan.FromMinutes(10)));
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(options =>
{
    ////In case of forcing a different OpenApi specification
    //options.OpenApiVersion = OpenApiSpecVersion.OpenApi2_0;

    options.AddDocumentTransformer((document, context, cancellationToken) =>
    {
        document.Info.Contact = new OpenApiContact
        {
            Name = "xaberue",
            Email = "xaberue@mail.com"
        };
        return Task.CompletedTask;
    });

    ////An operation transformer, for example, adding auth
    //options.AddOperationTransformer((operation, context, cancellationToken) =>
    //{
    //    if (context.Description.ActionDescriptor.EndpointMetadata.OfType<IAuthorizeData>().Any())
    //    {
    //        operation.Security = [new() { ["Bearer"] = [] }];
    //    }
    //    return Task.CompletedTask;
    //});

    //////An schema transformer, for example for decimals
    //options.AddSchemaTransformer((schema, context, cancellationToken) =>
    //{
    //    if (context.JsonTypeInfo.Type == typeof(decimal))
    //    {
    //        // default schema for decimal is just type: number.  Add format: decimal
    //        schema.Format = "decimal";
    //    }
    //    return Task.CompletedTask;
    //});
});

var app = builder.Build();

app.UseOutputCache();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi().CacheOutput();
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
.WithSummary("Getting weather forecast")
.WithDescription("Getting all weather forecast")
.WithTags("GET");

app.MapGet("/hello/{name}", 
        ([Description("The name of the person to greet.")] string name) => $"Hello, {name}!")
    .WithSummary("Get a personalized greeting")
    .WithDescription("This endpoint returns a personalized greeting.")
    .WithTags("Greetings");

app.Run();

internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
