using AutoMapper;
using DataAccess.Dto;
using DataAccess.Entities;

namespace DataAccess.Services
{
    public class AutoMapperEntityAndDtoProfile : Profile
    {
        public AutoMapperEntityAndDtoProfile()
        {
            CreateMap<BookDto, Book>().ReverseMap();
            CreateMap<BookTextStatisticDto, BookTextStatistic>().ReverseMap();
            CreateMap<AuthorDto, Author>().ReverseMap();
            CreateMap<GenreDto, Genre>().ReverseMap();
        }
    }
}
