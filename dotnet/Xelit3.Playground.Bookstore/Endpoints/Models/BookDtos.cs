namespace Xelit3.Playground.Bookstore.Endpoints.Models;

public record BookDto(int Id, string Isbn, string Title, string Author);

public record CreateBookDto(string Isbn, string Title, string Author, int YearPublished, decimal Price) 
{
    public CreateBookRequest ToRequest() => new CreateBookRequest(Isbn, Title, Author, YearPublished, Price);
}

public record BooksLendDto(string[] IsbnNumbers, int ClientId) 
{
    public BooksLendRequest ToRequest() => new BooksLendRequest(IsbnNumbers, ClientId);
}