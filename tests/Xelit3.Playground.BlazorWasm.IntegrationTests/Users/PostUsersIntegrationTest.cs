using Microsoft.EntityFrameworkCore;
using System.Net.Http.Json;
using Xelit3.Playground.BlazorWasm.IntegrationTests.Base;
using Xelit3.Playground.BlazorWasm.IntegrationTests.Configuration;
using Xelit3.Playground.BlazorWasm.Shared;
using Xelit3.Tests.Model.Models;

namespace Xelit3.Playground.BlazorWasm.IntegrationTests;

public class PostUsersIntegrationTest : IntegrationTestBase, IAsyncLifetime
{

    Country<Guid>? _testCountry = null;
    Guid? _userIdCreated = null;


    public PostUsersIntegrationTest(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    { }


    [Fact]
    public async Task Given_UsersContext_When_UserCreated_Then_UserCreated()
    {
        //Arrange
        var creationCommand = new UserCreationDto(_testCountry.Id, "Test", "Surname", DateTime.Now);

        // Act
        var response = await Client.PostAsJsonAsync("api/users", creationCommand);
        var userCreated = await response.Content.ReadFromJsonAsync<UserDto>();

        _userIdCreated = userCreated.Id;

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.True(userCreated.Id != Guid.Empty);
        Assert.Equal(userCreated.FullName, $"{creationCommand.Name} {creationCommand.Surname}");
        Assert.Equal(userCreated.BirthDate, creationCommand.BirthDate);
    }


    public async Task InitializeAsync() 
    {
        _testCountry = new Country<Guid>() { Id = Guid.NewGuid(), Name = "Spain" };
        
        using var dbContext = GetDbContext();
        
        var test = dbContext.Database.GetConnectionString();
        await dbContext.AddAsync(_testCountry);
        await dbContext.SaveChangesAsync();
    }

    public async Task DisposeAsync()
    {
        using var dbContext = GetDbContext();

        var user = dbContext.Persons_Guid.Find(_userIdCreated);
        dbContext.Persons_Guid.Remove(user);
        await dbContext.SaveChangesAsync();
        dbContext.Remove(_testCountry);
        await dbContext.SaveChangesAsync();
    }
}