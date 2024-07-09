using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Client : ModelBase
{
    public string Name { get; set; }
    public string Surname { get; set; }
    public string Address { get; set; }
    public DateTime RegistrationDate { get; set; }

    public ICollection<Loan> Loans { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
}
