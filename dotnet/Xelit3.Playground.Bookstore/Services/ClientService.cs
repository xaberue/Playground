using Xelit3.Playground.Bookstore.Domain.Models;
using Xelit3.Playground.Bookstore.Endpoints.Models;
using Xelit3.Playground.Bookstore.Infrastructure;

namespace Xelit3.Playground.Bookstore.Services;


public interface IClientService
{
    Task<ClientDto> GetSingleAsync(int id);
    Task<ClientDto> CreateAsync(ClientCreationDto creationDto);
}


public class ClientService : IClientService
{

    private readonly BookstoreDbContext _dbContext;


    public ClientService(BookstoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    public async Task<ClientDto> GetSingleAsync(Int32 id)
    {
        var client = await _dbContext.Clients.FindAsync(id);

        return MapDto(client);
    }

    public async Task<ClientDto> CreateAsync(ClientCreationDto creationDto)
    {
        var client = new Client(creationDto.Name, creationDto.Surname, creationDto.Address, creationDto.BirthDate);

        await _dbContext.AddAsync(client);
        await _dbContext.SaveChangesAsync();
        
        return MapDto(client);
    }


    private static ClientDto MapDto(Client client)
    {
        return new ClientDto(client.Id, $"{client.Name} {client.Surname}", DateOnly.FromDateTime(client.BirthDate));
    }


}
