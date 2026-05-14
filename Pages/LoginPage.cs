using Microsoft.Playwright;
using PlaywrightQuest.Data;

namespace PlaywrightQuest.Pages;

public class LoginPage
{
    private readonly IPage _page;

    public LoginPage(IPage page)
    {
        _page = page;
    }

    public async Task VerifyLoginPage()
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Heading, new() { Name = "Login to your account" })).ToBeVisibleAsync();
    }

    public async Task Login(string email, string password)
    {
        await _page.Locator("form").Filter(new() { HasText = "Login" }).GetByPlaceholder("Email Address").FillAsync(email);
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password" }).FillAsync(password);
        await _page.GetByRole(AriaRole.Button, new() { Name = "Login" }).ClickAsync();
    }

    public async Task VerifyLogin()
    {
        await Assertions.Expect(_page.GetByText("Logged in as")).ToBeVisibleAsync();
        await Assertions.Expect(_page.GetByRole(AriaRole.Link, new() { Name = " Delete Account" })).ToBeVisibleAsync();
    }

    public async Task VerifyLoginInvalid()
    {
        await Assertions.Expect(_page.GetByText("Your email or password is")).ToBeVisibleAsync();
    }

    public async Task Signup(User user)
    {
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "Name" }).FillAsync(user.Name);
        await _page.Locator("form").Filter(new() { HasText = "Signup" }).GetByPlaceholder("Email Address").FillAsync(user.Email);

        await _page.GetByRole(AriaRole.Button, new() { Name = "Signup" }).ClickAsync();
        await Assertions.Expect(_page.GetByText("Enter Account Information")).ToBeVisibleAsync();

        await _page.GetByRole(AriaRole.Radio, new() { Name = "Mr." }).ClickAsync();
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "Password *" }).FillAsync(user.Password);
        await _page.Locator("#days").SelectOptionAsync(new[] { "6" });
        await _page.Locator("#months").SelectOptionAsync(new[] { "6" });
        await _page.Locator("#years").SelectOptionAsync(new[] { "1985" });
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "First name *" }).FillAsync(user.FirstName);
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "Last name *" }).FillAsync(user.LastName);
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "Address * (Street address, P." }).FillAsync(user.Address);
        await _page.GetByLabel("Country *").SelectOptionAsync(new[] { "Canada" });
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "State *" }).FillAsync(user.State);
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "City * Zipcode *" }).FillAsync(user.City);
        await _page.Locator("#zipcode").FillAsync(user.Zipcode);
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "Mobile Number *" }).FillAsync(user.Phonenumber);
        await _page.GetByRole(AriaRole.Checkbox, new() { Name = "Sign up for our newsletter!" }).CheckAsync();
        await _page.GetByRole(AriaRole.Checkbox, new() { Name = "Receive special offers from" }).CheckAsync();

        await _page.GetByRole(AriaRole.Button, new() { Name = "Create Account" }).ClickAsync();
    }

    public async Task ContinueAfterSignup()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "Continue" }).ClickAsync();
    }

    public async Task VerifySignup()
    {
        await Assertions.Expect(_page.GetByText("Account Created!")).ToBeVisibleAsync();
    }

    public async Task Logout()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = " Logout" }).ClickAsync();
    }
}