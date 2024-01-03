using Xelit3.Playground.API.GraphQL.Models;
using Xelit3.Playground.API.Grpc.Models;

namespace Xelit3.Playground.API.GraphQL.Queries;

public class TodoQueries
{

    public IEnumerable<ToDoItemDto> GetAll()
    {
        return new List<ToDoItemDto>()
        {
            new ToDoItemDto(1, "Test 1", "Test Description 1", ToDoItemStatus.New),
            new ToDoItemDto(2, "Test 2", "Test Description 2", ToDoItemStatus.New),
            new ToDoItemDto(3, "Test 3", "Test Description 3", ToDoItemStatus.InProgress),
            new ToDoItemDto(4, "Test 4", "Test Description 4", ToDoItemStatus.Done)
        };
    }
}
