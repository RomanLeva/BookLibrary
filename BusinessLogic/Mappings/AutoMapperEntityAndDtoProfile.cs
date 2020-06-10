using AutoMapper;
using BusinessLogic.Dto;
using DataAccess.Entities;

namespace BusinessLogic.Mappings
{
    public class AutoMapperEntityAndDtoProfile : Profile
    {
        public AutoMapperEntityAndDtoProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<GenreDto, Genre>().ReverseMap();
        }
    }
}
