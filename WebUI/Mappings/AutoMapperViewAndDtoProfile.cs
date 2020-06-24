using AutoMapper;
using WebUI.Models;
using DataAccess.Dto;

namespace WebUI.Mappings
{
    public class AutoMapperViewAndDtoProfile : Profile
    {
        public AutoMapperViewAndDtoProfile()
        {
            CreateMap<BookDto, BookViewModel>().ReverseMap();
            CreateMap<BookTextStatisticDto, BookTextStatisticViewModel>().ReverseMap();
            CreateMap<AuthorDto, AuthorViewModel>().ReverseMap();
            CreateMap<GenreDto, GenreViewModel>().ReverseMap();
        }
    }
}