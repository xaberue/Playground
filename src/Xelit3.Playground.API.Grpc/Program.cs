using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Xelit3.Playground.API.Grpc.Data;
using Xelit3.Playground.API.Grpc.Services;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ToDoDataContext>(opt => {
    opt.UseSqlite("Data Source=ToDoDatabase.db");
});

builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(x => 
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo API", Version = "v1" });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API v1");
});

app.MapGrpcService<TodoService>();
app.MapGrpcReflectionService();

app.Run();
