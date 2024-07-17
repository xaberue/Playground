using Xelit3.Playground.Bookstore.Books;
using Xelit3.Playground.Bookstore.Clients;
using Xelit3.Playground.Bookstore.Shared.Base;

namespace Xelit3.Playground.Bookstore.Lends;

public class Lend : ModelBase
{

    public DateTime Date { get; init; }
    public DateTime ReturnDate { get; init; }

    public ICollection<Book> Books { get; init; } = [];
    public Client Client { get; init; } = null!;


    public Lend(ICollection<Book> books, Client client)
        : base()
    {
        Books = books;
        Client = client;

        var days = client.IsUnder18() ? 30 : 15;
        ReturnDate = DateTime.Now.AddDays(days);
        Date = DateTime.Now;
    }

    public Lend(DateTime date, DateTime returnDate)
        : base()
    {
        Date = date;
        ReturnDate = returnDate;
    }
}
