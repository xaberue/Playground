var builder = DistributedApplication.CreateBuilder(args);

var schedulingSqlServer = builder.AddSqlServer("scheduling-sql")
    .WithLifetime(ContainerLifetime.Persistent);

var hangfireDb = schedulingSqlServer.AddDatabase("hangfire-db");

builder.AddProject<Projects.Xelit3_Playground_Scheduling_HangfireDemo>("hangfire")
    .WithUrl("/hangfire/servers", "Hangfire Dashboard")
    .WithReference(hangfireDb)
    .WaitFor(hangfireDb);

builder.Build().Run();
