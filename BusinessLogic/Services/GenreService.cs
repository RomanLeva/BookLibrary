using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DomainAccess.Abstract;
using DomainAccess.Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class GenreService : IGenreService
    {
        private IGenreRepository repository;
        private IMapper mapper;

        public GenreService(IGenreRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Create(GenreDTO item)
        {
            var obj = mapper.Map<Genre>(item);
            repository.Create(obj);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<GenreDTO> Find(Func<GenreDTO, bool> predicate)
        {
            var objects = repository.GetAll();
            var dtos = mapper.Map<List<GenreDTO>>(objects);
            var entities = new List<Genre>();
            foreach (var b in dtos)
            {
                if (predicate.Invoke(b))
                {
                    entities.Add(mapper.Map<Genre>(b));
                }
            }
            return mapper.Map<List<GenreDTO>>(entities);
        }

        public void Update(GenreDTO item)
        {
            var obj = mapper.Map<Genre>(item);
            repository.Update(obj);
        }

        List<GenreDTO> IGenreService.Find(Func<GenreDTO, bool> predicate)
        {
            var objects = repository.GetAll();
            var dtos = mapper.Map<List<GenreDTO>>(objects);
            var entities = new List<Genre>();
            foreach (var b in dtos)
            {
                if (predicate.Invoke(b))
                {
                    entities.Add(mapper.Map<Genre>(b));
                }
            }
            return mapper.Map<List<GenreDTO>>(entities);
        }

        List<GenreDTO> IGenreService.GetAll()
        {
            var objects = repository.GetAll();
            return mapper.Map<List<GenreDTO>>(objects);
        }

        GenreDTO IGenreService.GetOne(int id)
        {
            var obj = repository.Get(id);
            return mapper.Map<GenreDTO>(obj);
        }
    }
}
