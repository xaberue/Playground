
using System.Threading.Channels;

namespace Xelit3.Playground.Channels;

public class Processor : BackgroundService
{

    private readonly Channel<NameMsg> _channel;


    public Processor(Channel<NameMsg> channel)
    {
        _channel = channel;
    }


    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (await _channel.Reader.WaitToReadAsync(stoppingToken))
        {
            var request = await _channel.Reader.ReadAsync(stoppingToken);

            Console.WriteLine($"Hello {request.Value}!");
        }
    }
}
