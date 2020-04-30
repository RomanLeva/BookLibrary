using AutoMapper;
using WebUI.Models;
using BusinessLogic.DTO;

namespace WebUI.Infrastructure
{
    public class MyAutoMapperViewAndDto : Profile
    {
        public MyAutoMapperViewAndDto()
        {
            CreateMap<BookDTO, BookViewModel>();
            CreateMap<AuthorDTO, AuthorViewModel>();
            CreateMap<GenreDTO, GenreViewModel>();
            CreateMap<BookViewModel, BookDTO>();
            CreateMap<AuthorViewModel, AuthorDTO>();
            CreateMap<GenreViewModel, GenreDTO>();
        }
    }
}