using System.Reflection;

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
    public string Zipcode { get; set; } = "";
    public string Phonenumber { get; set; } = "";

    public static User CreateRandomValidUser()
    {
        return new User
        {
            Name = "Dragos",
            Email = $"dragos{Guid.NewGuid()}@mail.com",
            Password = "asd123",
            FirstName = "Dragos",
            LastName = "Florin",
            Address = "Str. Mea 66",
            State = "Dolj",
            City = "Craiova",
            Zipcode = Random.Shared.Next(20000, 29999).ToString(),
            Phonenumber = "07" + Random.Shared.Next(10000000, 99999999),
        };
    }

    public static User CheckoutUser()
    {
        return new User
        {
            Name = "Dragos",
            Email = "dragoscheckout@mail.com",
            Password = "asd123",
            FirstName = "Dragos",
            LastName = "Florin",
            Address = "Str. Mea 66",
            State = "Dolj",
            City = "Craiova",
            Zipcode = "200101",
            Phonenumber = "0760000101",
        };
    }
}