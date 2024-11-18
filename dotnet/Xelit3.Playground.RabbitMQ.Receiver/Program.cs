using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

ConnectionFactory factory = new();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
factory.ClientProvidedName = "Rabbit Receiver App";

var connection = await factory.CreateConnectionAsync();
var channel = await connection.CreateChannelAsync();

var exchangeName = "DemoExchange";
var routingKey = "demo-routing-key";
var queueName = "DemoQueue";

await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
await channel.QueueDeclareAsync(queueName, durable: false, exclusive: false, autoDelete: false);
await channel.QueueBindAsync(queueName, exchangeName, routingKey);

await channel.BasicQosAsync(prefetchSize: 0, prefetchCount: 1, global: false);

var consumer = new AsyncEventingBasicConsumer(channel);

consumer.ReceivedAsync += async (sender, args) =>
{
    var body = args.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);

    Console.WriteLine($"Message received: {message}");

    await channel.BasicAckAsync(args.DeliveryTag, multiple: false);
};

var consumerTag = await channel.BasicConsumeAsync(queueName, autoAck: false, consumer);

Console.ReadLine();

await channel.BasicCancelAsync(consumerTag);
await channel.CloseAsync();
await connection.CloseAsync();