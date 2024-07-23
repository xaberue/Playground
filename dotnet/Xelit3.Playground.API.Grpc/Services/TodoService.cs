using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.API.Shared.Data;
using Xelit3.Playground.API.Shared.Models;

namespace Xelit3.Playground.API.Grpc.Services;

public class TodoService : ToDo.ToDoBase
{

    private readonly ILogger<TodoService> _logger;
    private readonly ToDoDataContext _context;


    public TodoService(ILogger<TodoService> logger, ToDoDataContext context)
    {
        _logger = logger;
        _context = context;
    }


    public override async Task<ToDoResponse> GetSingleToDo(GetSingleToDoRequest request, ServerCallContext context)
    {
        var item = await _context.ToDoItems.FindAsync(request.Id) ?? throw new RpcException(new Status(StatusCode.NotFound, $"ToDoItem with id {request.Id} not found"));

        return new ToDoResponse { Id = item.Id, Title = item.Title, Description = item.Description, ToDoStatus = item.Status.ToString() };
    }

    public override async Task<ToDoCollectionResponse> GetAllToDo(GetAllToDoRequest request, ServerCallContext context)
    {
        var items = await _context.ToDoItems.ToListAsync();
        var response = new ToDoCollectionResponse();

        foreach (var item in items)
        {
            response.ToDos.Add(new ToDoResponse
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                ToDoStatus = item.Status.ToString()
            });
        }

        return response;
    }

    public override async Task GetAllToDoStream(GetAllToDoRequest request, IServerStreamWriter<ToDoResponse> responseStream, ServerCallContext context)
    {
        var items = await _context.ToDoItems.ToListAsync();
        
        foreach (var item in items)
        {
            await responseStream.WriteAsync(new ToDoResponse
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                ToDoStatus = item.Status.ToString()
            });
        }
    }

    public override async Task<ToDoCollectionResponse> GetMultipleToDoStream(IAsyncStreamReader<GetSingleToDoRequest> requestStream, ServerCallContext context)
    {
        var response = new ToDoCollectionResponse();

        while (await requestStream.MoveNext())
        {
            var item = await _context.ToDoItems.FindAsync(requestStream.Current.Id) ?? throw new RpcException(new Status(StatusCode.NotFound, $"ToDoItem with id {requestStream.Current.Id} not found"));

            response.ToDos.Add(new ToDoResponse
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                ToDoStatus = item.Status.ToString()
            });
        }

        return response;
    }

    public override async Task GetMultipleToDoBidirectionalStream(IAsyncStreamReader<GetSingleToDoRequest> requestStream, IServerStreamWriter<ToDoResponse> responseStream, ServerCallContext context)
    {
        while (await requestStream.MoveNext())
        {
            var todo = await _context.ToDoItems.FindAsync(requestStream.Current.Id) ?? throw new RpcException(new Status(StatusCode.NotFound, $"ToDoItem with id {requestStream.Current.Id} not found"));
            await responseStream.WriteAsync(new ToDoResponse
            {
                Id = todo.Id,
                Title = todo.Title,
                Description = todo.Description,
                ToDoStatus = todo.Status.ToString()
            });
        }
    }

    public override async Task<CreateToDoResponse> CreateToDo(CreateToDoRequest request, ServerCallContext context)
    {
        if(string.IsNullOrWhiteSpace(request.Title) || string.IsNullOrWhiteSpace(request.Description))
            throw new RpcException(new Status(StatusCode.InvalidArgument, "Title and Description are required"));

        var todoItem = new ToDoItem(request.Title, request.Description);

        await _context.ToDoItems.AddAsync(todoItem);
        await _context.SaveChangesAsync();

        return await Task.FromResult(new CreateToDoResponse{ Id = todoItem.Id });
    }

    public override async Task<UpdateToDoResponse> UpdateToDo(UpdateToDoRequest request, ServerCallContext context)
    {
        var todoItem = await _context.ToDoItems.FindAsync(request.Id) ?? throw new RpcException(new Status(StatusCode.NotFound, $"ToDoItem with id {request.Id} not found"));

        todoItem.Update(request.Title, request.Description);        
        await _context.SaveChangesAsync();

        return await Task.FromResult(new UpdateToDoResponse { Id = todoItem.Id });
    }

    public override async Task<DeleteToDoResponse> DeleteToDo(DeleteToDoRequest request, ServerCallContext context)
    {
        var todoItem = await _context.ToDoItems.FindAsync(request.Id) ?? throw new RpcException(new Status(StatusCode.NotFound, $"ToDoItem with id {request.Id} not found"));

        _context.ToDoItems.Remove(todoItem);
        await _context.SaveChangesAsync();

        return await Task.FromResult(new DeleteToDoResponse { Id = request.Id });
    }

}
