using CosmoLibrary.Business.Models;

namespace CosmoLibrary.Business.Services.Interfaces;

public interface IBookService
{
    Task<BookDto> GetBookAsync(string id);
    Task<IEnumerable<BookDto>> GetBooksAsync();
    Task AddBookAsync(AddBookDto book);
    Task UpdateBookAsync(AddBookDto book);
    Task AddAuthorToBookAsync(string bookId, string authorId);
    Task RemoveAuthorFromBookAsync(string bookId, string authorId);
    Task DeleteBookAsync(string id);
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync(string bookId);
}
