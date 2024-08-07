﻿using Xelit3.Playground.Bookstore.Lends;
using Xelit3.Playground.Bookstore.Purchases;
using Xelit3.Playground.Bookstore.Shared.Base;
using Xelit3.Playground.Bookstore.Shared.ValueObjects;

namespace Xelit3.Playground.Bookstore.Books;

public class Book : ModelBase
{
    public string Isbn { get; init; }
    public string Title { get; init; }
    public string Author { get; init; }
    public int YearPublished { get; init; }
    public Price Price { get; init; }

    public ICollection<Lend> Lends { get; init; } = [];
    public ICollection<Purchase> Purchases { get; init; } = [];



    public Book(string isbn, string title, string author, int yearPublished, Price price)
        : base()
    {
        Isbn = isbn;
        Title = title;
        Author = author;
        YearPublished = yearPublished;
        Price = price;
    }

    public Book(string isbn, string title, string author, int yearPublished, decimal price)
        : this(isbn, title, author, yearPublished, new Price(price))
    { }

    public Book(string isbn, string title, string author, int yearPublished, Price price, ICollection<Lend> lends, ICollection<Purchase> purchases)
        : this(isbn, title, author, yearPublished, price)
    {
        Lends = lends;
        Purchases = purchases;
    }
}
