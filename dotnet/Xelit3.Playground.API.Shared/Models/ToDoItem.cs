﻿namespace Xelit3.Playground.API.Shared.Models;

public class ToDoItem
{
    public int Id { get; init; }
    public string Title { get; private set; } = null!;
    public string Description { get; private set; } = null!;
    public ToDoItemStatus Status { get; private set; }



    public ToDoItem(string title, string description)
    {
        Title = title;
        Description = description;
        Status = ToDoItemStatus.New;
    }

    public ToDoItem(int id, string title, string description, ToDoItemStatus status)
    {
        Id = id;
        Title = title;
        Description = description;
        Status = status;
    }


    public void Update(string title, string description)
    {
        Title = title;
        Description = description;
    }

    public void ChangeStatus(ToDoItemStatus newStatus)
    {
        Status = newStatus;
    }
}
