namespace Xelit3.Playground.Bookstore.Endpoints.Models;

public record BookDto(int Id, string Isbn, string Title, string Author);

public record BookCreationDto(string Isbn, string Title, string Author);

public record BookLoanDto(string[] IsbnNumbers, int ClientId);