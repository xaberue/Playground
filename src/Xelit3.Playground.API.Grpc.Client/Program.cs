// The port number must match the port of the gRPC server.
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

await channel.ShutdownAsync();

Console.WriteLine("Press any key to exit...");
Console.ReadKey();