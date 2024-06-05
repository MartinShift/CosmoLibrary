using AutoMapper;
using CosmoLibrary.Business.Models;
using CosmoLibrary.Business.Services.Interfaces;
using CosmoLibrary.Data.Entities;
using CosmoLibrary.Data.Repositories.Interfaces;

namespace CosmoLibrary.Business.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AuthorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<AuthorDto> GetAuthorAsync(string id)
    {
        var author = await _unitOfWork.Authors.GetAuthorAsync(id);
        return _mapper.Map<AuthorDto>(author);
    }

    public async Task<IEnumerable<AuthorDto>> GetAuthorsAsync()
    {
        var authors = await _unitOfWork.Authors.GetAuthorsAsync();
        return authors.Select(a => _mapper.Map<AuthorDto>(a));
    }

    public async Task AddAuthorAsync(AuthorDto author)
    {
        await _unitOfWork.Authors.AddAuthorAsync(_mapper.Map<Author>(author));
    }

    public async Task UpdateAuthorAsync(AuthorDto author)
    {
        await _unitOfWork.Authors.UpdateAuthorAsync(_mapper.Map<Author>(author));
    }

    public async Task DeleteAuthorAsync(string id)
    {
        await _unitOfWork.Authors.DeleteAuthorAsync(id);
    }
}