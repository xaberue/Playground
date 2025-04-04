namespace Xelit3.Playground.Caching.Fusion.ApiService;

public class WeatherService
{

    private int counter = 0;

    string[] summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };


    public WeatherForecast[] GetWeatherForecasts()
    {
        counter++;

        if(counter % 2 == 0)
            throw new Exception("Test exception, emulating erratic behaviour");

        return Enumerable.Range(1, 5).Select(index =>
            new WeatherForecast
            (
                DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                Random.Shared.Next(-20, 55),
                summaries[Random.Shared.Next(summaries.Length)]
            ))
            .ToArray();
    }
}
