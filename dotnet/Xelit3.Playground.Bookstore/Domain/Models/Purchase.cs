using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Purchase : ModelBase
{
    public DateTime Date { get; set; }
    public decimal Amount { get; set; }

    public ICollection<Book> Books { get; set; }
    public Client Client { get; set; }
}
