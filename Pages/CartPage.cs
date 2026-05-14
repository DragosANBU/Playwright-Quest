using Microsoft.Playwright;

namespace PlaywrightQuest.Pages;

public class CartPage
{
    private readonly IPage _page;

    public CartPage(IPage page)
    {
        _page = page;
    }

    public async Task VerifyCartPage()
    {
        await Assertions.Expect(_page.Locator("ol")).ToContainTextAsync("Shopping Cart");
    }

    public async Task VerifyProductToCart(string productName)
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Link, new() { Name = productName })).ToBeVisibleAsync();
    }

    public async Task VerifyProductPriceinCart(string productName)
    {
        var row = _page.Locator("tr", new() { HasText = productName });

        var price = await row.Locator(".cart_price p").InnerTextAsync();
        var qty = await row.Locator(".cart_quantity button").InnerTextAsync();
        var total = await row.Locator(".cart_total p").InnerTextAsync();

        var priceValue = decimal.Parse(price.Replace("Rs.", "").Trim());
        var qtyValue = int.Parse(qty.Trim());
        var totalValue = decimal.Parse(total.Replace("Rs.", "").Trim());

        Assert.That(totalValue, Is.EqualTo(priceValue * qtyValue));
    }

    public async Task CheckItemInCartQuantity(string quantity)
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Button, new() { Name = quantity })).ToBeVisibleAsync();
    }

    // This method only works if there is only on product in the cart.
    public async Task DeleteProduct()
    {
        await _page.Locator(".cart_quantity_delete").ClickAsync();
    }

    public async Task VerifyCartIsEmpty()
    {
        await Assertions.Expect(_page.GetByText("Cart is empty!")).ToBeVisibleAsync();
    }

    public async Task ProceedToCheckout()
    {
        await _page.GetByText("Proceed To Checkout").ClickAsync();
    }

    public async Task VerifyProductQuantityInCart(string quantity)
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Button, new() { Name = quantity })).ToBeVisibleAsync();
    }
}