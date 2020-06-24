using AutoMapper;
using DataAccess.Dto;
using DataAccess.Repositories;
using System.Collections.Generic;

namespace DataAccess.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _IAuthorRepository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _IAuthorRepository = repository;
            _mapper = mapper;
        }

        List<AuthorDto> IAuthorService.GetAll()
        {
            var authors = _IAuthorRepository.GetAll();
            return _mapper.Map<List<AuthorDto>>(authors);
        }

        AuthorDto IAuthorService.GetById(int authorId)
        {
            var author = _IAuthorRepository.Get(authorId);
            return _mapper.Map<AuthorDto>(author);
        }
    }
}
