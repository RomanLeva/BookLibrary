using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _repository;
        private readonly IMapper _mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        List<AuthorDto> IAuthorService.GetAll()
        {
            var objects = _repository.GetAll();
            return _mapper.Map<List<AuthorDto>>(objects);
        }

        AuthorDto IAuthorService.GetById(int authorId)
        {
            var obj = _repository.Get(authorId);
            return _mapper.Map<AuthorDto>(obj);
        }
    }
}
