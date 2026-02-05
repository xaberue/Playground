using Hangfire;
using System.Net;
using Xelit3.Playground.Scheduling.HangfireDemo;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

builder.Services.AddOpenApi();

builder.Services.AddSingleton<ExampleJob>();

builder.Services.AddHangfire(conf =>
    conf
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseSqlServerStorage(builder.Configuration.GetConnectionString("hangfire-db"))
);

builder.Services.AddHangfireServer(x => 
x.SchedulePollingInterval = TimeSpan.FromSeconds(1));  //Don't do this in PROD, we are requesting each second knowing the jobs to be executed. By default is 15 seconds.

// Register hosted service that sets up a scheduled recurring job with Hangfire
builder.Services.AddHostedService<HangfireRecurringJobScheduler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/enqueue", (IBackgroundJobClient jobClient) =>
{
    jobClient.Enqueue(() => Console.WriteLine("Enqueueing a -> Hello from Hangfire!"));

    return Results.Ok();
});

app.MapGet("/schedule", (IBackgroundJobClient jobClient) =>
{
    jobClient.Schedule(() => Console.WriteLine("Scheduling a delayed job -> Hello from Hangfire!"), TimeSpan.FromSeconds(10));

    return Results.Ok();
});

app.MapGet("/schedule-class-process", (IBackgroundJobClient jobClient) =>
{
    jobClient.Schedule<ExampleJob>(x => x.Execute("API invokation"), TimeSpan.FromSeconds(10));

    return Results.Ok();
});

app.MapGet("/background", (IRecurringJobManager jobManager) =>
{
    jobManager.AddOrUpdate(
        "background-process", 
        () => Console.WriteLine("Scheduling a recurrent job -> Hello from Hangfire!"),
        "*/5 * * * *" //Every five mintues
        );

    return Results.Ok();
});

app.UseHangfireDashboard(); //Dasbhoard -> https://localhost:7023/hangfire/servers

app.MapDefaultEndpoints();

app.Run();

