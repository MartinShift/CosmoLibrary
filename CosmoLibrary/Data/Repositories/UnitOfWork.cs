using CosmoLibrary.Data.Repositories.Interfaces;

namespace CosmoLibrary.Data.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly LibraryContext _context;
    public IAuthorRepository Authors { get; }
    public IBookRepository Books { get; }

    public UnitOfWork(LibraryContext context, IAuthorRepository authorRepository, IBookRepository bookRepository)
    {
        _context = context;
        Authors = authorRepository;
        Books = bookRepository;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}
