using AutoMapper;
using WebUI.Models;
using BusinessLogic.DTO;

namespace WebUI.Mappings
{
    public class AutoMapperViewAndDtoProfile : Profile
    {
        public AutoMapperViewAndDtoProfile()
        {
            CreateMap<BookDto, BookViewModel>().MaxDepth(1);
            CreateMap<AuthorDto, AuthorViewModel>().MaxDepth(1);
            CreateMap<GenreDto, GenreViewModel>().MaxDepth(1);
            CreateMap<BookViewModel, BookDto>().MaxDepth(1);
            CreateMap<AuthorViewModel, AuthorDto>().MaxDepth(1);
            CreateMap<GenreViewModel, GenreDto>().MaxDepth(1);
        }
    }
}