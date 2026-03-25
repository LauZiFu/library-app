namespace libraryApp.Api.Models;

public class Loan
{
    public int OrderNumber { get; set; }
    public int CustomerNumber { get; set; }
    public DateTime OrderDate { get; set; }
    public string? Status { get; set; }
}
