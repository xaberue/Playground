using Microsoft.EntityFrameworkCore;
using Xelit3.Playground.BlazorWasm.IntegrationTests.Base;
using Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration;
using Xelit3.Tests.Model.Helpers;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.BlazorWasm.IntegrationTests;

public class UsersIntegrationTests : IntegrationTestBase, IAsyncLifetime
{

    Country<Guid>? _testCountry = null;
    ICollection<Person<Guid>>? _testUsers = null;


    public UsersIntegrationTests(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    { }


    [Fact]
    public async Task Test_1()
    {
       //TODO
    }


    public async Task InitializeAsync() 
    {
        _testCountry = new Country<Guid>() { Id = Guid.NewGuid(), Name = "Kenya" };
        _testUsers = PersonHelper.Generate(100, _testCountry!).ToList();
        
        using var dbContext = GetDbContext();
        
        var test = dbContext.Database.GetConnectionString();
        await dbContext.AddAsync(_testCountry);
        await dbContext.SaveChangesAsync();
        await dbContext.Persons_Guid.AddRangeAsync(_testUsers);
        await dbContext.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        using var dbContext = GetDbContext();

        dbContext.Persons_Guid.RemoveRange(_testUsers);
        await dbContext.SaveChangesAsync();
        dbContext.Remove(_testCountry);
        await dbContext.SaveChangesAsync();
    }
}