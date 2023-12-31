using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.API.Grpc.Models;

namespace Xelit3.Playground.API.Shared.Data;

public class ToDoDataContext : DbContext
{

    public DbSet<ToDoItem> ToDoItems { get; set; }

    public ToDoDataContext(DbContextOptions options) 
        : base(options)
    {
    }
}
