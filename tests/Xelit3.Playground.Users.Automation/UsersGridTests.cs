using Microsoft.Playwright.NUnit;
using Microsoft.Playwright;
using System.Text.RegularExpressions;

namespace Xelit3.Playground.Users.Automation;


[Parallelizable(ParallelScope.Self)]
[TestFixture]
public class Tests : PageTest
{
    [Test]
    public async Task UsersContainer_RedirectsToNewUser_WhenAddIsClicked()
    {
        await Page.GotoAsync("https://localhost:7060/users");

        // Expect a title "to contain" a substring.
        await Expect(Page).ToHaveTitleAsync(new Regex("Xelit3.Playground.Users.WebUI"));

        // create a locator
        var addUserButton = Page.GetByRole(AriaRole.Button, new() { Name = "Add" });

        // Click the get started link.
        await addUserButton.ClickAsync();

        // Expects the URL to contain intro.
        await Expect(Page).ToHaveURLAsync(new Regex(".*new-user"));
    }

    [Test]
    public async Task NewUser_AddsNewUSer_WhenDataFilledAndSubmited()
    {
        await Page.GotoAsync("https://localhost:7060/users");

        var addUserButton = Page.GetByRole(AriaRole.Button, new() { Name = "Add" });
        
        await addUserButton.ClickAsync();

        await Page.Locator("#form-input-name").FillAsync("John");
        await Page.Locator("#form-input-surname").FillAsync("asdasd");
        await Page.Locator("#form-input-email").FillAsync("john.doe@email.com");
        await Page.Locator("#form-input-password").FillAsync("Pwd1234!");
        await Page.Locator("#form-input-birthdate").FillAsync("2001-01-01");

        var submitUser = Page.GetByRole(AriaRole.Button, new() { Name = "Submit" });

        await submitUser.ClickAsync();

        await Expect(Page).ToHaveURLAsync(new Regex(".*users"));
    }
}