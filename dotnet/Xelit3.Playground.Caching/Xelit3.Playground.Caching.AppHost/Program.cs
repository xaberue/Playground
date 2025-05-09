var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache").WithRedisInsight();

var apiServiceCustom = builder.AddProject<Projects.Xelit3_Playground_Caching_Custom_ApiService>("apiservice-custom")
    .WithReference(cache);

var apiServiceFusion = builder.AddProject<Projects.Xelit3_Playground_Caching_Fusion_ApiService>("apiservice-fusion")
    .WithReplicas(2)
    .WithReference(cache);

var apiServiceHybrid = builder.AddProject<Projects.Xelit3_Playground_Caching_Hybrid_ApiService>("apiservice-hybrid")
    .WithReference(cache);

builder.Build().Run();
