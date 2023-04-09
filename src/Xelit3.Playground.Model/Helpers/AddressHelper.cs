using Bogus;

namespace Xelit3.Tests.Model.Helpers;

public static class AddressHelper
{
    public static List<Address<TKey>> Generate<TKey>(int count, City<TKey> city, Person<TKey> person)
        => new Faker<Address<TKey>>()
            .RuleFor(x => x.CityId, city.Id)
            .RuleFor(x => x.PersonId, person.Id)
            .RuleFor(x => x.Line, f => f.Address.FullAddress())
            .Generate(count);
}
