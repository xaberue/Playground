using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Book : ModelBase
{
    public string Isbn { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int YearPublished { get; set; }
    public decimal Price { get; set; }

    public ICollection<Lend> Lends { get; set; }
    public ICollection<Purchase> Purchases { get; set; }
}
