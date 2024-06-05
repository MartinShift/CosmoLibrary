namespace CosmoLibrary.Controllers;

using System.Collections.Generic;
using System.Threading.Tasks;
using CosmoLibrary.Business.Models;
using CosmoLibrary.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[Route("/authors")]
[ApiController]
public class AuthorController : ControllerBase
{
    private readonly IAuthorService _service;

    public AuthorController(IAuthorService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAuthors()
    {
        return Ok(await _service.GetAuthorsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<AuthorDto>> GetAuthor(string id)
    {
        var author = await _service.GetAuthorAsync(id);
        if (author == null)
        {
            return NotFound();
        }
        return Ok(author);
    }

    [HttpPost]
    public async Task<ActionResult> AddAuthor(AuthorDto author)
    {
        author.Id = Guid.NewGuid().ToString();
        await _service.AddAuthorAsync(author);
        return CreatedAtAction(nameof(GetAuthor), new { id = author.Id }, author);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateAuthor(string id, AuthorDto author)
    {
        if (id != author.Id)
        {
            return BadRequest();
        }
        await _service.UpdateAuthorAsync(author);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteAuthor(string id)
    {
        await _service.DeleteAuthorAsync(id);
        return NoContent();
    }
}
