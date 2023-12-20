using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.API.Grpc.Data;
using Xelit3.Playground.API.Grpc.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDataContext>(opt => {
    opt.UseSqlite("Data Source=ToDoDatabase.db");
});

builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection();


var app = builder.Build();

app.MapGrpcService<TodoService>();
app.MapGrpcReflectionService();

app.Run();
