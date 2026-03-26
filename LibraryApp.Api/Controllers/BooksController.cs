using libraryApp.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace libraryApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase
{
    private readonly LibraryContext _context;

    public BooksController(LibraryContext context)
    {
        _context = context;
    }

    // GET: api/books
    [HttpGet]
    public async Task<IActionResult> GetBooks()
    {
        var books = await _context.Books.ToListAsync();
        return Ok(books);
    }

    // GET: api/books/{id}
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBook(string id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    // POST: api/books
    [HttpPost]
    public async Task<IActionResult> CreateBook(Book book)
    {
        _context.Books.Add(book);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBook), new { id = book.ProductCode }, book);
    }

    //PUT: api/books/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBook(string id, Book book)
    {
        if (id != book.ProductCode)
        {
            return BadRequest();
        }

        _context.Entry(book).State = EntityState.Modified;

        var existingBook = await _context.Books.SingleOrDefaultAsync(b => b.ProductCode == id);
        if (existingBook == null)
        {
            existingBook = book;
            await _context.SaveChangesAsync();
        }
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBook(string id)
    {
        var book = await _context.Books.FindAsync(id);
        if (book == null)
            return NotFound();

        await _context.Database.ExecuteSqlRawAsync(
            "DELETE FROM orderdetails WHERE productCode = {0}",
            id
        );

        _context.Books.Remove(book);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    //GET:api/books/search?query=example
    [HttpGet("search")]
    public async Task<IActionResult> SearchBooks([FromQuery] string query)
    {
        if (string.IsNullOrEmpty(query))
            return BadRequest("Query is required");

        var books = await _context.Books.FromSqlRaw("CALL SearchBooks({0})", query).ToListAsync();

        return Ok(books);
    }
}
