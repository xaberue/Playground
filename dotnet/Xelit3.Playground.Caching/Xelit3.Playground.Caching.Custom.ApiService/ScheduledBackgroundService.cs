namespace Xelit3.Playground.Caching.Hybrid.ApiService;

public class ScheduledBackgroundService : BackgroundService
{
    private readonly ILogger<ScheduledBackgroundService> _logger;
    private CustomCacheService _cache;

    public ScheduledBackgroundService(ILogger<ScheduledBackgroundService> logger, CustomCacheService cache)
    {
        _logger = logger;
        _cache = cache;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            var date = DateTimeOffset.Now;
            _logger.LogInformation("Background process running, The time is: {Time}", date);
            
            await _cache.SetLastExecTimeAsync(date);
            await Task.Delay(TimeSpan.FromMinutes(2), stoppingToken);
        }
    }
}