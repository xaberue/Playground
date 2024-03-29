using Bogus;
using Xelit3.Playground.Users.WebApi.Models;

namespace Xelit3.Playground.Users.Tests.Helpers;

public static class UsersHelper
{
    public static IEnumerable<User> Generate(int number)
    {
        var faker = new Faker();
        
        for (int i = 0; i < number; i++)
        {
            yield return new User(
                faker.Person.FirstName,
                faker.Person.LastName,
                faker.Person.Email,
                faker.UniqueIndex.ToString(),
                faker.Person.DateOfBirth
                );
        }
    }
}
