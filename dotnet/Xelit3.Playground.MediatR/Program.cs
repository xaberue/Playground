using MediatR;
using System.Diagnostics;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMediatR(cfg => {
    cfg.RegisterServicesFromAssembly(typeof(Program).Assembly);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/ping", async (IMediator mediator) =>
{
    var response = await mediator.Send(new Ping());

    return Results.Ok(response);
})
.WithName("PingApi")
.WithOpenApi();

app.MapGet("/long-task", async (IMediator mediator) =>
{
    await mediator.Send(new OneWay());

    return Results.Ok("Running...");
})
.WithName("LongTaskApi")
.WithOpenApi();

app.Run();



// Request / Response sample.

public class Ping : IRequest<string> { }


public class PingHandler : IRequestHandler<Ping, string>
{
    public Task<string> Handle(Ping request, CancellationToken cancellationToken)
    {
        return Task.FromResult("Pong");
    }
}

//


// Request without response sample.

public class OneWay : IRequest { }

public class OneWayHandler : IRequestHandler<OneWay>
{
    public Task Handle(OneWay request, CancellationToken cancellationToken)
    {
        // do work
        return Task.CompletedTask;
    }
}
