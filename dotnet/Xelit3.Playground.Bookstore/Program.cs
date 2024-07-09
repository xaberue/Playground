using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Endpoints;
using Xelit3.Playground.Bookstore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookstoreDbContext>(opt =>
{
    opt.UseSqlite("Data Source=BookstoreDb.db");
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGroup("books").MapBookEndpoints().WithOpenApi();



app.Run();