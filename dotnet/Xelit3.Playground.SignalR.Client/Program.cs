using Microsoft.AspNetCore.SignalR.Client;
using System.Net.Http.Json;
using Xelit3.Playground.SignalR.Shared.Models;

using var httpClint = new HttpClient();
httpClint.BaseAddress = new Uri("https://localhost:7157");
var response = await httpClint.GetAsync("/users");
var users = await response.Content.ReadFromJsonAsync<UserViewModel[]>() ?? [];

PrintUsers(users);

//var connection = new HubConnectionBuilder()
//    .WithUrl("https://localhost:7157/user-counter")
//    .Build();

var connection = new HubConnectionBuilder()
    .WithUrl("https://localhost:7157/user-counter", o =>
    {
        o.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
        o.SkipNegotiation = true;
    })
    .Build();

connection.On("UserClickReceived", (UserViewModel currentUser) =>
{
    var previousUserData = users.First(x => x.Id == currentUser.Id);

    previousUserData.Counter = currentUser.Counter;

    PrintUsers(users);
});

static async void PrintUsers(UserViewModel[] users)
{
    foreach (var user in users)
        Console.WriteLine($"User: {user}");
}

try
{
    await connection.StartAsync();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

try
{
    while (true)
    {
        Console.WriteLine("User Id?:");
        var userId = int.Parse(Console.ReadLine()!);

        await connection.InvokeAsync("NotifyClick", userId);
        Console.WriteLine("Click sent");
    }
}
finally
{
    await connection.StopAsync();
}