using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightQuest.Data;
using PlaywrightQuest.Pages;

namespace PlaywrightQuest.Tests;

public class ProductsTest : PageTest
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
    // 5th Test
    // Test Case 8: Verify All Products and product detail page - from Test Cases - https://www.automationexercise.com/test_cases
    public async Task VerifyAllProductsAndDetail()
    {
        var productsPage = new ProductsPage(Page);
        var homePage = new HomePage(Page);

        await homePage.OpenHomePage();
        await homePage.CookieConsent();
        await homePage.VerifyHomePage();

        await homePage.GoToProductsPage();
        await productsPage.VerifyProductsPage();

        await productsPage.ViewProduct();
        await productsPage.VerifyDetailsAreVisible();
    }

    [Test]
    // 6th Test
    // Test Case 9: Search Product - from Test Cases - https://www.automationexercise.com/test_cases
    public async Task SearchProduct()
    {
        var productsPage = new ProductsPage(Page);
        var homePage = new HomePage(Page);
        var search = Search.CreateSearchProduct();

        await homePage.OpenHomePage();
        await homePage.CookieConsent();
        await homePage.VerifyHomePage();

        await homePage.GoToProductsPage();
        await productsPage.VerifyProductsPage();

        await productsPage.SearchProduct(search);
        await productsPage.VerifySearchedProductsIsVisible();
        await productsPage.VerifyAllSearchedProductsAreVisible(search);
    }
}