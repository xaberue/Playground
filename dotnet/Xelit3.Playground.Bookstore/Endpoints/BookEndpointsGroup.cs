using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Services;

namespace Xelit3.Playground.Bookstore.Endpoints;

public static class BookEndpointsGroup
{
    public static RouteGroupBuilder MapBookEndpoints(this RouteGroupBuilder group)
    {
        group
            .MapGet("/{id}", GetBookById)
            .WithName("GetBookById");

        group
            .MapGet("/", GetAllBooks)
            .WithName("GetAllBooks");

        group
            .MapPost("/", CreateBook)
            .WithName("CreateBook");

        return group;
    }


    public static async Task<IResult> GetBookById(IBookService bookService, int id)
    {
        var book = await bookService.GetSingleAsync(id);

        if (book is not null)
            return TypedResults.Ok(book);
        else
            return TypedResults.NotFound();
    }

    public static IResult GetAllBooks(IBookService bookService)
    {
       var all = bookService.GetAllAsync();

        return TypedResults.Ok(all);
    }

    public static async Task<IResult> CreateBook(BookCreationDto bookCreationDto, IBookService bookService)
    {
        var book = bookService.CreateAsync(bookCreationDto);

        return TypedResults.Created($"{book.Id}", book);
    }

}
