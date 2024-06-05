using CosmoLibrary.Data.Entities;

namespace CosmoLibrary.Data.Repositories.Interfaces;

public interface IBookRepository
{
    Task<Book> GetBookAsync(string id);
    Task<IEnumerable<Book>> GetBooksAsync();
    Task AddBookAsync(Book book);
    Task UpdateBookAsync(Book book);
    Task DeleteBookAsync(string id);
    Task ClearAuthorsAsync(string bookId);
    Task DeleteAuthorFromBookAsync(string bookId, string authorId);
    Task AddAuthorToBookAsync(string bookId, string authorId);
    Task<IEnumerable<Author>> GetAuthorsAsync(string bookId);
}
