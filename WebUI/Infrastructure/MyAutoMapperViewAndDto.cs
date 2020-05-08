using AutoMapper;
using WebUI.Models;
using BusinessLogic.DTO;

namespace WebUI.Infrastructure
{
    public class MyAutoMapperViewAndDto : Profile
    {
        public MyAutoMapperViewAndDto()
        {
            CreateMap<BookDTO, BookViewModel>().MaxDepth(1);
            CreateMap<AuthorDTO, AuthorViewModel>().MaxDepth(1);
            CreateMap<GenreDTO, GenreViewModel>().MaxDepth(1);
            CreateMap<BookViewModel, BookDTO>().MaxDepth(1);
            CreateMap<AuthorViewModel, AuthorDTO>().MaxDepth(1);
            CreateMap<GenreViewModel, GenreDTO>().MaxDepth(1);
        }
    }
}