using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Shared.Base;

public abstract class RequestHandlerBase
{

    protected readonly BookstoreDbContext _dbContext;


    protected RequestHandlerBase(BookstoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
