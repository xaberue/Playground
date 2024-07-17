namespace Xelit3.Playground.Bookstore.Endpoints.Models;

public record ClientDto(int Id, string FullName, DateOnly BirthDate);

public record CreateClientDto(string Name, string Surname, string Address, DateTime BirthDate) 
{
    public CreateClientRequest ToRequest() => new CreateClientRequest(Name, Surname, Address, BirthDate);
}