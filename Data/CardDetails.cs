using Microsoft.Testing.Extensions.TrxReport.Abstractions;

namespace PlaywrightQuest.Data;

public class CardDetails
{
    public string FullName { get; set; } = "";
    public string CardNumber { get; set; } = "";
    public string CVC { get; set; } = "";
    public string ExpMonth { get; set; } = "";
    public string ExpYear { get; set; } = "";

    public static CardDetails CheckoutValidCardDragos()
    {
        return new CardDetails
        {
            FullName = "Dragos Florin",
            CardNumber = "1111 2222 3333 4444",
            CVC = "123",
            ExpMonth = "06",
            ExpYear = "2030",
        };
    }

}
