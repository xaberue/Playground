using MediatR;

namespace Xelit3.Playground.Bookstore.Endpoints.Models;

public record GetClientByIdRequest(int Id) : IRequest<ClientDto?>;

public record CreateClientRequest(string Name, string Surname, string Address, DateTime BirthDate) : IRequest<ClientDto>;
