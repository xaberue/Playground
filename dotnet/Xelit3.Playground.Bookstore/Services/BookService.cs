using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Domain.Models;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Services;


public interface IBookService
{
    IAsyncEnumerable<BookDto> GetAllAsync();
    Task<Book> GetSingleAsync(Int32 id);
    Task<Book> CreateAsync(BookCreationDto bookCreationDto);
}


public class BookService : IBookService
{

    private readonly BookstoreDbContext _dbContext;


    public BookService(BookstoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<Book> GetSingleAsync(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);

        return book;
    }

    public IAsyncEnumerable<BookDto> GetAllAsync()
    {
        var all = _dbContext.Books
           .Select(x => new BookDto(x.Id, x.Isbn, x.Title, x.Author))
           .AsAsyncEnumerable();

        return all;
    }

    public async Task<Book> CreateAsync(BookCreationDto bookCreationDto)
    {
        var book = new Book
        {
            Isbn = bookCreationDto.Isbn,
            Title = bookCreationDto.Title,
            Author = bookCreationDto.Author
        };

        await _dbContext.AddAsync(book);
        await _dbContext.SaveChangesAsync();

        return book;
    }
}
