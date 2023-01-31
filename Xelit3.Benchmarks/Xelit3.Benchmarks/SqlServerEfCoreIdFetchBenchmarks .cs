using BenchmarkDotNet.Attributes;
using Bogus;
using Xelit3.Tests.Model;

namespace Xelit3.Benchmarks;

[MemoryDiagnoser(false)]
public class SqlServerEfCoreIdFetchBenchmarks
{

    [GlobalSetup]
    public void Initialize()
    {
        var testCountry = new Country<Guid>() { Id = Guid.NewGuid(), Name = "Kenya" };

        var testPersons = new Faker<Xelit3.Tests.Model.Person<Guid>>()
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.OriginId, testCountry.Id)
            .RuleFor(x => x.Origin, testCountry)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
            .Generate(1000000);

        var dbConntext = new EFTestDataContext();

        dbConntext.Add(testCountry);
        dbConntext.AddRange(testPersons);
        dbConntext.SaveChanges();
    }


    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromGuid()
    {
        return await Task.FromResult(true);
    }

}
