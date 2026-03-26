using System.ComponentModel.DataAnnotations;

namespace libraryApp.Api.Models;

public class Book
{
    [Required]
    [StringLength(50)]
    public string ProductCode { get; set; } //PK

    [Required]
    [StringLength(255)]
    public string ProductName { get; set; }

    [Required]
    public string ProductLine { get; set; }

    [Required]
    [Range(0.01, 10000)]
    public decimal BuyPrice { get; set; }

    [Required]
    [Range(0, short.MaxValue)]
    public int QuantityInStock { get; set; }

    [Required]
    [Range(0.01, 10000)]
    public decimal MSRP { get; set; }
}
