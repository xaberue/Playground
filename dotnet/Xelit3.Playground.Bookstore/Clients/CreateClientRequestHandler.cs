using MediatR;
using Xelit3.Playground.Bookstore.Infrastructure;
using Xelit3.Playground.Bookstore.Shared.Base;

namespace Xelit3.Playground.Bookstore.Clients;

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
