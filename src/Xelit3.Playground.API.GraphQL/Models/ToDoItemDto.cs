using Xelit3.Playground.API.Shared.Models;

namespace Xelit3.Playground.API.GraphQL.Models;

public record ToDoItemDto(int Id, string Title, string Description, ToDoItemStatus Status);
