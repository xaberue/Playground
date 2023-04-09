using BenchmarkDotNet.Attributes;
using Bogus;
using Microsoft.EntityFrameworkCore;
using Xelit3.Tests.Model;

namespace Xelit3.Benchmarks;


[Config(typeof(AntivirusFriendlyConfig))]
[MemoryDiagnoser(false)]
public class SqlServerEfCoreIdFetchBenchmarks
{
    
    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromGuid()
    {
        var element = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Guid.Find(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RandomPersonGuid.Id);        
        
        return await Task.FromResult(true);
    }

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromInt()
    {
        var element = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Int.Find(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RandomPersonInt.Id);
        
        return await Task.FromResult(true);
    }

    [Benchmark]
    public async Task<bool> RetrieveSingleElementFromLong()
    {
        var element = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Long.Find(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RandomPersonLong.Id);

        return await Task.FromResult(true);
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithTracking()
    {
        var data = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Int
            .Take(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RowsToRetrieve)
            .ToList();
    }

    [Benchmark]
    public void RetrieveMultilpeRowsWithoutTracking()
    {
        var data = SqlServerEfCoreIdFetchBenchmarksHelper.Instance.DbContext.Persons_Int
            .AsNoTracking()
            .Take(SqlServerEfCoreIdFetchBenchmarksHelper.Instance.RowsToRetrieve)
            .ToList();
    }
}


public class SqlServerEfCoreIdFetchBenchmarksHelper
{
    internal EFTestDataContext DbContext { get; private set; }

    internal Person<Guid>? RandomPersonGuid { get; private set; }
    internal Person<int>? RandomPersonInt { get; private set; }
    internal Person<long>? RandomPersonLong { get; private set; }

    internal int RowsNumber { get; private set; }
    internal int RowsToRetrieve => RowsNumber * 20 / 100;


    Country<Guid> _testCountryGuid = new Country<Guid>() { Id = Guid.NewGuid(), Name = "Kenya" };
    Country<int> _testCountryInt = new Country<int>() { Name = "Kenya" };
    Country<long> _testCountryLong = new Country<long>() { Name = "Kenya" };

    List<Person<Guid>> _testPersonsGuid = new List<Person<Guid>>();
    List<Person<int>> _testPersonsInt = new List<Person<int>>();
    List<Person<long>> _testPersonsLong = new List<Person<long>>();


    private SqlServerEfCoreIdFetchBenchmarksHelper()
    {
        DbContext = new EFTestDataContext();
    }

    private static SqlServerEfCoreIdFetchBenchmarksHelper _instance = null;
    public static SqlServerEfCoreIdFetchBenchmarksHelper Instance => TryPrepareAndReturnInstance();


    private static SqlServerEfCoreIdFetchBenchmarksHelper TryPrepareAndReturnInstance()
    {
        if (_instance == null)
            _instance = new SqlServerEfCoreIdFetchBenchmarksHelper();

        return _instance;
    }

    public void Initialize(int personsCount)
    {
        DbContext.Add(_testCountryGuid);        
        DbContext.Add(_testCountryInt);        
        DbContext.Add(_testCountryLong);

        DbContext.SaveChanges();

        Console.WriteLine($"Added new country, ID: {_testCountryGuid.Id}");
        Console.WriteLine($"Added new country, ID: {_testCountryInt.Id}");
        Console.WriteLine($"Added new country, ID: {_testCountryLong.Id}");


        _testPersonsGuid = new Faker<Person<Guid>>()
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.OriginId, _testCountryGuid.Id)
            .RuleFor(x => x.Origin, _testCountryGuid)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
            .Generate(personsCount);

        _testPersonsInt = new Faker<Person<int>>()
            .RuleFor(x => x.Id, 0)
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.OriginId, _testCountryInt.Id)
            .RuleFor(x => x.Origin, _testCountryInt)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
            .Generate(personsCount);        

        _testPersonsLong = new Faker<Person<long>>()
            .RuleFor(x => x.Id, 0)
            .RuleFor(x => x.Name, f => f.Person.FirstName)
            .RuleFor(x => x.Surname, f => f.Person.LastName)
            .RuleFor(x => x.OriginId, _testCountryLong.Id)
            .RuleFor(x => x.Origin, _testCountryLong)
            .RuleFor(x => x.BirthDate, f => f.Person.DateOfBirth)
            .Generate(personsCount);

        
        DbContext.AddRange(_testPersonsGuid);
        Console.WriteLine($"Added {personsCount} persons. GUID Id type");

        DbContext.AddRange(_testPersonsInt);
        Console.WriteLine($"Added {personsCount} persons. INT Id type");

        DbContext.AddRange(_testPersonsLong);
        Console.WriteLine($"Added {personsCount} persons. LONG Id type");

        DbContext.SaveChanges();
        Console.WriteLine($"Transaction completed...");


        var random = new Random().Next(personsCount);

        RandomPersonGuid = _testPersonsGuid.Skip(random).First();
        RandomPersonInt = _testPersonsInt.Skip(random).First();
        RandomPersonLong = _testPersonsLong.Skip(random).First();
        Console.WriteLine($"Prepared random persons to find...");
    }

    public void Finish()
    {
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Persons_Guid]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Persons_int]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Persons_long]");

        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Countries_Guid]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Countries_int]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Countries_long]");
    }
}