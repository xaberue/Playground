using Xelit3.Playground.Bookstore.Books;
using Xelit3.Playground.Bookstore.Clients;
using Xelit3.Playground.Bookstore.Shared.Base;

namespace Xelit3.Playground.Bookstore.Purchases;

public class Purchase : ModelBase
{
    public DateTime Date { get; init; }
    public decimal Amount { get; init; }

    public ICollection<Book> Books { get; init; }
    public Client Client { get; init; }
}
