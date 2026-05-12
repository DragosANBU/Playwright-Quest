using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightQuest.Pages;

public class HomePage
{
    private readonly IPage _page;

    public HomePage(IPage page)
    {
        _page = page;
    }

    public async Task OpenHomePage()
    {
        await _page.GotoAsync("https://automationexercise.com/");
    }

    public async Task CookieConsent()
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Heading, new() { Name = "This site asks for consent to" })).ToBeVisibleAsync();
        await _page.GetByRole(AriaRole.Button, new() { Name = "Consent" }).ClickAsync();
    }

    public async Task VerifyHomePage()
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Link, new() { Name = "Website for automation" })).ToBeVisibleAsync();
    }

    public async Task GoToSignupOrLoginPage()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = " Signup / Login" }).ClickAsync();
    }

    public async Task GoToProductsPage()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = " Products" }).ClickAsync();
    }

    public async Task GoToCartPage()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = " Cart" }).ClickAsync();
    }

    public async Task GoToContactUsPage()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = " Contact us" }).ClickAsync();
    }

    //public async Task CheckForAdds()
    //{
    //    await Assertions.Expect(_page.Locator("iframe[name=\"aswift_4\"]").ContentFrame.GetByRole(AriaRole.Button, new() { Name = "Close ad" })).ToBeVisibleAsync();
    //    await _page.Locator("iframe[name=\"aswift_4\"]").ContentFrame.GetByRole(AriaRole.Button, new() { Name = "Close ad" }).ClickAsync();
    //}
}