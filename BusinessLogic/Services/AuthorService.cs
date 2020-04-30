using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DomainAccess.Abstract;
using DomainAccess.Entities;
using System;
using System.Collections.Generic;

namespace BusinessLogic.Services
{
    public class AuthorService : IAuthorService
    {
        private IAuthorRepository repository;
        private IMapper mapper;

        public AuthorService(IAuthorRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Create(AuthorDTO item)
        {
            var obj = mapper.Map<Author>(item);
            repository.Create(obj);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<AuthorDTO> Find(Func<AuthorDTO, bool> predicate)
        {
            var objects = repository.GetAll();
            var dtos = mapper.Map<List<AuthorDTO>>(objects);
            var entities = new List<Author>();
            foreach (var b in dtos)
            {
                if (predicate.Invoke(b))
                {
                    entities.Add(mapper.Map<Author>(b));
                }
            }
            return mapper.Map<List<AuthorDTO>>(entities);
        }

        public void Update(AuthorDTO item)
        {
            var obj = mapper.Map<Author>(item);
            repository.Update(obj);
        }

        List<AuthorDTO> IAuthorService.GetAll()
        {
            var objects = repository.GetAll();
            return mapper.Map<List<AuthorDTO>>(objects);
        }

        AuthorDTO IAuthorService.GetOne(int id)
        {
            var obj = repository.Get(id);
            return mapper.Map<AuthorDTO>(obj);
        }
    }
}
