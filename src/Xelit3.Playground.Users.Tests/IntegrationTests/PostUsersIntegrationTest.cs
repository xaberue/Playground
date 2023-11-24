using System.Net.Http.Json;
using Xelit3.Playground.Users.Shared.Enums;
using Xelit3.Playground.Users.Shared.Models;
using Xelit3.Playground.Users.Tests.Helpers;

namespace Xelit3.Playground.Users.Tests.IntegrationTests;


public class PostUsersIntegrationTest : IntegrationTestBase, IAsyncLifetime
{

    int? _userIdCreated = null;


    public PostUsersIntegrationTest(CustomWebApplicationFactory<Program> factory)
        : base(factory)
    { }


    [Fact]
    public async Task Given_UsersContext_When_UserCreated_Then_UserCreated()
    {
        //Arrange
        var creationCommand = new CreateUserDto
        {
            Name = "John",
            Surname = "Doe",
            BirthDate = new DateTime(1980, 1, 1),
            Email = "john.doe@email.com",
            Password = "123456"
        };

        // Act
        var response = await Client.PostAsJsonAsync("users", creationCommand);
        var userCreated = await response.Content.ReadFromJsonAsync<UserDto>();

        _userIdCreated = userCreated.Id;

        // Assert
        response.EnsureSuccessStatusCode();
        Assert.True(userCreated.Id != default);
        Assert.Equal(creationCommand.Name, userCreated.Name);
        Assert.Equal(creationCommand.Surname, userCreated.Surname);
        Assert.Equal(creationCommand.Email, userCreated.Email);
        Assert.Equal(creationCommand.BirthDate, userCreated.BirthDate);
        Assert.True(userCreated.IsAdult);
        Assert.Equal(RoleType.Basic, userCreated.Role);
        Assert.Equal($"{creationCommand.Name} {creationCommand.Surname}", userCreated.FullName);
    }


    public async Task InitializeAsync()
    {
       //Nothing to do
    }

    public async Task DisposeAsync()
    {
        using var dbContext = GetDbContext();

        var user = dbContext.Users.Find(_userIdCreated);
        dbContext.Users.Remove(user);
        await dbContext.SaveChangesAsync();
    }
}