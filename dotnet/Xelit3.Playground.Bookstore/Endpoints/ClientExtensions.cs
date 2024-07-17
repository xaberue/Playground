using Xelit3.Playground.Bookstore.Domain.Models;
using Xelit3.Playground.Bookstore.Endpoints.Models;

namespace Xelit3.Playground.Bookstore.Endpoints;

public static class ClientExtensions
{
    public static ClientDto ToDto(this Client entity)
        => new ClientDto(entity.Id, $"{entity.Name} {entity.Surname}", DateOnly.FromDateTime(entity.BirthDate));    
}
