using AutoMapper;
using BusinessLogic.Dto;
using BusinessLogic.Interfaces;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _repository;
        private readonly IMapper _mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public GenreDto GetById(int genreId)
        {
            var obj = _repository.Get(genreId);
            return _mapper.Map<GenreDto>(obj);
        }

        List<GenreDto> IGenreService.GetAll()
        {
            var objects = _repository.GetAll();
            return _mapper.Map<List<GenreDto>>(objects);
        }
    }
}
