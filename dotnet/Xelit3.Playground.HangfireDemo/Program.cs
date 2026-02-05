using Hangfire;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddHangfire(conf => 
    conf
        .UseSimpleAssemblyNameTypeSerializer()
        .UseRecommendedSerializerSettings()
        .UseInMemoryStorage()
);

builder.Services.AddHangfireServer(x => 
x.SchedulePollingInterval = TimeSpan.FromSeconds(1));  //Don't do this in PROD, we are requesting each second knowing the jobs to be executed. By default is 15 seconds.

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/job", (IBackgroundJobClient jobClient) =>
{
    jobClient.Enqueue(() => Console.WriteLine("Hello from Hangfire!"));

    return Results.Ok();
});

app.UseHangfireDashboard(); //Dasbhoard -> https://localhost:7023/hangfire/servers

app.Run();

