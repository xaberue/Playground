using Xelit3.Playground.Bookstore.Domain.Base;

namespace Xelit3.Playground.Bookstore.Domain.Models;

public class Book : ModelBase
{
    public string Isbn { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
    public int YearPublished { get; init; }
    public decimal Price { get; init; }

    public ICollection<Lend> Lends { get; init; } = [];
    public ICollection<Purchase> Purchases { get; init; } = [];



    public Book(string isbn, string title, string author, int yearPublished, decimal price)
        : base()
    {
        Isbn = isbn;
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        Price = price;
    }

    public Book(string isbn, string title, string author, int yearPublished, decimal price, ICollection<Lend> lends, ICollection<Purchase> purchases)
        : this(isbn, title, author, yearPublished, price)
    {
        Lends = lends;
        Purchases = purchases;
    }
}
