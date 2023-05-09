using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Net.Http.Json;
using Xelit3.Playground.BlazorWasm.IntegrationTests.Base;
using Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration;
using Xelit3.Playground.BlazorWasm.Shared;
using Xelit3.Tests.Model.Helpers;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.BlazorWasm.IntegrationTests;

public class GetPaginatedUsersIntegrationTest : IntegrationTestBase, IAsyncLifetime
{

    Country<Guid>? _testCountry = null;
    ICollection<Person<Guid>>? _testUsers = null;


    public GetPaginatedUsersIntegrationTest(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    { }
   

    [Fact]
    public async Task Given_UsersDataInsertedAndTimeTreshold_When_ThousandsUsersRequested_Then_UsersRetrivedInTime()
    {
        //Assert
        int page = 0, size = 1000;
        int thesholdInMiliseconds = 10000;

        // Act
        var watch = Stopwatch.StartNew();
        var response = await Client.GetAsync($"api/users/paginated?page={page}&size={size}");
        watch.Stop();
        var usersList = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(usersList.Count(), size);
        Assert.True(watch.ElapsedMilliseconds < thesholdInMiliseconds);
    }


    public async Task InitializeAsync() 
    {
        _testCountry = new Country<Guid>() { Id = Guid.NewGuid(), Name = "Kenya" };
        _testUsers = PersonHelper.Generate(1000, _testCountry!).ToList();
        
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