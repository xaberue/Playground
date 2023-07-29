using Xelit3.Playground.AspNetCore.DI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddTransient<ServiceImplementationA>();
builder.Services.AddTransient<ServiceImplementationB>();

builder.Services.AddTransient<ServiceResolver>(serviceProvider => implType =>
{
    return implType switch
    {
        ServiceImplementation.A => serviceProvider.GetService<ServiceImplementationA>()!,
        ServiceImplementation.B => serviceProvider.GetService<ServiceImplementationB>()!,
        _ => throw new ArgumentException("Invalid service type")
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/test-a", async (ServiceResolver serviceResolver) =>
{
    var service = serviceResolver(ServiceImplementation.A);
    var data = await service.DoSomethingAsync();

    return Results.Ok(data);
})
.WithName("TestEndpoint-A")
.WithOpenApi();

app.MapGet("/test-b", async (ServiceResolver serviceResolver) =>
{
    var service = serviceResolver(ServiceImplementation.B);
    var data = await service.DoSomethingAsync();

    return Results.Ok(data);
})
.WithName("TestEndpoint-B")
.WithOpenApi();

app.Run();
