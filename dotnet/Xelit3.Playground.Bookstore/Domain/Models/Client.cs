using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Client : ModelBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Address { get; set; }
    public DateTime RegistrationDate { get; set; }
    public DateTime BirthDate { get; set; }

    public ICollection<Lend> Lends { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
}
