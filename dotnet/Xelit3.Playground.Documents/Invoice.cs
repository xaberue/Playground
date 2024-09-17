namespace Xelit3.Playground.Documents;

public class Invoice
{

    public int Id { get; set; }
    public string Number { get; set; }
    public DateTime Date { get; set; }

    public List<Item> Items { get; set; }

    public Address Address { get; set; }
}


public class Item
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

}


public class Address
{
    public int Id { get; set; }
    public string Line { get; set; }
}
