using MediatR;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Infrastructure;
using Xelit3.Playground.Bookstore.Shared.Base;

namespace Xelit3.Playground.Bookstore.Books;

public class GetAllBooksRequestHandler : RequestHandlerBase, IStreamRequestHandler<GetAllBooksRequest, BookDto>
{

    public GetAllBooksRequestHandler(BookstoreDbContext dbContext)
        : base(dbContext)
    { }


    public IAsyncEnumerable<BookDto> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
    {
        var all = _dbContext.Books
           .Select(x => x.ToDto())
           .AsAsyncEnumerable();

        return all;
    }
}
