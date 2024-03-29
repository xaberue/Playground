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

        //Act
        var cut = RenderComponent<UserCreation>();

        cut.Find("#form-input-name").Change("Test");
        cut.Find("#form-input-surname").Change("Surname");
        cut.Find("#form-input-email").Change("test@email.com");
        cut.Find("#form-input-password").Change("Test.1234!");
        cut.Find("#form-input-birthdate").Change(DateTime.Now.ToString("yyyy-MM-dd"));

        var submitButton = cut.Find("button[type=submit]");
        submitButton.Click();

        //Assert
        cut.Find("h3").MarkupMatches("<h3>New User</h3>");
        Assert.DoesNotContain("validation-message", cut.Markup);

    }

}
