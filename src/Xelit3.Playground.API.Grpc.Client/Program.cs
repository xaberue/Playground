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


//Get All ToDo

var allReply = await client.GetAllToDoAsync(
     new GetAllToDoRequest { }
     );


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


Console.WriteLine("Press any key to exit...");
Console.ReadKey();