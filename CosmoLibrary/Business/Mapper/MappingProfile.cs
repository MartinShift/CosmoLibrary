using AutoMapper;
using CosmoLibrary.Business.Models;
using CosmoLibrary.Data.Entities;

namespace CosmoLibrary.Business.Mapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorDto, Author>();
        CreateMap<Book, BookDto>();
        CreateMap<BookDto, Book>();
        CreateMap<Publisher, PublisherDto>();
        CreateMap<PublisherDto, Publisher>();
        CreateMap<AddressDto, Address>();
        CreateMap<Address, AddressDto>();
        CreateMap<BookAuthor, BookAuthorDto>();
        CreateMap<BookAuthorDto, BookAuthor>();
    }
}
