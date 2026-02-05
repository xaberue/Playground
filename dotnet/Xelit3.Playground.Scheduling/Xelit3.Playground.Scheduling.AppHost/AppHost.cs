var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.Xelit3_Playground_Scheduling_HangfireDemo>("hangfire")
    .WithUrl("/hangfire/servers", "Hangfire Dashboard");

builder.Build().Run();
