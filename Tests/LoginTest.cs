using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightQuest.Data;
using PlaywrightQuest.Pages;

namespace PlaywrightQuest.Tests;

public class LoginTest : PageTest
{
    //Record video for the test - it will be saved in /bin/Debug/net10.0/videos
    public override BrowserNewContextOptions ContextOptions()
    {
        return new BrowserNewContextOptions
        {
            RecordVideoDir = "videos/",
            RecordVideoSize = new()
            {
                Width = 1280,
                Height = 720
            }
        };
    }

    [Test]
    // 1st Test
    // Test Case 1: Register User - from Test Cases - https://www.automationexercise.com/test_cases
    public async Task SignupValidUser()
    {
        var user = User.CreateRandomValidUser();
        var loginPage = new LoginPage(Page);
        var homePage = new HomePage(Page);

        await homePage.OpenHomePage();
        await homePage.CookieConsent();
        await homePage.VerifyHomePage();

        await homePage.GoToLoginPage();
        await loginPage.VerifyLoginPage();

        await loginPage.Signup(user);
        await loginPage.VerifySignup();
        await loginPage.ContinueAfterSignup();
        await loginPage.VerifyLogin();

        await homePage.DeleteAccount();
        await homePage.VerifyDeleteAccount();

    }
    [Test]
    // 2nd Test
    // Test Case 2: Login User with correct email and password -  from Test Cases - https://www.automationexercise.com/test_cases
    // This test will use an already registered user - email: "dragoslogin@mail.com", password: "asd123"
    public async Task LoginValidUser()
    {
        var loginPage = new LoginPage(Page);
        var homePage = new HomePage(Page);

        await homePage.OpenHomePage();
        await homePage.CookieConsent();
        await homePage.VerifyHomePage();

        await homePage.GoToLoginPage();
        await loginPage.VerifyLoginPage();

        await loginPage.Login("dragoslogin@mail.com", "asd123");
        await loginPage.VerifyLogin();
    }

    [Test]
    // 3rd Test
    // Test Case 3: Login User with incorrect email and password - from Test Cases - https://www.automationexercise.com/test_cases
    public async Task LoginInvalidUser()
    {
        var user = User.CreateRandomValidUser();
        var loginPage = new LoginPage(Page);
        var homePage = new HomePage(Page);

        await homePage.OpenHomePage();
        await homePage.CookieConsent();
        await homePage.VerifyHomePage();

        await homePage.GoToLoginPage();
        await loginPage.VerifyLoginPage();

        await loginPage.Login($"{Guid.NewGuid()}@mail.com", $"{Guid.NewGuid()}");
        await loginPage.VerifyLoginInvalid();
    }

    [Test]
    // 4th Test
    // Test Case 4: Logout User - from Test Cases - https://www.automationexercise.com/test_cases
    // This test will use an already registered user - email: "dragoslogout@mail.com", password: "asd123"

    public async Task LogoutUser()
    {
        var user = User.CreateRandomValidUser();
        var loginPage = new LoginPage(Page);
        var homePage = new HomePage(Page);

        await homePage.OpenHomePage();
        await homePage.CookieConsent();
        await homePage.VerifyHomePage();

        await homePage.GoToLoginPage();
        await loginPage.VerifyLoginPage();

        await loginPage.Login("dragoslogout@mail.com", "asd123");
        await loginPage.VerifyLogin();

        await loginPage.Logout();
        await loginPage.VerifyLoginPage();
    }
}