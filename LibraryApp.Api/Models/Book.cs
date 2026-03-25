namespace libraryApp.Api.Models;

public class Book
{
    public string ProductCode { get; set; } //Primary Key
    public string ProductName { get; set; }
    public string ProductLine { get; set; }
    public decimal BuyPrice { get; set; }
}
