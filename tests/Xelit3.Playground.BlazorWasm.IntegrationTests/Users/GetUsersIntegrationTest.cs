using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Xelit3.Playground.BlazorWasm.IntegrationTests.Base;
using Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration;
using Xelit3.Playground.BlazorWasm.Shared;
using Xelit3.Tests.Model.Helpers;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.BlazorWasm.IntegrationTests;

public class GetUsersIntegrationTest : IntegrationTestBase, IAsyncLifetime
{

    Country<Guid>? _testCountry = null;
    ICollection<Person<Guid>>? _testUsers = null;


    public GetUsersIntegrationTest(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    { }


    [Fact]
    public async Task Given_UsersDataInserted_When_UsersRequested_Then_UsersRetrived()
    {
        // Act
        var response = await Client.GetAsync("api/users");
        var usersList = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.True(usersList.Count() >= _testUsers.Count);
        Assert.Empty(usersList.Select(x => x.Id).Except(_testUsers.Select(x => x.Id)));
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