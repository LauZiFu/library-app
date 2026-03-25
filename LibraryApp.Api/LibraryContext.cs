using libraryApp.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.Api;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options) { }

    public DbSet<Book> Books { get; set; }
    public DbSet<Member> Members { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().ToTable("products").HasKey(pk => pk.ProductCode);
        modelBuilder.Entity<Member>().ToTable("customers").HasKey(pk => pk.CustomerNumber);
        modelBuilder.Entity<Loan>().ToTable("orders").HasKey(pk => pk.OrderNumber);
    }
}
