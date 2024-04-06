using Xelit3.Playground.API.Shared.Models;

namespace Xelit3.Playground.API.Minimal.Rest.Models;

public record ToDoItemDto(int Id, string Title, string Description, ToDoItemStatus Status);

public record ToDoItemCreationCommand(string Title, string Description);

public record ToDoItemEditionCommand(int Id, string Title, string Description);

public record ToDoItemChangeStatusCommand(int Id, ToDoItemStatus Status);