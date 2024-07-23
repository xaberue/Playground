using MediatR;

namespace Xelit3.Playground.Bookstore.Books;

public record GetAllBooksRequest : IStreamRequest<BookDto> { }

public record GetBookByIdRequest(int Id) : IRequest<BookDto?>;

public record CreateBookRequest(string Isbn, string Title, string Author, int YearPublished, decimal Price) : IRequest<BookDto>;

public record BooksLendRequest(string[] IsbnNumbers, int ClientId) : IRequest;