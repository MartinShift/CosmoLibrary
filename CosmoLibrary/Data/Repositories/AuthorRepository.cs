using CosmoLibrary.Data.Entities;
using CosmoLibrary.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace CosmoLibrary.Data.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly LibraryContext _context;

    public AuthorRepository(LibraryContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<Author> GetAuthorAsync(string id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync()
    {
        return await _context.Authors.ToListAsync();
    }

    public async Task AddAuthorAsync(Author author)
    {
        await _context.Authors.AddAsync(author);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAuthorAsync(Author author)
    {
        _context.Authors.Update(author);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAuthorAsync(string id)
    {
        var author = await _context.Authors.FindAsync(id);
        if (author != null)
        {
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
        }
    }
}
