using Bogus;

namespace Xelit3.Tests.Model.Helpers;

public static class PersonHelper
{
    public static List<Person<TKey>> Generate<TKey>(int personsCount, Country<TKey> originCountry)
        => new Faker<Person<TKey>>()
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.OriginId, originCountry.Id)
            .RuleFor(x => x.Origin, originCountry)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
            .Generate(personsCount);
}
