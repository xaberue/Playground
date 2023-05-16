using Microsoft.EntityFrameworkCore;
using Xelit3.Tests.Model;
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


    Country<Guid> _testCountryGuid = CountryHelper.GetSingle<Guid>();
    Country<int> _testCountryInt = CountryHelper.GetSingle<int>();
    Country<long> _testCountryLong = CountryHelper.GetSingle<long>();

    City<Guid> _testCityGuid = CityHelper.GetSingle<Guid>();
    City<int> _testCityInt = CityHelper.GetSingle<int>();
    

    List<Person<Guid>> _testPersonsGuid = new List<Person<Guid>>();
    List<Person<int>> _testPersonsInt = new List<Person<int>>();
    List<Person<long>> _testPersonsLong = new List<Person<long>>();

    List<Address<Guid>> _testPersonsAddresses = new List<Address<Guid>>();
    List<Post<Guid>> _testPersonsPosts = new List<Post<Guid>>();

    
    private EFTestDataContextHelper()
    {
        DbContext = new EFTestDataContext("Data Source=localhost;Initial Catalog=Test;Integrated Security=True;TrustServerCertificate=True");
    }

    private static EFTestDataContextHelper _instance = null;
    public static EFTestDataContextHelper Instance => TryPrepareAndReturnInstance();


    private static EFTestDataContextHelper TryPrepareAndReturnInstance()
    {
        if (_instance == null)
            _instance = new EFTestDataContextHelper();

        return _instance;
    }

    public void InitializeDefault(int personsCount)
    {
        DbContext.Database.EnsureCreated();

        DbContext.Add(_testCountryGuid);
        
        DbContext.SaveChanges();

        _testCityGuid.CountryId = _testCountryGuid.Id;
        DbContext.Add(_testCityGuid);

        DbContext.SaveChanges();

        Console.WriteLine($"Added new city, ID: {_testCityGuid.Id}");

        Console.WriteLine($"Added new country, ID: {_testCountryGuid.Id}");
        
        
        _testPersonsGuid = PersonHelper.Generate<Guid>(personsCount, _testCountryGuid);
        
        DbContext.AddRange(_testPersonsGuid);
        Console.WriteLine($"Added {personsCount} persons. GUID Id type");

        DbContext.SaveChanges();

        foreach (var personTest in _testPersonsGuid)
        {
            var generatedAddresses = AddressHelper.Generate<Guid>(10, _testCityGuid, personTest);
            var generatedPosts = PostHelper.Generate<Guid>(100, personTest);

            _testPersonsAddresses.AddRange(generatedAddresses);
            _testPersonsPosts.AddRange(generatedPosts);
        }

        DbContext.AddRange(_testPersonsAddresses);
        DbContext.AddRange(_testPersonsPosts);
        DbContext.SaveChanges();
        Console.WriteLine($"Added {_testPersonsAddresses.Count} addresses in total (for each user). GUID Id type");
        Console.WriteLine($"Added {_testPersonsPosts.Count} posts in total (for each user). GUID Id type");

        var random = new Random().Next(personsCount);

        RandomPersonGuid = _testPersonsGuid.Skip(random).First();
        
        Console.WriteLine($"Prepared random person to find...");
    }

    public void InitializeAllKeyTypes(int personsCount)
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

        var random = new Random().Next(personsCount);

        RandomPersonGuid = _testPersonsGuid.Skip(random).First();
        RandomPersonInt = _testPersonsInt.Skip(random).First();
        RandomPersonLong = _testPersonsLong.Skip(random).First();
        Console.WriteLine($"Prepared random persons to find...");
    }



    public void Finish()
    {
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Posts_Guid]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Posts_int]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Posts_long]");

        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Addresses_Guid]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Addresses_Int]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Addresses_long]");

        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Persons_Guid]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Persons_int]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Persons_long]");

        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Cities_Guid]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Cities_int]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Cities_long]");

        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Countries_Guid]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Countries_int]");
        DbContext.Database.ExecuteSqlRaw("DELETE FROM [dbo].[Countries_long]");
    }
}
