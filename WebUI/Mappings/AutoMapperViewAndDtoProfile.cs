using AutoMapper;
using WebUI.Models;
using BusinessLogic.Dto;

namespace WebUI.Mappings
{
    public class AutoMapperViewAndDtoProfile : Profile
    {
        public AutoMapperViewAndDtoProfile()
        {
            CreateMap<BookDto, BookViewModel>().ReverseMap();
            CreateMap<AuthorDto, AuthorViewModel>().ReverseMap();
            CreateMap<GenreDto, GenreViewModel>().ReverseMap();
        }
    }
}