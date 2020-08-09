using AutoMapper;
using DataAccess.Dto;
using DataAccess.Entities;
using System.Collections.Generic;
using DataAccess.Repositories;

namespace DataAccess.Services
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
            var genre = _repository.Get(genreId);
            return _mapper.Map<GenreDto>(genre);
        }

        List<GenreDto> IGenreService.GetAll()
        {
            var genres = _repository.GetAll();
            return _mapper.Map<List<GenreDto>>(genres);
        }
    }
}
