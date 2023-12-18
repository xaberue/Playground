using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.API.Grpc.Data;
using Xelit3.Playground.API.Grpc.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDataContext>(opt => {
    opt.UseSqlite("Data Source=ToDoDatabase.db");
});

builder.Services.AddGrpc();


var app = builder.Build();

app.MapGrpcService<GreeterService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
