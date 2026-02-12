namespace Xelit3.Playground.Scheduling.HangfireDemo;

public class ExampleJob
{
    private readonly ILogger<ExampleJob> _logger;

    public ExampleJob(ILogger<ExampleJob> logger)
    {
        _logger = logger;
    }

    public void Execute(string from)
    {
        _logger.LogInformation("Executing ExampleJob from {from} at {Time}", from, DateTimeOffset.Now);
        // Simulate some work
        Thread.Sleep(1000);
        _logger.LogInformation("Finished executing from {from} ExampleJob at {Time}", from, DateTimeOffset.Now);
    }
}
