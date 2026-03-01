using Microsoft.EntityFrameworkCore;
using TickerQ.Dashboard.DependencyInjection;
using TickerQ.DependencyInjection;
using TickerQ.EntityFrameworkCore.DbContextFactory;
using TickerQ.EntityFrameworkCore.DependencyInjection;
using Xelit3.Playground.Scheduling.TickerqDemo;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi();

builder.AddSqlServerDbContext<AppDbContext>("tickerq-db");

builder.Services.AddTickerQ(options =>
{
    // Core configuration
    options.ConfigureScheduler(schedulerOptions =>
    {
        schedulerOptions.MaxConcurrency = 10;
        schedulerOptions.NodeIdentifier = "notification-server";
    });

    options.SetExceptionHandler<NotificationExceptionHandler>();

    // Entity Framework persistence using built-in TickerQDbContext
    options.AddOperationalStore(efOptions =>
    {
        efOptions.UseTickerQDbContext<TickerQDbContext>(optionsBuilder =>
        {
            optionsBuilder.UseSqlServer(builder.Configuration.GetConnectionString("tickerq-db"));
        });
        efOptions.SetDbContextPoolSize(34);
    });

    // Dashboard
    options.AddDashboard(dashboardOptions =>
    {
        dashboardOptions.SetBasePath("/tickerq/dashboard");
        //dashboardOptions.WithBasicAuth("admin", "secure-password");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseTickerQ();

app.MapControllers();

app.MapDefaultEndpoints();

app.Run();