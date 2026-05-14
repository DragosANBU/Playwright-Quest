using Microsoft.Playwright;

namespace PlaywrightQuest.Pages
{
    public class CheckoutPage
    {
        private readonly IPage _page;

        public CheckoutPage(IPage page)
        {
            _page = page;
        }

        public async Task VerifyCheckoutPage()
        {
            await Assertions.Expect(_page.GetByText("Checkout")).ToBeVisibleAsync();
        }

        public async Task VerifyDeliveryAdressDetails(string FirstName, string LastName, string Address, string City, string State, string Zipcode, string Phonenumber)
        {
            await Assertions.Expect(_page.Locator("#address_delivery")).ToContainTextAsync(FirstName);
            await Assertions.Expect(_page.Locator("#address_delivery")).ToContainTextAsync(LastName);
            await Assertions.Expect(_page.Locator("#address_delivery")).ToContainTextAsync(Address);
            await Assertions.Expect(_page.Locator("#address_delivery")).ToContainTextAsync(City);
            await Assertions.Expect(_page.Locator("#address_delivery")).ToContainTextAsync(State);
            await Assertions.Expect(_page.Locator("#address_delivery")).ToContainTextAsync(Zipcode);
            await Assertions.Expect(_page.Locator("#address_delivery")).ToContainTextAsync(Phonenumber);
        }

        public async Task VerifyBillingAdressDetails(string FirstName, string LastName, string Address, string City, string State, string Zipcode, string Phonenumber)
        {
            await Assertions.Expect(_page.Locator("#address_invoice")).ToContainTextAsync(FirstName);
            await Assertions.Expect(_page.Locator("#address_invoice")).ToContainTextAsync(LastName);
            await Assertions.Expect(_page.Locator("#address_invoice")).ToContainTextAsync(Address);
            await Assertions.Expect(_page.Locator("#address_invoice")).ToContainTextAsync(City);
            await Assertions.Expect(_page.Locator("#address_invoice")).ToContainTextAsync(State);
            await Assertions.Expect(_page.Locator("#address_invoice")).ToContainTextAsync(Zipcode);
            await Assertions.Expect(_page.Locator("#address_invoice")).ToContainTextAsync(Phonenumber);

        }

        public async Task EnterOrderComment(string OrderComment)
        {
            await _page.Locator("textarea[name=\"message\"]").FillAsync(OrderComment);
        }

        public async Task PlaceOrder()
        {
           await _page.GetByRole(AriaRole.Link, new() { Name = "Place Order" }).ClickAsync();
        }

        public async Task EnterPaymentDetails(string FullName, string CardNumber, string CVC, string ExpMonth, string ExpYear)
        {
            await _page.Locator("input[name=\"name_on_card\"]").FillAsync(FullName);
            await _page.Locator("input[name=\"card_number\"]").FillAsync(CardNumber);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "ex." }).FillAsync(CVC);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "MM" }).FillAsync(ExpMonth);
            await _page.GetByRole(AriaRole.Textbox, new() { Name = "YYYY" }).FillAsync(ExpYear);
        }

        public async Task PayAndConfirmOrder()
        {
            await _page.GetByRole(AriaRole.Button, new() { Name = "Pay and Confirm Order" }).ClickAsync();
        }

        public async Task VerifyOrderCompletion()
        {
            await Assertions.Expect(_page.GetByText("Congratulations! Your order")).ToBeVisibleAsync();
        }
    }
}
