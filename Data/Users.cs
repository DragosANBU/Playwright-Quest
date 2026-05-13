namespace PlaywrightQuest.Data;

public class User
{
    public string Name { get; set; } = "";
    public string Email { get; set; } = "";
    public string Password { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string Address { get; set; } = "";
    public string State { get; set; } = "";
    public string City { get; set; } = "";
    public string ZipCode { get; set; } = "";
    public string PhoneNumber { get; set; } = "";

    public static User CreateRandomValidUser()
    {
        return new User
        {
            Name = "Dragos",
            Email = $"dragos{Guid.NewGuid()}@mail.com",
            Password = "asd123!",
            FirstName = "Dragos",
            LastName = "Florin",
            Address = "Str. Mea 66",
            State = "Dolj",
            City = "Craiova",
            ZipCode = Random.Shared.Next(20000, 29999).ToString(),
            PhoneNumber = "07" + Random.Shared.Next(10000000, 99999999),
        };
    }
}