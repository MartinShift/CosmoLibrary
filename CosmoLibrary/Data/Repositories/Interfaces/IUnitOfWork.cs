namespace CosmoLibrary.Data.Repositories.Interfaces;

public interface IUnitOfWork
{
    IAuthorRepository Authors { get; }
    IBookRepository Books { get; }
    Task SaveAsync();
}