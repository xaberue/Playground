using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.API.Shared.Models;

namespace Xelit3.Playground.API.Shared.Data;

public class ToDoDataContext : DbContext
{

    public DbSet<ToDoItem> ToDoItems { get; set; }

    public ToDoDataContext(DbContextOptions<ToDoDataContext> options) 
        : base(options)
    { }
}
