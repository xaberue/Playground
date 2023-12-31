using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Xelit3.Playground.API.Grpc.Services;
using Xelit3.Playground.API.Shared.Data;
using Xelit3.Playground.API.Shared.Models;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication().AddBearerToken(IdentityConstants.BearerScheme);
builder.Services.AddAuthorizationBuilder();

builder.Services.AddDbContext<ToDoDataContext>(opt => {
    opt.UseSqlite("Data Source=ToDoDatabase.db");
});
builder.Services.AddDbContext<AppIdentityDbContext>(opt => {
    opt.UseSqlite("Data Source=ToDoDatabase.db");
});

builder.Services
    .AddIdentityCore<AppUser>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddApiEndpoints();

builder.Services.AddGrpc().AddJsonTranscoding();
builder.Services.AddGrpcReflection();
builder.Services.AddGrpcSwagger();
builder.Services.AddSwaggerGen(x => 
{
    x.SwaggerDoc("v1", new OpenApiInfo { Title = "ToDo API", Version = "v1" });
});


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();

    app.UseSwaggerUI(x =>
    {
        x.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API v1");
    });
}

app.MapIdentityApi<AppUser>();

app.MapGrpcService<TodoService>();

if (app.Environment.IsDevelopment())
{
    app.MapGrpcReflectionService();
}

app.Run();
