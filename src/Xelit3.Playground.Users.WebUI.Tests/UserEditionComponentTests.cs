using System;
using System.Threading.Tasks;
using Xelit3.Playground.Users.Shared.Enums;
using Xelit3.Playground.Users.Shared.Models;
using Xelit3.Playground.Users.WebUI.Pages;
using Xelit3.Playground.Users.WebUI.Services;

namespace Xelit3.Playground.Users.WebUI.Tests;


public class UserEditionComponentTests : TestContext
{
    [Fact]
    public void Given_UserEditionComponent_When_Rendered_InitialMarkdownIsExpected()
    {
        //Arrange
        var userId = 1;
        var userService = Substitute.For<IUserService>();
        userService.GetAsync(userId).Returns(Task.FromResult(new UserDto(userId, "Name", "Surname", "email@test.com", DateTime.Now.AddYears(-20), true, RoleType.Basic)));
        Services.AddScoped<IUserService>(x => userService);

        //Act
        var cut = RenderComponent<UserEdition>(p => 
            p.Add(n => n.Id, userId)
        );

        //Assert
        cut.Find("h3").MarkupMatches("<h3>Edit User</h3>");        
    }
   
}
