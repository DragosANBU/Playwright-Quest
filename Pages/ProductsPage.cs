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
}