using System;
using System.Threading.Tasks;
using Xelit3.Playground.Users.WebUI.Pages;
using Xelit3.Playground.Users.WebUI.Services;

namespace Xelit3.Playground.Users.WebUI.Tests;


public class UserCreationComponentTests : TestContext
{
    [Fact]
    public void Given_UserCreationComponent_When_Rendered_InitialMarkdownIsExpected()
    {
        //Arrange
        var userService = Substitute.For<IUserService>();
        userService.CreateAsync(default!).ReturnsForAnyArgs(Task.CompletedTask);
        Services.AddScoped<IUserService>(x => userService);

        //Act
        var cut = RenderComponent<UserCreation>();
        
        //Assert
        cut.Find("h3").MarkupMatches("<h3>New User</h3>");        
    }

    [Fact]
    public void Given_UserCreationComponentRenderedWithoutFormFilled_When_SubmitClicked_ValidationErrorsExpected()
    {
        //Arrange
        var userService = Substitute.For<IUserService>();
        userService.CreateAsync(default!).ReturnsForAnyArgs(Task.CompletedTask);
        Services.AddScoped<IUserService>(x => userService);

        //Act
        var cut = RenderComponent<UserCreation>();
        var submitButton = cut.Find("button[type=submit]");
        submitButton.Click();

        //Assert
        cut.Find("h3").MarkupMatches("<h3>New User</h3>");
        Assert.Contains(@"<li class=""validation-message"">The Name field is required.</li>", cut.Markup);
        Assert.Contains(@"<li class=""validation-message"">The Surname field is required.</li>", cut.Markup);
        Assert.Contains(@"<li class=""validation-message"">The Email field is required.</li>", cut.Markup);
        Assert.Contains(@"<li class=""validation-message"">The Password field is required.</li>", cut.Markup);
    }

    [Fact]
    public void Given_UserCreationComponentRenderedWithValidDataFilled_When_SubmitClicked_Expected()
    {
        //Arrange
        var userService = Substitute.For<IUserService>();
        userService.CreateAsync(default!).ReturnsForAnyArgs(Task.CompletedTask);
        Services.AddScoped<IUserService>(x => userService);
        var expectedName = "Name";
        var expectedSurname = "Surname";
        var expectedEmail = "test@email.com";
        var expectedPassword = "Pa$$w0rd.343_";
        var expectedBirthdate = DateTime.Now;

        //Act
        var nav = Services.GetRequiredService<FakeNavigationManager>();
        var cut = RenderComponent<UserCreation>();

        cut.Find("#form-input-name").Change(expectedName);
        cut.Find("#form-input-surname").Change(expectedSurname);
        cut.Find("#form-input-email").Change(expectedEmail);
        cut.Find("#form-input-password").Change(expectedPassword);
        cut.Find("#form-input-birthdate").Change(expectedBirthdate.ToString("yyyy-MM-dd"));

        var submitButton = cut.Find("button[type=submit]");
        submitButton.Click();

        //Assert
        cut.Find("h3").MarkupMatches("<h3>New User</h3>");
        Assert.DoesNotContain("validation-message", cut.Markup);
        Assert.Equal(expectedName, cut.Instance.Model.Name);
        Assert.Equal(expectedSurname, cut.Instance.Model.Surname);
        Assert.Equal(expectedEmail, cut.Instance.Model.Email);
        Assert.Equal(expectedPassword, cut.Instance.Model.Password);
        Assert.Equal(expectedBirthdate.Date, cut.Instance.Model.BirthDate.Date);
        Assert.Equal("http://localhost/users", nav.Uri);
    }

}
