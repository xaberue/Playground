using Bogus;

namespace Xelit3.Playground.Documents;

public static class InvoiceHelper
{

    public static Invoice GetFakeInvoice()
    {
        var faker = new Faker();

        return new Invoice
        {
            Id = 1,
            Date = DateTime.Now,
            Number = faker.Random.Number(10000, 99999).ToString(),
            Address = new Address
            {
                Id = 1,
                Line = faker.Address.FullAddress()
            },
            Items = GetFakeItems(faker).ToList()
        };
    }


    private static IEnumerable<Item> GetFakeItems(Faker faker)
    {
        for (var i = 0; i < 100; i++)
        {
            yield return new Item
            {
                Id = i,
                Name = faker.Vehicle.Model(),
                Price = faker.Random.Decimal(1, 100),
                Quantity = faker.Random.Int(1, 10)
            };
        }
    }
}
