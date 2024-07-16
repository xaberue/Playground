namespace Xelit3.Playground.Bookstore.Endpoints.Models;

public record ClientDto(int Id, string FullName, DateOnly BirthDate);

public record ClientCreationDto(string Name, string Surname, string Address, DateTime BirthDate);