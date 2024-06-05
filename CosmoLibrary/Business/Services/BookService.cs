using AutoMapper;
using CosmoLibrary.Business.Models;
using CosmoLibrary.Business.Services.Interfaces;
using CosmoLibrary.Data.Entities;
using CosmoLibrary.Data.Repositories.Interfaces;

namespace CosmoLibrary.Business.Services;

public class BookService : IBookService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public BookService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<BookDto> GetBookAsync(string id)
    {
        var book = await _unitOfWork.Books.GetBookAsync(id);
        return _mapper.Map<BookDto>(book);
    }

    public async Task<IEnumerable<BookDto>> GetBooksAsync()
    {
        var books = await _unitOfWork.Books.GetBooksAsync();
        return books.Select(b => _mapper.Map<BookDto>(b));
    }

    public async Task AddBookAsync(AddBookDto book)
    {
        book.Book.Id = Guid.NewGuid().ToString(); 
        book.Book.Publisher.Id = Guid.NewGuid().ToString();
        book.Book.Publisher.Address.Id = Guid.NewGuid().ToString();
        book.Book.Publisher.BookId = book.Book.Id;
        book.Book.Publisher.Address.PublisherId = book.Book.Publisher.Id;
        await _unitOfWork.Books.AddBookAsync(_mapper.Map<Book>(book.Book));
        book.AuthorIds.ForEach(async id => await _unitOfWork.Books.AddAuthorToBookAsync(book.Book.Id, id));
    }

    public async Task UpdateBookAsync(AddBookDto book)
    {
        book.Book.Publisher.Id = Guid.NewGuid().ToString();
        book.Book.Publisher.Address.Id = Guid.NewGuid().ToString();
        book.Book.Publisher.BookId = book.Book.Id;
        book.Book.Publisher.Address.PublisherId = book.Book.Publisher.Id;
        await _unitOfWork.Books.UpdateBookAsync(_mapper.Map<Book>(book.Book));
        await _unitOfWork.Books.ClearAuthorsAsync(book.Book.Id);
    }

    public async Task AddAuthorToBookAsync(string bookId, string authorId)
    {
        await _unitOfWork.Books.AddAuthorToBookAsync(bookId, authorId);
    }

    public async Task RemoveAuthorFromBookAsync(string bookId, string authorId)
    {
        await _unitOfWork.Books.DeleteAuthorFromBookAsync(bookId, authorId);
    }

    public async Task DeleteBookAsync(string id)
    {
        await _unitOfWork.Books.DeleteBookAsync(id);
    }

    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync(string bookId)
    {
        var authors = await _unitOfWork.Books.GetAuthorsAsync(bookId);
        return authors.Select(a => _mapper.Map<AuthorDto>(a));
    }
}
