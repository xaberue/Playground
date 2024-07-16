using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Client : ModelBase
{
    public string Name { get; init; }
    public string Surname { get; init; }
    public string Address { get; init; }
    public DateTime RegistrationDate { get; init; }
    public DateTime BirthDate { get; init; }

    public ICollection<Lend> Lends { get; init; }
    public ICollection<Purchase> Purchases { get; init; }
}
