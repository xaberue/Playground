using MediatR;
using Xelit3.Playground.Bookstore.Infrastructure;
using Xelit3.Playground.Bookstore.Shared.Base;

namespace Xelit3.Playground.Bookstore.Books;

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
