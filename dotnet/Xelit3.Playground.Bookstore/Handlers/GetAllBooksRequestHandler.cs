using MediatR;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Endpoints;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Handlers;

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
