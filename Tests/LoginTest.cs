using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightQuest.Data;
using PlaywrightQuest.Pages;

namespace PlaywrightQuest.Tests;

public class LoginTest : PageTest
{
    ////Record video for the test - it will be saved in /bin/Debug/net10.0/videos
    //public override BrowserNewContextOptions ContextOptions()
    //{
    //    return new BrowserNewContextOptions
    //    {
    //        RecordVideoDir = "videos/",
    //        RecordVideoSize = new()
    //        {
    //            Width = 1280,
    //            Height = 720
    //        }
    //    };
    //}

    [Test]
    public async Task SignupValidUser()
    {
        var user = User.CreateValidUser();
        var loginPage = new LoginPage(Page);
        var homePage = new HomePage(Page);

        await homePage.OpenHomePage();
        await homePage.CookieConsent();
        await homePage.VerifyHomePage();

        await homePage.GoToSignupOrLoginPage();

        await loginPage.Signup(user);
        await loginPage.VerifySignup();
        await loginPage.ContinueAfterSignup();
        await loginPage.VerifyLogin();
    }
}