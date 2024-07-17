using MediatR;
using Xelit3.Playground.Bookstore.Endpoints;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Handlers;

public class GetBookByIdRequestHandler : RequestHandlerBase, IRequestHandler<GetBookByIdRequest, BookDto?>
{

    public GetBookByIdRequestHandler(BookstoreDbContext dbContext)
        : base(dbContext)
    { }


    public async Task<BookDto?> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
    {
        var book = await _dbContext.Books.FindAsync(request.Id);

        return book?.ToDto();
    }
}
