namespace Xelit3.Playground.Bookstore.Clients;

public static class ClientExtensions
{
    public static ClientDto ToDto(this Client entity)
        => new ClientDto(entity.Id, $"{entity.Name} {entity.Surname}", DateOnly.FromDateTime(entity.BirthDate));
}
