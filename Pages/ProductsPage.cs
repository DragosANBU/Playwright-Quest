using Microsoft.Playwright;
using PlaywrightQuest.Data;

namespace PlaywrightQuest.Pages;

public class ProductsPage
{
    private readonly IPage _page;

    public ProductsPage(IPage page)
    {
        _page = page;
    }

    public async Task VerifyProductsPage()
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Heading, new() { Name = "All Products" })).ToBeVisibleAsync();
    }

    public async Task ViewProduct()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = " View Product" }).First.ClickAsync();
    }

    public async Task VerifyDetailsAreVisible()
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Heading, new() { Name = "Blue Top" })).ToBeVisibleAsync();
        await Assertions.Expect(_page.GetByText("Category: Women > Tops")).ToBeVisibleAsync();
        await Assertions.Expect(_page.GetByText("Rs.")).ToBeVisibleAsync();
        await Assertions.Expect(_page.GetByText("Availability:")).ToBeVisibleAsync();
        await Assertions.Expect(_page.GetByText("Condition:")).ToBeVisibleAsync();
        await Assertions.Expect(_page.GetByText("Brand:")).ToBeVisibleAsync();
    }

    public async Task SearchProduct(Search search)
    {
        await _page.GetByRole(AriaRole.Textbox, new() { Name = "Search Product" }).FillAsync(search.Name);
        await _page.Locator("#submit_search").ClickAsync();
    }

    public async Task VerifySearchedProductsIsVisible()
    {
        await Assertions.Expect(_page.GetByRole(AriaRole.Heading, new() { Name = "Searched Products" })).ToBeVisibleAsync();
    }

    public async Task VerifyAllSearchedProductsAreVisible(Search search)
    {
        var products = _page.Locator(".productinfo p");

        var productTexts = await products.AllTextContentsAsync();

        foreach (var text in productTexts)
        {
            Assert.That(text, Does.Contain(search.Name));
        }
    }

    public async Task AddFirstItemToCart()
    {
        await _page.GetByText("Blue Top").First.HoverAsync();
        await _page.GetByText("Add to cart").Nth(1).ClickAsync();
    }

    public async Task AddFirstItemToCartMultipleTimes(int quantity)
    {
        while (quantity > 1)
        {
            await _page.GetByText("Blue Top").First.HoverAsync();
            await _page.GetByText("Add to cart").Nth(1).ClickAsync();
            await _page.GetByRole(AriaRole.Button, new() { Name = "Continue Shopping" }).ClickAsync();
            quantity--;
        }
        await _page.GetByText("Blue Top").First.HoverAsync();
        await _page.GetByText("Add to cart").Nth(1).ClickAsync();
    }

    public async Task AddSecondItemToCart()
    {
        await _page.GetByText("Men Tshirt").Nth(1).HoverAsync();
        await _page.GetByText("Add to cart").Nth(3).ClickAsync();
    }

    public async Task ContinueShopping()
    {
        await _page.GetByRole(AriaRole.Button, new() { Name = "Continue Shopping" }).ClickAsync();
    }

    public async Task ViewCartAfterAddToCart()
    {
        await _page.GetByRole(AriaRole.Link, new() { Name = "View Cart" }).ClickAsync();
    }

    public async Task ChangeQuantity(string quantity)
    {
        await _page.Locator("#quantity").FillAsync(quantity);
    }

    public async Task AddToCart()
    {
        await _page.GetByRole(AriaRole.Button, new() { Name = " Add to cart" }).ClickAsync();
    }
}