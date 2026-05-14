using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightQuest.Pages;


namespace PlaywrightQuest.Tests
{
    internal class CartTest : PageTest
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
        // 7th Test
        // Test Case 12: Add Products in Cart - from Test Cases - https://www.automationexercise.com/test_cases

        public async Task AddToCart()
        {
            var homePage = new HomePage(Page);
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);

            await homePage.OpenHomePage();
            await homePage.CookieConsent();
            await homePage.VerifyHomePage();

            await homePage.GoToProductsPage();
            await productsPage.VerifyProductsPage();

            await productsPage.AddFirstItemToCart();
            await productsPage.ContinueShopping();
            await productsPage.AddSecondItemToCart();

            await productsPage.ViewCartAfterAddToCart();
            await cartPage.VerifyCartPage();
            await cartPage.VerifyProductToCart("Men Tshirt");
            await cartPage.VerifyProductPriceinCart("Blue Top");
            await cartPage.VerifyProductPriceinCart("Men Tshirt");


        }

        [Test]
        // 8th Test
        // Test Case 13: Verify Product quantity in Cart - from Test Cases - https://www.automationexercise.com/test_cases
        public async Task VerifyProductQuantityInCart()
        {
            var homePage = new HomePage(Page);
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);

            await homePage.OpenHomePage();
            await homePage.CookieConsent();
            await homePage.VerifyHomePage();

            await productsPage.ViewProduct();
            await productsPage.VerifyDetailsAreVisible();
            await productsPage.ChangeQuantity("4");
            await productsPage.AddToCart();
            await productsPage.ViewCartAfterAddToCart();

            await cartPage.VerifyCartPage();
            await cartPage.CheckItemInCartQuantity("4");

        }

        [Test]
        // 9th Test
        // Test Case 17: Remove Products From Cart - from Test Cases - https://www.automationexercise.com/test_cases

        public async Task RemoveProductFromCart()
        {
            var homePage = new HomePage(Page);
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);

            await homePage.OpenHomePage();
            await homePage.CookieConsent();
            await homePage.VerifyHomePage();

            await productsPage.AddFirstItemToCart();
            await productsPage.ViewCartAfterAddToCart();

            await cartPage.VerifyCartPage();
            await cartPage.DeleteProduct();
            await cartPage.VerifyCartIsEmpty();

        }
    }
}
