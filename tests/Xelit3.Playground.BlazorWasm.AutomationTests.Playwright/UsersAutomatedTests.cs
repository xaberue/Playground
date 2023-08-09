using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using System.Text.RegularExpressions;

namespace PlaywrightTests;


[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task HomepageHasPlaywrightInTitleAndGetStartedLinkLinkingtoTheIntroPage()
    {
        await Page.GotoAsync("https://localhost:7138/");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Home"));

        // create a locator
        var surveyClick = Page.GetByRole(AriaRole.Link, new() { Name = "brief survey" });

        // Expect an attribute "to be strictly equal" to the value.
        await Expect(surveyClick).ToHaveAttributeAsync("href", "https://go.microsoft.com/fwlink/?linkid=2186157");
        
        //Link to new opened tab
        var newPage = await Page.Context.RunAndWaitForPageAsync(async () =>
        {
            //Click the get started link.
            await surveyClick.ClickAsync();
        });
        await newPage.WaitForLoadStateAsync();

        // Expects the URL to contain intro.
        await Expect(newPage).ToHaveURLAsync(new Regex("survey.*"));
    }
}