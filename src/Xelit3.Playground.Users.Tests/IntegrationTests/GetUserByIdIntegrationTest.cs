using System.Net.Http.Json;
using Xelit3.Playground.Users.Shared.Models;
using Xelit3.Playground.Users.Tests.Helpers;
using Xelit3.Playground.Users.WebApi.Models;

namespace Xelit3.Playground.Users.Tests.IntegrationTests;


public class GetUserByIdIntegrationTest : IntegrationTestBase, IAsyncLifetime
{

    User? _testUser = null;


    public GetUserByIdIntegrationTest(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    { }


    [Fact]
    public async Task Given_UsersDataInserted_When_UsersRequestedById_Then_UserRetrived()
    {
        // Act
        var response = await Client.GetAsync($"users/{_testUser!.Id}");
        var user = await response.Content.ReadFromJsonAsync<UserDto>();

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.Equal(_testUser.Id, user.Id);
        Assert.Equal(_testUser.Name, user.Name);
        Assert.Equal(_testUser.Surname, user.Surname);
    }


    public async Task InitializeAsync() 
    {
        _testUser = UsersHelper.Generate(1).First();
        
        using var dbContext = GetDbContext();
        
        await dbContext.AddAsync(_testUser);        
        await dbContext.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        using var dbContext = GetDbContext();

        dbContext.Remove(_testUser!);
        await dbContext.SaveChangesAsync();
    }
}