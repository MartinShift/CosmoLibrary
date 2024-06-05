using CosmoLibrary.Business.Models;
using CosmoLibrary.Business.Services;
using CosmoLibrary.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CosmoLibrary.Controllers;

[Route("/books")]
[ApiController]
public class BookController : ControllerBase
{
    private readonly IBookService _service;

    private readonly ImageService _imageService;

    public BookController(IBookService service, ImageService imageService)
    {
        _service = service;
        _imageService = imageService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<BookDto>>> GetBooks()
    {
        return Ok(await _service.GetBooksAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BookDto>> GetBook(string id)
    {
        var book = await _service.GetBookAsync(id);
        if (book == null)
        {
            return NotFound();
        }
        return Ok(book);
    }

    [HttpPost]
    public async Task<ActionResult> AddBook(AddBookDto book)
    {
        await _service.AddBookAsync(book);
        return CreatedAtAction(nameof(GetBook), new { id = book.Book.Id }, book);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateBook(string id, AddBookDto book)
    {
        if (id != book.Book.Id)
        {
            return BadRequest();
        }

        await _service.UpdateBookAsync(book);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteBook(string id)
    {
        await _service.DeleteBookAsync(id);
        return NoContent();
    }

    [HttpGet("{bookId}/authors")]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetBookAuthors(string bookId)
    {
        return Ok(await _service.GetAuthorsAsync(bookId));
    }

}
