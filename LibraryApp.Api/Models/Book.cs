namespace libraryApp.Api.Models;

public class Book
{
    public string ProductCode { get; set; } //PK
    public string ProductName { get; set; }
    public string ProductLine { get; set; } //FK
    public decimal BuyPrice { get; set; }
}
