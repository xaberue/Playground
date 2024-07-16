using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Endpoints;
using Xelit3.Playground.Bookstore.Infrastructure;
using Xelit3.Playground.Bookstore.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookstoreDbContext>(opt =>
{
    opt.UseSqlite("Data Source=BookstoreDb.db");
});

builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IClientService, ClientService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGroup("books").MapBookEndpoints().WithOpenApi();
app.MapGroup("clients").MapClientEndpoints().WithOpenApi();


app.Run();