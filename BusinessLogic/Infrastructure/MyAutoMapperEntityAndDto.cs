using AutoMapper;
using BusinessLogic.DTO;
using DomainAccess.Entities;

namespace BusinessLogic.Infrastructure
{
    public class MyAutoMapperEntityAndDto : Profile
    {
        public MyAutoMapperEntityAndDto()
        {
            CreateMap<BookDTO, Book>();
            CreateMap<AuthorDTO, Author>();
            CreateMap<GenreDTO, Genre>();
            CreateMap<Book, BookDTO>();
            CreateMap<Author, AuthorDTO>();
            CreateMap<Genre, GenreDTO>();
        }
    }
}
