using Xelit3.Playground.API.Resilience;

var builder = WebApplication.CreateBuilder(args);

var openWeatherApiKey = builder.Configuration["OpenWeatherApiKey"];

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

app.MapGet("/weather/{city}", async (IHttpClientFactory httpClientFactory, string city) =>
{
    var client = httpClientFactory.CreateClient("OpenWeatherApi");
    var response = await client.GetAsync($"weather?q={city}&appid={openWeatherApiKey}");

    return await response.Content.ReadFromJsonAsync<WeatherResponse>();
})
.WithName("GetWeather")
.WithOpenApi();

app.Run();