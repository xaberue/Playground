﻿namespace Xelit3.Playground.API.Grpc.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public ToDoItemStatus Status { get; set; }
}
