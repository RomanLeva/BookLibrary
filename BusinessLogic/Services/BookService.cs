using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Interfaces;
using DomainAccess.Abstract;
using DomainAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private IBookRepository repository;
        private IMapper mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public void Create(BookDTO item)
        {
            var obj = mapper.Map<Book>(item);
            repository.Create(obj);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }

        public List<BookDTO> Find(Func<BookDTO, bool> predicate)
        {
            var objects = repository.GetAll();
            var dtos = mapper.Map<List<BookDTO>>(objects);
            var entities = new List<Book>();
            foreach (var b in dtos)
            {
                if (predicate.Invoke(b))
                {
                    entities.Add(mapper.Map<Book>(b));
                }
            }
            var e = mapper.Map<List<BookDTO>>(entities);
            return e;
        }

        public void Update(BookDTO item)
        {
            var obj = mapper.Map<Book>(item);
            repository.Update(obj);
        }

        List<BookDTO> IBookService.GetAll()
        {
            var objects = repository.GetAll();
            return mapper.Map<List<BookDTO>>(objects);
        }

        BookDTO IBookService.GetOne(int id)
        {
            var obj = repository.Get(id);
            return mapper.Map<BookDTO>(obj);
        }

        public List<BookDTO> Search(string BookName, string AuthorName, string Genre, string Date)
        {
            var books = repository.Search(BookName,AuthorName,Genre,Date);
            return mapper.Map<List<BookDTO>>(books);
        }
        
    }
}
