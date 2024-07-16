using MediatR;
using Xelit3.Playground.Bookstore.Domain.Models;
using Xelit3.Playground.Bookstore.Endpoints;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Handlers;

public class CreateBookRequestHandler : RequestHandlerBase, IRequestHandler<CreateBookRequest, BookDto>
{

    public CreateBookRequestHandler(BookstoreDbContext dbContext)
        : base(dbContext)
    { }


    public async Task<BookDto> Handle(CreateBookRequest equest, CancellationToken cancellationToken)
    {
        var book = new Book(equest.Isbn, equest.Title, equest.Author, equest.YearPublished, equest.Price);

        await _dbContext.AddAsync(book);
        await _dbContext.SaveChangesAsync();

        return book.ToDto();
    }
}
