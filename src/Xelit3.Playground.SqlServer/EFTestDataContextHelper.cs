using Microsoft.EntityFrameworkCore;
using Xelit3.Tests.Model.Helpers;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.SqlServer;

public class EFTestDataContextHelper
{
    public EFTestDataContext DbContext { get; private set; }

    public Person<Guid>? RandomPersonGuid { get; private set; }
    public Person<int>? RandomPersonInt { get; private set; }
    public Person<long>? RandomPersonLong { get; private set; }

    public int RowsNumber { get; private set; }
    public int RowsToRetrieve => RowsNumber * 20 / 100;


    Country<Guid> _testCountryGuid = new Country<Guid>() { Id = Guid.NewGuid(), Name = "Kenya" };
    Country<int> _testCountryInt = new Country<int>() { Name = "Kenya" };
    Country<long> _testCountryLong = new Country<long>() { Name = "Kenya" };

    City<int> _testCityInt = new City<int>() { Name = "Barcelona", Population = 3600000 };

    List<Person<Guid>> _testPersonsGuid = new List<Person<Guid>>();
    List<Person<int>> _testPersonsInt = new List<Person<int>>();
    List<Person<long>> _testPersonsLong = new List<Person<long>>();

    List<Address<int>> _testPersonsAddresses = new List<Address<int>>();
    List<Post<int>> _testPersonsPosts = new List<Post<int>>();


    private EFTestDataContextHelper()
    {
        DbContext = new EFTestDataContext();
    }

    private static EFTestDataContextHelper _instance = null;
    public static EFTestDataContextHelper Instance => TryPrepareAndReturnInstance();


    private static EFTestDataContextHelper TryPrepareAndReturnInstance()
    {
        if (_instance == null)
            _instance = new EFTestDataContextHelper();

        return _instance;
    }

    public void Initialize(int personsCount)
    {
        DbContext.Add(_testCountryGuid);
        DbContext.Add(_testCountryInt);
        DbContext.Add(_testCountryLong);

        DbContext.SaveChanges();

        _testCityInt.CountryId = _testCountryInt.Id;
        DbContext.Add(_testCityInt);

        DbContext.SaveChanges();

        Console.WriteLine($"Added new city, ID: {_testCityInt.Id}");

        Console.WriteLine($"Added new country, ID: {_testCountryGuid.Id}");
        Console.WriteLine($"Added new country, ID: {_testCountryInt.Id}");
        Console.WriteLine($"Added new country, ID: {_testCountryLong.Id}");
        
        _testPersonsGuid = PersonHelper.Generate<Guid>(personsCount, _testCountryGuid);
        _testPersonsInt = PersonHelper.Generate<int>(personsCount, _testCountryInt);
        _testPersonsLong = PersonHelper.Generate<long>(personsCount, _testCountryLong);       

        DbContext.AddRange(_testPersonsGuid);
        Console.WriteLine($"Added {personsCount} persons. GUID Id type");

        DbContext.AddRange(_testPersonsInt);
        Console.WriteLine($"Added {personsCount} persons. INT Id type");

        DbContext.AddRange(_testPersonsLong);
        Console.WriteLine($"Added {personsCount} persons. LONG Id type");

        DbContext.SaveChanges();
        Console.WriteLine($"Transaction completed...");

        foreach (var personTest in _testPersonsInt)
        {
            var generatedAddresses = AddressHelper.Generate<int>(10, _testCityInt, personTest);
            var generatedPosts = PostHelper.Generate<int>(10, personTest);

            _testPersonsAddresses.AddRange(generatedAddresses);
            _testPersonsPosts.AddRange(generatedPosts);
        }

        DbContext.AddRange(_testPersonsAddresses);
        DbContext.AddRange(_testPersonsPosts);
        DbContext.SaveChanges();
        Console.WriteLine($"Added {_testPersonsAddresses.Count} addresses in total (for each INT user). INT Id type");
        Console.WriteLine($"Added {_testPersonsPosts.Count} posts in total (for each INT user). INT Id type");

        var random = new Random().Next(personsCount);

        RandomPersonGuid = _testPersonsGuid.Skip(random).First();
        RandomPersonInt = _testPersonsInt.Skip(random).First();
        RandomPersonLong = _testPersonsLong.Skip(random).First();
        Console.WriteLine($"Prepared random persons to find...");
    }

    

    public void Finish()
    {
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Posts_int]");

        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Addresses_Int]");

        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Persons_Guid]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Persons_int]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Persons_long]");

        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Cities_int]");

        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Countries_Guid]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Countries_int]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Countries_long]");
    }
}
