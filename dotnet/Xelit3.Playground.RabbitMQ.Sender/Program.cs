using RabbitMQ.Client;
using System.Text;


ConnectionFactory factory = new();
factory.Uri = new Uri("amqp://guest:guest@localhost:5672");
factory.ClientProvidedName = "Rabbit Sender App";

var connection = await factory.CreateConnectionAsync();
var channel = await connection.CreateChannelAsync();

var exchangeName = "DemoExchange";
var routingKey = "demo-routing-key";
var queueName = "DemoQueue";

await channel.ExchangeDeclareAsync(exchangeName, ExchangeType.Direct);
await channel.QueueDeclareAsync(queueName, durable: false, exclusive: false, autoDelete: false);
await channel.QueueBindAsync(queueName, exchangeName, routingKey);

//byte[] messageBody = Encoding.UTF8.GetBytes("Hello World!");

//await channel.BasicPublishAsync(exchangeName, routingKey, messageBody);

for (var i = 1; i <= 1000; i++)
{
    Console.WriteLine($"Sending message: {i}");

    var messageBody = Encoding.UTF8.GetBytes($"Hello World #{i}!");

    await channel.BasicPublishAsync(exchangeName, routingKey, messageBody);

    await Task.Delay(100);
}

await channel.CloseAsync();
await connection.CloseAsync();