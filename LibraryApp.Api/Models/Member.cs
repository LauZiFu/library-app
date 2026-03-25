namespace LibraryApp.Api.Models;

public class Member
{
    public int CustomerNumber { get; set; } // PK
    public string CustomerName { get; set; }
    public string ContactLastName { get; set; }
    public string ContactFirstName { get; set; }
    public string Phone { get; set; }
    public string City { get; set; }
}
