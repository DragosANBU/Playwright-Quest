namespace PlaywrightQuest.Data;

public class Search
{
    public string Name { get; set; } = "";

    public static Search CreateSearchProduct()
    {
        return new Search
        {
            Name = "Jeans"
        };
    }
}