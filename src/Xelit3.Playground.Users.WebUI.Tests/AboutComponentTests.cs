using Xelit3.Playground.Users.WebUI.Pages;

namespace Xelit3.Playground.Users.WebUI.Tests;


public class AboutComponentTests : TestContext
{
    [Fact]
    public void Given_AboutComponent_When_Rendered_InitialMarkdownIsExpected()
    {
        // Arrange
        var cut = RenderComponent<About>();

        // Assert that content of the paragraph shows counter at zero
        cut.Find("h1").MarkupMatches("<h1>About Xelit3 Plaground Users</h1>");
        cut.Find("p").MarkupMatches("<p>This project is a showcase of how to work with a REST API in a Blazor app, and how to test the entire system.</p>");
    }
   
}
