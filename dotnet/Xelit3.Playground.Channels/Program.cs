using System.Threading.Channels;
using Xelit3.Playground.Channels;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<Processor>();

builder.Services.AddSingleton<Channel<NameMsg>>(
    _ => Channel.CreateUnbounded<NameMsg>(new UnboundedChannelOptions
    {
        SingleReader = true,
        SingleWriter = true,
        AllowSynchronousContinuations = false
    }));

var app = builder.Build();

app.UseHttpsRedirection();

app.MapGet("/hello/{name}", async (string name, Channel<NameMsg> channel) =>
{
    //channel.Writer.TryWrite(new NameMsg(name));
    await channel.Writer.WriteAsync(new NameMsg(name));

    return Results.Accepted();
})
.WithName("SendHello");

app.Run();
