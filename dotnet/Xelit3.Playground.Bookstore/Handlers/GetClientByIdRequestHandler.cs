using MediatR;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Handlers;

public class GetClientByIdRequestHandler : RequestHandlerBase, IRequestHandler<GetClientByIdRequest, ClientDto?>
{
    
    public GetClientByIdRequestHandler(BookstoreDbContext dbContext) 
        : base(dbContext)
    { }


    public async Task<ClientDto?> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
    {
        var client = await _dbContext.Clients.FindAsync(id);

        return client?.ToDto();
    }
}
