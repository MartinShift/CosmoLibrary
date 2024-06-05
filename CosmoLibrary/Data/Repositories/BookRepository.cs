using CosmoLibrary.Data.Entities;
using CosmoLibrary.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CosmoLibrary.Data.Repositories;

public class BookRepository : IBookRepository
{
    private readonly LibraryContext _context;

    public BookRepository(LibraryContext context)
    {
        _context = context;
        _context.Database.EnsureCreated();
    }

    public async Task<Book> GetBookAsync(string id)
    {
        var book = _context.Books.First(x=> x.Id == id);
        book.Publisher = _context.Publishers.FirstOrDefault(x => x.Id == book.Id);
        book.Publisher.Address = _context.Addresses.FirstOrDefault(x => x.Id == book.Publisher.Id);
        return book;
    }

    public async Task<IEnumerable<Book>> GetBooksAsync()
    {
        return await _context.Books.ToListAsync();
    }

    public async Task AddBookAsync(Book book)
    {
        await _context.Books.AddAsync(book);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateBookAsync(Book book)
    {
        _context.Books.Update(book);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteBookAsync(string id)
    {
        var book = _context.Books.Find(id);
        if (book != null)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
    }

    public async Task AddAuthorToBookAsync(string bookId, string authorId)
    {
        var book = _context.Books.Find(bookId);
        var author = _context.Authors.Find(authorId);
        if (book != null && author != null)
        {
            _context.BookAuthors.Add(new BookAuthor { AuthorId = authorId, BookId = bookId });
            _context.SaveChanges();
        }
    }

    public async Task DeleteAuthorFromBookAsync(string bookId, string authorId)
    {
        var bookAuthor = _context.BookAuthors.Find(bookId, authorId);
        if (bookAuthor != null)
        {
            _context.BookAuthors.Remove(bookAuthor);
            await _context.SaveChangesAsync();
        }
    }

    public async Task ClearAuthorsAsync(string bookId)
    {
        var bookAuthors = _context.BookAuthors.Where(ba => ba.BookId == bookId).ToList();
        if (bookAuthors.Count != 0)
        {
            _context.BookAuthors.RemoveRange(bookAuthors);
            _context.SaveChanges();
        }
    }

    public async Task<IEnumerable<Author>> GetAuthorsAsync(string bookId)
    {
        var authorIds = await _context.BookAuthors
            .Where(ba => ba.BookId == bookId)
            .Select(ba => ba.AuthorId)
            .ToListAsync();
        var authors = await _context.Authors.Where(a => authorIds.Contains(a.Id)).ToListAsync();
        return authors;
    }
}
