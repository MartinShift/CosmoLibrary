using CosmoLibrary.Data.Entities;

namespace CosmoLibrary.Data.Repositories.Interfaces;

public interface IAuthorRepository
{
    Task<Author> GetAuthorAsync(string id);
    Task<IEnumerable<Author>> GetAuthorsAsync();
    Task AddAuthorAsync(Author author);
    Task UpdateAuthorAsync(Author author);
    Task DeleteAuthorAsync(string id);
}
