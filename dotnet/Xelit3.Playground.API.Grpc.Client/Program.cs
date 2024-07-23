// The port number must match the port of the gRPC server.
using Grpc.Core;
using Grpc.Net.Client;
using Xelit3.Playground.API.Grpc.Client;

using var channel = GrpcChannel.ForAddress("https://localhost:7066");

var client = new ToDo.ToDoClient(channel);

// Create new ToDo
var newToDo = new CreateToDoRequest
{
    Title = "Test from client",
    Description = "Test description from client"
};

var replyCreate = await client.CreateToDoAsync(newToDo);


////Get All ToDo

//Basic
var allToDosResponse = await client.GetAllToDoAsync(
     new GetAllToDoRequest { }
     );

//Stream

var allTodosStreamResponse = client.GetAllToDoStream(new GetAllToDoRequest { });

while (await allTodosStreamResponse.ResponseStream.MoveNext(CancellationToken.None))
{
    var value = allTodosStreamResponse.ResponseStream.Current;
    Console.WriteLine($"Id: {value.Id} - Title: {value.Title} - Description: {value.Description} - Status: {value.ToDoStatus}");
}

var multipleTodosStream = client.GetMultipleToDoStream();

for (var i = 1; i <= 3; i++)
{
    await multipleTodosStream.RequestStream.WriteAsync(new GetSingleToDoRequest { Id = i });
}

await multipleTodosStream.RequestStream.CompleteAsync();

await multipleTodosStream;

foreach (var item in (await multipleTodosStream.ResponseAsync).ToDos)
{
    Console.WriteLine($"Id: {item.Id} - Title: {item.Title} - Description: {item.Description} - Status: {item.ToDoStatus}");
}

var streamBidirectional = client.GetMultipleToDoBidirectionalStream();

var requestBidirectionalTask = Task.Run(async () => 
{
    for (int i = 1; i <= 3; i++)
    {
        await streamBidirectional.RequestStream.WriteAsync(new GetSingleToDoRequest { Id = i });
    }

    await streamBidirectional.RequestStream.CompleteAsync();
    await Console.Out.WriteLineAsync("Request stream to server completed");
});

var responseBidirectionalTask = Task.Run(async () =>
{
    while (await streamBidirectional.ResponseStream.MoveNext(CancellationToken.None))
    {
        Console.WriteLine(streamBidirectional.ResponseStream.Current);
    }

    await Console.Out.WriteLineAsync("Response stream from server completed");
});

await Task.WhenAll(requestBidirectionalTask, responseBidirectionalTask);


//Get ToDo by Id
var singleReply = await client.GetSingleToDoAsync(
     new GetSingleToDoRequest { Id = replyCreate.Id }
     );


// Update ToDo
var updateToDo = new UpdateToDoRequest
{
    Id = replyCreate.Id,
    Title = "Test from client",
    Description = "Test description from client (UPDATED)"
};

var replyUpdate = await client.UpdateToDoAsync(updateToDo);


//Remove ToDo
var removeReply = await client.DeleteToDoAsync(
    new DeleteToDoRequest { Id = replyCreate.Id }
);

//Auth example
var authClient = new Auth.AuthClient(channel);

var authResponse = await authClient.AuthenticateAsync(new AuthenticationRequest { Username = "Xelit3", Password = "Test.1234!" });

var headers = new Metadata();
headers.Add("Authorization", $"Bearer {authResponse.AccessToken}");

var usersClient = new User.UserClient(channel);

var userHelloResponse = await usersClient.SayHelloAsync(new HelloUserRequest { Name = "Xelit3" }, headers);

//If the user isn't valid, the server will return an Grpc.Core.RpcException

await channel.ShutdownAsync();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();