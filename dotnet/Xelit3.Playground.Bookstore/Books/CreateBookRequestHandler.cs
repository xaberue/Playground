using MediatR;
using Xelit3.Playground.Bookstore.Infrastructure;
using Xelit3.Playground.Bookstore.Shared.Base;

namespace Xelit3.Playground.Bookstore.Books;

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
