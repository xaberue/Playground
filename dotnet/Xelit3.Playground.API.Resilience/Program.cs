using Polly;
using Polly.Registry;
using Polly.Retry;
using Xelit3.Playground.API.Resilience;

var builder = WebApplication.CreateBuilder(args);

var openWeatherApiKey = builder.Configuration["OpenWeatherApiKey"];

builder.Services.AddResiliencePipeline("OpenWeatherApiPipeline", x =>
{
    x.AddRetry(new RetryStrategyOptions
    {
        ShouldHandle = new PredicateBuilder().Handle<Exception>(),
        Delay = TimeSpan.FromSeconds(2),
        MaxRetryAttempts = 3,
        BackoffType = DelayBackoffType.Exponential,
        UseJitter = true
    })
    .AddTimeout(TimeSpan.FromSeconds(15));
});

builder.Services.AddHttpClient("OpenWeatherApi", opt =>
{
    opt.BaseAddress = new Uri("https://api.openweathermap.org/data/2.5/");
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

app.MapGet("/weather/{city}", async (IHttpClientFactory httpClientFactory, ResiliencePipelineProvider<string> resiliencePipelineProvider, string city) =>
{
    var client = httpClientFactory.CreateClient("OpenWeatherApi");
    var pipeline = resiliencePipelineProvider.GetPipeline("OpenWeatherApiPipeline");

    var response = await pipeline.ExecuteAsync(async ct => await client.GetAsync($"weather?q={city}&appid={openWeatherApiKey}", ct));

    return await response.Content.ReadFromJsonAsync<WeatherResponse>();
})
.WithName("GetWeather")
.WithOpenApi();

app.Run();