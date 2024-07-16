using MediatR;
using Xelit3.Playground.Bookstore.Endpoints.Models;

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

        group
            .MapPost("/lend", BooksLend)
            .WithName("BooksLend");

        return group;
    }


    public static async Task<IResult> GetBookById(IMediator mediator, int id)
    {
        var request = new GetBookByIdRequest(id);
        var book = await mediator.Send(request);

        if (book is not null)
            return TypedResults.Ok(book);
        else
            return TypedResults.NotFound();
    }

    public static IResult GetAllBooks(IMediator mediator)
    {
        var request = new GetAllBooksRequest();
        var result = mediator.CreateStream(request);

        return TypedResults.Ok(result);
    }

    public static async Task<IResult> CreateBook(CreateBookDto bookCreationDto, IMediator mediator)
    {
        var request = bookCreationDto.ToRequest();
        var book = mediator.Send(request);

        return TypedResults.Created($"{book.Id}", book);
    }

    public static async Task<IResult> BooksLend(BooksLendDto leanDto, IMediator mediator)
    {
        var request = leanDto.ToRequest();
        await mediator.Send(request);

        return TypedResults.Ok();
    }

}
