using AutoMapper;
using BusinessLogic.DTO;
using DataAccess.Entities;

namespace BusinessLogic.Mappings
{
    public class AutoMapperEntityAndDtoProfile : Profile
    {
        public AutoMapperEntityAndDtoProfile()
        {
            CreateMap<BookDto, Book>();
            CreateMap<AuthorDto, Author>();
            CreateMap<GenreDto, Genre>();
            CreateMap<Book, BookDto>();
            CreateMap<Author, AuthorDto>();
            CreateMap<Genre, GenreDto>();
        }
    }
}
