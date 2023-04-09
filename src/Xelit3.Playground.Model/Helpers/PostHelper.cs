using Bogus;

namespace Xelit3.Tests.Model.Helpers;

public static class PostHelper
{
    public static List<Post<TKey>> Generate<TKey>(int count, Person<TKey> person)
        => new Faker<Post<TKey>>()            
            .RuleFor(x => x.AuthorId, person.Id)
            .RuleFor(x => x.Title, "Title")
            .RuleFor(x => x.Text, f => f.Lorem.Text())
            .Generate(count);
}
