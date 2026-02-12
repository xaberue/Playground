using Hangfire;
using Microsoft.Extensions.Hosting;

namespace Xelit3.Playground.Scheduling.HangfireDemo;

public class HangfireRecurringJobScheduler : IHostedService
{
    private readonly IRecurringJobManager _recurringJobManager;
    private readonly ILogger<HangfireRecurringJobScheduler> _logger;

    public HangfireRecurringJobScheduler(IRecurringJobManager recurringJobManager, ILogger<HangfireRecurringJobScheduler> logger)
    {
        _recurringJobManager = recurringJobManager;
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("Registering recurring Hangfire jobs...");

        // Schedule ExampleJob.Execute to run every day at 2:00 AM
        _recurringJobManager.AddOrUpdate<ExampleJob>(
            "daily-example-job",
            job => job.Execute("Hosted Service"),
            Cron.Daily(2)
        );

        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
