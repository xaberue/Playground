using MediatR;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Endpoints;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Handlers;

public class GetAllBooksHandler : RequestHandlerBase, IStreamRequestHandler<GetAllBooksRequest, BookDto>
{
    
    public GetAllBooksHandler(BookstoreDbContext dbContext) 
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
