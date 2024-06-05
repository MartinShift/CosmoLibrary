using CosmoLibrary.Business.Models;

namespace CosmoLibrary.Business.Services.Interfaces;

public interface IAuthorService
{
    Task<AuthorDto> GetAuthorAsync(string id);
    Task<IEnumerable<AuthorDto>> GetAuthorsAsync();
    Task AddAuthorAsync(AuthorDto author);
    Task UpdateAuthorAsync(AuthorDto author);
    Task DeleteAuthorAsync(string id);
}
