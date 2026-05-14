using Microsoft.Playwright;
using Microsoft.Playwright.NUnit;
using PlaywrightQuest.Pages;
using PlaywrightQuest.Data;

namespace PlaywrightQuest.Tests
{
    internal class CheckoutTest : PageTest
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
        // 10th Test
        // Test Case 16: Place Order: Login before Checkout - from Test Cases - https://www.automationexercise.com/test_cases
        public async Task PlaceOrderWithLogin()
        {
            var user = User.CheckoutUser();
            var card = CardDetails.CheckoutValidCardDragos();
            var homePage = new HomePage(Page);
            var loginPage = new LoginPage(Page);
            var productsPage = new ProductsPage(Page);
            var cartPage = new CartPage(Page);
            var checkoutPage = new CheckoutPage(Page);

            await homePage.OpenHomePage();
            await homePage.CookieConsent();
            await homePage.VerifyHomePage();
            await homePage.GoToLoginPage();

            await loginPage.VerifyLoginPage();
            await loginPage.Login(user.Email, user.Password);
            await loginPage.VerifyLogin();

            await productsPage.AddFirstItemToCart();
            await productsPage.ViewCartAfterAddToCart();

            await cartPage.VerifyCartPage();
            await cartPage.ProceedToCheckout();

            await checkoutPage.VerifyCheckoutPage();
            await checkoutPage.VerifyDeliveryAdressDetails(user.FirstName, user.LastName, user.Address, user.City, user.State, user.Zipcode, user.Phonenumber);
            await checkoutPage.VerifyBillingAdressDetails(user.FirstName, user.LastName, user.Address, user.City, user.State, user.Zipcode, user.Phonenumber);
            await checkoutPage.EnterOrderComment("I would like the product to be wrapped like a present.");
            await checkoutPage.PlaceOrder();
            await checkoutPage.EnterPaymentDetails(card.FullName, card.CardNumber, card.CVC, card.ExpMonth, card.ExpYear);
            await checkoutPage.PayAndConfirmOrder();
            await checkoutPage.VerifyOrderCompletion();

        }
    }
}
