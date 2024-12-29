using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi;
using Microsoft.OpenApi.Models;
using Scalar.AspNetCore;
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

    /*
     * Swagger integration
     * This is the only thing needed if you want to support the current OpenAPI specification with Swagger
     * https://localhost:7079/swagger/index.html
     */
    app.UseSwaggerUI(opt =>
    {
        opt.SwaggerEndpoint("/openapi/v1.json", "xaberue OpenAPI Demo");

    });

    /* 
     * Scalar integration
     * The basic doesn't need any parametrization 
     * https://localhost:7079/scalar/v1
     */
    app.MapScalarApiReference(opt => 
    {
        opt
            .WithTitle("xaberue OpenAPI Demo")
            .WithTheme(ScalarTheme.Kepler)
            .WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient);
    });
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
    .WithTags("GET");

app.Run();


/// <summary>
/// WeatherForecast model
/// </summary>
/// <param name="Date">Date of the forecast</param>
/// <param name="TemperatureC">Temperature measured in Celsius</param>
/// <param name="Summary">Brief summary about the day's weather</param>
internal record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
