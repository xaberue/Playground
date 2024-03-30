using Xelit3.Playground.Users.WebApi.Models;

namespace Xelit3.Playground.Users.Tests.UnitTests;

public class UserUnitTests
{
    [Fact]
    public void Given_AdultUser_When_IsUnder18Invoked_Then_FalseRetrived()
    {
        //Arrange
        var user = new User("Name", "Surname", "email@test.com", "pwd", DateTime.Now.AddYears(-20));

        //Act
        var result = user.IsUnder18();

        //Assert
        Assert.False(result);
    }

    [Fact]
    public void Given_UnderAgeUser_When_IsUnder18Invoked_Then_TrueRetrived()
    {
        //Arrange
        var user = new User("Name", "Surname", "email@test.com", "pwd", DateTime.Now.AddYears(-15));

        //Act
        var result = user.IsUnder18();

        //Assert
        Assert.True(result);
    }

    [Fact]
    public void Given_UserAndPasswordAndConfirmationEquals_When_UpdatePasswordInvoked_Then_PasswordUpdated()
    {
        //Arrange
        var expectedPassword = "newPwd";
        var user = new User("Name", "Surname", "email@test.com", "pwd", DateTime.Now.AddYears(-20));

        //Act
        user.UpdatePassword(expectedPassword, expectedPassword);

        //Assert            
        Assert.Equal(expectedPassword, user.Password);
    }


    [Fact]
    public void Given_UserAndPasswordAndConfirmationDifferent_When_UpdatePasswordInvoked_Then_ArgumentExceptionThrown()
    {
        //Arrange
        var expectedPassword = "newPwd";
        var user = new User("Name", "Surname", "email@test.com", "pwd", DateTime.Now.AddYears(-20));

        //Act
        var invokedMethod = () => user.UpdatePassword(expectedPassword, "differentPassword");
        //Assert
        //
        Assert.Throws<ArgumentException>(invokedMethod); 
    }
}