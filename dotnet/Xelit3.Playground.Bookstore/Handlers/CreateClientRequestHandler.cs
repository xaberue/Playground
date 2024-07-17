using MediatR;
using Xelit3.Playground.Bookstore.Domain.Models;
using Xelit3.Playground.Bookstore.Endpoints;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Handlers;

public class CreateClientRequestHandler : RequestHandlerBase, IRequestHandler<CreateClientRequest, ClientDto>
{

    public CreateClientRequestHandler(BookstoreDbContext dbContext) 
        : base(dbContext)
    { }


    public async Task<ClientDto> Handle(CreateClientRequest request, CancellationToken cancellationToken)
    {
        var client = new Client(request.Name, request.Surname, request.Address, request.BirthDate);

        await _dbContext.AddAsync(client);
        await _dbContext.SaveChangesAsync();

        return client.ToDto();
    }
}
