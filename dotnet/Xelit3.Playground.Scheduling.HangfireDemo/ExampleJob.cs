namespace Xelit3.Playground.Scheduling.HangfireDemo;

public class ExampleJob
{
    private readonly ILogger<ExampleJob> _logger;

    public ExampleJob(ILogger<ExampleJob> logger)
    {
        _logger = logger;
    }

    public void Execute()
    {
        _logger.LogInformation("Executing ExampleJob at {Time}", DateTimeOffset.Now);
        // Simulate some work
        Thread.Sleep(1000);
        _logger.LogInformation("Finished executing ExampleJob at {Time}", DateTimeOffset.Now);
    }
}
