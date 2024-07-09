﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Domain.Models;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Endpoints;

public static class BookEndpointsGroup
{
    public static RouteGroupBuilder MapBookEndpoints(this RouteGroupBuilder group)
    {
        group
            .MapGet("/{id}", async (BookstoreDbContext dbContext, int id) =>
            {
                var book = await dbContext.Books.FindAsync(id);

                if (book is not null)
                    return Results.Ok(book);
                else
                    return Results.NotFound();
            })
            .WithName("GetBookById");

        group
            .MapGet("/", GetAllBooks)
            .WithName("GetAllBooks");

        group
            .MapPost("/", CreateBook)
            .WithName("CreateBook");

        return group;
    }


    public static async Task<Ok<IAsyncEnumerable<BookDto>>> GetAllBooks(BookstoreDbContext dbContext)
    {
        var all = dbContext.Books
            .Select(x => new BookDto(x.Id, x.Isbn, x.Title, x.Author))
            .AsAsyncEnumerable();

        return TypedResults.Ok(all);
    }

    public static async Task<Created<Book>> CreateBook(BookCreationDto bookCreationDto, BookstoreDbContext dbContext)
    {
        var book = new Book
        {
            Isbn = bookCreationDto.Isbn,
            Title = bookCreationDto.Title,
            Author = bookCreationDto.Author
        };

        await dbContext.AddAsync(book);
        await dbContext.SaveChangesAsync();

        return TypedResults.Created($"{book.Id}", book);
    }

}
