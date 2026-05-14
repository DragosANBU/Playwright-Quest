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

        [Test]
        // Additional Test Case 1: Add Product multiple times and verify if the quantity in Cart updates correctly
        public async Task CheckIfQuantityUpdatesInCart()
        {
            var homePage = new HomePage(Page);
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);

            await homePage.OpenHomePage();
            await homePage.CookieConsent();
            await homePage.VerifyHomePage();

            await productsPage.AddFirstItemToCartMultipleTimes(5);
            await productsPage.ViewCartAfterAddToCart();

            await cartPage.VerifyCartPage();
            await cartPage.VerifyProductQuantityInCart("5");

        }

        [Test]
        // Additional Test Case 2: Login, add product to cart, refresh the page and check if the product is still in the cart and logged in
        public async Task CheckProductsInCartAndLoginAfterRefresh()
        {
            var homePage = new HomePage(Page);
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);
            var loginPage = new LoginPage(Page);

            await homePage.OpenHomePage();
            await homePage.CookieConsent();
            await homePage.VerifyHomePage();

            await homePage.GoToLoginPage();
            await loginPage.VerifyLoginPage();
            await loginPage.Login("dragoslogin@mail.com", "asd123");
            await loginPage.VerifyLogin();
            await productsPage.AddFirstItemToCartMultipleTimes(2);
            await productsPage.ViewCartAfterAddToCart();
            await cartPage.VerifyProductQuantityInCart("2");

            await homePage.GotoHomePage();
            await homePage.VerifyHomePage();
            await homePage.RefreshPage();

            await loginPage.VerifyLogin();
            await homePage.GoToCartPage();
            await cartPage.VerifyProductQuantityInCart("2");
            await cartPage.DeleteProduct();
            await cartPage.VerifyCartIsEmpty();
        }
    }
}
