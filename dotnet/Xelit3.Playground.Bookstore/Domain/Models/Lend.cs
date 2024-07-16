using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Lend : ModelBase
{
    public DateTime Date { get; init; }
    public DateTime ReturnDate { get; init; }

    public ICollection<Book> Books { get; init; }
    public Client Client { get; init; }
}
