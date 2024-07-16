using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Domain.Models;
using Xelit3.Playground.Bookstore.Endpoints;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Services;


public interface IBookService
{
    IAsyncEnumerable<BookDto> GetAllAsync();
    Task<BookDto?> GetSingleAsync(Int32 id);
    Task<BookDto> CreateAsync(BookCreationDto bookCreationDto);
    Task LendAsync(BookLendDto lendDto);
}


public class BookService : IBookService
{

    private readonly BookstoreDbContext _dbContext;


    public BookService(BookstoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<BookDto?> GetSingleAsync(int id)
    {
        var book = await _dbContext.Books.FindAsync(id);

        return book?.ToDto();
    }

    public IAsyncEnumerable<BookDto> GetAllAsync()
    {
        var all = _dbContext.Books
           .Select(x => x.ToDto())
           .AsAsyncEnumerable();

        return all;
    }

    public async Task<BookDto> CreateAsync(BookCreationDto creationDto)
    {
        var book = new Book(creationDto.Isbn, creationDto.Title, creationDto.Author, creationDto.YearPublished, creationDto.Price);
        
        await _dbContext.AddAsync(book);
        await _dbContext.SaveChangesAsync();

        return book.ToDto();
    }

    public async Task LendAsync(BookLendDto lendDto)
    {
        var books = await _dbContext.Books
            .Where(x => lendDto.IsbnNumbers.Contains(x.Isbn))
            .ToListAsync();

        var client = await _dbContext.Clients.FindAsync(lendDto.ClientId);

        var days = DateTime.Now.AddYears(-18) <= client.BirthDate ? 30 : 15;
        var returnDate = DateTime.Now.AddDays(days);

        var lend = new Lend { Books = books, Client = client, CreationDate = DateTime.Now, ReturnDate = returnDate };

        await _dbContext.AddAsync(lend);
        await _dbContext.SaveChangesAsync();
    }
}
