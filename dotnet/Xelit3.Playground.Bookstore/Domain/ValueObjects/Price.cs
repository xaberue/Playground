namespace Xelit3.Playground.Bookstore.Domain.ValueObjects;

public class Price
{

    public decimal Amount { get; init; }


    public Price(decimal amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Price can't be equar or lower than 0");

        Amount = amount;
    }

}
