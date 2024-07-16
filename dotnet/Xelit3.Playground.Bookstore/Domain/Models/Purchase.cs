using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Purchase : ModelBase
{
    public DateTime Date { get; init; }
    public decimal Amount { get; init; }

    public ICollection<Book> Books { get; init; }
    public Client Client { get; init; }
}
