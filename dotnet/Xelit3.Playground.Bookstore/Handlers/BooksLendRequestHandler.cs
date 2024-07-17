using MediatR;
using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.Bookstore.Domain.Models;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Handlers;

public class BooksLendRequestHandler : RequestHandlerBase, IRequestHandler<BooksLendRequest>
{

    public BooksLendRequestHandler(BookstoreDbContext dbContext)
        : base(dbContext)
    { }


    public async Task Handle(BooksLendRequest request, CancellationToken cancellationToken)
    {
        var books = await _dbContext.Books
           .Where(x => request.IsbnNumbers.Contains(x.Isbn))
           .ToListAsync();

        var client = await _dbContext.Clients.FindAsync(request.ClientId) ?? throw new ArgumentException("Client not found");
        var lend = new Lend(books, client);

        await _dbContext.AddAsync(lend);
        await _dbContext.SaveChangesAsync();
    }
}
