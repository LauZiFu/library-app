namespace libraryApp.Api.Models;

public class Loan
{
    public int OrderNumber { get; set; } //PK
    public int CustomerNumber { get; set; } //FK
    public DateTime OrderDate { get; set; }
    public string? Status { get; set; }
}
