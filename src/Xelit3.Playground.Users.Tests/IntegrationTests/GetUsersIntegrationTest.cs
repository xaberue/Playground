using System.Net.Http.Json;
using Xelit3.Playground.Users.Shared.Models;
using Xelit3.Playground.Users.Tests.Helpers;
using Xelit3.Playground.Users.WebApi.Models;

namespace Xelit3.Playground.Users.Tests.IntegrationTests;


public class GetUsersIntegrationTest : IntegrationTestBase, IAsyncLifetime
{

    ICollection<User>? _testUsers = null;


    public GetUsersIntegrationTest(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    { }


    [Fact]
    public async Task Given_UsersDataInserted_When_UsersRequested_Then_UsersRetrived()
    {
        // Act
        var response = await Client.GetAsync("users");
        var usersList = await response.Content.ReadFromJsonAsync<IEnumerable<UserDto>>();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.True(usersList.Count() >= _testUsers.Count);
        Assert.Empty(_testUsers.Select(x => x.Id).Except(usersList.Select(x => x.Id)));
    }


    public async Task InitializeAsync() 
    {
        _testUsers = UsersHelper.Generate(100).ToList();
        
        using var dbContext = GetDbContext();
        
        await dbContext.AddRangeAsync(_testUsers);        
        await dbContext.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        using var dbContext = GetDbContext();

        dbContext.RemoveRange(_testUsers);
        await dbContext.SaveChangesAsync();
    }
}