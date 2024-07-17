using MediatR;
using Xelit3.Playground.Bookstore.Infrastructure;
using Xelit3.Playground.Bookstore.Shared.Base;

namespace Xelit3.Playground.Bookstore.Clients;

public class GetClientByIdRequestHandler : RequestHandlerBase, IRequestHandler<GetClientByIdRequest, ClientDto?>
{

    public GetClientByIdRequestHandler(BookstoreDbContext dbContext)
        : base(dbContext)
    { }


    public async Task<ClientDto?> Handle(GetClientByIdRequest request, CancellationToken cancellationToken)
    {
        var client = await _dbContext.Clients.FindAsync(request.Id);

        return client?.ToDto();
    }
}
