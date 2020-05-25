using AutoMapper;
using BusinessLogic.DTO;
using BusinessLogic.Mappings;
using BusinessLogic.Interfaces;
using DataAccess.Abstract;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public void Create(BookDto item)
        {
            var obj = _mapper.Map<Book>(item);
            _repository.Create(obj);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public List<BookDto> Find(Func<BookDto, bool> predicate)
        {
            var objects = _repository.GetAll();
            var dtos = _mapper.Map<List<BookDto>>(objects);
            var entities = new List<Book>();
            foreach (var b in dtos)
            {
                if (predicate.Invoke(b))
                {
                    entities.Add(_mapper.Map<Book>(b));
                }
            }
            var e = _mapper.Map<List<BookDto>>(entities);
            return e;
        }

        public void Update(BookDto item)
        {
            var obj = _mapper.Map<Book>(item);
            _repository.Update(obj);
        }

        List<BookDto> IBookService.GetAll()
        {
            var objects = _repository.GetAll();
            return _mapper.Map<List<BookDto>>(objects);
        }

        BookDto IBookService.GetById(int bookId)
        {
            var obj = _repository.Get(bookId);
            return _mapper.Map<BookDto>(obj);
        }

        public List<BookDto> Search(string BookName, string AuthorName, string Genre, string Date)
        {
            var books = _repository.Search(BookName,AuthorName,Genre,Date);
            return _mapper.Map<List<BookDto>>(books);
        }
        public async Task FillStorageWithFakeUsers()
        {
            await Task.Run(() => TableGenerator.FillStorageWithFakeUsers(10000, 1000, 100));
        }
    }
}
