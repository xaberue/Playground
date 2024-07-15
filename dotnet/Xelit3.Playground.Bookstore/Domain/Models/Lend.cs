using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Lend : ModelBase
{
    public DateTime Date { get; set; }
    public DateTime ReturnDate { get; set; }

    public ICollection<Book> Books { get; set; }
    public Client Client { get; set; }
}
