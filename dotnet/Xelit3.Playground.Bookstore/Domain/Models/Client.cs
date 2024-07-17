using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Client : ModelBase
{

    public string Name { get; init; }
    public string Surname { get; init; }
    public string Address { get; init; }
    public DateTime RegistrationDate { get; init; }
    public DateTime BirthDate { get; init; }

    public ICollection<Lend> Lends { get; init; } = [];
    public ICollection<Purchase> Purchases { get; init; } = [];


    public Client(string name, string surname, string address, DateTime birthDate)
        : this(name, surname, address, birthDate, DateTime.Now, [], [])
    { }

    public Client(string name, string surname, string address, DateTime birthDate, DateTime registrationDate, ICollection<Lend> lends, ICollection<Purchase> purchases)
        : base()
    {
        Name = name;
        Surname = surname;
        Address = address;
        RegistrationDate = registrationDate;
        BirthDate = birthDate;
        Lends = lends;
        Purchases = purchases;
    }


    public bool IsUnder18()
    {
        return DateTime.Now.AddYears(-18) <= BirthDate;
    }

}
